using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Contable.Modelos
{
    public enum MetodoValuacion
    {
        PromedioPonderado,
        PEPS
    }

    /// <summary>
    /// Representa una instancia completa de Tarjeta Kardex guardada con metadatos y movimientos.
    /// </summary>
    public class KardexInstancia
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Nombre { get; set; } = string.Empty;
        public string CodigoArticulo { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
        public MetodoValuacion Metodo { get; set; } = MetodoValuacion.PromedioPonderado;
        public string MetodoValuacionTexto => Metodo == MetodoValuacion.PEPS ? "PEPS (FIFO)" : "Costo Promedio Ponderado";

        public DateTime FechaInicio { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime FechaFin { get; set; } = new DateTime(DateTime.Now.Year, 12, 31);
        public TipoDestinoLibro DestinoGuardado { get; set; } = TipoDestinoLibro.Local;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public List<KardexItem> Movimientos { get; set; } = new();

        public string TextoBadgeDestino => DestinoGuardado == TipoDestinoLibro.Local ? "[Local]" : "[PostgreSQL]";

        public string TextoPeriodo => $"{FechaInicio:dd/MM/yyyy} — {FechaFin:dd/MM/yyyy}";

        public decimal StockActual
        {
            get
            {
                var ult = Movimientos.LastOrDefault(m => !m.EsFilaEspecial);
                return ult?.CantidadSaldo ?? 0m;
            }
        }

        public decimal SaldoValorActual
        {
            get
            {
                var ult = Movimientos.LastOrDefault(m => !m.EsFilaEspecial);
                return ult?.SaldoValor ?? 0m;
            }
        }

        public string DescripcionSecundaria
        {
            get
            {
                string art = string.IsNullOrWhiteSpace(CodigoArticulo) ? string.Empty : $" · Ref: {CodigoArticulo}";
                return $"{MetodoValuacionTexto}{art} · Período: {TextoPeriodo} · {Movimientos.Count(m => !m.EsFilaEspecial)} Movimiento(s)";
            }
        }

        public string GrupoTemporal
        {
            get
            {
                var ahora = DateTime.Now.Date;
                var fechaMod = FechaModificacion.Date;

                if (fechaMod == ahora) return "Hoy";
                if (fechaMod >= ahora.AddDays(-7)) return "Esta semana";
                if (fechaMod.Month == ahora.Month && fechaMod.Year == ahora.Year) return "Este mes";
                return "Anteriores";
            }
        }
    }
}

