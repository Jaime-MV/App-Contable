using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_Contable.Datos;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmLibroDiario : Form
    {
        private readonly LibroDiarioServicio _servicio = LibroDiarioServicio.Instancia;
        private readonly LibroDiarioStorageService _storageService = new();
        private List<FilaLibroDiarioVisual> _filasActuales = new();
        private LibroDiarioInstancia? _instanciaActiva;

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
            btnVolverDashboard.Click += (s, e) => VolverAlDashboard();

            // Eventos de panel lateral derecho del Dashboard
            btnDashNuevo.Click     += btnCrearLibro_Click;
            btnDashGuardarBD.Click += btnGuardarBD_Click;
            btnDashEliminar.Click  += btnEliminarLibro_Click;

            // Búsqueda en vivo en dashboard
            txtBuscarDash.TextChanged += (s, e) => RefrescarDashboard();

            // Doble clic en la lista para abrir libro
            lstLibros.DoubleClick += (s, e) =>
            {
                var libro = ObtenerLibroSeleccionado();
                if (libro != null)
                {
                    AbrirInstanciaLibro(libro);
                }
            };

            // Bordes y divisores personalizados en paneles
            pnlToolbar.Paint += PnlToolbar_Paint;
            pnlDashHeader.Paint += PnlDashHeader_Paint;
            pnlAcciones.Paint += PnlAcciones_Paint;
            pnlResumenInferior.Paint += PnlResumenInferior_Paint;
        }

        private void PnlToolbar_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, pnl.Height - 1, pnl.Width, pnl.Height - 1);
            }
        }

        private void PnlDashHeader_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, pnl.Height - 1, pnl.Width, pnl.Height - 1);
            }
        }

        private void PnlAcciones_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, 0, pnl.Height);
            }
        }

        private void PnlResumenInferior_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, pnl.Width, 0);
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  NAVEGACIÓN ENTRE VISTAS
        // ══════════════════════════════════════════════════════════════
        private void MostrarVistaDashboard()
        {
            // Toolbar en dashboard
            pnlFiltroFechas.Visible      = false;
            btnEliminarAsiento.Visible   = false;
            btnEditarAsiento.Visible     = false;
            btnSubirAsiento.Visible      = false;
            btnBajarAsiento.Visible      = false;
            btnCargarEjemplo.Visible     = false;
            btnActualizar.Visible        = false;
            btnFiltrar.Visible           = false;
            btnVolverDashboard.Visible   = false;
            btnNuevoAsiento.Visible      = false;

            lblTituloSeccion.Text = "GESTIÓN DE LIBROS DIARIOS";

            // Mostrar dashboard, ocultar grilla y footer
            pnlDashboard.Visible         = true;
            pnlDashboard.Dock            = DockStyle.Fill;
            pnlGrillaContenedor.Visible  = false;
            pnlResumenInferior.Visible   = false;

            RefrescarDashboard();
        }

        private void MostrarVistaGrilla()
        {
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

            lblTituloSeccion.Text = _instanciaActiva != null
                ? $"LIBRO DIARIO — {_instanciaActiva.Nombre.ToUpper()}"
                : "LIBRO DIARIO — DETALLE";

            // Mostrar grilla y footer, ocultar dashboard
            pnlDashboard.Visible         = false;
            pnlGrillaContenedor.Visible  = true;
            pnlResumenInferior.Visible   = true;

            CargarDatos();
        }

        private void AbrirInstanciaLibro(LibroDiarioInstancia instancia)
        {
            _instanciaActiva = instancia;

            // Sincronizar fechas del libro
            dtpFechaInicio.Value = instancia.FechaInicio;
            dtpFechaFin.Value    = instancia.FechaFin;

            // Cargar asientos de la instancia en el servicio
            _servicio.LimpiarTodos();
            foreach (var asiento in instancia.Asientos)
            {
                _servicio.AgregarAsiento(asiento, out _);
            }

            MostrarVistaGrilla();
        }

        private void VolverAlDashboard()
        {
            if (_instanciaActiva != null)
            {
                // Persistir asientos actuales en la instancia
                _instanciaActiva.Asientos = _servicio.ObtenerAsientos().ToList();
                _instanciaActiva.FechaModificacion = DateTime.Now;
                _storageService.GuardarLibro(_instanciaActiva);
            }

            MostrarVistaDashboard();
        }

        // ══════════════════════════════════════════════════════════════
        //  DASHBOARD — Gestión de Instancias de Libros Diarios
        // ══════════════════════════════════════════════════════════════
        private void RefrescarDashboard()
        {
            var libros = _storageService.ObtenerLibros();
            string filtro = txtBuscarDash.Text.Trim();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                libros = libros.Where(l =>
                    l.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    l.Empresa.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    l.TextoPeriodo.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            lblBadgeTotal.Text = $"  {libros.Count} Libro(s)  ";
            lstLibros.Items.Clear();

            if (!libros.Any())
            {
                lstLibros.Items.Add(new LibroDiarioListItem
                {
                    Titulo = "No hay libros diarios registrados aún.",
                    Subtitulo = "Crea un nuevo libro desde el menú de la derecha.",
                    EsPlaceholder = true
                });
                return;
            }

            // Agrupar por grupo temporal ("Hoy", "Esta semana", "Este mes", "Anteriores")
            var grupos = libros.GroupBy(l => l.GrupoTemporal).ToList();

            foreach (var grupo in grupos)
            {
                lstLibros.Items.Add(new LibroDiarioListItem
                {
                    EsEncabezadoGrupo = true,
                    Titulo = grupo.Key.ToUpper()
                });

                foreach (var libro in grupo)
                {
                    lstLibros.Items.Add(new LibroDiarioListItem
                    {
                        Instancia = libro,
                        Titulo = libro.Nombre,
                        Subtitulo = libro.DescripcionSecundaria,
                        BadgeTexto = libro.TextoBadgeDestino,
                        Destino = libro.DestinoGuardado,
                        FechaModTexto = $"Modificado: {libro.FechaModificacion:dd/MM/yyyy HH:mm}",
                        TotalDebe = libro.TotalDebe,
                        CantidadAsientos = libro.Asientos.Count
                    });
                }
            }
        }

        private LibroDiarioInstancia? ObtenerLibroSeleccionado()
        {
            if (lstLibros.SelectedItem is LibroDiarioListItem item && !item.EsEncabezadoGrupo && !item.EsPlaceholder)
            {
                return item.Instancia;
            }
            return null;
        }

        // ══════════════════════════════════════════════════════════════
        //  ACCIONES DEL DASHBOARD
        // ══════════════════════════════════════════════════════════════

        private void btnCrearLibro_Click(object? sender, EventArgs e)
        {
            using var modal = new frmCrearLibroDiarioModal();
            if (modal.ShowDialog(this) == DialogResult.OK && modal.InstanciaCreada != null)
            {
                _storageService.GuardarLibro(modal.InstanciaCreada);
                RefrescarDashboard();
                AbrirInstanciaLibro(modal.InstanciaCreada);
            }
        }

        private async void btnGuardarBD_Click(object? sender, EventArgs e)
        {
            var libro = ObtenerLibroSeleccionado();
            if (libro == null)
            {
                MessageBox.Show(
                    "Por favor seleccione un Libro Diario de la lista para sincronizar con la Base de Datos.",
                    "Seleccionar Libro Diario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                btnDashGuardarBD.Enabled = false;

                bool exito = await _storageService.GuardarEnBaseDatosAsync(libro);
                if (exito)
                {
                    MessageBox.Show(
                        "Módulo de persistencia en PostgreSQL en cola de implementación.\n\n" +
                        $"• Libro Diario: '{libro.Nombre}'\n" +
                        $"• Empresa: {(string.IsNullOrWhiteSpace(libro.Empresa) ? "General" : libro.Empresa)}\n" +
                        $"• Período: {libro.TextoPeriodo}\n" +
                        $"• Asientos registrados: {libro.Asientos.Count}\n" +
                        $"• Destino: {libro.TextoBadgeDestino}\n\n" +
                        "La instancia se encuentra actualmente almacenada localmente en memoria de forma segura.",
                        "Sincronización con Base de Datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                btnDashGuardarBD.Enabled = true;
            }
        }

        private void btnEliminarLibro_Click(object? sender, EventArgs e)
        {
            var libro = ObtenerLibroSeleccionado();
            if (libro == null)
            {
                MessageBox.Show(
                    "Por favor seleccione un Libro Diario de la lista para eliminar.",
                    "Seleccionar Libro Diario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar la instancia seleccionada?\n\n" +
                $"• Nombre: {libro.Nombre}\n" +
                $"• Empresa: {(string.IsNullOrWhiteSpace(libro.Empresa) ? "General" : libro.Empresa)}\n" +
                $"• Período: {libro.TextoPeriodo}\n" +
                $"• Asientos registrados: {libro.Asientos.Count}\n\n" +
                "Esta acción eliminará el libro de la lista y de la memoria local. ¿Desea continuar?",
                "Confirmar Eliminación de Libro Diario",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                _storageService.EliminarLibro(libro.Id);
                RefrescarDashboard();

                MessageBox.Show(
                    $"El libro diario '{libro.Nombre}' ha sido eliminado exitosamente.",
                    "Libro Diario Eliminado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

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
            {
                e.CellStyle.ForeColor = Color.FromArgb(71, 85, 105);
                e.CellStyle.Font      = new Font("Segoe UI", 9f, FontStyle.Regular);
            }
        }

        private void ActualizarBarraResumen()
        {
            var asientos = _servicio.ObtenerAsientos();
            decimal totalDebe  = asientos.Sum(a => a.TotalDebe);
            decimal totalHaber = asientos.Sum(a => a.TotalHaber);
            bool todosCuadrados = asientos.All(a => a.EstaCuadrado);

            lblTotalAsientos.Text    = $"Asientos: {asientos.Count}";
            lblTotalDebeGlobal.Text  = $"Total Debe: {totalDebe:C2}";
            lblTotalHaberGlobal.Text = $"Total Haber: {totalHaber:C2}";

            if (!asientos.Any())
            {
                lblBadgeEstado.Text      = "Sin asientos registrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else if (todosCuadrados && Math.Round(totalDebe, 2) == Math.Round(totalHaber, 2))
            {
                lblBadgeEstado.Text      = "✓ Asientos Dobles Cuadrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                lblBadgeEstado.Text      = "⚠ Hay asientos descuadrados";
                lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        // ══════════════════════════════════════════════════════════════
        //  TOOLBAR EN GRILLA
        // ══════════════════════════════════════════════════════════════
        private void AbrirNuevoAsiento()
        {
            using var form = new frmAgregarAsiento();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                CargarDatos();
                if (_instanciaActiva != null)
                {
                    _instanciaActiva.Asientos = _servicio.ObtenerAsientos().ToList();
                    _storageService.GuardarLibro(_instanciaActiva);
                }
            }
        }

        private void btnEditarAsiento_Click(object? sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0)
            {
                MessageBox.Show("Por favor, seleccione una fila perteneciente a un asiento para editar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var asiento = _servicio.ObtenerAsientos().FirstOrDefault(a => a.NumeroAsiento == fila.NumeroAsiento);
            if (asiento == null) return;

            using var form = new frmAgregarAsiento(asiento);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                CargarDatos();
                if (_instanciaActiva != null)
                {
                    _instanciaActiva.Asientos = _servicio.ObtenerAsientos().ToList();
                    _storageService.GuardarLibro(_instanciaActiva);
                }
            }
        }

        private void btnEliminarAsiento_Click(object? sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is not FilaLibroDiarioVisual fila || fila.NumeroAsiento <= 0)
            {
                MessageBox.Show("Por favor, seleccione un asiento para eliminar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Está seguro de eliminar el Asiento N° {fila.NumeroAsiento}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _servicio.EliminarAsiento(fila.NumeroAsiento);
                CargarDatos();
                if (_instanciaActiva != null)
                {
                    _instanciaActiva.Asientos = _servicio.ObtenerAsientos().ToList();
                    _storageService.GuardarLibro(_instanciaActiva);
                }
            }
        }

        private void btnSubirAsiento_Click(object? sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is FilaLibroDiarioVisual fila && fila.NumeroAsiento > 0)
            {
                _servicio.MoverAsientoArriba(fila.NumeroAsiento);
                CargarDatos();
                if (_instanciaActiva != null)
                {
                    _instanciaActiva.Asientos = _servicio.ObtenerAsientos().ToList();
                    _storageService.GuardarLibro(_instanciaActiva);
                }
            }
        }

        private void btnBajarAsiento_Click(object? sender, EventArgs e)
        {
            if (dgvLibroDiario.CurrentRow?.Tag is FilaLibroDiarioVisual fila && fila.NumeroAsiento > 0)
            {
                _servicio.MoverAsientoAbajo(fila.NumeroAsiento);
                CargarDatos();
                if (_instanciaActiva != null)
                {
                    _instanciaActiva.Asientos = _servicio.ObtenerAsientos().ToList();
                    _storageService.GuardarLibro(_instanciaActiva);
                }
            }
        }

        private void btnCargarEjemplo_Click(object? sender, EventArgs e)
        {
            _servicio.CargarAsientosEjemplo();
            CargarDatos();
            if (_instanciaActiva != null)
            {
                _instanciaActiva.Asientos = _servicio.ObtenerAsientos().ToList();
                _storageService.GuardarLibro(_instanciaActiva);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e) => CargarDatos();

        private void btnFiltrar_Click(object? sender, EventArgs e) =>
            CargarDatos(dtpFechaInicio.Value, dtpFechaFin.Value);
    }

    // ══════════════════════════════════════════════════════════════════
    //  ITEM Y LISTBOX PERSONALIZADO DE INSTANCIAS DE LIBRO DIARIO
    // ══════════════════════════════════════════════════════════════════

    public class LibroDiarioListItem
    {
        public LibroDiarioInstancia? Instancia { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Subtitulo { get; set; } = string.Empty;
        public string BadgeTexto { get; set; } = string.Empty;
        public TipoDestinoLibro Destino { get; set; } = TipoDestinoLibro.Local;
        public string FechaModTexto { get; set; } = string.Empty;
        public decimal TotalDebe { get; set; }
        public int CantidadAsientos { get; set; }
        public bool EsEncabezadoGrupo { get; set; }
        public bool EsPlaceholder { get; set; }
    }

    public class LibroDiarioInstanciaListBox : ListBox
    {
        private static readonly Font _fntTitulo = new("Segoe UI Semibold", 10.5f, FontStyle.Bold);
        private static readonly Font _fntSub = new("Segoe UI", 8.5f);
        private static readonly Font _fntBadge = new("Segoe UI", 8f, FontStyle.Regular);
        private static readonly Font _fntFecha = new("Segoe UI", 8f);
        private static readonly Font _fntMonto = new("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        private static readonly Font _fntGrupo = new("Segoe UI", 8.5f, FontStyle.Bold);
        private static readonly Font _fntPlaceholder = new("Segoe UI", 9.5f, FontStyle.Italic);

        public LibroDiarioInstanciaListBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            DoubleBuffered = true;
            BorderStyle = BorderStyle.None;
            ItemHeight = 74;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count) return;
            if (Items[e.Index] is LibroDiarioListItem item && item.EsEncabezadoGrupo)
                e.ItemHeight = 28;
            else
                e.ItemHeight = 74;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count) return;
            if (Items[e.Index] is not LibroDiarioListItem item) return;

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var bounds = e.Bounds;

            // 1. Encabezado de grupo ("HOY", "ANTERIORES", etc.)
            if (item.EsEncabezadoGrupo)
            {
                using var brBg = new SolidBrush(Color.FromArgb(241, 245, 249));
                g.FillRectangle(brBg, bounds);
                using var brText = new SolidBrush(Color.FromArgb(100, 116, 139));
                g.DrawString(item.Titulo, _fntGrupo, brText, bounds.X + 16, bounds.Y + 6);

                using var penLine = new Pen(Color.FromArgb(226, 232, 240));
                g.DrawLine(penLine, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
                return;
            }

            // 2. Placeholder cuando no hay items
            if (item.EsPlaceholder)
            {
                g.FillRectangle(Brushes.White, bounds);
                using var brText = new SolidBrush(Color.FromArgb(148, 163, 184));
                g.DrawString(item.Titulo, _fntPlaceholder, brText, bounds.X + 20, bounds.Y + 16);
                g.DrawString(item.Subtitulo, _fntSub, brText, bounds.X + 20, bounds.Y + 38);
                return;
            }

            // 3. Item normal de Libro Diario
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color bg = selected ? Color.FromArgb(239, 246, 255) : Color.White;
            using (var brBg = new SolidBrush(bg))
            {
                g.FillRectangle(brBg, bounds);
            }

            // Borde izquierdo azul corporativo
            using (var brAccent = new SolidBrush(Color.FromArgb(37, 99, 235)))
            {
                g.FillRectangle(brAccent, bounds.X, bounds.Y + 4, 4, bounds.Height - 8);
            }

            int x = bounds.X + 16;
            int y = bounds.Y + 10;

            // Título del libro
            using (var brTitulo = new SolidBrush(Color.FromArgb(15, 23, 42)))
            {
                g.DrawString(item.Titulo, _fntTitulo, brTitulo, x, y);
            }
            y += 22;

            // Subtítulo (Empresa y Período)
            using (var brSub = new SolidBrush(Color.FromArgb(71, 85, 105)))
            {
                g.DrawString(item.Subtitulo, _fntSub, brSub, x, y);
            }
            y += 18;

            // Badge de Destino ([Local] o [BD - Pendiente])
            bool esLocal = item.Destino == TipoDestinoLibro.Local;
            Color badgeBg = esLocal ? Color.FromArgb(241, 245, 249) : Color.FromArgb(239, 246, 255);
            Color badgeBorder = esLocal ? Color.FromArgb(203, 213, 225) : Color.FromArgb(191, 219, 254);
            Color badgeFg = esLocal ? Color.FromArgb(51, 65, 85) : Color.FromArgb(29, 78, 216);

            var badgeSize = TextRenderer.MeasureText(item.BadgeTexto, _fntBadge);
            var badgeRect = new Rectangle(x, y - 1, badgeSize.Width + 10, 18);

            using (var brBdg = new SolidBrush(badgeBg))
            using (var penBdg = new Pen(badgeBorder))
            {
                g.FillRectangle(brBdg, badgeRect);
                g.DrawRectangle(penBdg, badgeRect.Left, badgeRect.Top, badgeRect.Width - 1, badgeRect.Height - 1);
            }

            using (var brFg = new SolidBrush(badgeFg))
            {
                g.DrawString(item.BadgeTexto, _fntBadge, brFg, badgeRect.X + 5, badgeRect.Y + 1);
            }

            // Fecha de última modificación
            using (var brFecha = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                g.DrawString(item.FechaModTexto, _fntFecha, brFecha, badgeRect.Right + 12, y + 1);
            }

            // Monto Total (Debe) en la esquina superior/media derecha
            string montoTexto = item.TotalDebe > 0 ? item.TotalDebe.ToString("C2") : "$0.00";
            using (var brMonto = new SolidBrush(Color.FromArgb(30, 64, 175)))
            {
                var szMonto = TextRenderer.MeasureText(montoTexto, _fntMonto);
                g.DrawString(montoTexto, _fntMonto, brMonto, bounds.Right - szMonto.Width - 24, bounds.Y + 14);
            }

            // Línea divisoria inferior
            using (var penDiv = new Pen(Color.FromArgb(241, 245, 249)))
            {
                g.DrawLine(penDiv, bounds.X + 16, bounds.Bottom - 1, bounds.Right - 16, bounds.Bottom - 1);
            }
        }
    }
}
