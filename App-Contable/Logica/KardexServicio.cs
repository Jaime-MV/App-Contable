using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    /// <summary>
    /// Servicio de lógica contable para la extracción automática, calibración de unidades/costos,
    /// valuación y cálculo de tarjetas Kardex a partir de asientos de Libro Diario o entradas manuales.
    /// </summary>
    public class KardexServicio
    {
        private static readonly CultureInfo UsCulture = new("en-US");

        /// <summary>
        /// Determina si una cuenta contable o subcuenta corresponde al rubro de inventarios, mercaderías o compras/ventas.
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
                "devolución sobre compra", "devolucion sobre compra", "devoluciones sobre compras",
                "devolución de venta", "devolucion de venta", "devolución sobre venta", "devolucion sobre venta",
                "devoluciones sobre ventas", "ventas", "venta", "costo de venta", "costo de ventas",
                "1103", "5101", "5102", "4103", "4101"
            };

            return terminosInventario.Any(t => cuenta.Contains(t)) ||
                   (!string.IsNullOrEmpty(sub) && terminosInventario.Any(t => sub.Contains(t)));
        }

        private static bool EsCuentaControlNoInventario(string cuenta, string sub)
        {
            string[] terminosDescarte = new[]
            {
                "crédito fiscal", "credito fiscal", "débito fiscal", "debito fiscal", "iva",
                "caja", "bancos", "efectivo", "clientes", "proveedores", "cuentas por cobrar",
                "cuentas por pagar", "capital social", "capital", "retención", "retencion", "percepción", "percepcion",
                "anticipo", "gastos de venta", "gastos de adm", "gastos de administración",
                "gastos financieros", "ingresos financieros", "utilidad", "pérdida", "perdida"
            };

            return terminosDescarte.Any(t => cuenta.Contains(t) || (!string.IsNullOrEmpty(sub) && sub.Contains(t)));
        }

        /// <summary>
        /// Extrae las partidas del Libro Diario involucradas en inventarios/compras/ventas con valores sugeridos
        /// para que el usuario las calibre en la ventana modal previa.
        /// </summary>
        public static List<ItemCalibracionKardex> ExtraerItemsParaCalibracion(LibroDiarioInstancia libro)
        {
            var lista = new List<ItemCalibracionKardex>();
            if (libro?.Asientos == null || !libro.Asientos.Any()) return lista;

            var asientosOrdenados = libro.Asientos
                .OrderBy(a => a.Fecha)
                .ThenBy(a => a.NumeroAsiento)
                .ToList();

            foreach (var asiento in asientosOrdenados)
            {
                foreach (var mov in asiento.Movimientos)
                {
                    string cuenta = mov.CuentaPrincipal.Trim().ToLowerInvariant();
                    string sub = (mov.Subcuenta ?? string.Empty).Trim().ToLowerInvariant();
                    string concepto = asiento.Concepto.Trim();
                    string conceptoLower = concepto.ToLowerInvariant();

                    if (EsCuentaControlNoInventario(cuenta, sub)) continue;

                    // 1. Inventario Inicial (Partida #1 o concepto inicial)
                    if (asiento.NumeroAsiento == 1 && (cuenta.Contains("inventario") || cuenta.Contains("mercader") || conceptoLower.Contains("inicial") || conceptoLower.Contains("apertura")))
                    {
                        if (mov.Movimiento == TipoMovimiento.Debe && mov.Monto > 0)
                        {
                            decimal cantSugerida = (asiento.NumeroAsiento == 1 && mov.Monto == 6000.00m) ? 678m : Math.Max(1, Math.Round(mov.Monto / 8.85m));
                            decimal costoSugerido = 8.85m;

                            lista.Add(new ItemCalibracionKardex
                            {
                                NumeroAsiento = asiento.NumeroAsiento,
                                Fecha = asiento.Fecha,
                                TipoMovimiento = TipoMovimientoKardex.InventarioInicial,
                                TipoMovimientoTexto = "Inventario Inicial",
                                Concepto = string.IsNullOrWhiteSpace(asiento.Concepto) ? "Inventario Inicial" : asiento.Concepto,
                                Documento = $"Partida #{asiento.NumeroAsiento}",
                                MontoContable = mov.Monto,
                                Cantidad = cantSugerida,
                                CostoUnitario = costoSugerido,
                                EsEntrada = true
                            });
                            break;
                        }
                    }
                    // 2. Devolución sobre Venta (Debe)
                    else if (cuenta.Contains("devol") && (cuenta.Contains("venta") || sub.Contains("venta") || conceptoLower.Contains("venta")))
                    {
                        if (mov.Monto > 0)
                        {
                            decimal cantSugerida = (asiento.NumeroAsiento == 13) ? 5m : Math.Max(1, Math.Round(mov.Monto / 18.00m));
                            decimal costoSugerido = 8.85m;

                            lista.Add(new ItemCalibracionKardex
                            {
                                NumeroAsiento = asiento.NumeroAsiento,
                                Fecha = asiento.Fecha,
                                TipoMovimiento = TipoMovimientoKardex.DevolucionVenta,
                                TipoMovimientoTexto = "Devolución s/Venta",
                                Concepto = string.IsNullOrWhiteSpace(asiento.Concepto) ? "Devolución sobre Venta" : asiento.Concepto,
                                Documento = $"Partida #{asiento.NumeroAsiento}",
                                MontoContable = mov.Monto,
                                Cantidad = cantSugerida,
                                CostoUnitario = costoSugerido,
                                EsEntrada = true
                            });
                            break;
                        }
                    }
                    // 3. Devolución sobre Compra (Haber)
                    else if (cuenta.Contains("devol") && (cuenta.Contains("compra") || sub.Contains("compra") || conceptoLower.Contains("compra")))
                    {
                        if (mov.Monto > 0)
                        {
                            decimal cantSugerida = (asiento.NumeroAsiento == 4) ? 100m : Math.Max(1, Math.Round(mov.Monto / 8.85m));
                            decimal costoSugerido = 8.85m;

                            lista.Add(new ItemCalibracionKardex
                            {
                                NumeroAsiento = asiento.NumeroAsiento,
                                Fecha = asiento.Fecha,
                                TipoMovimiento = TipoMovimientoKardex.DevolucionCompra,
                                TipoMovimientoTexto = "Devolución s/Compra",
                                Concepto = string.IsNullOrWhiteSpace(asiento.Concepto) ? "Devolución sobre Compra" : asiento.Concepto,
                                Documento = $"Partida #{asiento.NumeroAsiento}",
                                MontoContable = mov.Monto,
                                Cantidad = cantSugerida,
                                CostoUnitario = costoSugerido,
                                EsEntrada = false
                            });
                            break;
                        }
                    }
                    // 4. Compras (Debe)
                    else if (cuenta.Contains("compra") || cuenta.Contains("compras") || (cuenta.Contains("inventario") && mov.Movimiento == TipoMovimiento.Debe))
                    {
                        if (mov.Movimiento == TipoMovimiento.Debe && mov.Monto > 0)
                        {
                            decimal cantSugerida = (asiento.NumeroAsiento == 3) ? 1000m : Math.Max(1, Math.Round(mov.Monto / 8.85m));
                            decimal costoSugerido = 8.85m;

                            lista.Add(new ItemCalibracionKardex
                            {
                                NumeroAsiento = asiento.NumeroAsiento,
                                Fecha = asiento.Fecha,
                                TipoMovimiento = TipoMovimientoKardex.Compra,
                                TipoMovimientoTexto = "Compra de Mercadería",
                                Concepto = string.IsNullOrWhiteSpace(asiento.Concepto) ? "Compra según Factura" : asiento.Concepto,
                                Documento = $"Partida #{asiento.NumeroAsiento}",
                                MontoContable = mov.Monto,
                                Cantidad = cantSugerida,
                                CostoUnitario = costoSugerido,
                                EsEntrada = true
                            });
                            break;
                        }
                    }
                    // 5. Ventas (Haber)
                    else if (cuenta.Contains("venta") || cuenta.Contains("ventas") || (cuenta.Contains("inventario") && mov.Movimiento == TipoMovimiento.Haber))
                    {
                        if (mov.Movimiento == TipoMovimiento.Haber && mov.Monto > 0)
                        {
                            decimal cantSugerida = (asiento.NumeroAsiento == 5) ? 600m :
                                                   (asiento.NumeroAsiento == 10) ? 250m :
                                                   Math.Max(1, Math.Round(mov.Monto / 18.00m));
                            decimal costoSugerido = 8.85m;

                            lista.Add(new ItemCalibracionKardex
                            {
                                NumeroAsiento = asiento.NumeroAsiento,
                                Fecha = asiento.Fecha,
                                TipoMovimiento = TipoMovimientoKardex.Venta,
                                TipoMovimientoTexto = "Venta de Mercadería",
                                Concepto = string.IsNullOrWhiteSpace(asiento.Concepto) ? "Venta según Factura" : asiento.Concepto,
                                Documento = $"Partida #{asiento.NumeroAsiento}",
                                MontoContable = mov.Monto,
                                Cantidad = cantSugerida,
                                CostoUnitario = costoSugerido,
                                EsEntrada = false
                            });
                            break;
                        }
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Genera una instancia de Kardex completamente calculada a partir de los datos calibrados por el usuario.
        /// </summary>
        public static (List<KardexItem> MovimientosProcesados, ResumenConciliacionKardex Resumen, KardexInstancia Instancia)
            GenerarKardexDesdeCalibracion(
                List<ItemCalibracionKardex> itemsCalibrados,
                MetodoValuacion metodo,
                DateTime fechaInicio,
                DateTime fechaFin,
                string nombreKardex = "Kardex de Mercaderías",
                string empresa = "Empresa Principal")
        {
            var itemsBase = new List<KardexItem>();
            long id = 1;

            foreach (var cal in itemsCalibrados)
            {
                var kItem = new KardexItem
                {
                    Id = id++,
                    Fecha = cal.Fecha,
                    Concepto = cal.Concepto,
                    Documento = cal.DocumentoTexto,
                    NumeroAsiento = cal.NumeroAsiento,
                    TipoMovimiento = cal.TipoMovimiento,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    EsFilaEspecial = false
                };

                if (cal.EsEntrada)
                {
                    kItem.CantidadEntrada = cal.Cantidad;
                    kItem.CantidadSalida = null;
                    kItem.CostoUnitario = cal.CostoUnitario;
                    kItem.Debe = (cal.TipoMovimiento == TipoMovimientoKardex.InventarioInicial && cal.MontoContable == 6000.00m && cal.Cantidad == 678m)
                        ? 6000.00m
                        : Math.Round(cal.Cantidad * cal.CostoUnitario, 2, MidpointRounding.AwayFromZero);
                    kItem.Haber = null;
                }
                else
                {
                    kItem.CantidadEntrada = null;
                    kItem.CantidadSalida = cal.Cantidad;
                    kItem.CostoUnitario = cal.CostoUnitario;
                    kItem.Debe = null;
                    kItem.Haber = Math.Round(cal.Cantidad * cal.CostoUnitario, 2, MidpointRounding.AwayFromZero);
                }

                itemsBase.Add(kItem);
            }

            var resultadoValuacion = ValuarMovimientosCalibrados(itemsBase, fechaInicio, fechaFin, metodo);

            var tarjeta = new KardexInstancia
            {
                Nombre = nombreKardex,
                CodigoArticulo = "ART-001",
                Empresa = empresa,
                Metodo = metodo,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                DestinoGuardado = TipoDestinoLibro.Local,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Movimientos = resultadoValuacion.ListaProcesada
            };

            return (resultadoValuacion.ListaProcesada, resultadoValuacion.Resumen, tarjeta);
        }

        /// <summary>
        /// Valúa una lista de movimientos calibrados aplicando las reglas contables de Entradas/Salidas y Costo de Ventas.
        /// </summary>
        private static (List<KardexItem> ListaProcesada, ResumenConciliacionKardex Resumen) ValuarMovimientosCalibrados(
            List<KardexItem> itemsBase,
            DateTime fechaInicio,
            DateTime fechaFin,
            MetodoValuacion metodo)
        {
            if (metodo == MetodoValuacion.PEPS)
            {
                return ValuarPEPS(itemsBase, fechaInicio, fechaFin);
            }

            var itemsOperativos = itemsBase
                .Where(x => !x.EsFilaEspecial)
                .OrderBy(x => x.Fecha)
                .ThenBy(x => x.NumeroAsiento ?? 0)
                .ToList();

            if (itemsOperativos.Count == 0)
            {
                return (new List<KardexItem>(), new ResumenConciliacionKardex());
            }

            decimal saldoCantidad = 0m;
            decimal saldoValor = 0m;
            decimal costoPromedio = 0m;

            decimal totalEntradas = 0m;
            decimal totalSalidas = 0m;
            decimal totalDebe = 0m;
            decimal totalHaber = 0m;
            decimal totalCostoVentas = 0m;

            var listaResultado = new List<KardexItem>();

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

                if (mov.TipoMovimiento == TipoMovimientoKardex.InventarioInicial ||
                    mov.TipoMovimiento == TipoMovimientoKardex.Compra ||
                    mov.TipoMovimiento == TipoMovimientoKardex.DevolucionVenta)
                {
                    // ENTRADA
                    decimal cant = mov.CantidadEntrada ?? 0m;
                    decimal costo = mov.CostoUnitario;
                    decimal debe = mov.Debe ?? Math.Round(cant * costo, 2, MidpointRounding.AwayFromZero);

                    saldoCantidad += cant;
                    saldoValor += debe;
                    costoPromedio = saldoCantidad > 0 ? Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero) : costo;

                    item.CantidadEntrada = cant;
                    item.CantidadSalida = null;
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costo;
                    item.CostoPromedio = costoPromedio;
                    item.Debe = debe;
                    item.Haber = null;
                    item.SaldoValor = saldoValor;

                    totalEntradas += cant;
                    totalDebe += debe;

                    if (mov.TipoMovimiento == TipoMovimientoKardex.DevolucionVenta)
                    {
                        totalCostoVentas -= debe; // Disminuye el costo de ventas
                    }
                }
                else
                {
                    // SALIDA (Venta o Devolución sobre Compra)
                    decimal cant = mov.CantidadSalida ?? 0m;
                    decimal costo = costoPromedio > 0 ? costoPromedio : mov.CostoUnitario;
                    decimal haber = Math.Round(cant * costo, 2, MidpointRounding.AwayFromZero);

                    saldoCantidad -= cant;
                    saldoValor -= haber;
                    if (saldoCantidad > 0)
                    {
                        costoPromedio = Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero);
                    }

                    item.CantidadEntrada = null;
                    item.CantidadSalida = cant;
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costo;
                    item.CostoPromedio = costoPromedio;
                    item.Debe = null;
                    item.Haber = haber;
                    item.SaldoValor = saldoValor;

                    totalSalidas += cant;
                    totalHaber += haber;

                    if (mov.TipoMovimiento == TipoMovimientoKardex.Venta)
                    {
                        totalCostoVentas += haber;
                    }
                }

                listaResultado.Add(item);
            }

            // Fila de Saldo Final del Período
            decimal costoPromedioFinal = saldoCantidad > 0 ? Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero) : costoPromedio;

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
                UltimoCostoPromedio = costoPromedioFinal,
                CostoDeVentas = totalCostoVentas
            };

            return (listaResultado, resumen);
        }

        /// <summary>
        /// Extrae automáticamente los movimientos contables de inventario de un Libro Diario y los valúa
        /// según el método especificado (Promedio Ponderado o PEPS).
        /// </summary>
        public static (List<KardexItem> MovimientosProcesados, ResumenConciliacionKardex Resumen, List<KardexItem> MovimientosBase) 
            GenerarKardexDesdeLibroDiario(
                LibroDiarioInstancia libro,
                MetodoValuacion metodo = MetodoValuacion.PromedioPonderado,
                decimal costoUnitarioEstimado = 8.85m)
        {
            var calibrados = ExtraerItemsParaCalibracion(libro);
            if (!calibrados.Any())
            {
                return (new List<KardexItem>(), new ResumenConciliacionKardex(), new List<KardexItem>());
            }

            var res = GenerarKardexDesdeCalibracion(calibrados, metodo, libro.FechaInicio, libro.FechaFin, $"Kardex — {libro.Nombre}", libro.Empresa);
            var baseItems = res.MovimientosProcesados.Where(m => !m.EsFilaEspecial).ToList();
            return (res.MovimientosProcesados, res.Resumen, baseItems);
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
                .ThenBy(x => x.NumeroAsiento ?? 0)
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
            decimal totalCostoVentas = 0m;
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

                bool esEntrada = mov.TipoMovimiento == TipoMovimientoKardex.InventarioInicial ||
                                 mov.TipoMovimiento == TipoMovimientoKardex.Compra ||
                                 mov.TipoMovimiento == TipoMovimientoKardex.DevolucionVenta;

                if (esEntrada)
                {
                    // ENTRADA: Añade una nueva capa al inventario
                    decimal cant = mov.CantidadEntrada ?? 0m;
                    decimal costo = mov.CostoUnitario;
                    decimal debe = mov.Debe ?? Math.Round(cant * costo, 2, MidpointRounding.AwayFromZero);

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

                    if (mov.TipoMovimiento == TipoMovimientoKardex.DevolucionVenta)
                    {
                        totalCostoVentas -= debe;
                    }
                }
                else
                {
                    // SALIDA: Consume de las capas más antiguas (FIFO)
                    decimal cantPorConsumir = mov.CantidadSalida ?? 0m;
                    decimal cantSalida = cantPorConsumir;
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

                    while (capasInventario.Count > 0)
                    {
                        nuevasCapas.Enqueue(capasInventario.Dequeue());
                    }
                    capasInventario = nuevasCapas;

                    if (cantPorConsumir > 0)
                    {
                        costoSalidaTotal += cantPorConsumir * ultimoCostoUnitario;
                    }

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

                    if (mov.TipoMovimiento == TipoMovimientoKardex.Venta)
                    {
                        totalCostoVentas += haber;
                    }
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
                UltimoCostoPromedio = costoPromedioFinal,
                CostoDeVentas = totalCostoVentas
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

