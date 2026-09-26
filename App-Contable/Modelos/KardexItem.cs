using System;

namespace App_Contable.Modelos
{
    public enum TipoOrigenKardex
    {
        AutoLibroDiario,
        Manual
    }

    public enum TipoMovimientoKardex
    {
        InventarioInicial,
        Compra,
        Venta,
        DevolucionCompra,
        DevolucionVenta,
        AjustePositivo,
        AjusteNegativo,
        SaldoFinalPeriodo,
        Totales
    }

    public class KardexItem
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;

        // Unidades físicas
        public decimal? CantidadEntrada { get; set; }
        public decimal? CantidadSalida { get; set; }
        public decimal CantidadSaldo { get; set; }

        // Costos
        public decimal CostoUnitario { get; set; }
        public decimal CostoPromedio { get; set; }

        // Valores monetarios ($)
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public decimal SaldoValor { get; set; }

        // Origen y metadata
        public TipoOrigenKardex Origen { get; set; } = TipoOrigenKardex.Manual;
        public int? NumeroAsiento { get; set; }
        public TipoMovimientoKardex TipoMovimiento { get; set; } = TipoMovimientoKardex.Compra;
        public bool EsFilaEspecial { get; set; } = false;

        public string TextoOrigenBadge
        {
            get
            {
                if (EsFilaEspecial) return string.Empty;
                return Origen == TipoOrigenKardex.AutoLibroDiario
                    ? $"Auto · Asiento #{NumeroAsiento ?? 1}"
                    : "Manual";
            }
        }
    }

    public class ResumenConciliacionKardex
    {
        public decimal TotalEntradasFisicas { get; set; }
        public decimal TotalSalidasFisicas { get; set; }
        public decimal NetoFisico => TotalEntradasFisicas - TotalSalidasFisicas;
        public decimal SaldoFisicoFinal { get; set; }

        public decimal TotalDebe { get; set; }
        public decimal TotalHaber { get; set; }
        public decimal DiferenciaMonetaria => TotalDebe - TotalHaber;
        public decimal SaldoValorFinal { get; set; }
        public decimal UltimoCostoPromedio { get; set; }
        public decimal CostoDeVentas { get; set; }
    }
}

