using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Contable.Modelos
{
    public enum TipoMovimiento
    {
        Debe, // Cargo
        Haber // Abono
    }

    public enum TipoFilaVisual
    {
        EncabezadoPartida,
        CuentaPrincipal,
        Subcuenta,
        ConceptoGlosa,
        Separador,
        TotalSumasIguales
    }

    /// <summary>
    /// Representa un movimiento contable individual ingresado en una partida.
    /// </summary>
    public class MovimientoContable
    {
        public string CuentaPrincipal { get; set; } = string.Empty;
        public string? Subcuenta { get; set; }
        public TipoMovimiento Movimiento { get; set; }
        public decimal Monto { get; set; }

        public decimal Parcial => !string.IsNullOrWhiteSpace(Subcuenta) ? Monto : 0m;
        public decimal Debe => Movimiento == TipoMovimiento.Debe ? Monto : 0m;
        public decimal Haber => Movimiento == TipoMovimiento.Haber ? Monto : 0m;
    }

    /// <summary>
    /// Representa una partida o asiento contable completo en el Libro Diario.
    /// </summary>
    public class AsientoContable
    {
        public int NumeroAsiento { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Concepto { get; set; } = string.Empty;
        public List<MovimientoContable> Movimientos { get; set; } = new();

        public decimal TotalDebe => Movimientos.Where(m => m.Movimiento == TipoMovimiento.Debe).Sum(m => m.Monto);
        public decimal TotalHaber => Movimientos.Where(m => m.Movimiento == TipoMovimiento.Haber).Sum(m => m.Monto);
        public decimal Diferencia => Math.Abs(TotalDebe - TotalHaber);
        public bool EstaCuadrado => TotalDebe > 0 && Math.Round(TotalDebe, 2) == Math.Round(TotalHaber, 2);
    }

    /// <summary>
    /// Fila estructurada para el DataGridView del Libro Diario con las columnas:
    /// Fecha | Cuenta | Parcial | Debe | Haber
    /// </summary>
    public class FilaLibroDiarioVisual
    {
        public int NumeroAsiento { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string Cuenta { get; set; } = string.Empty;
        public decimal? Parcial { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public TipoFilaVisual TipoFila { get; set; }

        // Formatos de texto para visualización limpia
        public string ParcialTexto => Parcial.HasValue ? Parcial.Value.ToString("N2") : string.Empty;
        public string DebeTexto => Debe.HasValue ? Debe.Value.ToString("N2") : string.Empty;
        public string HaberTexto => Haber.HasValue ? Haber.Value.ToString("N2") : string.Empty;
    }
}
