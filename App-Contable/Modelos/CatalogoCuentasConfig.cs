using System;
using System.Collections.Generic;
using System.Linq;

namespace App_Contable.Modelos
{
    public class CuentaDefinicion
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public bool TieneSubcuentas { get; set; }
        public List<string> Subcuentas { get; set; } = new();
        public TipoNaturaleza NaturalezaPredeterminada { get; set; }

        public enum TipoNaturaleza
        {
            Deudora,
            Acreedora
        }
    }

    /// <summary>
    /// Catálogo oficial configurado estrictamente con las cuentas y subcuentas
    /// solicitadas para el Libro Diario.
    /// </summary>
    public static class CatalogoCuentasConfig
    {
        public static readonly List<CuentaDefinicion> CuentasPermitidas = new()
        {
            // --- Cuentas con Subcuentas ---
            new CuentaDefinicion
            {
                Codigo = "1101",
                Nombre = "Efectivo y Equivalentes",
                TieneSubcuentas = true,
                Subcuentas = new List<string> { "Caja", "Bancos" },
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Deudora
            },
            new CuentaDefinicion
            {
                Codigo = "1102",
                Nombre = "Cuentas por Cobrar",
                TieneSubcuentas = true,
                Subcuentas = new List<string> { "Clientes" },
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Deudora
            },
            new CuentaDefinicion
            {
                Codigo = "2101",
                Nombre = "Cuentas por Pagar",
                TieneSubcuentas = true,
                Subcuentas = new List<string> { "Proveedores", "Acreedores Varios" },
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Acreedora
            },
            new CuentaDefinicion
            {
                Codigo = "1201",
                Nombre = "Propiedad, Planta y Equipo",
                TieneSubcuentas = true,
                Subcuentas = new List<string>
                {
                    "Mobiliario y Equipo de Oficina",
                    "Equipo de Cómputo",
                    "Equipo de Transporte"
                },
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Deudora
            },
            new CuentaDefinicion
            {
                Codigo = "4101",
                Nombre = "Gastos Financieros",
                TieneSubcuentas = true,
                Subcuentas = new List<string> { "Comisión" },
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Deudora
            },

            // --- Cuentas Principales (Sin subcuenta registrada en el libro diario) ---
            new CuentaDefinicion
            {
                Codigo = "1103",
                Nombre = "Inventarios",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Deudora
            },
            new CuentaDefinicion
            {
                Codigo = "3101",
                Nombre = "Capital Social",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Acreedora
            },
            new CuentaDefinicion
            {
                Codigo = "5101",
                Nombre = "Compras",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Deudora
            },
            new CuentaDefinicion
            {
                Codigo = "5102",
                Nombre = "Devolución de Compra",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Acreedora
            },
            new CuentaDefinicion
            {
                Codigo = "4102",
                Nombre = "Venta",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Acreedora
            },
            new CuentaDefinicion
            {
                Codigo = "4103",
                Nombre = "Devolución de Venta",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Deudora
            },
            new CuentaDefinicion
            {
                Codigo = "1104",
                Nombre = "Crédito Fiscal IVA",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Deudora
            },
            new CuentaDefinicion
            {
                Codigo = "2102",
                Nombre = "Débito Fiscal IVA",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Acreedora
            },
            new CuentaDefinicion
            {
                Codigo = "2103",
                Nombre = "Préstamos Bancarios",
                TieneSubcuentas = false,
                Subcuentas = new(),
                NaturalezaPredeterminada = CuentaDefinicion.TipoNaturaleza.Acreedora
            }
        };

        public static CuentaDefinicion? ObtenerPorNombre(string nombre)
        {
            return CuentasPermitidas.FirstOrDefault(c => 
                string.Equals(c.Nombre, nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
