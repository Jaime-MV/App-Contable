using System;
using System.Windows.Forms;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmCrearLibroDiarioModal : Form
    {
        public LibroDiarioInstancia? InstanciaCreada { get; private set; }

        public frmCrearLibroDiarioModal()
        {
            InitializeComponent();

            var hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, 1, 1);
            dtpHasta.Value = new DateTime(hoy.Year, 12, 31);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del Libro Diario para continuar.",
                    "Campo Requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha de inicio no puede ser posterior a la fecha de fin del período contable.",
                    "Rango de Fechas Inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                dtpDesde.Focus();
                return;
            }

            InstanciaCreada = new LibroDiarioInstancia
            {
                Nombre = nombre,
                Empresa = txtEmpresa.Text.Trim(),
                FechaInicio = dtpDesde.Value.Date,
                FechaFin = dtpHasta.Value.Date,
                DestinoGuardado = rbLocal.Checked ? TipoDestinoLibro.Local : TipoDestinoLibro.PostgreSQL,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

