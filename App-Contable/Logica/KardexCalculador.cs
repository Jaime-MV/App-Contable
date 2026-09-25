using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    /// <summary>
    /// Representa un lote o capa de inventario bajo el método PEPS / FIFO.
    /// </summary>
    public class CapaInventarioPeps
    {
        public long IdMovimientoEntrada { get; set; }
        public DateTime Fecha { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Concepto { get; set; } = string.Empty;
        public decimal CantidadInicial { get; set; }
        public decimal CantidadDisponible { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal SaldoValorCapa => Math.Round(CantidadDisponible * CostoUnitario, 2, MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Motor de cálculo contable para Tarjetas Kardex exclusivamente bajo el método PEPS / FIFO
    /// (Primeras Entradas, Primeras Salidas / First In, First Out).
    /// </summary>
    public class KardexCalculador
    {
        /// <summary>
        /// Recalcula en cascada todos los saldos físicos y valorizados de una lista de movimientos
        /// bajo el método contable PEPS / FIFO (Primeras Entradas, Primeras Salidas).
        /// </summary>
        public static (List<KardexItem> ListaProcesada, ResumenConciliacionKardex Resumen, List<CapaInventarioPeps> CapasRemanentes) ProcesarKardex(
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
                return (new List<KardexItem>(), new ResumenConciliacionKardex
                {
                    TotalEntradasFisicas = 0m,
                    TotalSalidasFisicas = 0m,
                    SaldoFisicoFinal = 0m,
                    TotalDebe = 0m,
                    TotalHaber = 0m,
                    SaldoValorFinal = 0m,
                    UltimoCostoPromedio = 0m
                }, new List<CapaInventarioPeps>());
            }

            // Capas de inventario activas para PEPS (FIFO queue)
            var capas = new List<CapaInventarioPeps>();

            decimal saldoCantidad = 0m;
            decimal saldoValor = 0m;

            decimal totalEntradas = 0m;
            decimal totalSalidas = 0m;
            decimal totalDebe = 0m;
            decimal totalHaber = 0m;

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

                if (mov.CantidadEntrada.HasValue && mov.CantidadEntrada.Value > 0)
                {
                    // ==========================================
                    // ENTRADA PEPS (Compra / Saldo Inicial / Devolución)
                    // ==========================================
                    decimal cantEntrada = mov.CantidadEntrada.Value;
                    decimal costoUnit = mov.CostoUnitario;
                    decimal debe = Math.Round(cantEntrada * costoUnit, 2, MidpointRounding.AwayFromZero);

                    // Se agrega una nueva capa / lote con su costo de adquisición
                    capas.Add(new CapaInventarioPeps
                    {
                        IdMovimientoEntrada = mov.Id,
                        Fecha = mov.Fecha,
                        Documento = mov.Documento,
                        Concepto = mov.Concepto,
                        CantidadInicial = cantEntrada,
                        CantidadDisponible = cantEntrada,
                        CostoUnitario = costoUnit
                    });

                    saldoCantidad += cantEntrada;
                    saldoValor = capas.Sum(c => c.SaldoValorCapa);

                    item.CantidadEntrada = cantEntrada;
                    item.CantidadSalida = null;
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costoUnit;
                    item.CostoPromedio = costoUnit;
                    item.Debe = debe;
                    item.Haber = null;
                    item.SaldoValor = saldoValor;

                    totalEntradas += cantEntrada;
                    totalDebe += debe;
                }
                else if (mov.CantidadSalida.HasValue && mov.CantidadSalida.Value > 0)
                {
                    // ==========================================
                    // SALIDA PEPS (Venta / Merma / Salida de Inventario)
                    // Se consumen las unidades de las capas más antiguas primero
                    // ==========================================
                    decimal cantSalida = mov.CantidadSalida.Value;
                    decimal porConsumir = cantSalida;
                    decimal importeHaber = 0m;

                    foreach (var capa in capas.Where(c => c.CantidadDisponible > 0))
                    {
                        if (porConsumir <= 0) break;

                        decimal aTomar = Math.Min(porConsumir, capa.CantidadDisponible);
                        decimal costoTramo = Math.Round(aTomar * capa.CostoUnitario, 2, MidpointRounding.AwayFromZero);

                        capa.CantidadDisponible -= aTomar;
                        porConsumir -= aTomar;
                        importeHaber += costoTramo;
                    }

                    // En caso de que se supere el stock disponible (déficit)
                    if (porConsumir > 0)
                    {
                        decimal costoDeficit = capas.Count > 0 ? capas.Last().CostoUnitario : mov.CostoUnitario;
                        importeHaber += Math.Round(porConsumir * costoDeficit, 2, MidpointRounding.AwayFromZero);
                    }

                    saldoCantidad -= cantSalida;
                    saldoValor = capas.Sum(c => c.SaldoValorCapa);

                    decimal costoUnitarioEfectivo = cantSalida > 0
                        ? Math.Round(importeHaber / cantSalida, 4, MidpointRounding.AwayFromZero)
                        : 0m;

                    item.CantidadEntrada = null;
                    item.CantidadSalida = cantSalida;
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costoUnitarioEfectivo;
                    item.CostoPromedio = costoUnitarioEfectivo;
                    item.Debe = null;
                    item.Haber = importeHaber;
                    item.SaldoValor = saldoValor;

                    totalSalidas += cantSalida;
                    totalHaber += importeHaber;
                }
                else
                {
                    item.CantidadSaldo = saldoCantidad;
                    item.SaldoValor = saldoValor;
                }

                listaResultado.Add(item);
            }

            // Fila de Saldo Final del Período
            decimal costoFinalIndicativo = saldoCantidad > 0 && saldoValor > 0
                ? Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero)
                : (capas.Count > 0 ? capas.Last().CostoUnitario : 0m);

            var filaSaldoFinal = new KardexItem
            {
                Id = 99990,
                Fecha = fechaFin,
                Concepto = "Saldo Final del Período (PEPS)",
                Documento = "CIERRE-" + fechaFin.ToString("MM"),
                CantidadEntrada = null,
                CantidadSalida = null,
                CantidadSaldo = saldoCantidad,
                CostoUnitario = costoFinalIndicativo,
                CostoPromedio = costoFinalIndicativo,
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
                CostoUnitario = costoFinalIndicativo,
                CostoPromedio = costoFinalIndicativo,
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
                UltimoCostoPromedio = costoFinalIndicativo
            };

            var capasRemanentes = capas.Where(c => c.CantidadDisponible > 0).ToList();

            return (listaResultado, resumen, capasRemanentes);
        }

        /// <summary>
        /// Simula el costo de una salida bajo PEPS con base en las capas de inventario activas en memoria.
        /// </summary>
        public static (decimal ImporteTotalHaber, decimal CostoUnitarioPeps, string DesgloseCapas) SimularCostoSalidaPeps(
            IEnumerable<KardexItem> movimientosPrevios,
            decimal cantidadSalida)
        {
            if (cantidadSalida <= 0)
                return (0m, 0m, "Cantidad cero");

            var (_, _, capas) = ProcesarKardex(movimientosPrevios, DateTime.MinValue, DateTime.MaxValue);

            decimal porConsumir = cantidadSalida;
            decimal totalHaber = 0m;
            var tramosTexto = new List<string>();

            foreach (var capa in capas)
            {
                if (porConsumir <= 0) break;

                decimal aTomar = Math.Min(porConsumir, capa.CantidadDisponible);
                decimal costoTramo = Math.Round(aTomar * capa.CostoUnitario, 2, MidpointRounding.AwayFromZero);

                tramosTexto.Add($"{aTomar:N0} uds @ ${capa.CostoUnitario:N4}");

                porConsumir -= aTomar;
                totalHaber += costoTramo;
            }

            if (porConsumir > 0)
            {
                decimal costoDeficit = capas.Count > 0 ? capas.Last().CostoUnitario : 8.5000m;
                totalHaber += Math.Round(porConsumir * costoDeficit, 2, MidpointRounding.AwayFromZero);
                tramosTexto.Add($"{porConsumir:N0} uds (Déficit) @ ${costoDeficit:N4}");
            }

            decimal costoUnitarioPromedio = cantidadSalida > 0
                ? Math.Round(totalHaber / cantidadSalida, 4, MidpointRounding.AwayFromZero)
                : 0m;

            string desglose = string.Join(" + ", tramosTexto);
            return (totalHaber, costoUnitarioPromedio, desglose);
        }

        /// <summary>
        /// Devuelve los datos semilla calculados para PEPS / FIFO.
        /// </summary>
        public static List<KardexItem> ObtenerDatosSemillaEjemplo()
        {
            return new List<KardexItem>
            {
                new KardexItem
                {
                    Id = 1,
                    Fecha = new DateTime(2026, 9, 1),
                    Concepto = "Inventario Inicial",
                    Documento = "INV-0001",
                    CantidadEntrada = 300m,
                    CostoUnitario = 8.5000m,
                    TipoMovimiento = TipoMovimientoKardex.InventarioInicial,
                    Origen = TipoOrigenKardex.Manual
                },
                new KardexItem
                {
                    Id = 2,
                    Fecha = new DateTime(2026, 9, 5),
                    Concepto = "Compra Factura #402 — Prov. Cementera",
                    Documento = "F-402",
                    CantidadEntrada = 200m,
                    CostoUnitario = 8.4000m,
                    TipoMovimiento = TipoMovimientoKardex.Compra,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 12
                },
                new KardexItem
                {
                    Id = 3,
                    Fecha = new DateTime(2026, 9, 10),
                    Concepto = "Venta s/ Asiento #12 — Cliente Mayorista",
                    Documento = "OV-0088",
                    CantidadSalida = 120m, // Consume del Lote 1 (300 @ 8.50)
                    CostoUnitario = 8.5000m,
                    TipoMovimiento = TipoMovimientoKardex.Venta,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 12
                },
                new KardexItem
                {
                    Id = 4,
                    Fecha = new DateTime(2026, 9, 15),
                    Concepto = "Venta s/ Asiento #18 — Distribuidora Central",
                    Documento = "OV-8101",
                    CantidadSalida = 200m, // Consume 180 @ 8.50 + 20 @ 8.40
                    CostoUnitario = 8.4900m,
                    TipoMovimiento = TipoMovimientoKardex.Venta,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 18
                },
                new KardexItem
                {
                    Id = 5,
                    Fecha = new DateTime(2026, 9, 22),
                    Concepto = "Compra Factura #519 — Prov. Cementera",
                    Documento = "F-519",
                    CantidadEntrada = 150m,
                    CostoUnitario = 8.6000m,
                    TipoMovimiento = TipoMovimientoKardex.Compra,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 24
                }
            };
        }
    }
}

