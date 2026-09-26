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
    public partial class frmBalanceGeneral : Form
    {
        private static readonly CultureInfo UsCulture = new("en-US");
        private readonly BalanceGeneralServicio _servicio = BalanceGeneralServicio.Instancia;
        private DatosBalanceGeneral _balanceActual = new();
        private LibroDiarioInstancia? _libroActual = null;

        public frmBalanceGeneral()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ActualizarVisibilidad();
        }

        public frmBalanceGeneral(LibroDiarioInstancia libro)
        {
            InitializeComponent();
            _libroActual = libro;
            ConfigurarFormulario();
            dtpFechaCorte.Value = libro.FechaFin;
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            dtpFechaCorte.Value = DateTime.Today;

            dgvBalanceGeneral.AutoGenerateColumns = false;
            dgvBalanceGeneral.DoubleBuffered(true);

            foreach (DataGridViewColumn col in dgvBalanceGeneral.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            AplicarEstiloGrilla();

            // Centrar dinámicamente el placeholder vacío
            pnlEstadoVacio.Resize += (s, e) => CentrarCardVacio();
            CentrarCardVacio();

            dgvBalanceGeneral.CellFormatting += DgvBalanceGeneral_CellFormatting;
            dgvBalanceGeneral.RowPrePaint += DgvBalanceGeneral_RowPrePaint;

            // Recalcular al cambiar fecha
            dtpFechaCorte.ValueChanged += (s, e) =>
            {
                if (_libroActual != null) CargarDatos();
            };

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
            dgvBalanceGeneral.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(201, 218, 236);
            dgvBalanceGeneral.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvBalanceGeneral.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            dgvBalanceGeneral.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(201, 218, 236);
            dgvBalanceGeneral.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvBalanceGeneral.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvBalanceGeneral.EnableHeadersVisualStyles = false;

            dgvBalanceGeneral.DefaultCellStyle.BackColor = Color.White;
            dgvBalanceGeneral.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvBalanceGeneral.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvBalanceGeneral.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvBalanceGeneral.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvBalanceGeneral.GridColor = Color.FromArgb(203, 213, 225);
            dgvBalanceGeneral.BackgroundColor = Color.White;
            dgvBalanceGeneral.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBalanceGeneral.ColumnHeadersHeight = 36;
            dgvBalanceGeneral.RowTemplate.Height = 28;
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
            dgvBalanceGeneral.Visible = hayLibroCargado;
            pnlResumenInferior.Visible = hayLibroCargado;

            if (hayLibroCargado)
            {
                lblTituloSeccion.Text = $"BALANCE GENERAL — {_libroActual!.Nombre.ToUpperInvariant()}";
                dgvBalanceGeneral.BringToFront();
            }
            else
            {
                lblTituloSeccion.Text = "BALANCE GENERAL";
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

            _balanceActual = _servicio.CalcularDesdeLibro(_libroActual, dtpFechaCorte.Value.Date);

            var filas = _servicio.GenerarFilasVisuales(_balanceActual);
            dgvBalanceGeneral.Rows.Clear();

            foreach (var fila in filas)
            {
                string parcialStr = fila.Parcial.HasValue ? fila.Parcial.Value.ToString("$#,##0.00", UsCulture) : string.Empty;
                string subtotalStr = fila.Subtotal.HasValue ? fila.Subtotal.Value.ToString("$#,##0.00", UsCulture) : string.Empty;
                string totalStr = fila.Total.HasValue ? fila.Total.Value.ToString("$#,##0.00", UsCulture) : string.Empty;

                int index = dgvBalanceGeneral.Rows.Add(
                    fila.Cuenta,
                    parcialStr,
                    subtotalStr,
                    totalStr
                );

                dgvBalanceGeneral.Rows[index].Tag = fila;
            }

            ActualizarResumen();
            dgvBalanceGeneral.ClearSelection();
        }

        private void DgvBalanceGeneral_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBalanceGeneral.Rows.Count) return;

            var row = dgvBalanceGeneral.Rows[e.RowIndex];
            if (row.Tag is not FilaBalanceVisual fila) return;

            switch (fila.TipoFila)
            {
                case TipoFilaBalance.TituloSeccion:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(217, 225, 242);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaBalance.Subseccion:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(237, 242, 248);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaBalance.Cuenta:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaBalance.Subtotal:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(226, 239, 218);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaBalance.TotalPrincipal:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(169, 208, 142);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaBalance.Separador:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    row.Height = 12;
                    break;
            }
        }

        private void DgvBalanceGeneral_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBalanceGeneral.Rows.Count) return;

            var row = dgvBalanceGeneral.Rows[e.RowIndex];
            if (row.Tag is not FilaBalanceVisual fila) return;

            // Sangría contable suave
            if (e.ColumnIndex == colCuenta.Index && e.Value is string texto)
            {
                if (fila.TipoFila == TipoFilaBalance.Cuenta)
                {
                    e.Value = "    " + texto;
                }
                else if (fila.TipoFila == TipoFilaBalance.Subseccion)
                {
                    e.Value = "  " + texto;
                }
            }
        }

        private void ActualizarResumen()
        {
            lblTotalActivo.Text = $"Total Activo: {_balanceActual.TotalActivo.ToString("$#,##0.00", UsCulture)}";
            lblTotalPasivoPatrimonio.Text = $"Total Pasivo + Pat.: {_balanceActual.TotalPasivoMasPatrimonio.ToString("$#,##0.00", UsCulture)}";

            if (_balanceActual.EstaCuadrado)
            {
                lblBadgeEstado.Text = "✓ Balance General Cuadrado (Activo = Pasivo + Patrimonio)";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                lblBadgeEstado.Text = $"⚠ Descuadre en Balance General: {_balanceActual.Diferencia.ToString("$#,##0.00", UsCulture)}";
                lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        private void btnCargarDesdeLibro_Click(object sender, EventArgs e)
        {
            using var modal = new frmSeleccionarLibroDiarioModal("Escoge un libro diario para procesar automáticamente su Balance General.");
            if (modal.ShowDialog(this) == DialogResult.OK && modal.LibroSeleccionado != null)
            {
                _libroActual = modal.LibroSeleccionado;
                dtpFechaCorte.Value = _libroActual.FechaFin;
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

