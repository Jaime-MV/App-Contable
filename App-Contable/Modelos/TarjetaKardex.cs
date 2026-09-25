using System;
using System.Collections.Generic;

namespace App_Contable.Modelos
{
    public enum TipoAlmacenamientoKardex
    {
        EnMemoria
    }

    /// <summary>
    /// Representa los metadatos y contenido de una Tarjeta Kardex en memoria para un artículo o producto específico.
    /// Valuado bajo el método PEPS / FIFO (Primeras Entradas, Primeras Salidas).
    /// </summary>
    public class TarjetaKardex
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Nombre { get; set; } = string.Empty;
        public string CodigoArticulo { get; set; } = string.Empty;
        public string MetodoValuacion { get; set; } = "PEPS / FIFO (Primeras Entradas, Primeras Salidas)";
        public TipoAlmacenamientoKardex OrigenAlmacenamiento { get; set; } = TipoAlmacenamientoKardex.EnMemoria;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public decimal StockActual { get; set; }
        public decimal CostoPromedioActual { get; set; }
        public decimal SaldoValorActual { get; set; }
        public List<KardexItem> Movimientos { get; set; } = new();

        public string DescripcionSecundaria
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CodigoArticulo))
                {
                    return "PEPS / FIFO";
                }
                return $"PEPS / FIFO · Ref: {CodigoArticulo}";
            }
        }

        public string TextoBadgeOrigen => "En Memoria";

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

