using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_Contable.Modelos;

namespace App_Contable.Datos
{
    /// <summary>
    /// Repositorio de almacenamiento y gestión de instancias completas de Libros Diarios.
    /// Opera de forma local en memoria durante el desarrollo y provee el método stub asíncrono preparado para PostgreSQL.
    /// </summary>
    public class LibroDiarioStorageService
    {
        private static readonly List<LibroDiarioInstancia> _librosEnMemoria = new();
        private static bool _inicializado = false;

        public LibroDiarioStorageService()
        {
            if (!_inicializado)
            {
                InicializarLibrosSemilla();
                _inicializado = true;
            }
        }

        /// <summary>
        /// Obtiene todas las instancias de Libros Diarios ordenadas por última modificación.
        /// </summary>
        public List<LibroDiarioInstancia> ObtenerLibros()
        {
            return _librosEnMemoria.OrderByDescending(l => l.FechaModificacion).ToList();
        }

        /// <summary>
        /// Obtiene una instancia de Libro Diario por su Id.
        /// </summary>
        public LibroDiarioInstancia? ObtenerLibroPorId(string id)
        {
            return _librosEnMemoria.FirstOrDefault(l => l.Id == id);
        }

        /// <summary>
        /// Guarda o actualiza una instancia de Libro Diario en el almacenamiento local en memoria.
        /// </summary>
        public void GuardarLibro(LibroDiarioInstancia libro)
        {
            libro.FechaModificacion = DateTime.Now;

            var indice = _librosEnMemoria.FindIndex(l => l.Id == libro.Id);
            if (indice >= 0)
            {
                _librosEnMemoria[indice] = libro;
            }
            else
            {
                _librosEnMemoria.Add(libro);
            }
        }

        /// <summary>
        /// Elimina una instancia de Libro Diario de la memoria.
        /// </summary>
        public bool EliminarLibro(string id)
        {
            return _librosEnMemoria.RemoveAll(l => l.Id == id) > 0;
        }

        /// <summary>
        /// Método stub preparado para la persistencia asíncrona en PostgreSQL.
        /// </summary>
        /// <param name="libro">Instancia del Libro Diario a sincronizar.</param>
        /// <returns>True si la persistencia es exitosa.</returns>
        public async Task<bool> GuardarEnBaseDatosAsync(LibroDiarioInstancia libro)
        {
            // Simulación de llamada asíncrona a PostgreSQL
            await Task.Delay(300);

            // Stub: listo para integrar Npgsql / DbContext al habilitar PostgreSQL en la etapa final
            return true;
        }

        /// <summary>
        /// Inicializa libros de ejemplo precalculados para la sesión.
        /// </summary>
        private static void InicializarLibrosSemilla()
        {
            // Instancia 1: Libro Diario — Ejercicio 2026
            var libro1 = new LibroDiarioInstancia
            {
                Id = "libro_ejercicio_2026",
                Nombre = "Libro Diario — Ejercicio 2026",
                Empresa = "Corporación Industrial S.A. de C.V.",
                FechaInicio = new DateTime(2026, 1, 1),
                FechaFin = new DateTime(2026, 12, 31),
                DestinoGuardado = TipoDestinoLibro.Local,
                FechaCreacion = DateTime.Now.AddDays(-30),
                FechaModificacion = DateTime.Now.AddHours(-2),
                Asientos = GenerarAsientosDemoInstancia1()
            };

            // Instancia 2: Libro Diario — Septiembre 2026
            var libro2 = new LibroDiarioInstancia
            {
                Id = "libro_septiembre_2026",
                Nombre = "Libro Diario — Septiembre 2026",
                Empresa = "Comercializadora del Valle S.A.",
                FechaInicio = new DateTime(2026, 9, 1),
                FechaFin = new DateTime(2026, 9, 30),
                DestinoGuardado = TipoDestinoLibro.PostgreSQL,
                FechaCreacion = DateTime.Now.AddDays(-10),
                FechaModificacion = DateTime.Now.AddHours(-6),
                Asientos = GenerarAsientosDemoInstancia2()
            };

            _librosEnMemoria.Add(libro1);
            _librosEnMemoria.Add(libro2);
        }

