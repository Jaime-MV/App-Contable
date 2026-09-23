using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmLibroDiario : Form
    {
        private readonly LibroDiarioServicio _servicio = LibroDiarioServicio.Instancia;
        private List<FilaLibroDiarioVisual> _filasActuales = new();

        public frmLibroDiario()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            // Reducir parpadeos de pintado GDI+
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Fechas por defecto para el filtro (mes actual)
            var hoy = DateTime.Today;
            dtpFechaInicio.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpFechaFin.Value = new DateTime(hoy.Year, hoy.Month, DateTime.DaysInMonth(hoy.Year, hoy.Month));

            // Configuración avanzada de la grilla
            dgvLibroDiario.AutoGenerateColumns = false;
            dgvLibroDiario.DoubleBuffered(true);

            // Desactivar ordenamiento por columnas para preservar la estructura contable de las partidas
            foreach (DataGridViewColumn col in dgvLibroDiario.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvLibroDiario.CellFormatting += DgvLibroDiario_CellFormatting;
            dgvLibroDiario.RowPrePaint += DgvLibroDiario_RowPrePaint;
        }

        private void CargarDatos(DateTime? desde = null, DateTime? hasta = null)
        {
            _filasActuales = _servicio.GenerarFilasVisuales(desde, hasta);
            dgvLibroDiario.Rows.Clear();

            foreach (var fila in _filasActuales)
            {
                int index = dgvLibroDiario.Rows.Add(
                    fila.Fecha,
                    fila.Cuenta,
                    fila.Parcial.HasValue ? fila.Parcial.Value.ToString("N2") : string.Empty,
                    fila.Debe.HasValue ? fila.Debe.Value.ToString("N2") : string.Empty,
                    fila.Haber.HasValue ? fila.Haber.Value.ToString("N2") : string.Empty
                );

                dgvLibroDiario.Rows[index].Tag = fila;
            }

            ActualizarBarraResumen();
        }

        private void DgvLibroDiario_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLibroDiario.Rows.Count) return;

            var row = dgvLibroDiario.Rows[e.RowIndex];
            if (row.Tag is not FilaLibroDiarioVisual fila) return;

            switch (fila.TipoFila)
            {
                case TipoFilaVisual.EncabezadoPartida:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249); // Gris azulado suave
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaVisual.Subcuenta:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105); // Texto tenue para subcuentas
                    break;

                case TipoFilaVisual.CuentaPrincipal:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaVisual.ConceptoGlosa:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 8.5f, FontStyle.Italic);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
                    break;

                case TipoFilaVisual.Separador:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    row.Height = 12;
                    break;

                case TipoFilaVisual.TotalSumasIguales:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;
            }
        }

        private void DgvLibroDiario_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLibroDiario.Rows.Count) return;

            var row = dgvLibroDiario.Rows[e.RowIndex];
            if (row.Tag is not FilaLibroDiarioVisual fila) return;

            // Centrar la fecha
            if (e.CellStyle != null && e.ColumnIndex == colFecha.Index && !string.IsNullOrEmpty(fila.Fecha))
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ActualizarBarraResumen()
        {
            var asientos = _servicio.ObtenerAsientos();
            decimal totalDebe = asientos.Sum(a => a.TotalDebe);
            decimal totalHaber = asientos.Sum(a => a.TotalHaber);

            lblTotalAsientos.Text = $"Total Asientos: {asientos.Count}";
            lblTotalDebeGlobal.Text = $"Total Debe: {totalDebe:C2}";
            lblTotalHaberGlobal.Text = $"Total Haber: {totalHaber:C2}";

            bool cuadradas = asientos.All(a => a.EstaCuadrado);
            if (cuadradas && asientos.Any())
            {
                lblBadgeEstado.Text = "✓ Asientos Dobles Cuadrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else if (!asientos.Any())
            {
                lblBadgeEstado.Text = "Sin asientos registrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else
            {
                lblBadgeEstado.Text = "⚠ Advertencia: Asientos descuadrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        private void btnNuevoAsiento_Click(object sender, EventArgs e)
        {
            using var dialogo = new frmAgregarAsiento();
            if (dialogo.ShowDialog(this) == DialogResult.OK)
            {
                CargarDatos();
            }
        }

        private void btnEliminarAsiento_Click(object sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0)
            {
                MessageBox.Show("Por favor seleccione una fila perteneciente al asiento que desea eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el Asiento N° {fila.NumeroAsiento} del Libro Diario?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                if (_servicio.EliminarAsiento(fila.NumeroAsiento))
                {
                    MessageBox.Show($"Asiento N° {fila.NumeroAsiento} eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                }
            }
        }

        private void btnEditarAsiento_Click(object sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0)
            {
                MessageBox.Show("Por favor seleccione una fila perteneciente al asiento que desea editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var asientoExistente = _servicio.ObtenerAsientos().FirstOrDefault(a => a.NumeroAsiento == fila.NumeroAsiento);
            if (asientoExistente != null)
            {
                using var dialogo = new frmAgregarAsiento(asientoExistente);
                if (dialogo.ShowDialog(this) == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void btnSubirAsiento_Click(object sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0)
            {
                return;
            }
            _servicio.MoverAsientoArriba(fila.NumeroAsiento);
            CargarDatos();
        }

        private void btnBajarAsiento_Click(object sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0)
            {
                return;
            }
            _servicio.MoverAsientoAbajo(fila.NumeroAsiento);
            CargarDatos();
        }

        private void btnCargarEjemplo_Click(object sender, EventArgs e)
        {
            _servicio.CargarAsientosEjemplo();
            CargarDatos();
            MessageBox.Show("Se han restablecido los asientos de ejemplo con el catálogo oficial.", "Libro Diario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatos(dtpFechaInicio.Value.Date, dtpFechaFin.Value.Date);
        }
    }
}
