using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmBalanzaComprobacion : Form
    {
        private readonly BalanzaComprobacionServicio _servicio = BalanzaComprobacionServicio.Instancia;
        private bool _modoEjemplo = false;

        public frmBalanzaComprobacion()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarDatos(usarEjemplo: false);
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
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Estilo visual de la grilla
            AplicarEstiloGrilla();

            // Suscripciones
            dtpFechaInicio.ValueChanged += (s, e) => { if (!_modoEjemplo) CargarDatos(false); };
            dtpFechaFin.ValueChanged    += (s, e) => { if (!_modoEjemplo) CargarDatos(false); };

            LibroDiarioServicio.Instancia.DatosModificados += OnDatosModificados;
            this.FormClosed += (s, e) => LibroDiarioServicio.Instancia.DatosModificados -= OnDatosModificados;

            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible && !_modoEjemplo)
                    CargarDatos(false);
            };

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

        private void AplicarEstiloGrilla()
        {
            // Encabezado de columnas
            dgvBalanza.ColumnHeadersDefaultCellStyle.BackColor      = Color.FromArgb(189, 215, 238);
            dgvBalanza.ColumnHeadersDefaultCellStyle.ForeColor      = Color.FromArgb(15, 23, 42);
            dgvBalanza.ColumnHeadersDefaultCellStyle.Font           = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgvBalanza.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(189, 215, 238);
            dgvBalanza.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvBalanza.ColumnHeadersDefaultCellStyle.WrapMode       = DataGridViewTriState.True;
            dgvBalanza.EnableHeadersVisualStyles = false;

            // Celdas normales
            dgvBalanza.DefaultCellStyle.BackColor     = Color.White;
            dgvBalanza.DefaultCellStyle.ForeColor     = Color.FromArgb(30, 41, 59);
            dgvBalanza.DefaultCellStyle.Font          = new Font("Segoe UI", 9.5f);
            dgvBalanza.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 234, 245);
            dgvBalanza.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvBalanza.GridColor      = Color.FromArgb(203, 213, 225);
            dgvBalanza.BackgroundColor = Color.White;
            dgvBalanza.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBalanza.ColumnHeadersHeight = 36;
            dgvBalanza.RowTemplate.Height  = 28;

            // Eventos de pintado fila a fila
            dgvBalanza.RowPrePaint  += Dgv_RowPrePaint;
            dgvBalanza.CellPainting += Dgv_CellPainting;
        }

        // ──────────────────────────────────────────────────────────────
        //  Carga de datos
        // ──────────────────────────────────────────────────────────────
        private void OnDatosModificados()
        {
            if (!_modoEjemplo && IsHandleCreated && !IsDisposed)
                BeginInvoke(new Action(() => CargarDatos(false)));
        }

        public void CargarDatos(bool usarEjemplo)
        {
            _modoEjemplo = usarEjemplo;

            List<FilaBalanzaComprobacion> filas;
            ResumenBalanzaComprobacion resumen;

            if (_modoEjemplo)
            {
                (filas, resumen) = _servicio.ObtenerDatosEjemplo();
                btnCalcularMayor.BackColor = Color.White;
                btnCalcularMayor.ForeColor = Color.FromArgb(71, 85, 105);
                btnCargarEjemplo.BackColor = Color.FromArgb(241, 245, 249);
                btnCargarEjemplo.ForeColor = Color.FromArgb(30, 41, 59);
            }
            else
            {
                (filas, resumen) = _servicio.GenerarBalanza(dtpFechaInicio.Value.Date, dtpFechaFin.Value.Date);
                btnCalcularMayor.BackColor = Color.FromArgb(220, 252, 231);
                btnCalcularMayor.ForeColor = Color.FromArgb(22, 101, 52);
                btnCargarEjemplo.BackColor = Color.White;
                btnCargarEjemplo.ForeColor = Color.FromArgb(71, 85, 105);
            }

            PoblarGrilla(filas);
            ActualizarResumen(resumen);
        }

        private void PoblarGrilla(List<FilaBalanzaComprobacion> filas)
        {
            dgvBalanza.Rows.Clear();

            foreach (var fila in filas)
            {
                string debe  = fila.TotalDebe  > 0 ? fila.TotalDebe.ToString("N2")  : string.Empty;
                string haber = fila.TotalHaber > 0 ? fila.TotalHaber.ToString("N2") : string.Empty;

                int idx = dgvBalanza.Rows.Add(fila.Cuenta, debe, haber);
                dgvBalanza.Rows[idx].Tag = fila;
            }
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
                // Fila de Totales — fondo verde como en Excel
                row.DefaultCellStyle.BackColor = Color.FromArgb(169, 208, 142);
                row.DefaultCellStyle.Font      = new Font("Segoe UI", 10f, FontStyle.Bold);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                row.Height = 30;
            }
            else
            {
                // Filas normales — fondo blanco con fuente normal
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.Font      = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                row.Height = 28;
            }
        }

        private void Dgv_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            // Pintar la columna Cuenta con bold si la fila es de totales
            if (e.RowIndex < 0 || e.ColumnIndex != colCuenta.Index || e.Graphics is null) return;
            var row = dgvBalanza.Rows[e.RowIndex];
            if (row.Tag is FilaBalanzaComprobacion { EsFila_Total: true })
            {
                e.PaintBackground(e.ClipBounds, true);
                using var boldFont = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                TextRenderer.DrawText(e.Graphics, e.FormattedValue?.ToString() ?? string.Empty,
                    boldFont, e.CellBounds,
                    Color.FromArgb(15, 23, 42),
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.LeftAndRightPadding);
                e.Handled = true;
            }
        }

        // ──────────────────────────────────────────────────────────────
        //  Panel de resumen inferior
        // ──────────────────────────────────────────────────────────────
        private void ActualizarResumen(ResumenBalanzaComprobacion resumen)
        {
            lblTotalCuentas.Text = $"Total Cuentas: {resumen.TotalCuentas}";
            lblTotalDebe.Text    = $"Total Debe: ${resumen.TotalDebe:N2}";
            lblTotalHaber.Text   = $"Total Haber: ${resumen.TotalHaber:N2}";

            string origen = _modoEjemplo ? "(Datos de Prueba)" : "(Automático desde Asientos / Mayor)";

            if (resumen.EstaBalanceada)
            {
                lblBadgeEstado.Text      = $"✓ Balanza Cuadrada {origen}";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                decimal diff = Math.Abs(resumen.TotalDebe - resumen.TotalHaber);
                lblBadgeEstado.Text      = $"⚠ Diferencia: ${diff:N2} {origen}";
                lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        // ──────────────────────────────────────────────────────────────
        //  Eventos de botones
        // ──────────────────────────────────────────────────────────────
        private void btnCargarEjemplo_Click(object sender, EventArgs e) => CargarDatos(true);
        private void btnCalcularMayor_Click(object sender, EventArgs e) => CargarDatos(false);
        private void btnActualizar_Click(object sender, EventArgs e)    => CargarDatos(_modoEjemplo);
        private void btnFiltrar_Click(object sender, EventArgs e)       => CargarDatos(false);
    }
}
