using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    public class KardexCalculador
    {
        /// <summary>
        /// Recalcula en cascada todos los saldos físicos y valorizados de una lista de movimientos
        /// bajo el método de Costo Promedio Ponderado.
        /// </summary>
        public static (List<KardexItem> ListaProcesada, ResumenConciliacionKardex Resumen) ProcesarKardex(
            IEnumerable<KardexItem> movimientosOriginales,
            DateTime fechaInicio,
            DateTime fechaFin)
        {
            // Filtramos solo movimientos operativos reales ordenados cronológicamente
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
                });
            }

            decimal saldoCantidad = 0m;
            decimal saldoValor = 0m;
            decimal costoPromedio = 0m;

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
                    // ENTRADA (Compra o Saldo Inicial)
                    decimal cantEntrada = mov.CantidadEntrada.Value;
                    decimal costoUnit = mov.CostoUnitario;
                    decimal debe = Math.Round(cantEntrada * costoUnit, 2, MidpointRounding.AwayFromZero);

                    saldoCantidad += cantEntrada;
                    saldoValor += debe;
                    costoPromedio = saldoCantidad > 0 ? Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero) : costoUnit;

                    item.CantidadEntrada = cantEntrada;
                    item.CantidadSalida = null;
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costoUnit;
                    item.CostoPromedio = costoPromedio;
                    item.Debe = debe;
                    item.Haber = null;
                    item.SaldoValor = saldoValor;

                    totalEntradas += cantEntrada;
                    totalDebe += debe;
                }
                else if (mov.CantidadSalida.HasValue && mov.CantidadSalida.Value > 0)
                {
                    // SALIDA (Venta o Merma/Ajuste)
                    decimal cantSalida = mov.CantidadSalida.Value;
                    decimal costoUnitSalida = costoPromedio > 0 ? costoPromedio : mov.CostoUnitario;
                    decimal haber = Math.Round(cantSalida * costoUnitSalida, 2, MidpointRounding.AwayFromZero);

                    saldoCantidad -= cantSalida;
                    saldoValor -= haber;
                    if (saldoCantidad > 0)
                    {
                        costoPromedio = Math.Round(saldoValor / saldoCantidad, 4, MidpointRounding.AwayFromZero);
                    }

                    item.CantidadEntrada = null;
                    item.CantidadSalida = cantSalida;
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costoUnitSalida;
                    item.CostoPromedio = costoPromedio;
                    item.Debe = null;
                    item.Haber = haber;
                    item.SaldoValor = saldoValor;

                    totalSalidas += cantSalida;
                    totalHaber += haber;
                }
                else
                {
                    // Movimiento neutro o informativo
                    item.CantidadSaldo = saldoCantidad;
                    item.CostoUnitario = costoPromedio;
                    item.CostoPromedio = costoPromedio;
                    item.SaldoValor = saldoValor;
                }

                listaResultado.Add(item);
            }

            // Fila de Saldo Final del Período
            var filaSaldoFinal = new KardexItem
            {
                Id = 99990,
                Fecha = fechaFin,
                Concepto = "Saldo Final del Período",
                Documento = "CIERRE-" + fechaFin.ToString("MM"),
                CantidadEntrada = null,
                CantidadSalida = null,
                CantidadSaldo = saldoCantidad,
                CostoUnitario = costoPromedio,
                CostoPromedio = costoPromedio,
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
                CostoUnitario = costoPromedio,
                CostoPromedio = costoPromedio,
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
                UltimoCostoPromedio = costoPromedio
            };

            return (listaResultado, resumen);
        }

        /// <summary>
        /// Devuelve los datos semilla idénticos al ejemplo de la interfaz.
        /// </summary>
        public static List<KardexItem> ObtenerDatosSemillaEjemplo()
        {
            return new List<KardexItem>
            {
                new KardexItem
                {
                    Id = 1,
                    Fecha = new DateTime(2026, 9, 1),
                    Concepto = "Saldo Inicial",
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
                    Concepto = "Compra Factura #402 — Prov. Cem...",
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
                    Concepto = "Venta según Asiento #12 — Cliente ...",
                    Documento = "OV-0088",
                    CantidadSalida = 120m,
                    CostoUnitario = 8.4333m,
                    TipoMovimiento = TipoMovimientoKardex.Venta,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 12
                },
                new KardexItem
                {
                    Id = 4,
                    Fecha = new DateTime(2026, 9, 15),
                    Concepto = "Venta según Asiento #18 — Cliente ...",
                    Documento = "OV-8101",
                    CantidadSalida = 80m,
                    CostoUnitario = 8.4333m,
                    TipoMovimiento = TipoMovimientoKardex.Venta,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 18
                },
                new KardexItem
                {
                    Id = 5,
                    Fecha = new DateTime(2026, 9, 22),
                    Concepto = "Compra Factura #519 — Prov. Cem...",
                    Documento = "F-519",
                    CantidadEntrada = 150m,
                    CostoUnitario = 8.4500m,
                    TipoMovimiento = TipoMovimientoKardex.Compra,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 24
                }
            };
        }
    }
}

