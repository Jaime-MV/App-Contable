using System;

namespace App_Contable.Modelos
{
    public enum TipoFilaBalance
    {
        TituloSeccion,     // "ACTIVO", "PASIVO", "PATRIMONIO" (Fondo azul)
        Subseccion,        // "Activo corriente", "Activo no corriente", etc.
        Cuenta,            // Cuentas individuales (Importe en Parcial)
        Subtotal,          // "Total Activo Corriente", "Total Pasivo Corriente", etc. (Fondo verde claro)
        TotalPrincipal,    // "TOTAL ACTIVO", "TOTAL PASIVO", "TOTAL PASIVO + PATRIMONIO" (Fondo verde destacado)
        Separador          // Fila en blanco
    }

    public class FilaBalanceVisual
    {
        public string Cuenta { get; set; } = string.Empty;
        public decimal? Parcial { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public TipoFilaBalance TipoFila { get; set; }
    }

    public class DatosBalanceGeneral
    {
        public string Empresa { get; set; } = "EMPRESA COMERCIAL, S.A. DE C.V.";
        public DateTime FechaCorte { get; set; } = DateTime.Today;

        // Activo Corriente
        public decimal EfectivoYEquivalentes { get; set; }
        public decimal CreditoFiscalIva { get; set; }
        public decimal Inventarios { get; set; }
        public decimal CuentasPorCobrar { get; set; }
        public decimal TotalActivoCorriente => EfectivoYEquivalentes + CreditoFiscalIva + Inventarios + CuentasPorCobrar;

        // Activo No Corriente
        public decimal PropiedadPlantaYEquipo { get; set; }
        public decimal TotalActivoNoCorriente => PropiedadPlantaYEquipo;

        // Total Activo
        public decimal TotalActivo => TotalActivoCorriente + TotalActivoNoCorriente;

        // Pasivo Corriente
        public decimal CuentasPorPagar { get; set; }
        public decimal DebitoFiscalIva { get; set; }
        public decimal TotalPasivoCorriente => CuentasPorPagar + DebitoFiscalIva;

        // Pasivo No Corriente
        public decimal PrestamosBancarios { get; set; }
        public decimal TotalPasivoNoCorriente => PrestamosBancarios;

        // Total Pasivo
        public decimal TotalPasivo => TotalPasivoCorriente + TotalPasivoNoCorriente;

        // Patrimonio
        public decimal CapitalSocial { get; set; }
        public decimal UtilidadOperacional { get; set; }
        public decimal TotalPatrimonio => CapitalSocial + UtilidadOperacional;

        // Total Pasivo + Patrimonio
        public decimal TotalPasivoMasPatrimonio => TotalPasivo + TotalPatrimonio;

        public bool EstaCuadrado => Math.Round(TotalActivo, 2) == Math.Round(TotalPasivoMasPatrimonio, 2);
        public decimal Diferencia => Math.Abs(TotalActivo - TotalPasivoMasPatrimonio);
    }
}
