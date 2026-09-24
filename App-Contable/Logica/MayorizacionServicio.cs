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
    /// Tipos de fila para el renderizado contable del Libro Mayor en DataGridView unificado
    /// </summary>
    public enum TipoFilaMayorVisual
    {
        EncabezadoCuenta,
        Movimiento,
        TotalCuenta,
        Separador,
        TotalSumasIguales
    }

    /// <summary>
    /// Representa una fila formateada para la grilla continua del Libro Mayor (estilo Libro Diario)
    /// </summary>
    public class FilaMayorTablaVisual
    {
        public string Fecha { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public decimal? Saldo { get; set; }
        public string Naturaleza { get; set; } = string.Empty;
        public TipoFilaMayorVisual TipoFila { get; set; }
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

        /// <summary>
        /// Genera las filas formateadas para la grilla continua del Libro Mayor (estilo Libro Diario)
        /// con encabezado de cuenta, detalle de movimientos, total por cuenta, separadores y sumas iguales.
        /// </summary>
        public List<FilaMayorTablaVisual> GenerarFilasVisualesTabla(DateTime? desde = null, DateTime? hasta = null, string? filtroCuenta = null)
        {
            var cuentas = GenerarMayor(desde, hasta);

            if (!string.IsNullOrWhiteSpace(filtroCuenta) && !filtroCuenta.Equals("Todas las Cuentas", StringComparison.OrdinalIgnoreCase))
            {
                cuentas = cuentas.Where(c => c.NombreCuenta.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase) ||
                                             (!string.IsNullOrEmpty(c.NombreSubcuenta) && c.NombreSubcuenta.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase)))
                                 .ToList();
            }

            var resultado = new List<FilaMayorTablaVisual>();

            decimal totalDebeGlobal = 0m;
            decimal totalHaberGlobal = 0m;

            foreach (var cuenta in cuentas)
            {
                totalDebeGlobal += cuenta.TotalDebe;
                totalHaberGlobal += cuenta.TotalHaber;

                string tituloCuenta = string.IsNullOrWhiteSpace(cuenta.NombreSubcuenta)
                    ? cuenta.NombreCuenta
                    : $"{cuenta.NombreCuenta} › {cuenta.NombreSubcuenta}";

                // 1. Fila de Encabezado de la Cuenta (Estilo EncabezadoPartida de Libro Diario)
                resultado.Add(new FilaMayorTablaVisual
                {
                    Fecha = string.Empty,
                    Referencia = string.Empty,
                    Descripcion = $"CUENTA: {tituloCuenta.ToUpper()}   |   SALDO {cuenta.NaturalezaSaldo.ToUpper()}: ${cuenta.SaldoFinal:N2}",
                    Debe = null,
                    Haber = null,
                    Saldo = null,
                    Naturaleza = cuenta.NaturalezaSaldo == "Deudor" ? "D" : "A",
                    TipoFila = TipoFilaMayorVisual.EncabezadoCuenta
                });

                // 2. Movimientos de la cuenta
                foreach (var mov in cuenta.Movimientos)
                {
                    resultado.Add(new FilaMayorTablaVisual
                    {
                        Fecha = mov.Fecha,
                        Referencia = $"Partida N° {mov.NumeroAsiento}",
                        Descripcion = mov.Concepto,
                        Debe = mov.Debe,
                        Haber = mov.Haber,
                        Saldo = mov.Saldo,
                        Naturaleza = mov.NaturalezaSaldo,
                        TipoFila = TipoFilaMayorVisual.Movimiento
                    });
                }

                // 3. Fila de Total de la Cuenta
                resultado.Add(new FilaMayorTablaVisual
                {
                    Fecha = string.Empty,
                    Referencia = string.Empty,
                    Descripcion = $"TOTAL {tituloCuenta.ToUpper()}",
                    Debe = cuenta.TotalDebe,
                    Haber = cuenta.TotalHaber,
                    Saldo = cuenta.SaldoFinal,
                    Naturaleza = cuenta.NaturalezaSaldo == "Deudor" ? "D" : "A",
                    TipoFila = TipoFilaMayorVisual.TotalCuenta
                });

                // 4. Fila separadora tenue
                resultado.Add(new FilaMayorTablaVisual
                {
                    TipoFila = TipoFilaMayorVisual.Separador
                });
            }

            // 5. Fila Final de Sumas Iguales Globales (Exactamente como en Libro Diario)
            if (cuentas.Any())
            {
                resultado.Add(new FilaMayorTablaVisual
                {
                    Fecha = string.Empty,
                    Referencia = string.Empty,
                    Descripcion = "SUMAS IGUALES TOTALES DEL MAYOR",
                    Debe = totalDebeGlobal,
                    Haber = totalHaberGlobal,
                    Saldo = null,
                    Naturaleza = Math.Round(totalDebeGlobal, 2) == Math.Round(totalHaberGlobal, 2) ? "✓" : "≠",
                    TipoFila = TipoFilaMayorVisual.TotalSumasIguales
                });
            }

            return resultado;
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
