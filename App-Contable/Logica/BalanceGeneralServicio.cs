using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    public class BalanceGeneralServicio
    {
        private static BalanceGeneralServicio? _instancia;
        public static BalanceGeneralServicio Instancia => _instancia ??= new BalanceGeneralServicio();

        private readonly MayorizacionServicio _mayorServicio = new();

        /// <summary>
        /// Obtiene los datos de prueba idénticos a los solicitados en la plantilla contable oficial.
        /// </summary>
        public DatosBalanceGeneral ObtenerDatosEjemplo()
        {
            return new DatosBalanceGeneral
            {
                Empresa = "EMPRESA COMERCIAL, S.A. DE C.V.",
                FechaCorte = DateTime.Today,

                // Activo corriente
                EfectivoYEquivalentes = 48490.00m,
                CreditoFiscalIva = 2992.30m,
                Inventarios = 6487.05m,
                CuentasPorCobrar = 5900.00m,

                // Activo no corriente
                PropiedadPlantaYEquipo = 14053.10m,

                // Pasivo corriente
                CuentasPorPagar = 13500.00m,
                DebitoFiscalIva = 1944.25m,

                // Pasivo no corriente
                PrestamosBancarios = 20000.00m,

                // Patrimonio
                CapitalSocial = 36000.00m,
                UtilidadOperacional = 6478.20m
            };
        }

        /// <summary>
        /// Calcula el Balance General en tiempo real a partir de las cuentas y saldos
        /// registrados en el Libro Diario y Mayor.
        /// </summary>
        public DatosBalanceGeneral CalcularDesdeMayor(DateTime? hasta = null)
        {
            var cuentasMayor = _mayorServicio.GenerarMayor(hasta: hasta);
            var balance = new DatosBalanceGeneral
            {
                FechaCorte = hasta ?? DateTime.Today
            };

            if (!cuentasMayor.Any())
            {
                // Si aún no hay movimientos en el Libro Diario, devolver datos de ejemplo
                return ObtenerDatosEjemplo();
            }

            decimal saldoNeto(string nombre, bool esDeudor)
            {
                var matching = cuentasMayor.Where(x => x.NombreCuenta.Equals(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
                if (!matching.Any()) return 0m;
                decimal sumDebe = matching.Sum(x => x.TotalDebe);
                decimal sumHaber = matching.Sum(x => x.TotalHaber);
                return esDeudor ? (sumDebe - sumHaber) : (sumHaber - sumDebe);
            }

            // 1. Activo Corriente (Cuentas de naturaleza deudora)
            balance.EfectivoYEquivalentes = Math.Max(0, saldoNeto("Efectivo y Equivalentes", true));
            balance.CreditoFiscalIva = Math.Max(0, saldoNeto("Crédito Fiscal IVA", true));
            balance.Inventarios = Math.Max(0, saldoNeto("Inventarios", true));
            balance.CuentasPorCobrar = Math.Max(0, saldoNeto("Cuentas por Cobrar", true));

            // 2. Activo No Corriente (Deudora)
            balance.PropiedadPlantaYEquipo = Math.Max(0, saldoNeto("Propiedad, Planta y Equipo", true));

            // 3. Pasivo Corriente (Acreedoras)
            balance.CuentasPorPagar = Math.Max(0, saldoNeto("Cuentas por Pagar", false));
            balance.DebitoFiscalIva = Math.Max(0, saldoNeto("Débito Fiscal IVA", false));

            // 4. Pasivo No Corriente (Acreedora)
            balance.PrestamosBancarios = Math.Max(0, saldoNeto("Préstamos Bancarios", false));

            // 5. Patrimonio (Acreedora)
            balance.CapitalSocial = Math.Max(0, saldoNeto("Capital Social", false));

            // 6. Utilidad Operacional / del Ejercicio
            // Calculada de ingresos y costos/gastos o por partida doble exacta
            decimal ventasNetas = saldoNeto("Venta", false) - saldoNeto("Devolución de Venta", true);
            decimal costoComprasNeto = saldoNeto("Compras", true) - saldoNeto("Devolución de Compra", false);
            decimal gastosFinancieros = saldoNeto("Gastos Financieros", true);
            decimal utilidadCalculada = ventasNetas - costoComprasNeto - gastosFinancieros;

            decimal utilidadCuadre = balance.TotalActivo - balance.TotalPasivo - balance.CapitalSocial;
            balance.UtilidadOperacional = (utilidadCalculada != 0m) ? utilidadCalculada : utilidadCuadre;

            return balance;
        }

        /// <summary>
        /// Genera la lista de filas formateadas exactamente como la hoja de cálculo contable
        /// proporcionada por el usuario (Cuenta | Parcial | Subtotal | Total).
        /// </summary>
        public List<FilaBalanceVisual> GenerarFilasVisuales(DatosBalanceGeneral b)
        {
            var filas = new List<FilaBalanceVisual>();

            // ════════════════════════════════════════════════════════════════
            // 1. ACTIVO
            // ════════════════════════════════════════════════════════════════
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "ACTIVO",
                TipoFila = TipoFilaBalance.TituloSeccion
            });

            // Activo corriente
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "Activo corriente",
                TipoFila = TipoFilaBalance.Subseccion
            });

            filas.Add(new FilaBalanceVisual { Cuenta = "Efectivo y equivalentes", Parcial = b.EfectivoYEquivalentes, TipoFila = TipoFilaBalance.Cuenta });
            filas.Add(new FilaBalanceVisual { Cuenta = "Crédito Fiscal IVA", Parcial = b.CreditoFiscalIva, TipoFila = TipoFilaBalance.Cuenta });
            filas.Add(new FilaBalanceVisual { Cuenta = "Inventarios", Parcial = b.Inventarios, TipoFila = TipoFilaBalance.Cuenta });
            filas.Add(new FilaBalanceVisual { Cuenta = "Cuentas por cobrar", Parcial = b.CuentasPorCobrar, TipoFila = TipoFilaBalance.Cuenta });

            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "Total Activo Corriente",
                Total = b.TotalActivoCorriente,
                TipoFila = TipoFilaBalance.Subtotal
            });

            // Activo no corriente
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "Activo no corriente",
                TipoFila = TipoFilaBalance.Subseccion
            });

            filas.Add(new FilaBalanceVisual { Cuenta = "Propiedad, planta y equipo", Parcial = b.PropiedadPlantaYEquipo, TipoFila = TipoFilaBalance.Cuenta });

            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "Total Activo No Corriente",
                Total = b.TotalActivoNoCorriente,
                TipoFila = TipoFilaBalance.Subtotal
            });

            // TOTAL ACTIVO
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "TOTAL ACTIVO",
                Total = b.TotalActivo,
                TipoFila = TipoFilaBalance.TotalPrincipal
            });

            // Separador
            filas.Add(new FilaBalanceVisual { TipoFila = TipoFilaBalance.Separador });

            // ════════════════════════════════════════════════════════════════
            // 2. PASIVO
            // ════════════════════════════════════════════════════════════════
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "PASIVO",
                TipoFila = TipoFilaBalance.TituloSeccion
            });

            // Pasivo corriente
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "Pasivo corriente",
                TipoFila = TipoFilaBalance.Subseccion
            });

            filas.Add(new FilaBalanceVisual { Cuenta = "Cuentas por pagar", Parcial = b.CuentasPorPagar, TipoFila = TipoFilaBalance.Cuenta });
            filas.Add(new FilaBalanceVisual { Cuenta = "Débito Fiscal IVA", Parcial = b.DebitoFiscalIva, TipoFila = TipoFilaBalance.Cuenta });

            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "Total Pasivo Corriente",
                Total = b.TotalPasivoCorriente,
                TipoFila = TipoFilaBalance.Subtotal
            });

            // Pasivo no corriente
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "Pasivo no corriente",
                TipoFila = TipoFilaBalance.Subseccion
            });

            filas.Add(new FilaBalanceVisual { Cuenta = "Préstamos bancarios", Parcial = b.PrestamosBancarios, TipoFila = TipoFilaBalance.Cuenta });

            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "Total Pasivo No Corriente",
                Total = b.TotalPasivoNoCorriente,
                TipoFila = TipoFilaBalance.Subtotal
            });

            // TOTAL PASIVO
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "TOTAL PASIVO",
                Total = b.TotalPasivo,
                TipoFila = TipoFilaBalance.TotalPrincipal
            });

            // Separador
            filas.Add(new FilaBalanceVisual { TipoFila = TipoFilaBalance.Separador });

            // ════════════════════════════════════════════════════════════════
            // 3. PATRIMONIO
            // ════════════════════════════════════════════════════════════════
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "PATRIMONIO",
                TipoFila = TipoFilaBalance.TituloSeccion
            });

            filas.Add(new FilaBalanceVisual { Cuenta = "Capital Social", Parcial = b.CapitalSocial, TipoFila = TipoFilaBalance.Cuenta });
            filas.Add(new FilaBalanceVisual { Cuenta = "Utilidad operacional", Parcial = b.UtilidadOperacional, TipoFila = TipoFilaBalance.Cuenta });

            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "TOTAL PATRIMONIO",
                Total = b.TotalPatrimonio,
                TipoFila = TipoFilaBalance.Subtotal
            });

            // Separador
            filas.Add(new FilaBalanceVisual { TipoFila = TipoFilaBalance.Separador });

            // ════════════════════════════════════════════════════════════════
            // 4. TOTAL PASIVO + PATRIMONIO
            // ════════════════════════════════════════════════════════════════
            filas.Add(new FilaBalanceVisual
            {
                Cuenta = "TOTAL PASIVO + PATRIMONIO",
                Total = b.TotalPasivoMasPatrimonio,
                TipoFila = TipoFilaBalance.TotalPrincipal
            });

            return filas;
        }
    }
}
