using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    /// <summary>
    /// Servicio que genera la Balanza de Comprobación a partir de los saldos
    /// del Libro Mayor. Cada cuenta aparece una vez con su total Debe y Haber.
    /// </summary>
    public class BalanzaComprobacionServicio
    {
        private static BalanzaComprobacionServicio? _instancia;
        public static BalanzaComprobacionServicio Instancia => _instancia ??= new BalanzaComprobacionServicio();

        private readonly MayorizacionServicio _mayorServicio = new();

        /// <summary>
        /// Genera la lista de filas para la Balanza de Comprobación.
        /// Una fila por cada cuenta del Mayor con su TotalDebe y TotalHaber.
        /// </summary>
        public (List<FilaBalanzaComprobacion> Filas, ResumenBalanzaComprobacion Resumen)
            GenerarBalanza(DateTime? desde = null, DateTime? hasta = null)
        {
            var hoy = DateTime.Today;
            var fechaDesde = desde ?? new DateTime(hoy.Year, 1, 1);
            var fechaHasta = hasta ?? hoy;

            var cuentasMayor = _mayorServicio.GenerarMayor(fechaDesde, fechaHasta);

            var filas = new List<FilaBalanzaComprobacion>();

            foreach (var cuenta in cuentasMayor)
            {
                // Nombre de la cuenta: si tiene subcuenta se muestra "Principal › Subcuenta"
                string nombreMostrado = string.IsNullOrWhiteSpace(cuenta.NombreSubcuenta)
                    ? cuenta.NombreCuenta
                    : $"{cuenta.NombreCuenta} › {cuenta.NombreSubcuenta}";

                filas.Add(new FilaBalanzaComprobacion
                {
                    Cuenta = nombreMostrado,
                    TotalDebe = cuenta.TotalDebe,
                    TotalHaber = cuenta.TotalHaber
                });
            }

            decimal sumaGlobalDebe = filas.Sum(f => f.TotalDebe);
            decimal sumaGlobalHaber = filas.Sum(f => f.TotalHaber);

            var resumen = new ResumenBalanzaComprobacion
            {
                TotalDebe = sumaGlobalDebe,
                TotalHaber = sumaGlobalHaber,
                TotalCuentas = filas.Count,
                FechaInicio = fechaDesde,
                FechaFin = fechaHasta
            };

            return (filas, resumen);
        }

        /// <summary>
        /// Retorna datos de prueba estáticos que coinciden con la plantilla Excel del usuario.
        /// </summary>
        public (List<FilaBalanzaComprobacion> Filas, ResumenBalanzaComprobacion Resumen) ObtenerDatosEjemplo()
        {
            var hoy = DateTime.Today;

            var filas = new List<FilaBalanzaComprobacion>
            {
                new() { Cuenta = "Efectivo y Equivalentes",      TotalDebe = 48490.00m, TotalHaber = 0m       },
                new() { Cuenta = "Inventarios",                  TotalDebe = 6000.00m,  TotalHaber = 0m       },
                new() { Cuenta = "Capital Social",               TotalDebe = 0m,        TotalHaber = 36000.00m},
                new() { Cuenta = "Compras",                      TotalDebe = 8849.56m,  TotalHaber = 0m       },
                new() { Cuenta = "Crédito Fiscal IVA",           TotalDebe = 2992.30m,  TotalHaber = 0m       },
                new() { Cuenta = "Cuentas por Pagar",            TotalDebe = 0m,        TotalHaber = 13500.00m},
                new() { Cuenta = "Devolución de Compra",         TotalDebe = 0m,        TotalHaber = 884.96m  },
                new() { Cuenta = "Ventas",                       TotalDebe = 0m,        TotalHaber = 15044.25m},
                new() { Cuenta = "Débito Fiscal IVA",            TotalDebe = 0m,        TotalHaber = 1944.25m },
                new() { Cuenta = "Cuentas por Cobrar",           TotalDebe = 5900.00m,  TotalHaber = 0m       },
                new() { Cuenta = "Propiedad, Planta y Equipo",   TotalDebe = 14053.10m, TotalHaber = 0m       },
                new() { Cuenta = "Gastos Financieros",           TotalDebe = 1000.00m,  TotalHaber = 0m       },
                new() { Cuenta = "Préstamos Bancarios",          TotalDebe = 0m,        TotalHaber = 20000.00m},
                new() { Cuenta = "Devolución de Venta",          TotalDebe = 88.50m,    TotalHaber = 0m       },
            };

            decimal sumaD = filas.Sum(f => f.TotalDebe);
            decimal sumaH = filas.Sum(f => f.TotalHaber);

            var resumen = new ResumenBalanzaComprobacion
            {
                TotalDebe = sumaD,
                TotalHaber = sumaH,
                TotalCuentas = filas.Count,
                FechaInicio = new DateTime(hoy.Year, 1, 1),
                FechaFin = hoy
            };

            return (filas, resumen);
        }
    }
}
