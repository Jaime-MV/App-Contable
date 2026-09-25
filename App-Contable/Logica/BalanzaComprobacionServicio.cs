using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    /// <summary>
    /// Servicio que procesa en memoria los asientos contables de un Libro Diario y genera
    /// la Balanza de Comprobación con sus movimientos y saldos finales calculados por cuenta.
    /// </summary>
    public class BalanzaComprobacionServicio
    {
        private static BalanzaComprobacionServicio? _instancia;
        public static BalanzaComprobacionServicio Instancia => _instancia ??= new BalanzaComprobacionServicio();

        private readonly LibroDiarioServicio _libroDiario = LibroDiarioServicio.Instancia;

        /// <summary>
        /// Procesa una instancia específica de Libro Diario mediante LINQ para estructurar la Balanza de Comprobación:
        /// a) Extrae todos los renglones de movimientos de las partidas.
        /// b) Agrupa por código y nombre de cuenta/subcuenta contable.
        /// c) Suma el total acumulado en el Debe (Movimientos Deudores) y en el Haber (Movimientos Acreedores).
        /// d) Calcula Saldos Finales:
        ///    - Si Debe > Haber: Saldo Deudor = (Debe - Haber) y Saldo Acreedor = 0.00
        ///    - Si Haber > Debe: Saldo Acreedor = (Haber - Debe) y Saldo Deudor = 0.00
        ///    - Si son iguales: ambos saldos = 0.00
        /// </summary>
        public (List<FilaBalanzaComprobacion> Filas, ResumenBalanzaComprobacion Resumen)
            GenerarBalanzaDesdeLibro(LibroDiarioInstancia? libro, DateTime? desde = null, DateTime? hasta = null)
        {
            if (libro == null || libro.Asientos == null || !libro.Asientos.Any())
            {
                var hoy = DateTime.Today;
                return (new List<FilaBalanzaComprobacion>(), new ResumenBalanzaComprobacion
                {
                    FechaInicio = desde ?? (libro?.FechaInicio ?? new DateTime(hoy.Year, 1, 1)),
                    FechaFin = hasta ?? (libro?.FechaFin ?? hoy),
                    NombreLibro = libro?.Nombre ?? "Sin libro seleccionado"
                });
            }

            var asientos = libro.Asientos.AsEnumerable();

            if (desde.HasValue)
                asientos = asientos.Where(a => a.Fecha.Date >= desde.Value.Date);
            if (hasta.HasValue)
                asientos = asientos.Where(a => a.Fecha.Date <= hasta.Value.Date);

            // a) Extraer la totalidad de movimientos de todas las partidas
            var movimientosPlanos = asientos
                .OrderBy(a => a.Fecha)
                .ThenBy(a => a.NumeroAsiento)
                .SelectMany(a => a.Movimientos.Select(m =>
                {
                    string cuentaPrincipal = m.CuentaPrincipal.Trim();
                    string? subcuenta = string.IsNullOrWhiteSpace(m.Subcuenta) ? null : m.Subcuenta.Trim();

                    string nombreCompleto = string.IsNullOrWhiteSpace(subcuenta)
                        ? cuentaPrincipal
                        : $"{cuentaPrincipal} › {subcuenta}";

                    string codigo = ObtenerCodigoCuenta(cuentaPrincipal);

                    return new
                    {
                        Asiento = a,
                        Movimiento = m,
                        Codigo = codigo,
                        CuentaPrincipal = cuentaPrincipal,
                        Subcuenta = subcuenta,
                        NombreCompleto = nombreCompleto,
                        Debe = m.Debe,
                        Haber = m.Haber
                    };
                }))
                .ToList();

            // b) Agrupar mediante LINQ por código y nombre de cuenta
            var grupos = movimientosPlanos
                .GroupBy(x => new { x.Codigo, x.NombreCompleto, x.CuentaPrincipal })
                .OrderBy(g => ObtenerOrdenCatalogo(g.Key.CuentaPrincipal))
                .ThenBy(g => g.Key.NombreCompleto);

            var filas = new List<FilaBalanzaComprobacion>();

            decimal totalGlobalMovDebe = 0m;
            decimal totalGlobalMovHaber = 0m;
            decimal totalGlobalSaldoDeudor = 0m;
            decimal totalGlobalSaldoAcreedor = 0m;

            foreach (var grupo in grupos)
            {
                // c) Sumar total acumulado en el Debe y Haber
                decimal sumaDebe = grupo.Sum(x => x.Debe);
                decimal sumaHaber = grupo.Sum(x => x.Haber);

                // d) Calcular saldos finales
                decimal saldoDeudor = 0m;
                decimal saldoAcreedor = 0m;

                if (sumaDebe > sumaHaber)
                {
                    saldoDeudor = sumaDebe - sumaHaber;
                    saldoAcreedor = 0.00m;
                }
                else if (sumaHaber > sumaDebe)
                {
                    saldoAcreedor = sumaHaber - sumaDebe;
                    saldoDeudor = 0.00m;
                }

                filas.Add(new FilaBalanzaComprobacion
                {
                    Codigo = grupo.Key.Codigo,
                    Cuenta = grupo.Key.NombreCompleto,
                    MovimientoDebe = sumaDebe,
                    MovimientoHaber = sumaHaber,
                    SaldoDeudor = saldoDeudor,
                    SaldoAcreedor = saldoAcreedor
                });

                totalGlobalMovDebe += sumaDebe;
                totalGlobalMovHaber += sumaHaber;
                totalGlobalSaldoDeudor += saldoDeudor;
                totalGlobalSaldoAcreedor += saldoAcreedor;
            }

            var resumen = new ResumenBalanzaComprobacion
            {
                TotalMovimientoDebe = totalGlobalMovDebe,
                TotalMovimientoHaber = totalGlobalMovHaber,
                TotalSaldoDeudor = totalGlobalSaldoDeudor,
                TotalSaldoAcreedor = totalGlobalSaldoAcreedor,
                TotalCuentas = filas.Count,
                FechaInicio = desde ?? libro.FechaInicio,
                FechaFin = hasta ?? libro.FechaFin,
                NombreLibro = libro.Nombre
            };

            return (filas, resumen);
        }

        /// <summary>
        /// Genera la Balanza de Comprobación desde el libro general activo en memoria.
        /// </summary>
        public (List<FilaBalanzaComprobacion> Filas, ResumenBalanzaComprobacion Resumen)
            GenerarBalanza(DateTime? desde = null, DateTime? hasta = null)
        {
            var libroTemporal = new LibroDiarioInstancia
            {
                Nombre = "Libro Diario General",
                Asientos = _libroDiario.ObtenerAsientos().ToList()
            };

            return GenerarBalanzaDesdeLibro(libroTemporal, desde, hasta);
        }

        private static string ObtenerCodigoCuenta(string cuentaPrincipal)
        {
            var def = CatalogoCuentasConfig.ObtenerPorNombre(cuentaPrincipal);
            if (def != null && !string.IsNullOrWhiteSpace(def.Codigo))
            {
                return def.Codigo;
            }

            // Códigos estándar por defecto si no están en catálogo
            return cuentaPrincipal.ToLowerInvariant() switch
            {
                var c when c.Contains("efectivo") || c.Contains("caja") || c.Contains("banco") => "1101",
                var c when c.Contains("cobrar") || c.Contains("cliente") => "1102",
                var c when c.Contains("inventario") || c.Contains("mercader") => "1103",
                var c when c.Contains("crédito fiscal") || c.Contains("credito fiscal") => "1104",
                var c when c.Contains("propiedad") || c.Contains("equipo") || c.Contains("mobiliario") => "1201",
                var c when c.Contains("pagar") || c.Contains("proveedor") => "2101",
                var c when c.Contains("débito fiscal") || c.Contains("debito fiscal") => "2102",
                var c when c.Contains("préstamo") || c.Contains("prestamo") => "2103",
                var c when c.Contains("capital") => "3101",
                var c when c.Contains("financiero") || c.Contains("comisión") => "4101",
                var c when c.Contains("venta") && !c.Contains("devol") => "4102",
                var c when c.Contains("devolución de venta") || c.Contains("devolucion de venta") => "4103",
                var c when c.Contains("compra") && !c.Contains("devol") => "5101",
                var c when c.Contains("devolución de compra") || c.Contains("devolucion de compra") => "5102",
                _ => "1000"
            };
        }

        private static int ObtenerOrdenCatalogo(string nombreCuenta)
        {
            var orden = new[]
            {
                "Efectivo y Equivalentes", "Cuentas por Cobrar", "Inventarios",
                "Crédito Fiscal IVA", "Propiedad, Planta y Equipo", "Cuentas por Pagar",
                "Débito Fiscal IVA", "Préstamos Bancarios", "Capital Social",
                "Gastos Financieros", "Venta", "Devolución de Venta",
                "Compras", "Devolución de Compra"
            };

            int idx = Array.FindIndex(orden, o => o.Equals(nombreCuenta, StringComparison.OrdinalIgnoreCase));
            return idx < 0 ? 999 : idx;
        }
    }
}

