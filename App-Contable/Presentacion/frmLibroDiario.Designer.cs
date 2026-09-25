namespace App_Contable.Presentacion
{
    partial class frmLibroDiario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle cs1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cs2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cs3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cs4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cs5 = new System.Windows.Forms.DataGridViewCellStyle();

            // ── Controls ──────────────────────────────────────────────
            this.pnlToolbar          = new System.Windows.Forms.Panel();
            this.lblTituloSeccion    = new System.Windows.Forms.Label();
            this.pnlFiltroFechas     = new System.Windows.Forms.Panel();
            this.lblPeriodo          = new System.Windows.Forms.Label();
            this.dtpFechaInicio      = new System.Windows.Forms.DateTimePicker();
            this.lblFlechaRango      = new System.Windows.Forms.Label();
            this.dtpFechaFin         = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar          = new System.Windows.Forms.Button();
            this.btnNuevoAsiento     = new System.Windows.Forms.Button();
            this.btnEliminarAsiento  = new System.Windows.Forms.Button();
            this.btnEditarAsiento    = new System.Windows.Forms.Button();
            this.btnCargarEjemplo    = new System.Windows.Forms.Button();
            this.btnBajarAsiento     = new System.Windows.Forms.Button();
            this.btnSubirAsiento     = new System.Windows.Forms.Button();
            this.btnActualizar       = new System.Windows.Forms.Button();
            this.btnVolverDashboard  = new System.Windows.Forms.Button();
            // Dashboard panel
            this.pnlDashboard        = new System.Windows.Forms.Panel();
            this.pnlDashHeader       = new System.Windows.Forms.Panel();
            this.lblDashTitulo       = new System.Windows.Forms.Label();
            this.lblDashSubtitulo    = new System.Windows.Forms.Label();
            this.lblBadgeTotal       = new System.Windows.Forms.Label();
            this.pnlDashContent      = new System.Windows.Forms.Panel();
            this.pnlListaAsientos    = new System.Windows.Forms.Panel();
            this.lblListaHeader      = new System.Windows.Forms.Label();
            this.txtBuscarDash       = new System.Windows.Forms.TextBox();
            this.lstAsientos         = new App_Contable.Presentacion.AsientoListBox();
            this.pnlAcciones         = new System.Windows.Forms.Panel();
            this.lblAccionesHeader   = new System.Windows.Forms.Label();
            this.btnDashNuevo        = new System.Windows.Forms.Button();
            this.btnDashEjemplo      = new System.Windows.Forms.Button();
            this.btnDashVerLibro     = new System.Windows.Forms.Button();
            this.btnDashLimpiar      = new System.Windows.Forms.Button();
            // Grilla
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvLibroDiario      = new System.Windows.Forms.DataGridView();
            this.colFecha            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuenta           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParcial          = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebe             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHaber            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            // Footer
            this.pnlResumenInferior  = new System.Windows.Forms.Panel();
            this.lblBadgeEstado      = new System.Windows.Forms.Label();
            this.lblTotalHaberGlobal = new System.Windows.Forms.Label();
            this.lblTotalDebeGlobal  = new System.Windows.Forms.Label();
            this.lblTotalAsientos    = new System.Windows.Forms.Label();

            this.pnlToolbar.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlDashHeader.SuspendLayout();
            this.pnlDashContent.SuspendLayout();
            this.pnlListaAsientos.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibroDiario)).BeginInit();
            this.pnlResumenInferior.SuspendLayout();
            this.SuspendLayout();

            // ══ pnlToolbar ════════════════════════════════════════════
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnSubirAsiento);
            this.pnlToolbar.Controls.Add(this.btnBajarAsiento);
            this.pnlToolbar.Controls.Add(this.btnEditarAsiento);
            this.pnlToolbar.Controls.Add(this.btnActualizar);
            this.pnlToolbar.Controls.Add(this.btnCargarEjemplo);
            this.pnlToolbar.Controls.Add(this.btnEliminarAsiento);
            this.pnlToolbar.Controls.Add(this.btnNuevoAsiento);
            this.pnlToolbar.Controls.Add(this.btnVolverDashboard);
            this.pnlToolbar.Controls.Add(this.pnlFiltroFechas);
            this.pnlToolbar.Controls.Add(this.lblTituloSeccion);
            this.pnlToolbar.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Name     = "pnlToolbar";
            this.pnlToolbar.Padding  = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size     = new System.Drawing.Size(1100, 72);
            this.pnlToolbar.TabIndex = 0;
            this.pnlToolbar.Paint += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, ((System.Windows.Forms.Panel)s!).Height - 1,
                    ((System.Windows.Forms.Panel)s!).Width, ((System.Windows.Forms.Panel)s!).Height - 1);
            };

            // lblTituloSeccion
            this.lblTituloSeccion.AutoSize  = true;
            this.lblTituloSeccion.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTituloSeccion.Location  = new System.Drawing.Point(16, 24);
            this.lblTituloSeccion.Name      = "lblTituloSeccion";
            this.lblTituloSeccion.Text      = "LIBRO DIARIO";

            // pnlFiltroFechas
            this.pnlFiltroFechas.Controls.Add(this.btnFiltrar);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaFin);
            this.pnlFiltroFechas.Controls.Add(this.lblFlechaRango);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltroFechas.Controls.Add(this.lblPeriodo);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(160, 16);
            this.pnlFiltroFechas.Name     = "pnlFiltroFechas";
            this.pnlFiltroFechas.Size     = new System.Drawing.Size(370, 38);

            this.lblPeriodo.AutoSize  = true;
            this.lblPeriodo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPeriodo.Location  = new System.Drawing.Point(3, 11);
            this.lblPeriodo.Text      = "Período:";

            this.dtpFechaInicio.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaInicio.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(58, 8);
            this.dtpFechaInicio.Size     = new System.Drawing.Size(100, 23);
            this.dtpFechaInicio.Name     = "dtpFechaInicio";

            this.lblFlechaRango.AutoSize  = true;
            this.lblFlechaRango.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFlechaRango.Location  = new System.Drawing.Point(164, 11);
            this.lblFlechaRango.Text      = "—";

            this.dtpFechaFin.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaFin.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(182, 8);
            this.dtpFechaFin.Size     = new System.Drawing.Size(100, 23);
            this.dtpFechaFin.Name     = "dtpFechaFin";

            this.btnFiltrar.BackColor                 = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFiltrar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFiltrar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font                      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnFiltrar.ForeColor                 = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnFiltrar.Location                  = new System.Drawing.Point(290, 7);
            this.btnFiltrar.Name                      = "btnFiltrar";
            this.btnFiltrar.Size                      = new System.Drawing.Size(70, 25);
            this.btnFiltrar.Text                      = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor   = false;

            // btnVolverDashboard (solo en vista grilla)
            this.btnVolverDashboard.Anchor                           = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnVolverDashboard.BackColor                        = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnVolverDashboard.Cursor                           = System.Windows.Forms.Cursors.Hand;
            this.btnVolverDashboard.FlatAppearance.BorderColor       = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnVolverDashboard.FlatStyle                        = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverDashboard.Font                             = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVolverDashboard.ForeColor                        = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnVolverDashboard.Location                         = new System.Drawing.Point(440, 18);
            this.btnVolverDashboard.Name                             = "btnVolverDashboard";
            this.btnVolverDashboard.Size                             = new System.Drawing.Size(100, 36);
            this.btnVolverDashboard.Text                             = "← Inicio";
            this.btnVolverDashboard.UseVisualStyleBackColor          = false;
            this.btnVolverDashboard.Visible                          = false;

            // btnNuevoAsiento
            this.btnNuevoAsiento.Anchor                          = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevoAsiento.BackColor                       = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNuevoAsiento.Cursor                          = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoAsiento.FlatAppearance.BorderSize       = 0;
            this.btnNuevoAsiento.FlatStyle                       = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoAsiento.Font                            = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoAsiento.ForeColor                       = System.Drawing.Color.White;
            this.btnNuevoAsiento.Location                        = new System.Drawing.Point(965, 18);
            this.btnNuevoAsiento.Name                            = "btnNuevoAsiento";
            this.btnNuevoAsiento.Size                            = new System.Drawing.Size(115, 36);
            this.btnNuevoAsiento.Text                            = "➕ Nuevo";
            this.btnNuevoAsiento.UseVisualStyleBackColor         = false;

            // btnEliminarAsiento
            this.btnEliminarAsiento.Anchor                           = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminarAsiento.BackColor                        = System.Drawing.Color.White;
            this.btnEliminarAsiento.Cursor                           = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarAsiento.FlatAppearance.BorderColor       = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminarAsiento.FlatStyle                        = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarAsiento.Font                             = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminarAsiento.ForeColor                        = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnEliminarAsiento.Location                         = new System.Drawing.Point(860, 18);
            this.btnEliminarAsiento.Name                             = "btnEliminarAsiento";
            this.btnEliminarAsiento.Size                             = new System.Drawing.Size(100, 36);
            this.btnEliminarAsiento.Text                             = "🗑️ Eliminar";
            this.btnEliminarAsiento.UseVisualStyleBackColor          = false;
            this.btnEliminarAsiento.Visible                          = false;

            // btnEditarAsiento
            this.btnEditarAsiento.Anchor                           = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnEditarAsiento.BackColor                        = System.Drawing.Color.White;
            this.btnEditarAsiento.Cursor                           = System.Windows.Forms.Cursors.Hand;
            this.btnEditarAsiento.FlatAppearance.BorderColor       = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnEditarAsiento.FlatStyle                        = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarAsiento.Font                             = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditarAsiento.ForeColor                        = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnEditarAsiento.Location                         = new System.Drawing.Point(755, 18);
            this.btnEditarAsiento.Name                             = "btnEditarAsiento";
            this.btnEditarAsiento.Size                             = new System.Drawing.Size(100, 36);
            this.btnEditarAsiento.Text                             = "✏️ Editar";
            this.btnEditarAsiento.UseVisualStyleBackColor          = false;
            this.btnEditarAsiento.Visible                          = false;

            // btnBajarAsiento
            this.btnBajarAsiento.Anchor                           = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnBajarAsiento.BackColor                        = System.Drawing.Color.White;
            this.btnBajarAsiento.Cursor                           = System.Windows.Forms.Cursors.Hand;
            this.btnBajarAsiento.FlatAppearance.BorderColor       = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnBajarAsiento.FlatStyle                        = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajarAsiento.Font                             = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBajarAsiento.ForeColor                        = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnBajarAsiento.Location                         = new System.Drawing.Point(705, 18);
            this.btnBajarAsiento.Name                             = "btnBajarAsiento";
            this.btnBajarAsiento.Size                             = new System.Drawing.Size(45, 36);
            this.btnBajarAsiento.Text                             = "⬇️";
            this.btnBajarAsiento.UseVisualStyleBackColor          = false;
            this.btnBajarAsiento.Visible                          = false;

            // btnSubirAsiento
            this.btnSubirAsiento.Anchor                           = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnSubirAsiento.BackColor                        = System.Drawing.Color.White;
            this.btnSubirAsiento.Cursor                           = System.Windows.Forms.Cursors.Hand;
            this.btnSubirAsiento.FlatAppearance.BorderColor       = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnSubirAsiento.FlatStyle                        = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirAsiento.Font                             = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSubirAsiento.ForeColor                        = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnSubirAsiento.Location                         = new System.Drawing.Point(655, 18);
            this.btnSubirAsiento.Name                             = "btnSubirAsiento";
            this.btnSubirAsiento.Size                             = new System.Drawing.Size(45, 36);
            this.btnSubirAsiento.Text                             = "⬆️";
            this.btnSubirAsiento.UseVisualStyleBackColor          = false;
            this.btnSubirAsiento.Visible                          = false;

            // btnCargarEjemplo
            this.btnCargarEjemplo.Anchor                           = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCargarEjemplo.BackColor                        = System.Drawing.Color.White;
            this.btnCargarEjemplo.Cursor                           = System.Windows.Forms.Cursors.Hand;
            this.btnCargarEjemplo.FlatAppearance.BorderColor       = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCargarEjemplo.FlatStyle                        = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarEjemplo.Font                             = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCargarEjemplo.ForeColor                        = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCargarEjemplo.Location                         = new System.Drawing.Point(545, 18);
            this.btnCargarEjemplo.Name                             = "btnCargarEjemplo";
            this.btnCargarEjemplo.Size                             = new System.Drawing.Size(105, 36);
            this.btnCargarEjemplo.Text                             = "📥 Ejemplo";
            this.btnCargarEjemplo.UseVisualStyleBackColor          = false;
            this.btnCargarEjemplo.Visible                          = false;

            // btnActualizar
            this.btnActualizar.Anchor                           = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.BackColor                        = System.Drawing.Color.White;
            this.btnActualizar.Cursor                           = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor       = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnActualizar.FlatStyle                        = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font                             = new System.Drawing.Font("Segoe UI", 9F);
            this.btnActualizar.ForeColor                        = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnActualizar.Location                         = new System.Drawing.Point(545, 18);
            this.btnActualizar.Name                             = "btnActualizar";
            this.btnActualizar.Size                             = new System.Drawing.Size(95, 36);
            this.btnActualizar.Text                             = "🔄 Refrescar";
            this.btnActualizar.UseVisualStyleBackColor          = false;
            this.btnActualizar.Visible                          = false;

            // ══ pnlDashboard ══════════════════════════════════════════
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlDashboard.Controls.Add(this.pnlDashContent);
            this.pnlDashboard.Controls.Add(this.pnlDashHeader);
            this.pnlDashboard.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Name     = "pnlDashboard";

            // pnlDashHeader
            this.pnlDashHeader.BackColor = System.Drawing.Color.White;
            this.pnlDashHeader.Controls.Add(this.lblBadgeTotal);
            this.pnlDashHeader.Controls.Add(this.lblDashSubtitulo);
            this.pnlDashHeader.Controls.Add(this.lblDashTitulo);
            this.pnlDashHeader.Dock    = System.Windows.Forms.DockStyle.Top;
            this.pnlDashHeader.Name    = "pnlDashHeader";
            this.pnlDashHeader.Padding = new System.Windows.Forms.Padding(32, 20, 32, 20);
            this.pnlDashHeader.Size    = new System.Drawing.Size(1100, 90);
            this.pnlDashHeader.Paint  += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, ((System.Windows.Forms.Panel)s!).Height - 1,
                    ((System.Windows.Forms.Panel)s!).Width, ((System.Windows.Forms.Panel)s!).Height - 1);
            };

            this.lblDashTitulo.AutoSize  = true;
            this.lblDashTitulo.Font      = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDashTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDashTitulo.Location  = new System.Drawing.Point(32, 18);
            this.lblDashTitulo.Name      = "lblDashTitulo";
            this.lblDashTitulo.Text      = "Libro Diario";

            this.lblDashSubtitulo.AutoSize  = true;
            this.lblDashSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDashSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDashSubtitulo.Location  = new System.Drawing.Point(34, 54);
            this.lblDashSubtitulo.Name      = "lblDashSubtitulo";
            this.lblDashSubtitulo.Text      = "Selecciona un asiento o registra uno nuevo.";

            this.lblBadgeTotal.AutoSize  = true;
            this.lblBadgeTotal.Font      = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblBadgeTotal.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblBadgeTotal.BackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.lblBadgeTotal.Location  = new System.Drawing.Point(220, 58);
            this.lblBadgeTotal.Name      = "lblBadgeTotal";
            this.lblBadgeTotal.Padding   = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblBadgeTotal.Text      = "  0 Asientos  ";

            // pnlDashContent (SplitContainer simulado con dos paneles)
            this.pnlDashContent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlDashContent.Controls.Add(this.pnlAcciones);
            this.pnlDashContent.Controls.Add(this.pnlListaAsientos);
            this.pnlDashContent.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashContent.Name    = "pnlDashContent";
            this.pnlDashContent.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);

            // pnlListaAsientos (izquierda)
            this.pnlListaAsientos.BackColor = System.Drawing.Color.White;
            this.pnlListaAsientos.Controls.Add(this.lstAsientos);
            this.pnlListaAsientos.Controls.Add(this.txtBuscarDash);
            this.pnlListaAsientos.Controls.Add(this.lblListaHeader);
            this.pnlListaAsientos.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaAsientos.Name      = "pnlListaAsientos";
            this.pnlListaAsientos.Padding   = new System.Windows.Forms.Padding(0, 0, 16, 0);

            this.lblListaHeader.AutoSize  = true;
            this.lblListaHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblListaHeader.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblListaHeader.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblListaHeader.Name      = "lblListaHeader";
            this.lblListaHeader.Padding   = new System.Windows.Forms.Padding(16, 12, 0, 8);
            this.lblListaHeader.Text      = "Asientos Recientes y Guardados";

            this.txtBuscarDash.Dock             = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarDash.Font             = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarDash.PlaceholderText  = "🔍  Buscar asientos (Alt+S)...";
            this.txtBuscarDash.BorderStyle      = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarDash.Name             = "txtBuscarDash";
            this.txtBuscarDash.Height           = 32;
            this.txtBuscarDash.Margin           = new System.Windows.Forms.Padding(16, 0, 16, 8);

            this.lstAsientos.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.lstAsientos.Name     = "lstAsientos";
            this.lstAsientos.TabIndex = 0;
            this.lstAsientos.DoubleClick += (s, e) =>
            {
                if (lstAsientos.SelectedItem is AsientoListItem item && !item.EsEncabezadoGrupo && !item.EsPlaceholder)
                    MostrarVistaGrilla();
            };

            // Búsqueda en vivo en el dashboard
            this.txtBuscarDash.TextChanged += (s, e) => FiltrarListaDash(txtBuscarDash.Text.Trim());

            // pnlAcciones (derecha, ancho fijo 280)
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Controls.Add(this.btnDashLimpiar);
            this.pnlAcciones.Controls.Add(this.btnDashVerLibro);
            this.pnlAcciones.Controls.Add(this.btnDashEjemplo);
            this.pnlAcciones.Controls.Add(this.btnDashNuevo);
            this.pnlAcciones.Controls.Add(this.lblAccionesHeader);
            this.pnlAcciones.Dock      = System.Windows.Forms.DockStyle.Right;
            this.pnlAcciones.Name      = "pnlAcciones";
            this.pnlAcciones.Padding   = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlAcciones.Width     = 280;
            this.pnlAcciones.Paint    += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, 0, ((System.Windows.Forms.Panel)s!).Height);
            };

            this.lblAccionesHeader.AutoSize  = true;
            this.lblAccionesHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblAccionesHeader.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccionesHeader.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblAccionesHeader.Name      = "lblAccionesHeader";
            this.lblAccionesHeader.Padding   = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.lblAccionesHeader.Text      = "Comenzar";

            // Acción: Nuevo Asiento
            this.btnDashNuevo.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnDashNuevo.Dock                      = System.Windows.Forms.DockStyle.Top;
            this.btnDashNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.btnDashNuevo.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashNuevo.Font                      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDashNuevo.ForeColor                 = System.Drawing.Color.FromArgb(30, 64, 175);
            this.btnDashNuevo.BackColor                 = System.Drawing.Color.FromArgb(239, 246, 255);
            this.btnDashNuevo.Height                    = 60;
            this.btnDashNuevo.Margin                    = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDashNuevo.Name                      = "btnDashNuevo";
            this.btnDashNuevo.Text                      = "➕  Crear nuevo asiento\r\nRegistra una nueva partida contable.";
            this.btnDashNuevo.TextAlign                 = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashNuevo.Padding                   = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashNuevo.UseVisualStyleBackColor   = false;
            this.btnDashNuevo.Click += (s, e) => AbrirNuevoAsiento();

            // Acción: Ver Libro Diario completo
            this.btnDashVerLibro.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnDashVerLibro.Dock                      = System.Windows.Forms.DockStyle.Top;
            this.btnDashVerLibro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnDashVerLibro.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashVerLibro.Font                      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDashVerLibro.ForeColor                 = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnDashVerLibro.BackColor                 = System.Drawing.Color.FromArgb(248, 250, 252);
            this.btnDashVerLibro.Height                    = 60;
            this.btnDashVerLibro.Margin                    = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDashVerLibro.Name                      = "btnDashVerLibro";
            this.btnDashVerLibro.Text                      = "📖  Abrir Libro Diario\r\nVer todos los asientos con detalle.";
            this.btnDashVerLibro.TextAlign                 = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashVerLibro.Padding                   = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashVerLibro.UseVisualStyleBackColor   = false;
            this.btnDashVerLibro.Click += (s, e) => MostrarVistaGrilla();

            // Acción: Cargar Ejemplo
            this.btnDashEjemplo.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnDashEjemplo.Dock                      = System.Windows.Forms.DockStyle.Top;
            this.btnDashEjemplo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnDashEjemplo.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashEjemplo.Font                      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDashEjemplo.ForeColor                 = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnDashEjemplo.BackColor                 = System.Drawing.Color.FromArgb(248, 250, 252);
            this.btnDashEjemplo.Height                    = 60;
            this.btnDashEjemplo.Margin                    = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDashEjemplo.Name                      = "btnDashEjemplo";
            this.btnDashEjemplo.Text                      = "🔄  Cargar Asientos de Ejemplo\r\nCarga datos demostrativos calculados.";
            this.btnDashEjemplo.TextAlign                 = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashEjemplo.Padding                   = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashEjemplo.UseVisualStyleBackColor   = false;
            this.btnDashEjemplo.Click                    += (s, e) => CargarEjemploYRefrescar();

            // Acción: Limpiar
            this.btnDashLimpiar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnDashLimpiar.Dock                      = System.Windows.Forms.DockStyle.Top;
            this.btnDashLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(254, 202, 202);
            this.btnDashLimpiar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashLimpiar.Font                      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDashLimpiar.ForeColor                 = System.Drawing.Color.FromArgb(153, 27, 27);
            this.btnDashLimpiar.BackColor                 = System.Drawing.Color.FromArgb(254, 242, 242);
            this.btnDashLimpiar.Height                    = 60;
            this.btnDashLimpiar.Margin                    = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDashLimpiar.Name                      = "btnDashLimpiar";
            this.btnDashLimpiar.Text                      = "🗑  Limpiar Asientos en Memoria\r\nElimina todos los asientos de la sesión.";
            this.btnDashLimpiar.TextAlign                 = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashLimpiar.Padding                   = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashLimpiar.UseVisualStyleBackColor   = false;
            this.btnDashLimpiar.Click += (s, e) => LimpiarAsientos();

            // ══ pnlGrillaContenedor ═══════════════════════════════════
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlGrillaContenedor.Controls.Add(this.dgvLibroDiario);
            this.pnlGrillaContenedor.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Name     = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding  = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.Visible  = false;

            // dgvLibroDiario
            this.dgvLibroDiario.AllowUserToAddRows    = false;
            this.dgvLibroDiario.AllowUserToDeleteRows = false;
            this.dgvLibroDiario.AllowUserToResizeRows = false;
            this.dgvLibroDiario.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLibroDiario.BackgroundColor       = System.Drawing.Color.White;
            this.dgvLibroDiario.BorderStyle           = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvLibroDiario.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLibroDiario.GridColor             = System.Drawing.Color.FromArgb(180, 198, 215);

            cs1.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cs1.BackColor          = System.Drawing.Color.FromArgb(189, 215, 238);
            cs1.Font               = new System.Drawing.Font("Segoe UI", 10F);
            cs1.ForeColor          = System.Drawing.Color.FromArgb(15, 23, 42);
            cs1.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            cs1.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cs1.WrapMode           = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLibroDiario.ColumnHeadersDefaultCellStyle      = cs1;
            this.dgvLibroDiario.ColumnHeadersHeight                 = 36;
            this.dgvLibroDiario.ColumnHeadersHeightSizeMode         = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLibroDiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colFecha, this.colCuenta, this.colParcial, this.colDebe, this.colHaber });
            this.dgvLibroDiario.Dock                               = System.Windows.Forms.DockStyle.Fill;
            this.dgvLibroDiario.EnableHeadersVisualStyles          = false;
            this.dgvLibroDiario.MultiSelect                        = false;
            this.dgvLibroDiario.Name                               = "dgvLibroDiario";
            this.dgvLibroDiario.ReadOnly                           = true;
            this.dgvLibroDiario.RowHeadersVisible                  = false;
            this.dgvLibroDiario.RowTemplate.Height                 = 26;
            this.dgvLibroDiario.SelectionMode                      = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            cs2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colFecha.DefaultCellStyle = cs2;
            this.colFecha.FillWeight       = 85F;
            this.colFecha.HeaderText       = "Fecha";
            this.colFecha.Name             = "colFecha";
            this.colFecha.ReadOnly         = true;
            this.colFecha.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            this.colCuenta.FillWeight  = 260F;
            this.colCuenta.HeaderText  = "Cuenta";
            this.colCuenta.Name        = "colCuenta";
            this.colCuenta.ReadOnly    = true;
            this.colCuenta.SortMode    = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            cs3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cs3.Format    = "N2";
            this.colParcial.DefaultCellStyle = cs3;
            this.colParcial.FillWeight       = 95F;
            this.colParcial.HeaderText       = "Parcial";
            this.colParcial.Name             = "colParcial";
            this.colParcial.ReadOnly         = true;
            this.colParcial.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            cs4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cs4.Format    = "N2";
            this.colDebe.DefaultCellStyle = cs4;
            this.colDebe.FillWeight       = 95F;
            this.colDebe.HeaderText       = "Debe";
            this.colDebe.Name             = "colDebe";
            this.colDebe.ReadOnly         = true;
            this.colDebe.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            cs5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cs5.Format    = "N2";
            this.colHaber.DefaultCellStyle = cs5;
            this.colHaber.FillWeight       = 95F;
            this.colHaber.HeaderText       = "Haber";
            this.colHaber.Name             = "colHaber";
            this.colHaber.ReadOnly         = true;
            this.colHaber.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // ══ pnlResumenInferior ════════════════════════════════════
            this.pnlResumenInferior.BackColor = System.Drawing.Color.White;
            this.pnlResumenInferior.Controls.Add(this.lblBadgeEstado);
            this.pnlResumenInferior.Controls.Add(this.lblTotalHaberGlobal);
            this.pnlResumenInferior.Controls.Add(this.lblTotalDebeGlobal);
            this.pnlResumenInferior.Controls.Add(this.lblTotalAsientos);
            this.pnlResumenInferior.Dock    = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumenInferior.Name    = "pnlResumenInferior";
            this.pnlResumenInferior.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlResumenInferior.Size    = new System.Drawing.Size(1100, 48);
            this.pnlResumenInferior.Visible = false;
            this.pnlResumenInferior.Paint  += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, ((System.Windows.Forms.Panel)s!).Width, 0);
            };

            this.lblBadgeEstado.Anchor    = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.lblBadgeEstado.AutoSize  = true;
            this.lblBadgeEstado.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBadgeEstado.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblBadgeEstado.Location  = new System.Drawing.Point(820, 15);
            this.lblBadgeEstado.Name      = "lblBadgeEstado";
            this.lblBadgeEstado.Text      = "✓ Asientos Dobles Cuadrados";

            this.lblTotalHaberGlobal.AutoSize  = true;
            this.lblTotalHaberGlobal.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalHaberGlobal.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalHaberGlobal.Location  = new System.Drawing.Point(400, 15);
            this.lblTotalHaberGlobal.Name      = "lblTotalHaberGlobal";
            this.lblTotalHaberGlobal.Text      = "Total Haber: $0.00";

            this.lblTotalDebeGlobal.AutoSize  = true;
            this.lblTotalDebeGlobal.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebeGlobal.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalDebeGlobal.Location  = new System.Drawing.Point(190, 15);
            this.lblTotalDebeGlobal.Name      = "lblTotalDebeGlobal";
            this.lblTotalDebeGlobal.Text      = "Total Debe: $0.00";

            this.lblTotalAsientos.AutoSize  = true;
            this.lblTotalAsientos.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTotalAsientos.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTotalAsientos.Location  = new System.Drawing.Point(16, 15);
            this.lblTotalAsientos.Name      = "lblTotalAsientos";
            this.lblTotalAsientos.Text      = "Asientos: 0";

            // ══ frmLibroDiario ════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlDashboard);
            this.Controls.Add(this.pnlResumenInferior);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "frmLibroDiario";
            this.Text                = "Libro Diario";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashHeader.ResumeLayout(false);
            this.pnlDashHeader.PerformLayout();
            this.pnlDashContent.ResumeLayout(false);
            this.pnlListaAsientos.ResumeLayout(false);
            this.pnlListaAsientos.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibroDiario)).EndInit();
            this.pnlResumenInferior.ResumeLayout(false);
            this.pnlResumenInferior.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // ── Toolbar ──────────────────────────────────────────────────
        private System.Windows.Forms.Panel    pnlToolbar;
        private System.Windows.Forms.Label    lblTituloSeccion;
        private System.Windows.Forms.Panel    pnlFiltroFechas;
        private System.Windows.Forms.Label    lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label    lblFlechaRango;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button   btnFiltrar;
        private System.Windows.Forms.Button   btnNuevoAsiento;
        private System.Windows.Forms.Button   btnEliminarAsiento;
        private System.Windows.Forms.Button   btnEditarAsiento;
        private System.Windows.Forms.Button   btnCargarEjemplo;
        private System.Windows.Forms.Button   btnBajarAsiento;
        private System.Windows.Forms.Button   btnSubirAsiento;
        private System.Windows.Forms.Button   btnActualizar;
        private System.Windows.Forms.Button   btnVolverDashboard;
        // Dashboard
        private System.Windows.Forms.Panel    pnlDashboard;
        private System.Windows.Forms.Panel    pnlDashHeader;
        private System.Windows.Forms.Label    lblDashTitulo;
        private System.Windows.Forms.Label    lblDashSubtitulo;
        private System.Windows.Forms.Label    lblBadgeTotal;
        private System.Windows.Forms.Panel    pnlDashContent;
        private System.Windows.Forms.Panel    pnlListaAsientos;
        private System.Windows.Forms.Label    lblListaHeader;
        private System.Windows.Forms.TextBox  txtBuscarDash;
        private App_Contable.Presentacion.AsientoListBox lstAsientos;
        private System.Windows.Forms.Panel    pnlAcciones;
        private System.Windows.Forms.Label    lblAccionesHeader;
        private System.Windows.Forms.Button   btnDashNuevo;
        private System.Windows.Forms.Button   btnDashEjemplo;
        private System.Windows.Forms.Button   btnDashVerLibro;
        private System.Windows.Forms.Button   btnDashLimpiar;
        // Grilla
        private System.Windows.Forms.Panel    pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvLibroDiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParcial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHaber;
        // Footer
        private System.Windows.Forms.Panel    pnlResumenInferior;
        private System.Windows.Forms.Label    lblTotalAsientos;
        private System.Windows.Forms.Label    lblTotalDebeGlobal;
        private System.Windows.Forms.Label    lblTotalHaberGlobal;
        private System.Windows.Forms.Label    lblBadgeEstado;
    }
}
