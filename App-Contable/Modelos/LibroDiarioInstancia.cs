using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Contable.Modelos
{
    public enum TipoDestinoLibro
    {
        Local,
        PostgreSQL
    }

    /// <summary>
    /// Representa una instancia completa de Libro Diario con sus metadatos y colección de asientos contables.
    /// </summary>
    public class LibroDiarioInstancia
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Nombre { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime FechaFin { get; set; } = new DateTime(DateTime.Now.Year, 12, 31);
        public TipoDestinoLibro DestinoGuardado { get; set; } = TipoDestinoLibro.Local;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public List<AsientoContable> Asientos { get; set; } = new();

        public string TextoBadgeDestino => DestinoGuardado == TipoDestinoLibro.Local ? "[Local]" : "[BD - Pendiente]";

        public string TextoPeriodo => $"{FechaInicio:dd/MM/yyyy} — {FechaFin:dd/MM/yyyy}";

        public string DescripcionSecundaria
        {
            get
            {
                string empresaTexto = string.IsNullOrWhiteSpace(Empresa) ? "Empresa Principal" : Empresa;
                return $"{empresaTexto} · Período: {TextoPeriodo} · {Asientos.Count} Asiento(s)";
            }
        }

        public decimal TotalDebe => Asientos.Sum(a => a.TotalDebe);
        public decimal TotalHaber => Asientos.Sum(a => a.TotalHaber);

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

