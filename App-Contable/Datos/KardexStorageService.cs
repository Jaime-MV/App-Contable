using System;
using System.Collections.Generic;
using System.Linq;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Datos
{
    /// <summary>
    /// Repositorio de almacenamiento en memoria para Tarjetas Kardex durante la sesión de desarrollo.
    /// Valuado exclusivamente bajo el método PEPS / FIFO.
    /// </summary>
    public class KardexStorageService
    {
        // Almacén centralizado en memoria para la sesión activa
        private static readonly List<TarjetaKardex> _tarjetasEnMemoria = new();
        private static bool _inicializado = false;

        public KardexStorageService()
        {
            if (!_inicializado)
            {
                InicializarTarjetasSemillaEnMemoria();
                _inicializado = true;
            }
        }

        /// <summary>
        /// Obtiene todas las tarjetas Kardex almacenadas en memoria.
        /// </summary>
        public List<TarjetaKardex> ObtenerTarjetasLocales()
        {
            return _tarjetasEnMemoria.OrderByDescending(t => t.FechaModificacion).ToList();
        }

        /// <summary>
        /// Guarda o actualiza una tarjeta Kardex en memoria.
        /// </summary>
        public void GuardarTarjetaLocal(TarjetaKardex tarjeta)
        {
            tarjeta.FechaModificacion = DateTime.Now;
            tarjeta.OrigenAlmacenamiento = TipoAlmacenamientoKardex.EnMemoria;
            tarjeta.MetodoValuacion = "PEPS / FIFO (Primeras Entradas, Primeras Salidas)";

            var index = _tarjetasEnMemoria.FindIndex(t => t.Id == tarjeta.Id);
            if (index >= 0)
            {
                _tarjetasEnMemoria[index] = tarjeta;
            }
            else
            {
                _tarjetasEnMemoria.Add(tarjeta);
            }
        }

        /// <summary>
        /// Elimina una tarjeta Kardex de la memoria.
        /// </summary>
        public bool EliminarTarjetaLocal(TarjetaKardex tarjeta)
        {
            return _tarjetasEnMemoria.RemoveAll(t => t.Id == tarjeta.Id) > 0;
        }

        /// <summary>
        /// Reinicia las tarjetas en memoria con los datos de demostración bajo PEPS / FIFO.
        /// </summary>
        public void RecargarEjemplosEnMemoria()
        {
            _tarjetasEnMemoria.Clear();
            InicializarTarjetasSemillaEnMemoria();
        }

        private static void InicializarTarjetasSemillaEnMemoria()
        {
            // Tarjeta 1: Cemento Portland Tipo I (Ejemplo principal PEPS / FIFO)
            var movimientosT1 = KardexCalculador.ObtenerDatosSemillaEjemplo();
            var (_, resT1, _) = KardexCalculador.ProcesarKardex(movimientosT1, DateTime.MinValue, DateTime.MaxValue);

            var t1 = new TarjetaKardex
            {
                Id = "kardex_cemento_01",
                Nombre = "Kardex Cemento Portland Tipo I (50kg)",
                CodigoArticulo = "MAT-0101",
                MetodoValuacion = "PEPS / FIFO (Primeras Entradas, Primeras Salidas)",
                OrigenAlmacenamiento = TipoAlmacenamientoKardex.EnMemoria,
                FechaCreacion = DateTime.Now.AddDays(-15),
                FechaModificacion = DateTime.Now.AddHours(-1),
                StockActual = resT1.SaldoFisicoFinal,
                CostoPromedioActual = resT1.UltimoCostoPromedio,
                SaldoValorActual = resT1.SaldoValorFinal,
                Movimientos = movimientosT1
            };

            // Tarjeta 2: Varilla de Hierro Corrugada 3/8
            var movimientosT2 = new List<KardexItem>
            {
                new KardexItem
                {
                    Id = 1,
                    Fecha = new DateTime(2026, 9, 2),
                    Concepto = "Inventario Inicial",
                    Documento = "INV-0002",
                    CantidadEntrada = 100m,
                    CostoUnitario = 12.5000m,
                    TipoMovimiento = TipoMovimientoKardex.InventarioInicial,
                    Origen = TipoOrigenKardex.Manual
                },
                new KardexItem
                {
                    Id = 2,
                    Fecha = new DateTime(2026, 9, 8),
                    Concepto = "Compra Factura #630 — Aceros de Centroamérica",
                    Documento = "F-630",
                    CantidadEntrada = 150m,
                    CostoUnitario = 13.0000m,
                    TipoMovimiento = TipoMovimientoKardex.Compra,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 15
                },
                new KardexItem
                {
                    Id = 3,
                    Fecha = new DateTime(2026, 9, 16),
                    Concepto = "Venta s/ Factura #840 — Proyecto Residencial",
                    Documento = "OV-9021",
                    CantidadSalida = 80m, // Consume del Lote 1 (100 @ 12.50)
                    CostoUnitario = 12.5000m,
                    TipoMovimiento = TipoMovimientoKardex.Venta,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 19
                }
            };
            var (_, resT2, _) = KardexCalculador.ProcesarKardex(movimientosT2, DateTime.MinValue, DateTime.MaxValue);

            var t2 = new TarjetaKardex
            {
                Id = "kardex_varilla_02",
                Nombre = "Inventario Varilla de Hierro Corrugada 3/8",
                CodigoArticulo = "AC-502",
                MetodoValuacion = "PEPS / FIFO (Primeras Entradas, Primeras Salidas)",
                OrigenAlmacenamiento = TipoAlmacenamientoKardex.EnMemoria,
                FechaCreacion = DateTime.Now.AddDays(-8),
                FechaModificacion = DateTime.Now.AddHours(-3),
                StockActual = resT2.SaldoFisicoFinal,
                CostoPromedioActual = resT2.UltimoCostoPromedio,
                SaldoValorActual = resT2.SaldoValorFinal,
                Movimientos = movimientosT2
            };

            _tarjetasEnMemoria.Add(t1);
            _tarjetasEnMemoria.Add(t2);
        }
    }
}

