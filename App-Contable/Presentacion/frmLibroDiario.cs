using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        // ─── Vista actual ────────────────────────────────────────────
        private bool _enVistaGrilla = false;

        public frmLibroDiario()
        {
            InitializeComponent();
            ConfigurarFormulario();
            MostrarVistaDashboard();
        }

        // ══════════════════════════════════════════════════════════════
        //  CONFIGURACIÓN INICIAL
        // ══════════════════════════════════════════════════════════════
        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            // Filtro de fechas por defecto
            var hoy = DateTime.Today;
            dtpFechaInicio.Value = new DateTime(hoy.Year, 1, 1);
            dtpFechaFin.Value    = hoy;

            // Grilla
            dgvLibroDiario.AutoGenerateColumns = false;
            dgvLibroDiario.DoubleBuffered(true);

            foreach (DataGridViewColumn col in dgvLibroDiario.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvLibroDiario.CellFormatting += DgvLibroDiario_CellFormatting;
            dgvLibroDiario.RowPrePaint    += DgvLibroDiario_RowPrePaint;

            // Eventos de toolbar
            btnNuevoAsiento.Click    += (s, e) => AbrirNuevoAsiento();
            btnEliminarAsiento.Click += btnEliminarAsiento_Click;
            btnEditarAsiento.Click   += btnEditarAsiento_Click;
            btnSubirAsiento.Click    += btnSubirAsiento_Click;
            btnBajarAsiento.Click    += btnBajarAsiento_Click;
            btnCargarEjemplo.Click   += btnCargarEjemplo_Click;
            btnActualizar.Click      += btnActualizar_Click;
            btnFiltrar.Click         += btnFiltrar_Click;

            // Botón "Volver al inicio" (solo visible en grilla)
            btnVolverDashboard.Click += (s, e) => MostrarVistaDashboard();
        }

        // ══════════════════════════════════════════════════════════════
        //  NAVEGACIÓN ENTRE VISTAS
        // ══════════════════════════════════════════════════════════════
        private void MostrarVistaDashboard()
        {
            _enVistaGrilla = false;

            // Panel de toolbar: solo título + botón Nuevo en dashboard
            pnlFiltroFechas.Visible      = false;
            btnEliminarAsiento.Visible   = false;
            btnEditarAsiento.Visible     = false;
            btnSubirAsiento.Visible      = false;
            btnBajarAsiento.Visible      = false;
            btnCargarEjemplo.Visible     = false;
            btnActualizar.Visible        = false;
            btnFiltrar.Visible           = false;
            btnVolverDashboard.Visible   = false;
            btnNuevoAsiento.Visible      = true;

            lblTituloSeccion.Text = "LIBRO DIARIO";

            // Mostrar dashboard, ocultar grilla y footer
            pnlDashboard.Visible         = true;
            pnlDashboard.Dock            = DockStyle.Fill;
            pnlGrillaContenedor.Visible  = false;
            pnlResumenInferior.Visible   = false;

            RefrescarDashboard();
        }

        private void MostrarVistaGrilla()
        {
            _enVistaGrilla = true;

            // Mostrar controles de toolbar completos
            pnlFiltroFechas.Visible      = true;
            btnEliminarAsiento.Visible   = true;
            btnEditarAsiento.Visible     = true;
            btnSubirAsiento.Visible      = true;
            btnBajarAsiento.Visible      = true;
            btnCargarEjemplo.Visible     = true;
            btnActualizar.Visible        = true;
            btnFiltrar.Visible           = true;
            btnVolverDashboard.Visible   = true;
            btnNuevoAsiento.Visible      = true;

            lblTituloSeccion.Text = "Libro Diario — Detalle";

            // Mostrar grilla y footer, ocultar dashboard
            pnlDashboard.Visible         = false;
            pnlGrillaContenedor.Visible  = true;
            pnlResumenInferior.Visible   = true;

            CargarDatos();
        }

        // ══════════════════════════════════════════════════════════════
        //  DASHBOARD — Panel de inicio estilo Kardex
        // ══════════════════════════════════════════════════════════════
        private void RefrescarDashboard()
        {
            // Encabezado
            lblDashTitulo.Text    = "Libro Diario";
            lblDashSubtitulo.Text = "Selecciona un asiento para ver su detalle o registra uno nuevo.";

            // Contar y mostrar badge
            var asientos = _servicio.ObtenerAsientos();
            lblBadgeTotal.Text = $"  {asientos.Count} Asiento(s)  ";

            // Poblar lista de asientos recientes
            lstAsientos.Items.Clear();

            if (!asientos.Any())
            {
                lstAsientos.Items.Add(new AsientoListItem
                {
                    Numero       = 0,
                    FechaTexto   = "—",
                    Concepto     = "No hay asientos registrados aún.",
                    TotalDebe    = 0,
                    EsPlaceholder = true
                });
                return;
            }

            // Agrupar por HOY y ANTERIORES (como en Kardex)
            var hoy        = DateTime.Today;
            var deHoy      = asientos.Where(a => a.Fecha.Date == hoy).OrderByDescending(a => a.NumeroAsiento).ToList();
            var anteriores = asientos.Where(a => a.Fecha.Date != hoy).OrderByDescending(a => a.NumeroAsiento).ToList();

            if (deHoy.Any())
            {
                lstAsientos.Items.Add(new AsientoListItem { EsEncabezadoGrupo = true, Concepto = "HOY" });
                foreach (var a in deHoy)
                    lstAsientos.Items.Add(AsientoAListItem(a));
            }

            if (anteriores.Any())
            {
                lstAsientos.Items.Add(new AsientoListItem { EsEncabezadoGrupo = true, Concepto = "ANTERIORES" });
                foreach (var a in anteriores)
                    lstAsientos.Items.Add(AsientoAListItem(a));
            }
        }

        private static AsientoListItem AsientoAListItem(AsientoContable a) => new()
        {
            Numero      = a.NumeroAsiento,
            FechaTexto  = a.Fecha.ToString("dd/MM/yyyy"),
            Concepto    = $"Asiento N° {a.NumeroAsiento} — {a.Concepto}",
            TotalDebe   = a.TotalDebe,
            EstaCuadrado = a.EstaCuadrado,
            CuentasPrinc = string.Join(", ",
                a.Movimientos.Select(m => m.CuentaPrincipal).Distinct().Take(3))
        };

        // ══════════════════════════════════════════════════════════════
        //  GRILLA — Carga y pintado
        // ══════════════════════════════════════════════════════════════
        private void CargarDatos(DateTime? desde = null, DateTime? hasta = null)
        {
            _filasActuales = _servicio.GenerarFilasVisuales(desde, hasta);
            dgvLibroDiario.Rows.Clear();

            foreach (var fila in _filasActuales)
            {
                int index = dgvLibroDiario.Rows.Add(
                    fila.Fecha,
                    fila.Cuenta,
                    fila.Parcial.HasValue  ? fila.Parcial.Value.ToString("N2")  : string.Empty,
                    fila.Debe.HasValue     ? fila.Debe.Value.ToString("N2")     : string.Empty,
                    fila.Haber.HasValue    ? fila.Haber.Value.ToString("N2")    : string.Empty
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
                    row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
                    row.DefaultCellStyle.Font      = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;
                case TipoFilaVisual.Subcuenta:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font      = new Font("Segoe UI", 9f);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
                    break;
                case TipoFilaVisual.CuentaPrincipal:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font      = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;
                case TipoFilaVisual.ConceptoGlosa:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font      = new Font("Segoe UI", 8.5f, FontStyle.Italic);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
                    break;
                case TipoFilaVisual.Separador:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    row.Height = 12;
                    break;
                case TipoFilaVisual.TotalSumasIguales:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
                    row.DefaultCellStyle.Font      = new Font("Segoe UI", 10f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;
            }
        }

        private void DgvLibroDiario_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLibroDiario.Rows.Count) return;
            var row = dgvLibroDiario.Rows[e.RowIndex];
            if (row.Tag is not FilaLibroDiarioVisual fila) return;

            if (e.CellStyle != null && e.ColumnIndex == colFecha.Index && !string.IsNullOrEmpty(fila.Fecha))
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ActualizarBarraResumen()
        {
            var asientos  = _servicio.ObtenerAsientos();
            decimal debe  = asientos.Sum(a => a.TotalDebe);
            decimal haber = asientos.Sum(a => a.TotalHaber);

            lblTotalAsientos.Text    = $"Total Asientos: {asientos.Count}";
            lblTotalDebeGlobal.Text  = $"Total Debe: {debe:C2}";
            lblTotalHaberGlobal.Text = $"Total Haber: {haber:C2}";

            bool cuadradas = asientos.All(a => a.EstaCuadrado);
            if (cuadradas && asientos.Any())
            {
                lblBadgeEstado.Text      = "✓ Asientos Dobles Cuadrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else if (!asientos.Any())
            {
                lblBadgeEstado.Text      = "Sin asientos registrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else
            {
                lblBadgeEstado.Text      = "⚠ Advertencia: Asientos descuadrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  ACCIONES
        // ══════════════════════════════════════════════════════════════
        private void AbrirNuevoAsiento()
        {
            using var dlg = new frmAgregarAsiento();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                if (_enVistaGrilla) CargarDatos();
                else { RefrescarDashboard(); }
            }
        }

        private void btnEliminarAsiento_Click(object? sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0)
            {
                MessageBox.Show("Por favor seleccione una fila del asiento a eliminar.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show(
                $"¿Eliminar el Asiento N° {fila.NumeroAsiento}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (r == DialogResult.Yes && _servicio.EliminarAsiento(fila.NumeroAsiento))
                CargarDatos();
        }

        private void btnEditarAsiento_Click(object? sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0)
            {
                MessageBox.Show("Por favor seleccione una fila del asiento a editar.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var asiento = _servicio.ObtenerAsientos().FirstOrDefault(a => a.NumeroAsiento == fila.NumeroAsiento);
            if (asiento != null)
            {
                using var dlg = new frmAgregarAsiento(asiento);
                if (dlg.ShowDialog(this) == DialogResult.OK) CargarDatos();
            }
        }

        private void btnSubirAsiento_Click(object? sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0) return;
            _servicio.MoverAsientoArriba(fila.NumeroAsiento);
            CargarDatos();
        }

        private void btnBajarAsiento_Click(object? sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0) return;
            _servicio.MoverAsientoAbajo(fila.NumeroAsiento);
            CargarDatos();
        }

        private void btnCargarEjemplo_Click(object? sender, EventArgs e)
        {
            _servicio.CargarAsientosEjemplo();
            if (_enVistaGrilla) CargarDatos();
            else RefrescarDashboard();
            MessageBox.Show("Se han cargado los asientos de ejemplo.", "Libro Diario",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnActualizar_Click(object? sender, EventArgs e) => CargarDatos();

        private void btnFiltrar_Click(object? sender, EventArgs e)
            => CargarDatos(dtpFechaInicio.Value.Date, dtpFechaFin.Value.Date);

        // ── Métodos auxiliares del Dashboard ─────────────────────────
        internal void FiltrarListaDash(string q)
        {
            var asientos = _servicio.ObtenerAsientos();
            lstAsientos.Items.Clear();

            var filtrados = string.IsNullOrWhiteSpace(q)
                ? asientos
                : asientos.Where(a =>
                    a.Concepto.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    a.NumeroAsiento.ToString().Contains(q)).ToList();

            if (!filtrados.Any())
            {
                lstAsientos.Items.Add(new AsientoListItem { EsPlaceholder = true, Concepto = "No se encontraron resultados." });
                return;
            }

            foreach (var a in filtrados.OrderByDescending(a => a.NumeroAsiento))
                lstAsientos.Items.Add(AsientoAListItem(a));
        }

        internal void CargarEjemploYRefrescar()
        {
            _servicio.CargarAsientosEjemplo();
            RefrescarDashboard();
        }

        internal void LimpiarAsientos()
        {
            var r = MessageBox.Show(
                "¿Deseas eliminar TODOS los asientos de la sesión actual?\nEsta acción no se puede deshacer.",
                "Confirmar limpieza", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                _servicio.LimpiarTodos();
                RefrescarDashboard();
            }
        }
    }

    // ══════════════════════════════════════════════════════════════════
    //  Modelo ligero para el ListBox del Dashboard
    // ══════════════════════════════════════════════════════════════════
    internal class AsientoListItem
    {
        public int    Numero            { get; set; }
        public string FechaTexto        { get; set; } = "";
        public string Concepto          { get; set; } = "";
        public string CuentasPrinc      { get; set; } = "";
        public decimal TotalDebe        { get; set; }
        public bool   EstaCuadrado      { get; set; }
        public bool   EsEncabezadoGrupo { get; set; }
        public bool   EsPlaceholder     { get; set; }
    }

    // ══════════════════════════════════════════════════════════════════
    //  ListBox personalizado con diseño tipo Kardex
    // ══════════════════════════════════════════════════════════════════
    internal class AsientoListBox : ListBox
    {
        private static readonly Font _fntGrupo   = new("Segoe UI", 8f, FontStyle.Bold);
        private static readonly Font _fntConcepto = new("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        private static readonly Font _fntSub      = new("Segoe UI", 8.5f);
        private static readonly Font _fntFecha    = new("Segoe UI", 8f);
        private static readonly Font _fntPlaceholder = new("Segoe UI", 9f, FontStyle.Italic);

        public AsientoListBox()
        {
            DrawMode      = DrawMode.OwnerDrawVariable;
            BorderStyle   = BorderStyle.None;
            BackColor     = Color.FromArgb(248, 250, 252);
            ItemHeight    = 70;
            SelectionMode = SelectionMode.One;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count) return;
            var item = Items[e.Index] as AsientoListItem;
            if (item == null) return;

            e.ItemHeight = item.EsEncabezadoGrupo ? 28 : (item.EsPlaceholder ? 56 : 72);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count) return;
            var item = Items[e.Index] as AsientoListItem;
            if (item == null) return;

            var g      = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var bounds = e.Bounds;

            // ── Encabezado de grupo (HOY / ANTERIORES) ────────────────
            if (item.EsEncabezadoGrupo)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(241, 245, 249)), bounds);
                g.DrawString(item.Concepto, _fntGrupo,
                    new SolidBrush(Color.FromArgb(100, 116, 139)),
                    bounds.X + 16, bounds.Y + 8);

                using var penLine = new Pen(Color.FromArgb(226, 232, 240));
                g.DrawLine(penLine, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
                return;
            }

            // ── Placeholder (sin asientos) ────────────────────────────
            if (item.EsPlaceholder)
            {
                g.FillRectangle(Brushes.White, bounds);
                g.DrawString(item.Concepto, _fntPlaceholder,
                    new SolidBrush(Color.FromArgb(148, 163, 184)),
                    bounds.X + 20, bounds.Y + 18);
                return;
            }

            // ── Item normal ───────────────────────────────────────────
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color bg = selected ? Color.FromArgb(224, 234, 250) : Color.White;
            g.FillRectangle(new SolidBrush(bg), bounds);

            // Borde izquierdo color según estado
            Color accent = item.EstaCuadrado ? Color.FromArgb(37, 99, 235) : Color.FromArgb(220, 38, 38);
            g.FillRectangle(new SolidBrush(accent), bounds.X, bounds.Y + 4, 4, bounds.Height - 8);

            int x = bounds.X + 16;
            int y = bounds.Y + 8;

            // Concepto (negrita)
            g.DrawString(item.Concepto, _fntConcepto,
                new SolidBrush(Color.FromArgb(15, 23, 42)), x, y);
            y += 20;

            // Cuentas
            if (!string.IsNullOrWhiteSpace(item.CuentasPrinc))
            {
                g.DrawString(item.CuentasPrinc, _fntSub,
                    new SolidBrush(Color.FromArgb(71, 85, 105)), x, y);
                y += 16;
            }

            // Fecha + monto
            string monto = item.TotalDebe.ToString("C2");
            g.DrawString($"Fecha: {item.FechaTexto}", _fntFecha,
                new SolidBrush(Color.FromArgb(100, 116, 139)), x, y);

            // Badge cuadrado
            string badge = item.EstaCuadrado ? "✓ Cuadrado" : "⚠ Descuadrado";
            Color  badgeBg   = item.EstaCuadrado ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
            Color  badgeFg   = item.EstaCuadrado ? Color.FromArgb(22, 101, 52)   : Color.FromArgb(153, 27, 27);
            var sz           = TextRenderer.MeasureText(badge, _fntFecha);
            var badgeRect    = new Rectangle(bounds.Right - sz.Width - 28, bounds.Y + 10, sz.Width + 16, 20);
            using var path   = RoundedRect(badgeRect, 6);
            g.FillPath(new SolidBrush(badgeBg), path);
            g.DrawString(badge, _fntFecha, new SolidBrush(badgeFg),
                badgeRect.X + 6, badgeRect.Y + 3);

            // Total Debe (esquina inferior derecha)
            g.DrawString(monto, _fntConcepto,
                new SolidBrush(Color.FromArgb(30, 64, 175)),
                bounds.Right - 100, bounds.Bottom - 22);

            // Línea divisoria
            using var pen = new Pen(Color.FromArgb(241, 245, 249));
            g.DrawLine(pen, bounds.X + 16, bounds.Bottom - 1, bounds.Right - 16, bounds.Bottom - 1);
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(r.X, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
