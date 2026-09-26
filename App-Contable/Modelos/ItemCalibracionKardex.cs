using System;
using System.Globalization;

namespace App_Contable.Modelos
{
    /// <summary>
    /// Representa una partida contable extraída del Libro Diario lista para ser calibrada
    /// por el usuario con cantidades físicas y costos unitarios antes de generar la tarjeta Kardex.
    /// </summary>
    public class ItemCalibracionKardex
    {
        private static readonly CultureInfo UsCulture = new("en-US");

        public int NumeroAsiento { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public TipoMovimientoKardex TipoMovimiento { get; set; } = TipoMovimientoKardex.Compra;
        public string TipoMovimientoTexto { get; set; } = string.Empty;
        public string Concepto { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public decimal MontoContable { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public bool EsEntrada { get; set; }

        public string PartidaTexto => $"Partida #{NumeroAsiento}";
        public string DocumentoTexto => string.IsNullOrWhiteSpace(Documento) ? PartidaTexto : Documento;
        public string FechaTexto => Fecha.ToString("dd/MM/yyyy");
        public string MontoContableTexto => MontoContable.ToString("$#,##0.00", UsCulture);
        public string CostoUnitarioTexto => CostoUnitario.ToString("$#,##0.00", UsCulture);
        public string TotalFisicoTexto => (Cantidad * CostoUnitario).ToString("$#,##0.00", UsCulture);
    }
}
