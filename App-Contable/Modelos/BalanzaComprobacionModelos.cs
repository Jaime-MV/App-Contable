using System;

namespace App_Contable.Modelos
{
    /// <summary>
    /// Representa una fila estructurada de la Balanza de Comprobación con sus 6 columnas estándar:
    /// Código | Cuenta / Nombre | Movimiento Debe | Movimiento Haber | Saldo Deudor | Saldo Acreedor
    /// </summary>
    public class FilaBalanzaComprobacion
    {
        /// <summary>Código numérico de la cuenta según el catálogo oficial</summary>
        public string Codigo { get; set; } = string.Empty;

        /// <summary>Nombre de la cuenta (principal + subcuenta si aplica)</summary>
        public string Cuenta { get; set; } = string.Empty;

        /// <summary>Total de movimientos cargados al Debe de la cuenta</summary>
        public decimal MovimientoDebe { get; set; }

        /// <summary>Total de movimientos abonados al Haber de la cuenta</summary>
        public decimal MovimientoHaber { get; set; }

        /// <summary>Saldo Deudor final (MovimientoDebe - MovimientoHaber si Debe > Haber; de lo contrario 0.00)</summary>
        public decimal SaldoDeudor { get; set; }

        /// <summary>Saldo Acreedor final (MovimientoHaber - MovimientoDebe si Haber > Debe; de lo contrario 0.00)</summary>
        public decimal SaldoAcreedor { get; set; }

        // Propiedades de compatibilidad
        public decimal TotalDebe
        {
            get => MovimientoDebe;
            set => MovimientoDebe = value;
        }

        public decimal TotalHaber
        {
            get => MovimientoHaber;
            set => MovimientoHaber = value;
        }

        /// <summary>Saldo final absoluto</summary>
        public decimal SaldoFinal => Math.Abs(MovimientoDebe - MovimientoHaber);

        /// <summary>"Deudor" o "Acreedor" según la naturaleza del saldo</summary>
        public string Naturaleza => MovimientoDebe >= MovimientoHaber ? "Deudor" : "Acreedor";

        /// <summary>Indica si es la fila de sumas iguales / totales finales</summary>
        public bool EsFila_Total { get; set; } = false;
    }

    /// <summary>
    /// Resumen global de la Balanza de Comprobación para el panel de pie y validación de doble partida.
    /// </summary>
    public class ResumenBalanzaComprobacion
    {
        public decimal TotalMovimientoDebe { get; set; }
        public decimal TotalMovimientoHaber { get; set; }
        public decimal TotalSaldoDeudor { get; set; }
        public decimal TotalSaldoAcreedor { get; set; }

        public decimal TotalDebe
        {
            get => TotalMovimientoDebe;
            set => TotalMovimientoDebe = value;
        }

        public decimal TotalHaber
        {
            get => TotalMovimientoHaber;
            set => TotalMovimientoHaber = value;
        }

        /// <summary>
        /// Valida el doble cuadre de la Balanza:
        /// 1) Suma Movimientos Debe == Suma Movimientos Haber
        /// 2) Suma Saldos Deudores == Suma Saldos Acreedores
        /// </summary>
        public bool EstaBalanceada =>
            Math.Round(TotalMovimientoDebe, 2) == Math.Round(TotalMovimientoHaber, 2) &&
            Math.Round(TotalSaldoDeudor, 2) == Math.Round(TotalSaldoAcreedor, 2);

        public decimal DiferenciaMovimientos => Math.Abs(TotalMovimientoDebe - TotalMovimientoHaber);
        public decimal DiferenciaSaldos => Math.Abs(TotalSaldoDeudor - TotalSaldoAcreedor);

        public int TotalCuentas { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string NombreLibro { get; set; } = string.Empty;
    }
}

