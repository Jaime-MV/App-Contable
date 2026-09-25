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
        /// Genera la lista de cuentas del Mayor con sus movimientos a partir de una instancia de Libro Diario,
        /// agrupando mediante LINQ por cuenta/subcuenta y calculando los saldos progresivos.
        /// </summary>
        public List<CuentaMayor> GenerarMayorDesdeLibro(LibroDiarioInstancia? libro, DateTime? desde = null, DateTime? hasta = null)
        {
            if (libro == null || libro.Asientos == null || !libro.Asientos.Any())
                return new List<CuentaMayor>();

            return GenerarMayorDesdeAsientos(libro.Asientos, desde, hasta);
        }

        /// <summary>
        /// Procesa la colección de asientos contables mediante LINQ en memoria para estructurar las cuentas del Mayor.
        /// </summary>
        public List<CuentaMayor> GenerarMayorDesdeAsientos(IEnumerable<AsientoContable> asientosFuente, DateTime? desde = null, DateTime? hasta = null)
        {
            var asientos = asientosFuente.AsEnumerable();

            if (desde.HasValue)
                asientos = asientos.Where(a => a.Fecha.Date >= desde.Value.Date);
            if (hasta.HasValue)
                asientos = asientos.Where(a => a.Fecha.Date <= hasta.Value.Date);

            // a) Extraer la totalidad de movimientos de todos los asientos del libro
            var movimientosPlanos = asientos
                .OrderBy(a => a.Fecha)
                .ThenBy(a => a.NumeroAsiento)
                .SelectMany(a => a.Movimientos.Select(m => new
                {
                    Asiento = a,
                    Movimiento = m,
                    CuentaPrincipal = m.CuentaPrincipal.Trim(),
                    Subcuenta = string.IsNullOrWhiteSpace(m.Subcuenta) ? null : m.Subcuenta.Trim(),
                    ClaveAgrupacion = string.IsNullOrWhiteSpace(m.Subcuenta)
                        ? m.CuentaPrincipal.Trim()
                        : $"{m.CuentaPrincipal.Trim()} › {m.Subcuenta.Trim()}"
                }))
                .ToList();

            // b) Agrupar mediante LINQ los movimientos por el nombre o clave completa de la cuenta
            var grupos = movimientosPlanos
                .GroupBy(x => x.ClaveAgrupacion, StringComparer.OrdinalIgnoreCase);

            var listaCuentas = new List<CuentaMayor>();

            foreach (var grupo in grupos)
            {
                var primerElemento = grupo.First();
                var cuentaMayor = new CuentaMayor
                {
                    NombreCuenta = primerElemento.CuentaPrincipal,
                    NombreSubcuenta = primerElemento.Subcuenta,
                    ClaveAgrupacion = grupo.Key
                };

                decimal debeAcumulado = 0m;
                decimal haberAcumulado = 0m;

                // c) Ordenar los renglones cronológicamente por fecha y partida (Partida N° 1, 2, 3...)
                var movsOrdenados = grupo
                    .OrderBy(x => x.Asiento.Fecha)
                    .ThenBy(x => x.Asiento.NumeroAsiento)
                    .ToList();

                foreach (var item in movsOrdenados)
                {
                    decimal debeMov = item.Movimiento.Debe;
                    decimal haberMov = item.Movimiento.Haber;

                    debeAcumulado += debeMov;
                    haberAcumulado += haberMov;

                    // Calcular saldo progresivo en cada fila
                    decimal saldoProgresivo = debeAcumulado - haberAcumulado;
                    string naturalezaFila = saldoProgresivo >= 0 ? "D" : "A";

                    cuentaMayor.Movimientos.Add(new FilaMayorizacionVisual
                    {
                        Fecha = item.Asiento.Fecha.ToString("dd/MM/yyyy"),
                        NumeroAsiento = item.Asiento.NumeroAsiento,
                        Concepto = item.Asiento.Concepto,
                        Debe = debeMov > 0 ? debeMov : (decimal?)null,
                        Haber = haberMov > 0 ? haberMov : (decimal?)null,
                        Saldo = Math.Abs(saldoProgresivo),
                        NaturalezaSaldo = naturalezaFila
                    });
                }

                // d) Asignar sumas finales del Debe y Haber
                cuentaMayor.TotalDebe = debeAcumulado;
                cuentaMayor.TotalHaber = haberAcumulado;

                listaCuentas.Add(cuentaMayor);
            }

            // Ordenar cuentas según el catálogo oficial
            return listaCuentas
                .OrderBy(c => ObtenerOrdenCuenta(c.NombreCuenta))
                .ThenBy(c => c.NombreSubcuenta ?? string.Empty)
                .ToList();
        }

        /// <summary>
        /// Sobrecarga para compatibilidad: obtiene los asientos del servicio singleton activo.
        /// </summary>
        public List<CuentaMayor> GenerarMayor(DateTime? desde = null, DateTime? hasta = null)
        {
            var libroTemporal = new LibroDiarioInstancia
            {
                Nombre = "Libro Diario General",
                Asientos = _libroDiario.ObtenerAsientos().ToList()
            };
            return GenerarMayorDesdeLibro(libroTemporal, desde, hasta);
        }

        /// <summary>
        /// Genera las filas formateadas para la grilla continua del Libro Mayor (estilo Libro Diario)
        /// a partir de una instancia de Libro Diario.
        /// </summary>
        public List<FilaMayorTablaVisual> GenerarFilasVisualesTablaDesdeLibro(
            LibroDiarioInstancia? libro,
            DateTime? desde = null,
            DateTime? hasta = null,
            string? filtroCuenta = null)
        {
            var cuentas = GenerarMayorDesdeLibro(libro, desde, hasta);

            if (!string.IsNullOrWhiteSpace(filtroCuenta) && !filtroCuenta.Equals("Todas las Cuentas", StringComparison.OrdinalIgnoreCase))
            {
                cuentas = cuentas.Where(c => c.NombreCuenta.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase) ||
                                             (!string.IsNullOrEmpty(c.NombreSubcuenta) && c.NombreSubcuenta.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase)) ||
                                             c.ClaveAgrupacion.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase) ||
                                             $"{c.NombreCuenta} › {c.NombreSubcuenta}".Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase))
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

                // 3. Fila de Total de la Cuenta (TOTAL [CUENTA])
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

            // 5. Fila Final de Sumas Iguales Globales
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

        /// <summary>
        /// Sobrecarga para compatibilidad: genera las filas visuales desde el libro general activo.
        /// </summary>
        public List<FilaMayorTablaVisual> GenerarFilasVisualesTabla(DateTime? desde = null, DateTime? hasta = null, string? filtroCuenta = null)
        {
            var libroTemporal = new LibroDiarioInstancia
            {
                Nombre = "Libro Diario General",
                Asientos = _libroDiario.ObtenerAsientos().ToList()
            };
            return GenerarFilasVisualesTablaDesdeLibro(libroTemporal, desde, hasta, filtroCuenta);
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
