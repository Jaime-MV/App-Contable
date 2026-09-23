using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    /// <summary>
    /// Representa una fila individual de movimiento dentro de una cuenta del Mayor.
    /// </summary>
    public class FilaMayorizacionVisual
    {
        public string Fecha { get; set; } = string.Empty;
        public int NumeroAsiento { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public decimal Saldo { get; set; }
        public string NaturalezaSaldo { get; set; } = string.Empty; // "D" o "A"
        public bool EsEncabezado { get; set; }
        public bool EsTotalCierre { get; set; }
    }

    /// <summary>
    /// Representa una cuenta del Mayor con todos sus movimientos y saldo final.
    /// </summary>
    public class CuentaMayor
    {
        public string NombreCuenta { get; set; } = string.Empty;
        public string? NombreSubcuenta { get; set; }
        /// <summary>Identificador único para agrupación: "CuentaPrincipal|Subcuenta" o "CuentaPrincipal"</summary>
        public string ClaveAgrupacion { get; set; } = string.Empty;
        public List<FilaMayorizacionVisual> Movimientos { get; set; } = new();
        public decimal TotalDebe { get; set; }
        public decimal TotalHaber { get; set; }
        public decimal SaldoFinal => Math.Abs(TotalDebe - TotalHaber);
        public string NaturalezaSaldo => TotalDebe >= TotalHaber ? "Deudor" : "Acreedor";
    }

    public class MayorizacionServicio
    {
        private readonly LibroDiarioServicio _libroDiario;

        public MayorizacionServicio()
        {
            _libroDiario = LibroDiarioServicio.Instancia;
        }

        /// <summary>
        /// Genera la lista de cuentas del Mayor con sus movimientos, tomando como fuente
        /// los asientos registrados en el Libro Diario.
        /// </summary>
        public List<CuentaMayor> GenerarMayor(DateTime? desde = null, DateTime? hasta = null)
        {
            var asientos = _libroDiario.ObtenerAsientos().AsEnumerable();

            if (desde.HasValue)
                asientos = asientos.Where(a => a.Fecha.Date >= desde.Value.Date);
            if (hasta.HasValue)
                asientos = asientos.Where(a => a.Fecha.Date <= hasta.Value.Date);

            var asientosFiltrados = asientos.OrderBy(a => a.NumeroAsiento).ToList();

            // Agrupar movimientos por cuenta principal + subcuenta
            var agrupaciones = new Dictionary<string, CuentaMayor>(StringComparer.OrdinalIgnoreCase);

            foreach (var asiento in asientosFiltrados)
            {
                foreach (var mov in asiento.Movimientos)
                {
                    // Clave de agrupación: si tiene subcuenta, agrupamos por subcuenta
                    string clave = string.IsNullOrWhiteSpace(mov.Subcuenta)
                        ? mov.CuentaPrincipal
                        : $"{mov.CuentaPrincipal}|{mov.Subcuenta}";

                    if (!agrupaciones.TryGetValue(clave, out var cuentaMayor))
                    {
                        cuentaMayor = new CuentaMayor
                        {
                            NombreCuenta = mov.CuentaPrincipal,
                            NombreSubcuenta = string.IsNullOrWhiteSpace(mov.Subcuenta) ? null : mov.Subcuenta,
                            ClaveAgrupacion = clave
                        };
                        agrupaciones[clave] = cuentaMayor;
                    }

                    cuentaMayor.TotalDebe += mov.Debe;
                    cuentaMayor.TotalHaber += mov.Haber;

                    // Calcular saldo acumulado hasta este movimiento
                    decimal saldoAcum = cuentaMayor.TotalDebe - cuentaMayor.TotalHaber;

                    var fila = new FilaMayorizacionVisual
                    {
                        Fecha = asiento.Fecha.ToString("dd/MM/yyyy"),
                        NumeroAsiento = asiento.NumeroAsiento,
                        Concepto = asiento.Concepto,
                        Debe = mov.Movimiento == TipoMovimiento.Debe ? mov.Monto : (decimal?)null,
                        Haber = mov.Movimiento == TipoMovimiento.Haber ? mov.Monto : (decimal?)null,
                        Saldo = Math.Abs(saldoAcum),
                        NaturalezaSaldo = saldoAcum >= 0 ? "D" : "A"
                    };

                    cuentaMayor.Movimientos.Add(fila);
                }
            }

            // Ordenar cuentas según el catálogo oficial
            var cuentasOrdenadas = agrupaciones.Values
                .OrderBy(c => ObtenerOrdenCuenta(c.NombreCuenta))
                .ThenBy(c => c.NombreSubcuenta ?? string.Empty)
                .ToList();

            return cuentasOrdenadas;
        }

        private int ObtenerOrdenCuenta(string nombre)
        {
            var orden = new[]
            {
                "Efectivo y Equivalentes", "Cuentas por Cobrar", "Inventarios",
                "Propiedad, Planta y Equipo", "Cuentas por Pagar", "Préstamos Bancarios",
                "Capital Social", "Compras", "Devolución de Compra",
                "Venta", "Devolución de Venta", "Crédito Fiscal IVA", "Débito Fiscal IVA",
                "Gastos Financieros"
            };

            int idx = Array.FindIndex(orden, o => o.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            return idx < 0 ? 999 : idx;
        }
    }
}
