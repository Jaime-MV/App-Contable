using System;

namespace App_Contable.Modelos
{
    public enum TipoFilaEstadoResultados
    {
        Concepto,            // Líneas individuales con importe en columna Parcial
        Subtotal,            // Líneas de cálculo con importe en columna Subtotal (ej: Compras totales, (-) Gastos de operación)
        ResultadoIntermedio, // Líneas de balance intermedio en columna Total con fondo verde claro #E2EFDA (Ventas netas, Compras netas, Mercadería disponible, Costo de ventas, Utilidad bruta)
        ResultadoFinal,      // Resultado operacional antes de impuestos en columna Total con fondo verde #A9D08E
        Separador            // Fila separadora en blanco
    }

    public class FilaEstadoResultadosVisual
    {
        public string Concepto { get; set; } = string.Empty;
        public decimal? Parcial { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public TipoFilaEstadoResultados TipoFila { get; set; }
    }

    public class DatosEstadoResultados
    {
        public string Empresa { get; set; } = "EMPRESA COMERCIAL, S.A. DE C.V.";
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // Ventas
        public decimal Ventas { get; set; }
        public decimal DevolucionesSobreVentas { get; set; }
        public decimal VentasNetas => Ventas - DevolucionesSobreVentas;

        // Compras
        public decimal Compras { get; set; }
        public decimal GastosDeCompra { get; set; }
        public decimal ComprasTotales => Compras + GastosDeCompra;
        public decimal DevolucionesSobreCompras { get; set; }
        public decimal ComprasNetas => ComprasTotales - DevolucionesSobreCompras;

        // Inventarios y Costo
        public decimal InventarioInicial { get; set; }
        public decimal MercaderiaDisponible => ComprasNetas + InventarioInicial;
        public decimal InventarioFinal { get; set; }
        public decimal CostoDeVentas => MercaderiaDisponible - InventarioFinal;

        // Utilidad Bruta
        public decimal UtilidadBruta => VentasNetas - CostoDeVentas;

        // Gastos
        public decimal GastosFinancieros { get; set; }
        public decimal GastosDeOperacion => GastosFinancieros;

        // Utilidad Operacional
        public decimal UtilidadOperacional => UtilidadBruta - GastosDeOperacion;
    }
}
