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
    public partial class frmBalanzaComprobacion : Form
    {
        private static readonly CultureInfo UsCulture = new("en-US");
        private readonly BalanzaComprobacionServicio _servicio = BalanzaComprobacionServicio.Instancia;
        private LibroDiarioInstancia? _libroActual = null;

        public frmBalanzaComprobacion()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ActualizarVisibilidad();
        }

        public frmBalanzaComprobacion(LibroDiarioInstancia libro)
        {
            InitializeComponent();
            ConfigurarFormulario();
            _libroActual = libro;
            dtpFechaInicio.Value = libro.FechaInicio;
            dtpFechaFin.Value = libro.FechaFin;
            CargarDatos();
        }

        // ──────────────────────────────────────────────────────────────
        //  Configuración inicial
        // ──────────────────────────────────────────────────────────────
        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            var hoy = DateTime.Today;
            dtpFechaInicio.Value = new DateTime(hoy.Year, 1, 1);
            dtpFechaFin.Value = hoy;

            dgvBalanza.AutoGenerateColumns = false;
            dgvBalanza.DoubleBuffered(true);

            foreach (DataGridViewColumn col in dgvBalanza.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            AplicarEstiloGrilla();

            // Centrar el panel de estado vacío dinámicamente
            pnlEstadoVacio.Resize += (s, e) => CentrarCardVacio();
            CentrarCardVacio();

            // Suscripciones a eventos
            dtpFechaInicio.ValueChanged += (s, e) => { if (_libroActual != null) CargarDatos(); };
            dtpFechaFin.ValueChanged += (s, e) => { if (_libroActual != null) CargarDatos(); };

            pnlToolbar.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, pnlToolbar.Height - 1, pnlToolbar.Width, pnlToolbar.Height - 1);
            };

            pnlFooter.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, pnlFooter.Width, 0);
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
            // Encabezado de columnas (Celeste pastel suave unificado)
            dgvBalanza.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(201, 218, 236);
            dgvBalanza.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvBalanza.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            dgvBalanza.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(201, 218, 236);
            dgvBalanza.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvBalanza.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvBalanza.EnableHeadersVisualStyles = false;

            // Celdas normales
            dgvBalanza.DefaultCellStyle.BackColor = Color.White;
            dgvBalanza.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvBalanza.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvBalanza.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvBalanza.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvBalanza.GridColor = Color.FromArgb(203, 213, 225);
            dgvBalanza.BackgroundColor = Color.White;
            dgvBalanza.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBalanza.ColumnHeadersHeight = 42;
            dgvBalanza.RowTemplate.Height = 28;

            // Eventos de pintado fila a fila
            dgvBalanza.RowPrePaint += Dgv_RowPrePaint;
        }

        // ──────────────────────────────────────────────────────────────
        //  Alternancia de visibilidad entre Placeholder y Grilla
        // ──────────────────────────────────────────────────────────────
        private void ActualizarVisibilidad()
        {
            bool hayLibroCargado = _libroActual != null;

            pnlEstadoVacio.Visible = !hayLibroCargado;
            dgvBalanza.Visible = hayLibroCargado;
            pnlFooter.Visible = hayLibroCargado;

            if (hayLibroCargado)
            {
                lblTituloSeccion.Text = $"BALANZA — {_libroActual!.Nombre}";
                dgvBalanza.BringToFront();
            }
            else
            {
                lblTituloSeccion.Text = "BALANZA DE COMPROBACIÓN";
                pnlEstadoVacio.BringToFront();
                CentrarCardVacio();
            }
        }

        // ──────────────────────────────────────────────────────────────
        //  Carga de datos y renderizado
        // ──────────────────────────────────────────────────────────────
        public void CargarDatos()
        {
            if (_libroActual == null)
            {
                ActualizarVisibilidad();
                return;
            }

            ActualizarVisibilidad();

            var (filas, resumen) = _servicio.GenerarBalanzaDesdeLibro(
                _libroActual,
                dtpFechaInicio.Value.Date,
                dtpFechaFin.Value.Date);

            PoblarGrilla(filas, resumen);
            ActualizarResumen(resumen);
        }

        private void PoblarGrilla(List<FilaBalanzaComprobacion> filas, ResumenBalanzaComprobacion resumen)
        {
            dgvBalanza.Rows.Clear();

            foreach (var fila in filas)
            {
                string movDebe = fila.MovimientoDebe > 0 ? fila.MovimientoDebe.ToString("$#,##0.00", UsCulture) : "—";
                string movHaber = fila.MovimientoHaber > 0 ? fila.MovimientoHaber.ToString("$#,##0.00", UsCulture) : "—";
                string salDeudor = fila.SaldoDeudor > 0 ? fila.SaldoDeudor.ToString("$#,##0.00", UsCulture) : "—";
                string salAcreedor = fila.SaldoAcreedor > 0 ? fila.SaldoAcreedor.ToString("$#,##0.00", UsCulture) : "—";

                int idx = dgvBalanza.Rows.Add(
                    fila.Codigo,
                    fila.Cuenta,
                    movDebe,
                    movHaber,
                    salDeudor,
                    salAcreedor
                );

                dgvBalanza.Rows[idx].Tag = fila;
            }

            // Fila de Sumas Iguales / Totales
            if (filas.Any())
            {
                var filaTotales = new FilaBalanzaComprobacion
                {
                    Codigo = string.Empty,
                    Cuenta = "SUMAS IGUALES TOTALES",
                    MovimientoDebe = resumen.TotalMovimientoDebe,
                    MovimientoHaber = resumen.TotalMovimientoHaber,
                    SaldoDeudor = resumen.TotalSaldoDeudor,
                    SaldoAcreedor = resumen.TotalSaldoAcreedor,
                    EsFila_Total = true
                };

                int idxTot = dgvBalanza.Rows.Add(
                    string.Empty,
                    "SUMAS IGUALES TOTALES",
                    resumen.TotalMovimientoDebe.ToString("$#,##0.00", UsCulture),
                    resumen.TotalMovimientoHaber.ToString("$#,##0.00", UsCulture),
                    resumen.TotalSaldoDeudor.ToString("$#,##0.00", UsCulture),
                    resumen.TotalSaldoAcreedor.ToString("$#,##0.00", UsCulture)
                );

                dgvBalanza.Rows[idxTot].Tag = filaTotales;
            }

            dgvBalanza.ClearSelection();
        }

        // ──────────────────────────────────────────────────────────────
        //  Pintado visual por fila
        // ──────────────────────────────────────────────────────────────
        private void Dgv_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBalanza.Rows.Count) return;
            var row = dgvBalanza.Rows[e.RowIndex];

            if (row.Tag is not FilaBalanzaComprobacion fila) return;

            if (fila.EsFila_Total)
            {
                // Fila de Totales / Sumas Iguales
                row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
                row.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                row.Height = 32;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                row.Height = 28;
            }
        }

        // ──────────────────────────────────────────────────────────────
        //  Panel de resumen inferior con doble validación de cuadre
        // ──────────────────────────────────────────────────────────────
        private void ActualizarResumen(ResumenBalanzaComprobacion resumen)
        {
            lblTotalCuentas.Text = $"Cuentas: {resumen.TotalCuentas}";
            lblTotalMovDebe.Text = $"Mov. Debe: {resumen.TotalMovimientoDebe.ToString("$#,##0.00", UsCulture)}";
            lblTotalMovHaber.Text = $"Mov. Haber: {resumen.TotalMovimientoHaber.ToString("$#,##0.00", UsCulture)}";
            lblTotalSaldoDeudor.Text = $"Saldo Deudor: {resumen.TotalSaldoDeudor.ToString("$#,##0.00", UsCulture)}";
            lblTotalSaldoAcreedor.Text = $"Saldo Acreedor: {resumen.TotalSaldoAcreedor.ToString("$#,##0.00", UsCulture)}";

            if (resumen.EstaBalanceada && resumen.TotalCuentas > 0)
            {
                lblBadgeEstado.Text = "✓ Balanza Cuadrada";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else if (resumen.TotalCuentas == 0)
            {
                lblBadgeEstado.Text = "ℹ Sin movimientos en el período";
                lblBadgeEstado.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else
            {
                decimal diffMov = resumen.DiferenciaMovimientos;
                decimal diffSal = resumen.DiferenciaSaldos;

                if (diffMov > 0 && diffSal > 0)
                {
                    lblBadgeEstado.Text = $"⚠ Descuadre (Mov: {diffMov.ToString("$#,##0.00", UsCulture)} | Saldos: {diffSal.ToString("$#,##0.00", UsCulture)})";
                }
                else if (diffMov > 0)
                {
                    lblBadgeEstado.Text = $"⚠ Descuadre en Movimientos ({diffMov.ToString("$#,##0.00", UsCulture)})";
                }
                else
                {
                    lblBadgeEstado.Text = $"⚠ Descuadre en Saldos ({diffSal.ToString("$#,##0.00", UsCulture)})";
                }

                lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        // ──────────────────────────────────────────────────────────────
        //  Eventos de botones
        // ──────────────────────────────────────────────────────────────
        private void btnCargarDesdeLibro_Click(object sender, EventArgs e)
        {
            using var modal = new frmSeleccionarLibroDiarioModal();
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

