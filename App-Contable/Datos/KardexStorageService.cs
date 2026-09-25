using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Modelos;

namespace App_Contable.Datos
{
    /// <summary>
    /// Repositorio de almacenamiento y gestión de tarjetas Kardex guardadas.
    /// Provee acceso unificado en memoria con soporte para persistencia.
    /// </summary>
    public class KardexStorageService
    {
        private static readonly List<KardexInstancia> _tarjetasEnMemoria = new();
        private static bool _inicializado = false;

        public KardexStorageService()
        {
            if (!_inicializado)
            {
                InicializarTarjetasSemilla();
                _inicializado = true;
            }
        }

        public List<KardexInstancia> ObtenerTarjetas()
        {
            return _tarjetasEnMemoria.OrderByDescending(t => t.FechaModificacion).ToList();
        }

        public KardexInstancia? ObtenerTarjetaPorId(string id)
        {
            return _tarjetasEnMemoria.FirstOrDefault(t => t.Id == id);
        }

        public void GuardarTarjeta(KardexInstancia tarjeta)
        {
            tarjeta.FechaModificacion = DateTime.Now;
            var idx = _tarjetasEnMemoria.FindIndex(t => t.Id == tarjeta.Id);
            if (idx >= 0)
            {
                _tarjetasEnMemoria[idx] = tarjeta;
            }
            else
            {
                _tarjetasEnMemoria.Add(tarjeta);
            }
        }

        public bool EliminarTarjeta(string id)
        {
            return _tarjetasEnMemoria.RemoveAll(t => t.Id == id) > 0;
        }

        private static void InicializarTarjetasSemilla()
        {
            var tarjetaDemo = new KardexInstancia
            {
                Id = "kardex_cemento_portland",
                Nombre = "Kardex Cemento Portland Tipo I (50kg)",
                CodigoArticulo = "MAT-0101",
                Empresa = "Corporación Industrial S.A. de C.V.",
                Metodo = MetodoValuacion.PromedioPonderado,
                FechaInicio = new DateTime(2026, 9, 1),
                FechaFin = new DateTime(2026, 9, 30),
                DestinoGuardado = TipoDestinoLibro.Local,
                FechaCreacion = DateTime.Now.AddDays(-15),
                FechaModificacion = DateTime.Now.AddHours(-1),
                Movimientos = new List<KardexItem>
                {
                    new KardexItem
                    {
                        Id = 1,
                        Fecha = new DateTime(2026, 9, 1),
                        Concepto = "Inventario Inicial",
                        Documento = "INV-0001",
                        CantidadEntrada = 300,
                        CostoUnitario = 8.5000m,
                        CostoPromedio = 8.5000m,
                        Debe = 2550.00m,
                        SaldoValor = 2550.00m,
                        CantidadSaldo = 300,
                        Origen = TipoOrigenKardex.Manual,
                        TipoMovimiento = TipoMovimientoKardex.InventarioInicial
                    },
                    new KardexItem
                    {
                        Id = 2,
                        Fecha = new DateTime(2026, 9, 5),
                        Concepto = "Compra Factura #402 — Prov. Cemento Express",
                        Documento = "F-402",
                        CantidadEntrada = 200,
                        CostoUnitario = 8.4000m,
                        CostoPromedio = 8.4600m,
                        Debe = 1680.00m,
                        SaldoValor = 4230.00m,
                        CantidadSaldo = 500,
                        Origen = TipoOrigenKardex.AutoLibroDiario,
                        NumeroAsiento = 2,
                        TipoMovimiento = TipoMovimientoKardex.Compra
                    },
                    new KardexItem
                    {
                        Id = 3,
                        Fecha = new DateTime(2026, 9, 12),
                        Concepto = "Venta a Constructora Horizonte",
                        Documento = "F-105",
                        CantidadSalida = 250,
                        CostoUnitario = 8.4600m,
                        CostoPromedio = 8.4600m,
                        Haber = 2115.00m,
                        SaldoValor = 2115.00m,
                        CantidadSaldo = 250,
                        Origen = TipoOrigenKardex.AutoLibroDiario,
                        NumeroAsiento = 3,
                        TipoMovimiento = TipoMovimientoKardex.Venta
                    }
                }
            };

            _tarjetasEnMemoria.Add(tarjetaDemo);
        }
    }
}