        private static List<AsientoContable> GenerarAsientosDemoInstancia1()
        {
            return new List<AsientoContable>
            {
                new AsientoContable
                {
                    NumeroAsiento = 1,
                    Fecha = new DateTime(2026, 1, 2),
                    Concepto = "Por apertura contable y aporte inicial de capital social en efectivo y mobiliario.",
                    Movimientos = new List<MovimientoContable>
                    {
                        new MovimientoContable { CuentaPrincipal = "Efectivo y Equivalentes", Subcuenta = "Caja", Movimiento = TipoMovimiento.Debe, Monto = 5000.00m },
                        new MovimientoContable { CuentaPrincipal = "Efectivo y Equivalentes", Subcuenta = "Bancos", Movimiento = TipoMovimiento.Debe, Monto = 15000.00m },
                        new MovimientoContable { CuentaPrincipal = "Propiedad, Planta y Equipo", Subcuenta = "Mobiliario y Equipo de Oficina", Movimiento = TipoMovimiento.Debe, Monto = 3500.00m },
                        new MovimientoContable { CuentaPrincipal = "Capital Social", Subcuenta = null, Movimiento = TipoMovimiento.Haber, Monto = 23500.00m }
                    }
                },
                new AsientoContable
                {
                    NumeroAsiento = 2,
                    Fecha = new DateTime(2026, 1, 15),
                    Concepto = "Compra de mercaderías al crédito con comprobante de crédito fiscal.",
                    Movimientos = new List<MovimientoContable>
                    {
                        new MovimientoContable { CuentaPrincipal = "Compras", Subcuenta = null, Movimiento = TipoMovimiento.Debe, Monto = 4000.00m },
                        new MovimientoContable { CuentaPrincipal = "Crédito Fiscal IVA", Subcuenta = null, Movimiento = TipoMovimiento.Debe, Monto = 520.00m },
                        new MovimientoContable { CuentaPrincipal = "Cuentas por Pagar", Subcuenta = "Proveedores", Movimiento = TipoMovimiento.Haber, Monto = 4520.00m }
                    }
                },
                new AsientoContable
                {
                    NumeroAsiento = 3,
                    Fecha = new DateTime(2026, 1, 28),
                    Concepto = "Venta de mercaderías cobrando 50% con transferencia bancaria y 50% al crédito.",
                    Movimientos = new List<MovimientoContable>
                    {
                        new MovimientoContable { CuentaPrincipal = "Efectivo y Equivalentes", Subcuenta = "Bancos", Movimiento = TipoMovimiento.Debe, Monto = 3390.00m },
                        new MovimientoContable { CuentaPrincipal = "Cuentas por Cobrar", Subcuenta = "Clientes", Movimiento = TipoMovimiento.Debe, Monto = 3390.00m },
                        new MovimientoContable { CuentaPrincipal = "Venta", Subcuenta = null, Movimiento = TipoMovimiento.Haber, Monto = 6000.00m },
                        new MovimientoContable { CuentaPrincipal = "Débito Fiscal IVA", Subcuenta = null, Movimiento = TipoMovimiento.Haber, Monto = 780.00m }
                    }
                }
            };
        }

        private static List<AsientoContable> GenerarAsientosDemoInstancia2()
        {
            return new List<AsientoContable>
            {
                new AsientoContable
                {
                    NumeroAsiento = 1,
                    Fecha = new DateTime(2026, 9, 1),
                    Concepto = "Por saldo inicial de operaciones del mes de septiembre 2026.",
                    Movimientos = new List<MovimientoContable>
                    {
                        new MovimientoContable { CuentaPrincipal = "Efectivo y Equivalentes", Subcuenta = "Bancos", Movimiento = TipoMovimiento.Debe, Monto = 12500.00m },
                        new MovimientoContable { CuentaPrincipal = "Inventarios", Subcuenta = "Materia Prima", Movimiento = TipoMovimiento.Debe, Monto = 8000.00m },
                        new MovimientoContable { CuentaPrincipal = "Capital Social", Subcuenta = null, Movimiento = TipoMovimiento.Haber, Monto = 20500.00m }
                    }
                },
                new AsientoContable
                {
                    NumeroAsiento = 2,
                    Fecha = new DateTime(2026, 9, 10),
                    Concepto = "Pago de servicios públicos del mes con cheque bancario.",
                    Movimientos = new List<MovimientoContable>
                    {
                        new MovimientoContable { CuentaPrincipal = "Gastos de Administración", Subcuenta = "Servicios Básicos", Movimiento = TipoMovimiento.Debe, Monto = 450.00m },
                        new MovimientoContable { CuentaPrincipal = "Crédito Fiscal IVA", Subcuenta = null, Movimiento = TipoMovimiento.Debe, Monto = 58.50m },
                        new MovimientoContable { CuentaPrincipal = "Efectivo y Equivalentes", Subcuenta = "Bancos", Movimiento = TipoMovimiento.Haber, Monto = 508.50m }
                    }
                }
            };
        }
    }
}

