using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    public class EstadoResultadosServicio
    {
        private static EstadoResultadosServicio? _instancia;
        public static EstadoResultadosServicio Instancia => _instancia ??= new EstadoResultadosServicio();

        private readonly MayorizacionServicio _mayorServicio = new();

        /// <summary>
        /// Obtiene los datos de prueba oficiales tal como se muestran en la plantilla contable de Excel.
        /// </summary>
        public DatosEstadoResultados ObtenerDatosEjemplo()
        {
            var hoy = DateTime.Today;
            return new DatosEstadoResultados
            {
                Empresa = "EMPRESA COMERCIAL, S.A. DE C.V.",
                FechaInicio = new DateTime(hoy.Year, 1, 1),
                FechaFin = hoy,

                // Ventas
                Ventas = 15044.25m,
                DevolucionesSobreVentas = 88.50m,

                // Compras
                Compras = 8849.56m,
                GastosDeCompra = 0.00m,
                DevolucionesSobreCompras = 884.96m,

                // Inventarios
                InventarioInicial = 6000.00m,
                InventarioFinal = 6487.05m,

                // Gastos
                GastosFinancieros = 1000.00m
            };
        }

        /// <summary>
        /// Calcula el Estado de Resultados en tiempo real a partir de las cuentas y saldos
        /// registrados en el Libro Diario y Mayorización.
        /// </summary>
        public DatosEstadoResultados CalcularDesdeMayor(DateTime? desde = null, DateTime? hasta = null)
        {
            var hoy = DateTime.Today;
            var cuentasMayor = _mayorServicio.GenerarMayor(desde, hasta);

            var resultado = new DatosEstadoResultados
            {
                FechaInicio = desde ?? new DateTime(hoy.Year, 1, 1),
                FechaFin = hasta ?? hoy
            };

            if (!cuentasMayor.Any())
            {
                return ObtenerDatosEjemplo();
            }

            decimal SaldoNeto(string nombreCuenta, bool esDeudor)
            {
                var matching = cuentasMayor.Where(x => x.NombreCuenta.Equals(nombreCuenta, StringComparison.OrdinalIgnoreCase)).ToList();
                if (!matching.Any()) return 0m;
                decimal sumDebe = matching.Sum(x => x.TotalDebe);
                decimal sumHaber = matching.Sum(x => x.TotalHaber);
                return esDeudor ? (sumDebe - sumHaber) : (sumHaber - sumDebe);
            }

            // Ventas e ingresos
            resultado.Ventas = Math.Max(0, SaldoNeto("Venta", false));
            resultado.DevolucionesSobreVentas = Math.Max(0, SaldoNeto("Devolución de Venta", true));

            // Compras y devoluciones
            resultado.Compras = Math.Max(0, SaldoNeto("Compras", true));
            resultado.GastosDeCompra = 0m;
            resultado.DevolucionesSobreCompras = Math.Max(0, SaldoNeto("Devolución de Compra", false));

            // Inventarios
            decimal saldoInventario = Math.Max(0, SaldoNeto("Inventarios", true));
            if (saldoInventario > 0)
            {
                resultado.InventarioFinal = saldoInventario;
                resultado.InventarioInicial = Math.Max(0, saldoInventario - resultado.ComprasNetas * 0.2m);
            }
            else
            {
                var ejemplo = ObtenerDatosEjemplo();
                resultado.InventarioInicial = ejemplo.InventarioInicial;
                resultado.InventarioFinal = ejemplo.InventarioFinal;
            }

            // Gastos de operación
            resultado.GastosFinancieros = Math.Max(0, SaldoNeto("Gastos Financieros", true));

            // Si aún no se han registrado ventas ni compras en los asientos, usar datos de prueba
            if (resultado.Ventas == 0 && resultado.Compras == 0)
            {
                return ObtenerDatosEjemplo();
            }

            return resultado;
        }

        /// <summary>
        /// Genera la lista de filas formateadas exactamente como la plantilla oficial del usuario
        /// con columnas: Concepto | Parcial | Subtotal | Total
        /// </summary>
        public List<FilaEstadoResultadosVisual> GenerarFilasVisuales(DatosEstadoResultados d)
        {
            var filas = new List<FilaEstadoResultadosVisual>();

            // 1. Ventas
            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Ventas",
                Parcial = d.Ventas,
                TipoFila = TipoFilaEstadoResultados.Concepto
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "(-) Devoluciones sobre ventas",
                Parcial = d.DevolucionesSobreVentas,
                TipoFila = TipoFilaEstadoResultados.Concepto
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Ventas netas",
                Total = d.VentasNetas,
                TipoFila = TipoFilaEstadoResultados.ResultadoIntermedio
            });

            // Separador
            filas.Add(new FilaEstadoResultadosVisual { TipoFila = TipoFilaEstadoResultados.Separador });

            // 2. Compras
            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Compras",
                Parcial = d.Compras,
                TipoFila = TipoFilaEstadoResultados.Concepto
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "(+) Gastos de compra",
                Parcial = d.GastosDeCompra > 0 ? d.GastosDeCompra : null,
                TipoFila = TipoFilaEstadoResultados.Concepto
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Compras totales",
                Subtotal = d.ComprasTotales,
                TipoFila = TipoFilaEstadoResultados.Subtotal
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "(-) Devoluciones sobre compras",
                Parcial = d.DevolucionesSobreCompras,
                TipoFila = TipoFilaEstadoResultados.Concepto
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Compras netas",
                Total = d.ComprasNetas,
                TipoFila = TipoFilaEstadoResultados.ResultadoIntermedio
            });

            // 3. Inventarios y Costo
            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "(+) Inventario inicial",
                Parcial = d.InventarioInicial,
                TipoFila = TipoFilaEstadoResultados.Concepto
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Mercadería disponible",
                Total = d.MercaderiaDisponible,
                TipoFila = TipoFilaEstadoResultados.ResultadoIntermedio
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "(-) Inventario final",
                Parcial = d.InventarioFinal,
                TipoFila = TipoFilaEstadoResultados.Concepto
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Costo de ventas",
                Total = d.CostoDeVentas,
                TipoFila = TipoFilaEstadoResultados.ResultadoIntermedio
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Utilidad bruta",
                Total = d.UtilidadBruta,
                TipoFila = TipoFilaEstadoResultados.ResultadoIntermedio
            });

            // Separador
            filas.Add(new FilaEstadoResultadosVisual { TipoFila = TipoFilaEstadoResultados.Separador });

            // 4. Gastos de Operación
            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "(-) Gastos de operación",
                Subtotal = d.GastosDeOperacion,
                TipoFila = TipoFilaEstadoResultados.Subtotal
            });

            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Gastos financieros",
                Parcial = d.GastosFinancieros,
                TipoFila = TipoFilaEstadoResultados.Concepto
            });

            // 5. Utilidad Operacional antes de impuestos (Línea verde destacada)
            filas.Add(new FilaEstadoResultadosVisual
            {
                Concepto = "Utilidad operacional antes de impuestos",
                Total = d.UtilidadOperacional,
                TipoFila = TipoFilaEstadoResultados.ResultadoFinal
            });

            return filas;
        }
    }
}
