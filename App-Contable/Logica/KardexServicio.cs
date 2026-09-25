using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    /// <summary>
    /// Servicio de lógica contable para la extracción automática, valuación y cálculo de tarjetas Kardex
    /// a partir de asientos de Libro Diario o entradas manuales.
    /// </summary>
    public class KardexServicio
    {
        private static readonly CultureInfo UsCulture = new("en-US");

        /// <summary>
        /// Determina si una cuenta contable o subcuenta corresponde al rubro de inventarios, mercaderías o compras.
        /// </summary>
        public static bool EsCuentaInventarioOMercaderia(string cuentaPrincipal, string? subcuenta = null)
        {
            if (string.IsNullOrWhiteSpace(cuentaPrincipal)) return false;

            string cuenta = cuentaPrincipal.Trim().ToLowerInvariant();
            string sub = subcuenta?.Trim().ToLowerInvariant() ?? string.Empty;

            string[] terminosInventario = new[]
            {
                "inventario", "inventarios", "mercaderia", "mercaderías", "mercaderias",
                "materia prima", "producto terminado", "productos terminados",
                "compras", "compra", "devolución de compra", "devolucion de compra",
                "devolución de venta", "devolucion de venta", "costo de venta", "costo de ventas",
                "1103", "5101", "5102", "4103"
            };

            return terminosInventario.Any(t => cuenta.Contains(t)) ||
                   (!string.IsNullOrEmpty(sub) && terminosInventario.Any(t => sub.Contains(t)));
        }

        /// <summary>
        /// Extrae automáticamente los movimientos contables de inventario de un Libro Diario y los valúa
        /// según el método especificado (Promedio Ponderado o PEPS).
        /// </summary>
        public static (List<KardexItem> MovimientosProcesados, ResumenConciliacionKardex Resumen, List<KardexItem> MovimientosBase) 
            GenerarKardexDesdeLibroDiario(
                LibroDiarioInstancia libro,
                MetodoValuacion metodo = MetodoValuacion.PromedioPonderado,
                decimal costoUnitarioEstimado = 10.00m)
        {
            if (libro == null || libro.Asientos == null || !libro.Asientos.Any())
            {
                return (new List<KardexItem>(), new ResumenConciliacionKardex(), new List<KardexItem>());
            }

            var movimientosBase = new List<KardexItem>();
            long idContador = 1;

            // 1. Filtrar mediante LINQ los movimientos de cuentas de inventario/mercaderías
            var asientosOrdenados = libro.Asientos
                .OrderBy(a => a.Fecha)
                .ThenBy(a => a.NumeroAsiento)
                .ToList();

            foreach (var asiento in asientosOrdenados)
            {
                var movsInventario = asiento.Movimientos
                    .Where(m => EsCuentaInventarioOMercaderia(m.CuentaPrincipal, m.Subcuenta))
                    .ToList();

                foreach (var mov in movsInventario)
                {
                    bool esEntrada = mov.Movimiento == TipoMovimiento.Debe;
                    decimal monto = mov.Monto;
                    if (monto <= 0) continue;

                    string conceptoDetalle = string.IsNullOrWhiteSpace(mov.Subcuenta)
                        ? asiento.Concepto
                        : $"{asiento.Concepto} — {mov.Subcuenta}";

                    if (string.IsNullOrWhiteSpace(conceptoDetalle))
                    {
                        conceptoDetalle = esEntrada ? "Entrada según Asiento" : "Salida según Asiento";
                    }

                    var item = new KardexItem
                    {
                        Id = idContador++,
                        Fecha = asiento.Fecha,
                        Concepto = conceptoDetalle,
                        Documento = $"Partida #{asiento.NumeroAsiento}",
                        NumeroAsiento = asiento.NumeroAsiento,
                        Origen = TipoOrigenKardex.AutoLibroDiario,
                        EsFilaEspecial = false
                    };

                    if (esEntrada)
                    {
                        // DEBE -> ENTRADA
                        item.TipoMovimiento = asiento.NumeroAsiento == 1 && asiento.Concepto.ToLowerInvariant().Contains("inicial")
                            ? TipoMovimientoKardex.InventarioInicial
                            : (mov.CuentaPrincipal.ToLowerInvariant().Contains("devol") ? TipoMovimientoKardex.DevolucionVenta : TipoMovimientoKardex.Compra);

                        decimal costo = costoUnitarioEstimado > 0 ? costoUnitarioEstimado : 10.00m;
                        decimal cant = Math.Max(1m, Math.Round(monto / costo, 0));
                        costo = Math.Round(monto / cant, 4, MidpointRounding.AwayFromZero);

                        item.CantidadEntrada = cant;
                        item.CantidadSalida = null;
                        item.CostoUnitario = costo;
                        item.Debe = monto;
                        item.Haber = null;
                    }
                    else
                    {
                        // HABER -> SALIDA
                        item.TipoMovimiento = mov.CuentaPrincipal.ToLowerInvariant().Contains("devol")
                            ? TipoMovimientoKardex.DevolucionCompra
                            : TipoMovimientoKardex.Venta;

                        decimal costo = costoUnitarioEstimado > 0 ? costoUnitarioEstimado : 10.00m;
                        decimal cant = Math.Max(1m, Math.Round(monto / costo, 0));
                        costo = Math.Round(monto / cant, 4, MidpointRounding.AwayFromZero);

                        item.CantidadEntrada = null;
                        item.CantidadSalida = cant;
                        item.CostoUnitario = costo;
                        item.Debe = null;
                        item.Haber = monto;
                    }

                    movimientosBase.Add(item);
                }
            }

            // 2. Aplicar algoritmo de valuación seleccionado
            var resultado = ValuarMovimientos(movimientosBase, libro.FechaInicio, libro.FechaFin, metodo);
            return (resultado.ListaProcesada, resultado.Resumen, movimientosBase);
        }

        /// <summary>
        /// Valúa una lista de movimientos según el método contable indicado (Promedio Ponderado o PEPS).
        /// </summary>
        public static (List<KardexItem> ListaProcesada, ResumenConciliacionKardex Resumen) ValuarMovimientos(
            IEnumerable<KardexItem> movimientosOriginales,
            DateTime fechaInicio,
            DateTime fechaFin,
            MetodoValuacion metodo = MetodoValuacion.PromedioPonderado)
        {
            if (metodo == MetodoValuacion.PEPS)
            {
                return ValuarPEPS(movimientosOriginales, fechaInicio, fechaFin);
            }

            return KardexCalculador.ProcesarKardex(movimientosOriginales, fechaInicio, fechaFin);
        }

        /// <summary>
        /// Algoritmo de Valuación PEPS (Primeras Entradas, Primeras Salidas / FIFO).
        /// </summary>
        private static (List<KardexItem> ListaProcesada, ResumenConciliacionKardex Resumen) ValuarPEPS(
            IEnumerable<KardexItem> movimientosOriginales,
            DateTime fechaInicio,
            DateTime fechaFin)
        {
            var itemsOperativos = movimientosOriginales
                .Where(x => !x.EsFilaEspecial)
                .OrderBy(x => x.Fecha)
                .ThenBy(x => x.Id)
                .ToList();

            if (itemsOperativos.Count == 0)
            {
                return (new List<KardexItem>(), new ResumenConciliacionKardex());
            }

            var capasInventario = new Queue<(decimal CantidadDisponible, decimal CostoUnitario)>();
            var listaResultado = new List<KardexItem>();

            decimal saldoCantidad = 0m;
            decimal saldoValor = 0m;
            decimal totalEntradas = 0m;
            decimal totalSalidas = 0m;
            decimal totalDebe = 0m;
            decimal totalHaber = 0m;
            decimal ultimoCostoUnitario = 0m;

            foreach (var mov in itemsOperativos)
            {
                var item = new KardexItem
                {
                    Id = mov.Id,
                    Fecha = mov.Fecha,
                    Concepto = mov.Concepto,
                    Documento = mov.Documento,
                    TipoMovimiento = mov.TipoMovimiento,
                    Origen = mov.Origen,
                    NumeroAsiento = mov.NumeroAsiento,
                    EsFilaEspecial = false
                };

                if (mov.CantidadEntrada.HasValue && mov.CantidadEntrada.Value > 0)
                {
                    // ENTRADA: Añade una nueva capa al inventario
                    decimal cant = mov.CantidadEntrada.Value;
                    decimal costo = mov.CostoUnitario;
                    decimal debe = Math.Round(cant * costo, 2, MidpointRounding.AwayFromZero);

                    capasInventario.Enqueue((cant, costo));

                    saldoCantidad += cant;
                    saldoValor += debe;
                    ultimoCostoUnitario = costo;

                    item.CantidadEntrada = cant;
                    item.CantidadSalida = null;
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costo;
                    item.CostoPromedio = saldoCantidad > 0 ? Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero) : costo;
                    item.Debe = debe;
                    item.Haber = null;
                    item.SaldoValor = saldoValor;

                    totalEntradas += cant;
                    totalDebe += debe;
                }
                else if (mov.CantidadSalida.HasValue && mov.CantidadSalida.Value > 0)
                {
                    // SALIDA: Consume de las capas más antiguas (FIFO)
                    decimal cantPorConsumir = mov.CantidadSalida.Value;
                    decimal costoSalidaTotal = 0m;
                    decimal costoUnitarioSalida = ultimoCostoUnitario;

                    var nuevasCapas = new Queue<(decimal, decimal)>();

                    while (capasInventario.Count > 0 && cantPorConsumir > 0)
                    {
                        var capa = capasInventario.Dequeue();
                        if (capa.CantidadDisponible <= cantPorConsumir)
                        {
                            costoSalidaTotal += capa.CantidadDisponible * capa.CostoUnitario;
                            costoUnitarioSalida = capa.CostoUnitario;
                            cantPorConsumir -= capa.CantidadDisponible;
                        }
                        else
                        {
                            costoSalidaTotal += cantPorConsumir * capa.CostoUnitario;
                            costoUnitarioSalida = capa.CostoUnitario;
                            nuevasCapas.Enqueue((capa.CantidadDisponible - cantPorConsumir, capa.CostoUnitario));
                            cantPorConsumir = 0;
                        }
                    }

                    // Reencolar las capas restantes
                    while (capasInventario.Count > 0)
                    {
                        nuevasCapas.Enqueue(capasInventario.Dequeue());
                    }
                    capasInventario = nuevasCapas;

                    // Si quedó déficit
                    if (cantPorConsumir > 0)
                    {
                        costoSalidaTotal += cantPorConsumir * ultimoCostoUnitario;
                    }

                    decimal cantSalida = mov.CantidadSalida.Value;
                    decimal haber = Math.Round(costoSalidaTotal, 2, MidpointRounding.AwayFromZero);
                    costoUnitarioSalida = cantSalida > 0 ? Math.Round(haber / cantSalida, 4, MidpointRounding.AwayFromZero) : ultimoCostoUnitario;

                    saldoCantidad -= cantSalida;
                    saldoValor -= haber;

                    item.CantidadEntrada = null;
                    item.CantidadSalida = cantSalida;
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costoUnitarioSalida;
                    item.CostoPromedio = saldoCantidad > 0 ? Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero) : costoUnitarioSalida;
                    item.Debe = null;
                    item.Haber = haber;
                    item.SaldoValor = saldoValor;

                    totalSalidas += cantSalida;
                    totalHaber += haber;
                }
                else
                {
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = ultimoCostoUnitario;
                    item.CostoPromedio = ultimoCostoUnitario;
                    item.SaldoValor = saldoValor;
                }

                listaResultado.Add(item);
            }

            // Fila de Saldo Final del Período
            decimal costoPromedioFinal = saldoCantidad > 0 ? Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero) : ultimoCostoUnitario;

            var filaSaldoFinal = new KardexItem
            {
                Id = 99990,
                Fecha = fechaFin,
                Concepto = "Saldo Final del Período",
                Documento = "CIERRE-" + fechaFin.ToString("MM"),
                CantidadEntrada = null,
                CantidadSalida = null,
                CantidadSaldo = saldoCantidad,
                CostoUnitario = costoPromedioFinal,
                CostoPromedio = costoPromedioFinal,
                Debe = null,
                Haber = null,
                SaldoValor = saldoValor,
                EsFilaEspecial = true,
                TipoMovimiento = TipoMovimientoKardex.SaldoFinalPeriodo
            };
            listaResultado.Add(filaSaldoFinal);

            // Fila de TOTALES
            var filaTotales = new KardexItem
            {
                Id = 99999,
                Fecha = fechaFin,
                Concepto = "TOTALES",
                Documento = string.Empty,
                CantidadEntrada = totalEntradas,
                CantidadSalida = totalSalidas,
                CantidadSaldo = saldoCantidad,
                CostoUnitario = costoPromedioFinal,
                CostoPromedio = costoPromedioFinal,
                Debe = totalDebe,
                Haber = totalHaber,
                SaldoValor = saldoValor,
                EsFilaEspecial = true,
                TipoMovimiento = TipoMovimientoKardex.Totales
            };
            listaResultado.Add(filaTotales);

            var resumen = new ResumenConciliacionKardex
            {
                TotalEntradasFisicas = totalEntradas,
                TotalSalidasFisicas = totalSalidas,
                SaldoFisicoFinal = saldoCantidad,
                TotalDebe = totalDebe,
                TotalHaber = totalHaber,
                SaldoValorFinal = saldoValor,
                UltimoCostoPromedio = costoPromedioFinal
            };

            return (listaResultado, resumen);
        }

        /// <summary>
        /// Formatea un valor monetario estrictamente en USD con el patrón '$#,##0.00'.
        /// </summary>
        public static string FormatearUSD(decimal? monto)
        {
            if (!monto.HasValue) return "—";
            return monto.Value.ToString("$#,##0.00", UsCulture);
        }

        /// <summary>
        /// Formatea un costo unitario en USD con 4 decimales: '$#,##0.0000'.
        /// </summary>
        public static string FormatearCostoUnitarioUSD(decimal costo)
        {
            return costo.ToString("$#,##0.0000", UsCulture);
        }
    }
}

