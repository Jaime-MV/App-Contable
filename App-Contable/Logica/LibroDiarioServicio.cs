using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Logica
{
    public class LibroDiarioServicio
    {
        private static LibroDiarioServicio? _instancia;
        public static LibroDiarioServicio Instancia => _instancia ??= new LibroDiarioServicio();

        public event Action? DatosModificados;

        private void NotificarCambios()
        {
            DatosModificados?.Invoke();
        }

        private readonly List<AsientoContable> _asientos = new();

        public LibroDiarioServicio()
        {
            CargarAsientosEjemplo();
        }

        public IReadOnlyList<AsientoContable> ObtenerAsientos() => _asientos.OrderBy(a => a.NumeroAsiento).ToList();

        public void LimpiarTodos()
        {
            _asientos.Clear();
            NotificarCambios();
        }

        public int ObtenerSiguienteNumero()
        {
            return _asientos.Any() ? _asientos.Max(a => a.NumeroAsiento) + 1 : 1;
        }

        public bool AgregarAsiento(AsientoContable asiento, out string mensajeError)
        {
            if (asiento == null)
            {
                mensajeError = "El asiento no puede ser nulo.";
                return false;
            }

            if (!asiento.Movimientos.Any())
            {
                mensajeError = "El asiento debe contener al menos dos movimientos de cuenta.";
                return false;
            }

            if (!asiento.EstaCuadrado)
            {
                mensajeError = $"El asiento no cumple la partida doble. Total Debe: {asiento.TotalDebe:C2} vs Total Haber: {asiento.TotalHaber:C2}. Diferencia: {asiento.Diferencia:C2}";
                return false;
            }

            if (string.IsNullOrWhiteSpace(asiento.Concepto))
            {
                mensajeError = "Debe ingresar el concepto o glosa explicativa del asiento.";
                return false;
            }

            if (asiento.NumeroAsiento <= 0)
            {
                asiento.NumeroAsiento = ObtenerSiguienteNumero();
            }

            _asientos.Add(asiento);
            mensajeError = string.Empty;
            NotificarCambios();
            return true;
        }

        public bool EliminarAsiento(int numeroAsiento)
        {
            var encontrado = _asientos.FirstOrDefault(a => a.NumeroAsiento == numeroAsiento);
            if (encontrado != null)
            {
                _asientos.Remove(encontrado);
                RenumerarAsientos();
                NotificarCambios();
                return true;
            }
            return false;
        }

        private void RenumerarAsientos()
        {
            int nuevoNumero = 1;
            foreach (var asiento in _asientos)
            {
                asiento.NumeroAsiento = nuevoNumero++;
            }
        }

        public bool ActualizarAsiento(AsientoContable asientoActualizado, out string mensajeError)
        {
            var indice = _asientos.FindIndex(a => a.NumeroAsiento == asientoActualizado.NumeroAsiento);
            if (indice < 0)
            {
                mensajeError = "No se encontró el asiento a actualizar.";
                return false;
            }
            
            if (!asientoActualizado.Movimientos.Any())
            {
                mensajeError = "El asiento debe contener al menos dos movimientos de cuenta.";
                return false;
            }

            if (!asientoActualizado.EstaCuadrado)
            {
                mensajeError = $"El asiento no cumple la partida doble. Total Debe: {asientoActualizado.TotalDebe:C2} vs Total Haber: {asientoActualizado.TotalHaber:C2}. Diferencia: {asientoActualizado.Diferencia:C2}";
                return false;
            }

            if (string.IsNullOrWhiteSpace(asientoActualizado.Concepto))
            {
                mensajeError = "Debe ingresar el concepto o glosa explicativa del asiento.";
                return false;
            }
            
            _asientos[indice] = asientoActualizado;
            mensajeError = string.Empty;
            NotificarCambios();
            return true;
        }

        public void MoverAsientoArriba(int numeroAsiento)
        {
            var indice = _asientos.FindIndex(a => a.NumeroAsiento == numeroAsiento);
            if (indice > 0)
            {
                var actual = _asientos[indice];
                _asientos[indice] = _asientos[indice - 1];
                _asientos[indice - 1] = actual;
                RenumerarAsientos();
                NotificarCambios();
            }
        }

        public void MoverAsientoAbajo(int numeroAsiento)
        {
            var indice = _asientos.FindIndex(a => a.NumeroAsiento == numeroAsiento);
            if (indice >= 0 && indice < _asientos.Count - 1)
            {
                var actual = _asientos[indice];
                _asientos[indice] = _asientos[indice + 1];
                _asientos[indice + 1] = actual;
                RenumerarAsientos();
                NotificarCambios();
            }
        }

        public void LimpiarTodo()
        {
            _asientos.Clear();
            NotificarCambios();
        }

        /// <summary>
        /// Genera las filas formateadas para la tabla con las columnas:
        /// Fecha | Cuenta | Parcial | Debe | Haber
        /// </summary>
        public List<FilaLibroDiarioVisual> GenerarFilasVisuales(DateTime? desde = null, DateTime? hasta = null)
        {
            var resultado = new List<FilaLibroDiarioVisual>();

            var consulta = _asientos.AsEnumerable();
            if (desde.HasValue)
                consulta = consulta.Where(a => a.Fecha.Date >= desde.Value.Date);
            if (hasta.HasValue)
                consulta = consulta.Where(a => a.Fecha.Date <= hasta.Value.Date);

            var asientosFiltrados = consulta.OrderBy(a => a.NumeroAsiento).ToList();

            decimal totalDebeGlobal = 0m;
            decimal totalHaberGlobal = 0m;

            foreach (var asiento in asientosFiltrados)
            {
                totalDebeGlobal += asiento.TotalDebe;
                totalHaberGlobal += asiento.TotalHaber;

                // 1. Fila de Encabezado de la Partida
                resultado.Add(new FilaLibroDiarioVisual
                {
                    NumeroAsiento = asiento.NumeroAsiento,
                    Fecha = asiento.Fecha.ToString("dd/MM/yyyy"),
                    Cuenta = $"ASIENTO N° {asiento.NumeroAsiento}",
                    Parcial = null,
                    Debe = null,
                    Haber = null,
                    TipoFila = TipoFilaVisual.EncabezadoPartida
                });

                // 2. Movimientos al DEBE (Cargos)
                var cargos = asiento.Movimientos.Where(m => m.Movimiento == TipoMovimiento.Debe).ToList();
                var gruposDebe = cargos.GroupBy(m => m.CuentaPrincipal);

                foreach (var grupo in gruposDebe)
                {
                    decimal sumaCuentaPrincipal = grupo.Sum(m => m.Monto);
                    bool tieneSubcuentas = grupo.Any(m => !string.IsNullOrWhiteSpace(m.Subcuenta));

                    // Fila de Cuenta Principal en Debe
                    resultado.Add(new FilaLibroDiarioVisual
                    {
                        NumeroAsiento = asiento.NumeroAsiento,
                        Fecha = string.Empty,
                        Cuenta = grupo.Key,
                        Parcial = null,
                        Debe = sumaCuentaPrincipal,
                        Haber = null,
                        TipoFila = TipoFilaVisual.CuentaPrincipal
                    });

                    // Subcuentas en columna Parcial
                    if (tieneSubcuentas)
                    {
                        foreach (var mov in grupo.Where(m => !string.IsNullOrWhiteSpace(m.Subcuenta)))
                        {
                            resultado.Add(new FilaLibroDiarioVisual
                            {
                                NumeroAsiento = asiento.NumeroAsiento,
                                Fecha = string.Empty,
                                Cuenta = $"    {mov.Subcuenta}",
                                Parcial = mov.Monto,
                                Debe = null,
                                Haber = null,
                                TipoFila = TipoFilaVisual.Subcuenta
                            });
                        }
                    }
                }

                // 3. Movimientos al HABER (Abonos)
                var abonos = asiento.Movimientos.Where(m => m.Movimiento == TipoMovimiento.Haber).ToList();
                var gruposHaber = abonos.GroupBy(m => m.CuentaPrincipal);

                foreach (var grupo in gruposHaber)
                {
                    decimal sumaCuentaPrincipal = grupo.Sum(m => m.Monto);
                    bool tieneSubcuentas = grupo.Any(m => !string.IsNullOrWhiteSpace(m.Subcuenta));

                    // Fila de Cuenta Principal en Haber (sangría contable)
                    resultado.Add(new FilaLibroDiarioVisual
                    {
                        NumeroAsiento = asiento.NumeroAsiento,
                        Fecha = string.Empty,
                        Cuenta = $"    a/ {grupo.Key}",
                        Parcial = null,
                        Debe = null,
                        Haber = sumaCuentaPrincipal,
                        TipoFila = TipoFilaVisual.CuentaPrincipal
                    });

                    // Subcuentas en columna Parcial
                    if (tieneSubcuentas)
                    {
                        foreach (var mov in grupo.Where(m => !string.IsNullOrWhiteSpace(m.Subcuenta)))
                        {
                            resultado.Add(new FilaLibroDiarioVisual
                            {
                                NumeroAsiento = asiento.NumeroAsiento,
                                Fecha = string.Empty,
                                Cuenta = $"        {mov.Subcuenta}",
                                Parcial = mov.Monto,
                                Debe = null,
                                Haber = null,
                                TipoFila = TipoFilaVisual.Subcuenta
                            });
                        }
                    }
                }

                // 4. Glosa / Concepto Explicativo
                resultado.Add(new FilaLibroDiarioVisual
                {
                    NumeroAsiento = asiento.NumeroAsiento,
                    Fecha = string.Empty,
                    Cuenta = $"    V/ {asiento.Concepto}",
                    Parcial = null,
                    Debe = null,
                    Haber = null,
                    TipoFila = TipoFilaVisual.ConceptoGlosa
                });

                // 5. Separador visual entre partidas
                resultado.Add(new FilaLibroDiarioVisual
                {
                    NumeroAsiento = asiento.NumeroAsiento,
                    Fecha = string.Empty,
                    Cuenta = string.Empty,
                    Parcial = null,
                    Debe = null,
                    Haber = null,
                    TipoFila = TipoFilaVisual.Separador
                });
            }

            // 6. Fila final de Sumas Iguales
            if (asientosFiltrados.Any())
            {
                resultado.Add(new FilaLibroDiarioVisual
                {
                    NumeroAsiento = 0,
                    Fecha = string.Empty,
                    Cuenta = "SUMAS IGUALES",
                    Parcial = null,
                    Debe = totalDebeGlobal,
                    Haber = totalHaberGlobal,
                    TipoFila = TipoFilaVisual.TotalSumasIguales
                });
            }

            return resultado;
        }

        /// <summary>
        /// Carga asientos iniciales de ejemplo utilizando únicamente el catálogo estricto solicitado.
        /// </summary>
        public void CargarAsientosEjemplo()
        {
            _asientos.Clear();

            // Partida 1: Apertura con aporte en Efectivo y Mobiliario a Capital Social
            var partida1 = new AsientoContable
            {
                NumeroAsiento = 1,
                Fecha = DateTime.Today.AddDays(-10),
                Concepto = "Por constitución de la sociedad y aporte inicial de socios en efectivo y mobiliario.",
                Movimientos = new List<MovimientoContable>
                {
                    new MovimientoContable { CuentaPrincipal = "Efectivo y Equivalentes", Subcuenta = "Caja", Movimiento = TipoMovimiento.Debe, Monto = 5000.00m },
                    new MovimientoContable { CuentaPrincipal = "Efectivo y Equivalentes", Subcuenta = "Bancos", Movimiento = TipoMovimiento.Debe, Monto = 15000.00m },
                    new MovimientoContable { CuentaPrincipal = "Propiedad, Planta y Equipo", Subcuenta = "Mobiliario y Equipo de Oficina", Movimiento = TipoMovimiento.Debe, Monto = 3500.00m },
                    new MovimientoContable { CuentaPrincipal = "Capital Social", Subcuenta = null, Movimiento = TipoMovimiento.Haber, Monto = 23500.00m }
                }
            };
            _asientos.Add(partida1);

            // Partida 2: Compra de mercadería al crédito con IVA
            var partida2 = new AsientoContable
            {
                NumeroAsiento = 2,
                Fecha = DateTime.Today.AddDays(-7),
                Concepto = "Compra de mercadería al crédito a proveedores según factura comercial.",
                Movimientos = new List<MovimientoContable>
                {
                    new MovimientoContable { CuentaPrincipal = "Compras", Subcuenta = null, Movimiento = TipoMovimiento.Debe, Monto = 4000.00m },
                    new MovimientoContable { CuentaPrincipal = "Crédito Fiscal IVA", Subcuenta = null, Movimiento = TipoMovimiento.Debe, Monto = 520.00m },
                    new MovimientoContable { CuentaPrincipal = "Cuentas por Pagar", Subcuenta = "Proveedores", Movimiento = TipoMovimiento.Haber, Monto = 4520.00m }
                }
            };
            _asientos.Add(partida2);

            // Partida 3: Venta de mercaderías con cobro bancario y clientes con IVA
            var partida3 = new AsientoContable
            {
                NumeroAsiento = 3,
                Fecha = DateTime.Today.AddDays(-3),
                Concepto = "Venta de mercaderías cobrando 50% con transferencia y 50% al crédito.",
                Movimientos = new List<MovimientoContable>
                {
                    new MovimientoContable { CuentaPrincipal = "Efectivo y Equivalentes", Subcuenta = "Bancos", Movimiento = TipoMovimiento.Debe, Monto = 3390.00m },
                    new MovimientoContable { CuentaPrincipal = "Cuentas por Cobrar", Subcuenta = "Clientes", Movimiento = TipoMovimiento.Debe, Monto = 3390.00m },
                    new MovimientoContable { CuentaPrincipal = "Venta", Subcuenta = null, Movimiento = TipoMovimiento.Haber, Monto = 6000.00m },
                    new MovimientoContable { CuentaPrincipal = "Débito Fiscal IVA", Subcuenta = null, Movimiento = TipoMovimiento.Haber, Monto = 780.00m }
                }
            };
            _asientos.Add(partida3);

            NotificarCambios();
        }
    }
}
