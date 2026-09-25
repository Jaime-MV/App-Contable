using System;

namespace App_Contable.Modelos
{
    /// <summary>
    /// Representa una fila de la Balanza de Comprobación.
    /// Cada fila corresponde a una cuenta del Mayor con su total Debe y Haber.
    /// </summary>
    public class FilaBalanzaComprobacion
    {
        /// <summary>Nombre de la cuenta (principal + subcuenta si aplica)</summary>
        public string Cuenta { get; set; } = string.Empty;

        /// <summary>Total de movimientos al Debe de la cuenta</summary>
        public decimal TotalDebe { get; set; }

        /// <summary>Total de movimientos al Haber de la cuenta</summary>
        public decimal TotalHaber { get; set; }

        /// <summary>Saldo final (diferencia absoluta)</summary>
        public decimal SaldoFinal => Math.Abs(TotalDebe - TotalHaber);

        /// <summary>"Deudor" o "Acreedor" según la naturaleza del saldo</summary>
        public string Naturaleza => TotalDebe >= TotalHaber ? "Deudor" : "Acreedor";

        /// <summary>Indica si es la fila de totales finales</summary>
        public bool EsFila_Total { get; set; } = false;
    }

    /// <summary>
    /// Resumen global de la Balanza de Comprobación para el panel de pie.
    /// </summary>
    public class ResumenBalanzaComprobacion
    {
        public decimal TotalDebe { get; set; }
        public decimal TotalHaber { get; set; }
        public bool EstaBalanceada => Math.Round(TotalDebe, 2) == Math.Round(TotalHaber, 2);
        public int TotalCuentas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
