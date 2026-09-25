using System;
using System.Windows.Forms;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmNuevaTarjetaModal : Form
    {
        public TarjetaKardex? TarjetaCreada { get; private set; }

        public frmNuevaTarjetaModal()
        {
            InitializeComponent();
        }

        private void btnCrearYAbrir_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreTarjeta.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Por favor ingresa un nombre para la tarjeta Kardex.",
                    "Campo Requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNombreTarjeta.Focus();
                return;
            }

            string codigo = txtCodigoArticulo.Text.Trim();

            TarjetaCreada = new TarjetaKardex
            {
                Id = "kardex_" + Guid.NewGuid().ToString("N").Substring(0, 10),
                Nombre = nombre,
                CodigoArticulo = codigo,
                MetodoValuacion = "PEPS / FIFO (Primeras Entradas, Primeras Salidas)",
                OrigenAlmacenamiento = TipoAlmacenamientoKardex.EnMemoria,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                StockActual = 0,
                CostoPromedioActual = 0,
                SaldoValorActual = 0,
                Movimientos = new System.Collections.Generic.List<KardexItem>()
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

