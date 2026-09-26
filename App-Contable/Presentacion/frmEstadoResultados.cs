using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmEstadoResultados : Form
    {
        private static readonly CultureInfo UsCulture = new("en-US");
        private readonly EstadoResultadosServicio _servicio = EstadoResultadosServicio.Instancia;
        private DatosEstadoResultados _estadoActual = new();
        private LibroDiarioInstancia? _libroActual = null;

        public frmEstadoResultados()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ActualizarVisibilidad();
        }

        public frmEstadoResultados(LibroDiarioInstancia libro)
        {
            InitializeComponent();
            _libroActual = libro;
            ConfigurarFormulario();
            dtpFechaInicio.Value = libro.FechaInicio;
            dtpFechaFin.Value = libro.FechaFin;
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            var hoy = DateTime.Today;
            dtpFechaInicio.Value = new DateTime(hoy.Year, 1, 1);
            dtpFechaFin.Value = hoy;

            dgvEstadoResultados.AutoGenerateColumns = false;
            dgvEstadoResultados.DoubleBuffered(true);

            foreach (DataGridViewColumn col in dgvEstadoResultados.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            AplicarEstiloGrilla();

            // Centrar dinámicamente el placeholder vacío
            pnlEstadoVacio.Resize += (s, e) => CentrarCardVacio();
            CentrarCardVacio();

            dgvEstadoResultados.CellFormatting += DgvEstadoResultados_CellFormatting;
            dgvEstadoResultados.RowPrePaint += DgvEstadoResultados_RowPrePaint;

            // Recalcular al cambiar el rango de fechas
            dtpFechaInicio.ValueChanged += (s, e) => { if (_libroActual != null) CargarDatos(); };
            dtpFechaFin.ValueChanged += (s, e) => { if (_libroActual != null) CargarDatos(); };

            pnlToolbar.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, pnlToolbar.Height - 1, pnlToolbar.Width, pnlToolbar.Height - 1);
            };

            pnlResumenInferior.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, pnlResumenInferior.Width, 0);
            };

            // Suscribirse a cambios en los asientos contables
            LibroDiarioServicio.Instancia.DatosModificados += OnLibroDiarioModificado;
            this.FormClosed += (s, e) => LibroDiarioServicio.Instancia.DatosModificados -= OnLibroDiarioModificado;

            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible && _libroActual != null)
                {
                    CargarDatos();
                }
            };
        }

        private void CentrarCardVacio()
        {
            if (pnlEstadoVacio.ClientSize.Width > 0 && pnlEstadoVacio.ClientSize.Height > 0)
            {
                int x = Math.Max(10, (pnlEstadoVacio.ClientSize.Width - pnlCardVacio.Width) / 2);
                int y = Math.Max(20, (pnlEstadoVacio.ClientSize.Height - pnlCardVacio.Height) / 2);
                pnlCardVacio.Location = new Point(x, y);
            }
        }

        private void AplicarEstiloGrilla()
        {
            dgvEstadoResultados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(201, 218, 236);
            dgvEstadoResultados.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvEstadoResultados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            dgvEstadoResultados.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(201, 218, 236);
            dgvEstadoResultados.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvEstadoResultados.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvEstadoResultados.EnableHeadersVisualStyles = false;

            dgvEstadoResultados.DefaultCellStyle.BackColor = Color.White;
            dgvEstadoResultados.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvEstadoResultados.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvEstadoResultados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvEstadoResultados.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvEstadoResultados.GridColor = Color.FromArgb(203, 213, 225);
            dgvEstadoResultados.BackgroundColor = Color.White;
            dgvEstadoResultados.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvEstadoResultados.ColumnHeadersHeight = 36;
            dgvEstadoResultados.RowTemplate.Height = 28;
        }

        private void OnLibroDiarioModificado()
        {
            if (_libroActual != null && IsHandleCreated && !IsDisposed)
            {
                BeginInvoke(new Action(() => CargarDatos()));
            }
        }

        private void ActualizarVisibilidad()
        {
            bool hayLibroCargado = _libroActual != null;

            pnlEstadoVacio.Visible = !hayLibroCargado;
            dgvEstadoResultados.Visible = hayLibroCargado;
            pnlResumenInferior.Visible = hayLibroCargado;

            if (hayLibroCargado)
            {
                lblTituloSeccion.Text = $"ESTADO DE RESULTADOS — {_libroActual!.Nombre.ToUpperInvariant()}";
                dgvEstadoResultados.BringToFront();
            }
            else
            {
                lblTituloSeccion.Text = "ESTADO DE RESULTADOS";
                pnlEstadoVacio.BringToFront();
                CentrarCardVacio();
            }
        }

        public void CargarDatos()
        {
            if (_libroActual == null)
            {
                ActualizarVisibilidad();
                return;
            }

            ActualizarVisibilidad();

            _estadoActual = _servicio.CalcularDesdeLibro(
                _libroActual,
                dtpFechaInicio.Value.Date,
                dtpFechaFin.Value.Date);

            var filas = _servicio.GenerarFilasVisuales(_estadoActual);
            dgvEstadoResultados.Rows.Clear();

            foreach (var fila in filas)
            {
                string parcialStr = fila.Parcial.HasValue ? fila.Parcial.Value.ToString("$#,##0.00", UsCulture) : string.Empty;
                string subtotalStr = fila.Subtotal.HasValue ? fila.Subtotal.Value.ToString("$#,##0.00", UsCulture) : string.Empty;
                string totalStr = fila.Total.HasValue ? fila.Total.Value.ToString("$#,##0.00", UsCulture) : string.Empty;

                int index = dgvEstadoResultados.Rows.Add(
                    fila.Concepto,
                    parcialStr,
                    subtotalStr,
                    totalStr
                );

                dgvEstadoResultados.Rows[index].Tag = fila;
            }

            ActualizarResumen();
            dgvEstadoResultados.ClearSelection();
        }

        private void DgvEstadoResultados_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEstadoResultados.Rows.Count) return;

            var row = dgvEstadoResultados.Rows[e.RowIndex];
            if (row.Tag is not FilaEstadoResultadosVisual fila) return;

            switch (fila.TipoFila)
            {
                case TipoFilaEstadoResultados.ResultadoIntermedio:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(226, 239, 218);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaEstadoResultados.ResultadoFinal:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(169, 208, 142);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaEstadoResultados.Subtotal:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaEstadoResultados.Concepto:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaEstadoResultados.Separador:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    row.Height = 12;
                    break;
            }
        }

        private void DgvEstadoResultados_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEstadoResultados.Rows.Count) return;

            var row = dgvEstadoResultados.Rows[e.RowIndex];
            if (row.Tag is not FilaEstadoResultadosVisual fila) return;

            // Indentación contable estética
            if (e.ColumnIndex == colConcepto.Index && e.Value is string texto)
            {
                if (fila.TipoFila == TipoFilaEstadoResultados.Concepto && (texto.StartsWith("(-)") || texto.StartsWith("(+)")))
                {
                    e.Value = "  " + texto;
                }
                else if (fila.TipoFila == TipoFilaEstadoResultados.Concepto && texto == "Gastos financieros")
                {
                    e.Value = "    " + texto;
                }
            }
        }

        private void ActualizarResumen()
        {
            lblVentasNetas.Text = $"Ventas Netas: {_estadoActual.VentasNetas.ToString("$#,##0.00", UsCulture)}";
            lblCostoVentas.Text = $"Costo Ventas: {_estadoActual.CostoDeVentas.ToString("$#,##0.00", UsCulture)}";
            lblUtilidadBruta.Text = $"Utilidad Bruta: {_estadoActual.UtilidadBruta.ToString("$#,##0.00", UsCulture)}";
            lblUtilidadOperacional.Text = $"Utilidad Operacional: {_estadoActual.UtilidadOperacional.ToString("$#,##0.00", UsCulture)}";

            if (_estadoActual.UtilidadOperacional >= 0)
            {
                lblBadgeEstado.Text = "✓ Estado de Resultados Calculado";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                lblBadgeEstado.Text = "⚠ Pérdida Operacional";
                lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        private void btnCargarDesdeLibro_Click(object sender, EventArgs e)
        {
            using var modal = new frmSeleccionarLibroDiarioModal("Escoge un libro diario para procesar automáticamente su Estado de Resultados.");
            if (modal.ShowDialog(this) == DialogResult.OK && modal.LibroSeleccionado != null)
            {
                _libroActual = modal.LibroSeleccionado;
                dtpFechaInicio.Value = _libroActual.FechaInicio;
                dtpFechaFin.Value = _libroActual.FechaFin;
                CargarDatos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_libroActual != null)
            {
                CargarDatos();
            }
            else
            {
                btnCargarDesdeLibro_Click(sender, e);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (_libroActual != null)
            {
                CargarDatos();
            }
        }
    }
}

