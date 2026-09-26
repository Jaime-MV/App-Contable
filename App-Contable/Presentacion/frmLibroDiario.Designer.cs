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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            pnlToolbar = new Panel();
            btnSubirAsiento = new Button();
            btnBajarAsiento = new Button();
            btnEditarAsiento = new Button();
            btnActualizar = new Button();
            btnCargarEjemplo = new Button();
            btnEliminarAsiento = new Button();
            btnNuevoAsiento = new Button();
            btnVolverDashboard = new Button();
            pnlFiltroFechas = new Panel();
            btnFiltrar = new Button();
            dtpFechaFin = new DateTimePicker();
            lblFlechaRango = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblPeriodo = new Label();
            lblTituloSeccion = new Label();
            pnlDashboard = new Panel();
            pnlDashContent = new Panel();
            pnlAcciones = new Panel();
            btnDashEliminar = new Button();
            btnDashGuardarBD = new Button();
            btnDashNuevo = new Button();
            lblAccionesHeader = new Label();
            lblHerramientasHeader = new Label();
            btnDashImportar = new Button();
            btnDashExportar = new Button();
            pnlListaAsientos = new Panel();
            lstLibros = new LibroDiarioInstanciaListBox();
            txtBuscarDash = new TextBox();
            lblListaHeader = new Label();
            pnlDashHeader = new Panel();
            lblBadgeTotal = new Label();
            lblDashSubtitulo = new Label();
            lblDashTitulo = new Label();
            pnlGrillaContenedor = new Panel();
            dgvLibroDiario = new DataGridView();
            colFecha = new DataGridViewTextBoxColumn();
            colCuenta = new DataGridViewTextBoxColumn();
            colParcial = new DataGridViewTextBoxColumn();
            colDebe = new DataGridViewTextBoxColumn();
            colHaber = new DataGridViewTextBoxColumn();
            pnlResumenInferior = new Panel();
            lblBadgeEstado = new Label();
            lblTotalHaberGlobal = new Label();
            lblTotalDebeGlobal = new Label();
            lblTotalAsientos = new Label();
            pnlToolbar.SuspendLayout();
            pnlFiltroFechas.SuspendLayout();
            pnlDashboard.SuspendLayout();
            pnlDashContent.SuspendLayout();
            pnlAcciones.SuspendLayout();
            pnlListaAsientos.SuspendLayout();
            pnlDashHeader.SuspendLayout();
            pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibroDiario).BeginInit();
            pnlResumenInferior.SuspendLayout();
            SuspendLayout();
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.White;
            pnlToolbar.Controls.Add(btnSubirAsiento);
            pnlToolbar.Controls.Add(btnBajarAsiento);
            pnlToolbar.Controls.Add(btnEditarAsiento);
            pnlToolbar.Controls.Add(btnActualizar);
            pnlToolbar.Controls.Add(btnCargarEjemplo);
            pnlToolbar.Controls.Add(btnEliminarAsiento);
            pnlToolbar.Controls.Add(btnNuevoAsiento);
            pnlToolbar.Controls.Add(btnVolverDashboard);
            pnlToolbar.Controls.Add(pnlFiltroFechas);
            pnlToolbar.Controls.Add(lblTituloSeccion);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Margin = new Padding(3, 4, 3, 4);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(18, 16, 18, 16);
            pnlToolbar.Size = new Size(1257, 96);
            pnlToolbar.TabIndex = 0;
            // 
            // btnSubirAsiento
            // 
            btnSubirAsiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubirAsiento.BackColor = Color.White;
            btnSubirAsiento.Cursor = Cursors.Hand;
            btnSubirAsiento.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnSubirAsiento.FlatStyle = FlatStyle.Flat;
            btnSubirAsiento.Font = new Font("Segoe UI", 9F);
            btnSubirAsiento.ForeColor = Color.FromArgb(30, 41, 59);
            btnSubirAsiento.Location = new Point(749, 24);
            btnSubirAsiento.Margin = new Padding(3, 4, 3, 4);
            btnSubirAsiento.Name = "btnSubirAsiento";
            btnSubirAsiento.Size = new Size(51, 48);
            btnSubirAsiento.TabIndex = 0;
            btnSubirAsiento.Text = "⬆️";
            btnSubirAsiento.UseVisualStyleBackColor = false;
            btnSubirAsiento.Visible = false;
            // 
            // btnBajarAsiento
            // 
            btnBajarAsiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBajarAsiento.BackColor = Color.White;
            btnBajarAsiento.Cursor = Cursors.Hand;
            btnBajarAsiento.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnBajarAsiento.FlatStyle = FlatStyle.Flat;
            btnBajarAsiento.Font = new Font("Segoe UI", 9F);
            btnBajarAsiento.ForeColor = Color.FromArgb(30, 41, 59);
            btnBajarAsiento.Location = new Point(806, 24);
            btnBajarAsiento.Margin = new Padding(3, 4, 3, 4);
            btnBajarAsiento.Name = "btnBajarAsiento";
            btnBajarAsiento.Size = new Size(51, 48);
            btnBajarAsiento.TabIndex = 1;
            btnBajarAsiento.Text = "⬇️";
            btnBajarAsiento.UseVisualStyleBackColor = false;
            btnBajarAsiento.Visible = false;
            // 
            // btnEditarAsiento
            // 
            btnEditarAsiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditarAsiento.BackColor = Color.White;
            btnEditarAsiento.Cursor = Cursors.Hand;
            btnEditarAsiento.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnEditarAsiento.FlatStyle = FlatStyle.Flat;
            btnEditarAsiento.Font = new Font("Segoe UI", 9F);
            btnEditarAsiento.ForeColor = Color.FromArgb(30, 41, 59);
            btnEditarAsiento.Location = new Point(863, 24);
            btnEditarAsiento.Margin = new Padding(3, 4, 3, 4);
            btnEditarAsiento.Name = "btnEditarAsiento";
            btnEditarAsiento.Size = new Size(114, 48);
            btnEditarAsiento.TabIndex = 2;
            btnEditarAsiento.Text = "✏️ Editar";
            btnEditarAsiento.UseVisualStyleBackColor = false;
            btnEditarAsiento.Visible = false;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.BackColor = Color.White;
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 9F);
            btnActualizar.ForeColor = Color.FromArgb(71, 85, 105);
            btnActualizar.Location = new Point(623, 24);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(109, 48);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "🔄 Refrescar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Visible = false;
            // 
            // btnCargarEjemplo
            // 
            btnCargarEjemplo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCargarEjemplo.BackColor = Color.White;
            btnCargarEjemplo.Cursor = Cursors.Hand;
            btnCargarEjemplo.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCargarEjemplo.FlatStyle = FlatStyle.Flat;
            btnCargarEjemplo.Font = new Font("Segoe UI", 9F);
            btnCargarEjemplo.ForeColor = Color.FromArgb(71, 85, 105);
            btnCargarEjemplo.Location = new Point(623, 24);
            btnCargarEjemplo.Margin = new Padding(3, 4, 3, 4);
            btnCargarEjemplo.Name = "btnCargarEjemplo";
            btnCargarEjemplo.Size = new Size(120, 48);
            btnCargarEjemplo.TabIndex = 4;
            btnCargarEjemplo.Text = "📥 Ejemplo";
            btnCargarEjemplo.UseVisualStyleBackColor = false;
            btnCargarEjemplo.Visible = false;
            // 
            // btnEliminarAsiento
            // 
            btnEliminarAsiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEliminarAsiento.BackColor = Color.White;
            btnEliminarAsiento.Cursor = Cursors.Hand;
            btnEliminarAsiento.FlatAppearance.BorderColor = Color.FromArgb(239, 68, 68);
            btnEliminarAsiento.FlatStyle = FlatStyle.Flat;
            btnEliminarAsiento.Font = new Font("Segoe UI", 9F);
            btnEliminarAsiento.ForeColor = Color.FromArgb(220, 38, 38);
            btnEliminarAsiento.Location = new Point(983, 24);
            btnEliminarAsiento.Margin = new Padding(3, 4, 3, 4);
            btnEliminarAsiento.Name = "btnEliminarAsiento";
            btnEliminarAsiento.Size = new Size(114, 48);
            btnEliminarAsiento.TabIndex = 5;
            btnEliminarAsiento.Text = "🗑️ Eliminar";
            btnEliminarAsiento.UseVisualStyleBackColor = false;
            btnEliminarAsiento.Visible = false;
            // 
            // btnNuevoAsiento
            // 
            btnNuevoAsiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoAsiento.BackColor = Color.FromArgb(37, 99, 235);
            btnNuevoAsiento.Cursor = Cursors.Hand;
            btnNuevoAsiento.FlatAppearance.BorderSize = 0;
            btnNuevoAsiento.FlatStyle = FlatStyle.Flat;
            btnNuevoAsiento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnNuevoAsiento.ForeColor = Color.White;
            btnNuevoAsiento.Location = new Point(1103, 24);
            btnNuevoAsiento.Margin = new Padding(3, 4, 3, 4);
            btnNuevoAsiento.Name = "btnNuevoAsiento";
            btnNuevoAsiento.Size = new Size(131, 48);
            btnNuevoAsiento.TabIndex = 6;
            btnNuevoAsiento.Text = "➕ Nuevo";
            btnNuevoAsiento.UseVisualStyleBackColor = false;
            // 
            // btnVolverDashboard
            // 
            btnVolverDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVolverDashboard.BackColor = Color.FromArgb(241, 245, 249);
            btnVolverDashboard.Cursor = Cursors.Hand;
            btnVolverDashboard.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnVolverDashboard.FlatStyle = FlatStyle.Flat;
            btnVolverDashboard.Font = new Font("Segoe UI", 9F);
            btnVolverDashboard.ForeColor = Color.FromArgb(71, 85, 105);
            btnVolverDashboard.Location = new Point(503, 24);
            btnVolverDashboard.Margin = new Padding(3, 4, 3, 4);
            btnVolverDashboard.Name = "btnVolverDashboard";
            btnVolverDashboard.Size = new Size(114, 48);
            btnVolverDashboard.TabIndex = 7;
            btnVolverDashboard.Text = "← Inicio";
            btnVolverDashboard.UseVisualStyleBackColor = false;
            btnVolverDashboard.Visible = false;
            // 
            // pnlFiltroFechas
            // 
            pnlFiltroFechas.Controls.Add(btnFiltrar);
            pnlFiltroFechas.Controls.Add(dtpFechaFin);
            pnlFiltroFechas.Controls.Add(lblFlechaRango);
            pnlFiltroFechas.Controls.Add(dtpFechaInicio);
            pnlFiltroFechas.Controls.Add(lblPeriodo);
            pnlFiltroFechas.Location = new Point(183, 21);
            pnlFiltroFechas.Margin = new Padding(3, 4, 3, 4);
            pnlFiltroFechas.Name = "pnlFiltroFechas";
            pnlFiltroFechas.Size = new Size(423, 51);
            pnlFiltroFechas.TabIndex = 8;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(241, 245, 249);
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI", 8.5F);
            btnFiltrar.ForeColor = Color.FromArgb(51, 65, 85);
            btnFiltrar.Location = new Point(331, 9);
            btnFiltrar.Margin = new Padding(3, 4, 3, 4);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(80, 33);
            btnFiltrar.TabIndex = 0;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 9F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(208, 11);
            dtpFechaFin.Margin = new Padding(3, 4, 3, 4);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(114, 27);
            dtpFechaFin.TabIndex = 1;
            // 
            // lblFlechaRango
            // 
            lblFlechaRango.AutoSize = true;
            lblFlechaRango.ForeColor = Color.FromArgb(148, 163, 184);
            lblFlechaRango.Location = new Point(187, 15);
            lblFlechaRango.Name = "lblFlechaRango";
            lblFlechaRango.Size = new Size(24, 20);
            lblFlechaRango.TabIndex = 2;
            lblFlechaRango.Text = "—";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Segoe UI", 9F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(66, 11);
            dtpFechaInicio.Margin = new Padding(3, 4, 3, 4);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(114, 27);
            dtpFechaInicio.TabIndex = 3;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Font = new Font("Segoe UI", 9F);
            lblPeriodo.ForeColor = Color.FromArgb(71, 85, 105);
            lblPeriodo.Location = new Point(3, 15);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(63, 20);
            lblPeriodo.TabIndex = 4;
            lblPeriodo.Text = "Período:";
            // 
            // lblTituloSeccion
            // 
            lblTituloSeccion.AutoSize = true;
            lblTituloSeccion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloSeccion.ForeColor = Color.FromArgb(30, 41, 59);
            lblTituloSeccion.Location = new Point(18, 32);
            lblTituloSeccion.Name = "lblTituloSeccion";
            lblTituloSeccion.Size = new Size(144, 28);
            lblTituloSeccion.TabIndex = 9;
            lblTituloSeccion.Text = "LIBRO DIARIO";
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(248, 250, 252);
            pnlDashboard.Controls.Add(pnlDashContent);
            pnlDashboard.Controls.Add(pnlDashHeader);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 96);
            pnlDashboard.Margin = new Padding(3, 4, 3, 4);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1257, 693);
            pnlDashboard.TabIndex = 1;
            // 
            // pnlDashContent
            // 
            pnlDashContent.BackColor = Color.FromArgb(248, 250, 252);
            pnlDashContent.Controls.Add(pnlAcciones);
            pnlDashContent.Controls.Add(pnlListaAsientos);
            pnlDashContent.Dock = DockStyle.Fill;
            pnlDashContent.Location = new Point(0, 120);
            pnlDashContent.Margin = new Padding(3, 4, 3, 4);
            pnlDashContent.Name = "pnlDashContent";
            pnlDashContent.Padding = new Padding(27);
            pnlDashContent.Size = new Size(1257, 573);
            pnlDashContent.TabIndex = 0;
            // 
            // pnlAcciones
            // 
            pnlAcciones.AutoScroll = true;
            pnlAcciones.BackColor = Color.White;
            pnlAcciones.Controls.Add(btnDashExportar);
            pnlAcciones.Controls.Add(btnDashImportar);
            pnlAcciones.Controls.Add(lblHerramientasHeader);
            pnlAcciones.Controls.Add(btnDashEliminar);
            pnlAcciones.Controls.Add(btnDashGuardarBD);
            pnlAcciones.Controls.Add(btnDashNuevo);
            pnlAcciones.Controls.Add(lblAccionesHeader);
            pnlAcciones.Dock = DockStyle.Right;
            pnlAcciones.Location = new Point(910, 27);
            pnlAcciones.Margin = new Padding(3, 4, 3, 4);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(18, 16, 18, 16);
            pnlAcciones.Size = new Size(320, 519);
            pnlAcciones.TabIndex = 0;
            // 
            // btnDashExportar
            // 
            btnDashExportar.BackColor = Color.FromArgb(248, 250, 252);
            btnDashExportar.Cursor = Cursors.Hand;
            btnDashExportar.Dock = DockStyle.Top;
            btnDashExportar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnDashExportar.FlatStyle = FlatStyle.Flat;
            btnDashExportar.Font = new Font("Segoe UI", 9.5F);
            btnDashExportar.ForeColor = Color.FromArgb(30, 41, 59);
            btnDashExportar.Location = new Point(18, 435);
            btnDashExportar.Margin = new Padding(0, 5, 0, 5);
            btnDashExportar.Name = "btnDashExportar";
            btnDashExportar.Padding = new Padding(11, 0, 0, 0);
            btnDashExportar.Size = new Size(284, 80);
            btnDashExportar.TabIndex = 5;
            btnDashExportar.Text = "📤  Exportar Libro Diario\r\nDescargar libro seleccionado como CSV o PDF";
            btnDashExportar.TextAlign = ContentAlignment.MiddleLeft;
            btnDashExportar.UseVisualStyleBackColor = false;
            // 
            // btnDashImportar
            // 
            btnDashImportar.BackColor = Color.FromArgb(248, 250, 252);
            btnDashImportar.Cursor = Cursors.Hand;
            btnDashImportar.Dock = DockStyle.Top;
            btnDashImportar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnDashImportar.FlatStyle = FlatStyle.Flat;
            btnDashImportar.Font = new Font("Segoe UI", 9.5F);
            btnDashImportar.ForeColor = Color.FromArgb(30, 41, 59);
            btnDashImportar.Location = new Point(18, 355);
            btnDashImportar.Margin = new Padding(0, 5, 0, 5);
            btnDashImportar.Name = "btnDashImportar";
            btnDashImportar.Padding = new Padding(11, 0, 0, 0);
            btnDashImportar.Size = new Size(284, 80);
            btnDashImportar.TabIndex = 4;
            btnDashImportar.Text = "📥  Importar Libro Diario\r\nCargar libro desde archivo CSV o PDF";
            btnDashImportar.TextAlign = ContentAlignment.MiddleLeft;
            btnDashImportar.UseVisualStyleBackColor = false;
            // 
            // lblHerramientasHeader
            // 
            lblHerramientasHeader.AutoSize = true;
            lblHerramientasHeader.Dock = DockStyle.Top;
            lblHerramientasHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblHerramientasHeader.ForeColor = Color.FromArgb(30, 41, 59);
            lblHerramientasHeader.Location = new Point(18, 295);
            lblHerramientasHeader.Name = "lblHerramientasHeader";
            lblHerramientasHeader.Padding = new Padding(0, 16, 0, 10);
            lblHerramientasHeader.Size = new Size(160, 45);
            lblHerramientasHeader.TabIndex = 3;
            lblHerramientasHeader.Text = "Herramientas de Datos";
            // 
            // btnDashEliminar
            // 
            btnDashEliminar.BackColor = Color.FromArgb(254, 242, 242);
            btnDashEliminar.Cursor = Cursors.Hand;
            btnDashEliminar.Dock = DockStyle.Top;
            btnDashEliminar.FlatAppearance.BorderColor = Color.FromArgb(254, 202, 202);
            btnDashEliminar.FlatStyle = FlatStyle.Flat;
            btnDashEliminar.Font = new Font("Segoe UI", 9.5F);
            btnDashEliminar.ForeColor = Color.FromArgb(185, 28, 28);
            btnDashEliminar.Location = new Point(18, 215);
            btnDashEliminar.Margin = new Padding(0, 5, 0, 5);
            btnDashEliminar.Name = "btnDashEliminar";
            btnDashEliminar.Padding = new Padding(11, 0, 0, 0);
            btnDashEliminar.Size = new Size(284, 80);
            btnDashEliminar.TabIndex = 0;
            btnDashEliminar.Text = "🗑️  Eliminar Libro Diario\r\nRemueve la instancia de la memoria local.";
            btnDashEliminar.TextAlign = ContentAlignment.MiddleLeft;
            btnDashEliminar.UseVisualStyleBackColor = false;
            // 
            // btnDashGuardarBD
            // 
            btnDashGuardarBD.BackColor = Color.FromArgb(248, 250, 252);
            btnDashGuardarBD.Cursor = Cursors.Hand;
            btnDashGuardarBD.Dock = DockStyle.Top;
            btnDashGuardarBD.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnDashGuardarBD.FlatStyle = FlatStyle.Flat;
            btnDashGuardarBD.Font = new Font("Segoe UI", 9.5F);
            btnDashGuardarBD.ForeColor = Color.FromArgb(30, 41, 59);
            btnDashGuardarBD.Location = new Point(18, 135);
            btnDashGuardarBD.Margin = new Padding(0, 5, 0, 5);
            btnDashGuardarBD.Name = "btnDashGuardarBD";
            btnDashGuardarBD.Padding = new Padding(11, 0, 0, 0);
            btnDashGuardarBD.Size = new Size(284, 80);
            btnDashGuardarBD.TabIndex = 1;
            btnDashGuardarBD.Text = "💾  Guardar Cambios en BD\r\nSincroniza la instancia con PostgreSQL.";
            btnDashGuardarBD.TextAlign = ContentAlignment.MiddleLeft;
            btnDashGuardarBD.UseVisualStyleBackColor = false;
            // 
            // btnDashNuevo
            // 
            btnDashNuevo.BackColor = Color.FromArgb(239, 246, 255);
            btnDashNuevo.Cursor = Cursors.Hand;
            btnDashNuevo.Dock = DockStyle.Top;
            btnDashNuevo.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);
            btnDashNuevo.FlatStyle = FlatStyle.Flat;
            btnDashNuevo.Font = new Font("Segoe UI", 9.5F);
            btnDashNuevo.ForeColor = Color.FromArgb(30, 64, 175);
            btnDashNuevo.Location = new Point(18, 55);
            btnDashNuevo.Margin = new Padding(0, 5, 0, 5);
            btnDashNuevo.Name = "btnDashNuevo";
            btnDashNuevo.Padding = new Padding(11, 0, 0, 0);
            btnDashNuevo.Size = new Size(284, 80);
            btnDashNuevo.TabIndex = 2;
            btnDashNuevo.Text = "➕  Crear Nuevo Libro Diario\r\nRegistra una nueva instancia de libro.";
            btnDashNuevo.TextAlign = ContentAlignment.MiddleLeft;
            btnDashNuevo.UseVisualStyleBackColor = false;
            // 
            // lblAccionesHeader
            // 
            lblAccionesHeader.AutoSize = true;
            lblAccionesHeader.Dock = DockStyle.Top;
            lblAccionesHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAccionesHeader.ForeColor = Color.FromArgb(30, 41, 59);
            lblAccionesHeader.Location = new Point(18, 16);
            lblAccionesHeader.Name = "lblAccionesHeader";
            lblAccionesHeader.Padding = new Padding(0, 0, 0, 16);
            lblAccionesHeader.Size = new Size(88, 39);
            lblAccionesHeader.TabIndex = 3;
            lblAccionesHeader.Text = "Comenzar";
            // 
            // pnlListaAsientos
            // 
            pnlListaAsientos.BackColor = Color.White;
            pnlListaAsientos.Controls.Add(lstLibros);
            pnlListaAsientos.Controls.Add(txtBuscarDash);
            pnlListaAsientos.Controls.Add(lblListaHeader);
            pnlListaAsientos.Dock = DockStyle.Fill;
            pnlListaAsientos.Location = new Point(27, 27);
            pnlListaAsientos.Margin = new Padding(3, 4, 3, 4);
            pnlListaAsientos.Name = "pnlListaAsientos";
            pnlListaAsientos.Padding = new Padding(0, 0, 18, 0);
            pnlListaAsientos.Size = new Size(1203, 519);
            pnlListaAsientos.TabIndex = 1;
            // 
            // lstLibros
            // 
            lstLibros.BorderStyle = BorderStyle.None;
            lstLibros.Dock = DockStyle.Fill;
            lstLibros.DrawMode = DrawMode.OwnerDrawVariable;
            lstLibros.ItemHeight = 74;
            lstLibros.Location = new Point(0, 79);
            lstLibros.Margin = new Padding(3, 4, 3, 4);
            lstLibros.Name = "lstLibros";
            lstLibros.Size = new Size(1185, 440);
            lstLibros.TabIndex = 0;
            // 
            // txtBuscarDash
            // 
            txtBuscarDash.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarDash.Dock = DockStyle.Top;
            txtBuscarDash.Font = new Font("Segoe UI", 9.5F);
            txtBuscarDash.Location = new Point(0, 50);
            txtBuscarDash.Margin = new Padding(18, 0, 18, 11);
            txtBuscarDash.Name = "txtBuscarDash";
            txtBuscarDash.PlaceholderText = "🔍  Buscar libros diarios (Alt+S)...";
            txtBuscarDash.Size = new Size(1185, 29);
            txtBuscarDash.TabIndex = 1;
            // 
            // lblListaHeader
            // 
            lblListaHeader.AutoSize = true;
            lblListaHeader.Dock = DockStyle.Top;
            lblListaHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblListaHeader.ForeColor = Color.FromArgb(30, 41, 59);
            lblListaHeader.Location = new Point(0, 0);
            lblListaHeader.Name = "lblListaHeader";
            lblListaHeader.Padding = new Padding(18, 16, 0, 11);
            lblListaHeader.Size = new Size(218, 50);
            lblListaHeader.TabIndex = 2;
            lblListaHeader.Text = "Libros Diarios Guardados";
            // 
            // pnlDashHeader
            // 
            pnlDashHeader.BackColor = Color.White;
            pnlDashHeader.Controls.Add(lblBadgeTotal);
            pnlDashHeader.Controls.Add(lblDashSubtitulo);
            pnlDashHeader.Controls.Add(lblDashTitulo);
            pnlDashHeader.Dock = DockStyle.Top;
            pnlDashHeader.Location = new Point(0, 0);
            pnlDashHeader.Margin = new Padding(3, 4, 3, 4);
            pnlDashHeader.Name = "pnlDashHeader";
            pnlDashHeader.Padding = new Padding(37, 27, 37, 27);
            pnlDashHeader.Size = new Size(1257, 120);
            pnlDashHeader.TabIndex = 1;
            // 
            // lblBadgeTotal
            // 
            lblBadgeTotal.AutoSize = true;
            lblBadgeTotal.BackColor = Color.FromArgb(219, 234, 254);
            lblBadgeTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblBadgeTotal.ForeColor = Color.FromArgb(37, 99, 235);
            lblBadgeTotal.Location = new Point(297, 32);
            lblBadgeTotal.Name = "lblBadgeTotal";
            lblBadgeTotal.Padding = new Padding(7, 3, 7, 3);
            lblBadgeTotal.Size = new Size(102, 26);
            lblBadgeTotal.TabIndex = 0;
            lblBadgeTotal.Text = "  0 Libro(s)  ";
            // 
            // lblDashSubtitulo
            // 
            lblDashSubtitulo.AutoSize = true;
            lblDashSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblDashSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblDashSubtitulo.Location = new Point(39, 72);
            lblDashSubtitulo.Name = "lblDashSubtitulo";
            lblDashSubtitulo.Size = new Size(619, 21);
            lblDashSubtitulo.TabIndex = 1;
            lblDashSubtitulo.Text = "Selecciona un libro diario existente o crea uno nuevo para comenzar a registrar partidas.";
            // 
            // lblDashTitulo
            // 
            lblDashTitulo.AutoSize = true;
            lblDashTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDashTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblDashTitulo.Location = new Point(37, 24);
            lblDashTitulo.Name = "lblDashTitulo";
            lblDashTitulo.Size = new Size(369, 41);
            lblDashTitulo.TabIndex = 2;
            lblDashTitulo.Text = "Gestión de Libros Diarios";
            // 
            // pnlGrillaContenedor
            // 
            pnlGrillaContenedor.BackColor = Color.FromArgb(241, 245, 249);
            pnlGrillaContenedor.Controls.Add(dgvLibroDiario);
            pnlGrillaContenedor.Dock = DockStyle.Fill;
            pnlGrillaContenedor.Location = new Point(0, 96);
            pnlGrillaContenedor.Margin = new Padding(3, 4, 3, 4);
            pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            pnlGrillaContenedor.Padding = new Padding(18, 16, 18, 16);
            pnlGrillaContenedor.Size = new Size(1257, 693);
            pnlGrillaContenedor.TabIndex = 0;
            pnlGrillaContenedor.Visible = false;
            // 
            // dgvLibroDiario
            // 
            dgvLibroDiario.AllowUserToAddRows = false;
            dgvLibroDiario.AllowUserToDeleteRows = false;
            dgvLibroDiario.AllowUserToResizeRows = false;
            dgvLibroDiario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibroDiario.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLibroDiario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLibroDiario.ColumnHeadersHeight = 36;
            dgvLibroDiario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLibroDiario.Columns.AddRange(new DataGridViewColumn[] { colFecha, colCuenta, colParcial, colDebe, colHaber });
            dgvLibroDiario.Dock = DockStyle.Fill;
            dgvLibroDiario.EnableHeadersVisualStyles = false;
            dgvLibroDiario.GridColor = Color.FromArgb(180, 198, 215);
            dgvLibroDiario.Location = new Point(18, 16);
            dgvLibroDiario.Margin = new Padding(3, 4, 3, 4);
            dgvLibroDiario.MultiSelect = false;
            dgvLibroDiario.Name = "dgvLibroDiario";
            dgvLibroDiario.ReadOnly = true;
            dgvLibroDiario.RowHeadersVisible = false;
            dgvLibroDiario.RowHeadersWidth = 51;
            dgvLibroDiario.RowTemplate.Height = 26;
            dgvLibroDiario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibroDiario.Size = new Size(1221, 661);
            dgvLibroDiario.TabIndex = 0;
            // 
            // colFecha
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFecha.DefaultCellStyle = dataGridViewCellStyle2;
            colFecha.FillWeight = 85F;
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colCuenta
            // 
            colCuenta.FillWeight = 260F;
            colCuenta.HeaderText = "Cuenta";
            colCuenta.MinimumWidth = 6;
            colCuenta.Name = "colCuenta";
            colCuenta.ReadOnly = true;
            colCuenta.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colParcial
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            colParcial.DefaultCellStyle = dataGridViewCellStyle3;
            colParcial.FillWeight = 95F;
            colParcial.HeaderText = "Parcial";
            colParcial.MinimumWidth = 6;
            colParcial.Name = "colParcial";
            colParcial.ReadOnly = true;
            colParcial.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colDebe
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            colDebe.DefaultCellStyle = dataGridViewCellStyle4;
            colDebe.FillWeight = 95F;
            colDebe.HeaderText = "Debe";
            colDebe.MinimumWidth = 6;
            colDebe.Name = "colDebe";
            colDebe.ReadOnly = true;
            colDebe.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // colHaber
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            colHaber.DefaultCellStyle = dataGridViewCellStyle5;
            colHaber.FillWeight = 95F;
            colHaber.HeaderText = "Haber";
            colHaber.MinimumWidth = 6;
            colHaber.Name = "colHaber";
            colHaber.ReadOnly = true;
            colHaber.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlResumenInferior
            // 
            pnlResumenInferior.BackColor = Color.White;
            pnlResumenInferior.Controls.Add(lblBadgeEstado);
            pnlResumenInferior.Controls.Add(lblTotalHaberGlobal);
            pnlResumenInferior.Controls.Add(lblTotalDebeGlobal);
            pnlResumenInferior.Controls.Add(lblTotalAsientos);
            pnlResumenInferior.Dock = DockStyle.Bottom;
            pnlResumenInferior.Location = new Point(0, 789);
            pnlResumenInferior.Margin = new Padding(3, 4, 3, 4);
            pnlResumenInferior.Name = "pnlResumenInferior";
            pnlResumenInferior.Padding = new Padding(18, 13, 18, 13);
            pnlResumenInferior.Size = new Size(1257, 64);
            pnlResumenInferior.TabIndex = 2;
            pnlResumenInferior.Visible = false;
            // 
            // lblBadgeEstado
            // 
            lblBadgeEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblBadgeEstado.AutoSize = true;
            lblBadgeEstado.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            lblBadgeEstado.Location = new Point(937, 20);
            lblBadgeEstado.Name = "lblBadgeEstado";
            lblBadgeEstado.Size = new Size(227, 21);
            lblBadgeEstado.TabIndex = 0;
            lblBadgeEstado.Text = "✓ Asientos Dobles Cuadrados";
            // 
            // lblTotalHaberGlobal
            // 
            lblTotalHaberGlobal.AutoSize = true;
            lblTotalHaberGlobal.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTotalHaberGlobal.ForeColor = Color.FromArgb(30, 41, 59);
            lblTotalHaberGlobal.Location = new Point(457, 20);
            lblTotalHaberGlobal.Name = "lblTotalHaberGlobal";
            lblTotalHaberGlobal.Size = new Size(143, 21);
            lblTotalHaberGlobal.TabIndex = 1;
            lblTotalHaberGlobal.Text = "Total Haber: $0.00";
            // 
            // lblTotalDebeGlobal
            // 
            lblTotalDebeGlobal.AutoSize = true;
            lblTotalDebeGlobal.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblTotalDebeGlobal.ForeColor = Color.FromArgb(30, 41, 59);
            lblTotalDebeGlobal.Location = new Point(217, 20);
            lblTotalDebeGlobal.Name = "lblTotalDebeGlobal";
            lblTotalDebeGlobal.Size = new Size(136, 21);
            lblTotalDebeGlobal.TabIndex = 2;
            lblTotalDebeGlobal.Text = "Total Debe: $0.00";
            // 
            // lblTotalAsientos
            // 
            lblTotalAsientos.AutoSize = true;
            lblTotalAsientos.Font = new Font("Segoe UI", 9.5F);
            lblTotalAsientos.ForeColor = Color.FromArgb(71, 85, 105);
            lblTotalAsientos.Location = new Point(18, 20);
            lblTotalAsientos.Name = "lblTotalAsientos";
            lblTotalAsientos.Size = new Size(85, 21);
            lblTotalAsientos.TabIndex = 3;
            lblTotalAsientos.Text = "Asientos: 0";
            // 
            // frmLibroDiario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1257, 853);
            Controls.Add(pnlGrillaContenedor);
            Controls.Add(pnlDashboard);
            Controls.Add(pnlResumenInferior);
            Controls.Add(pnlToolbar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmLibroDiario";
            Text = "Libro Diario";
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            pnlFiltroFechas.ResumeLayout(false);
            pnlFiltroFechas.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            pnlDashContent.ResumeLayout(false);
            pnlAcciones.ResumeLayout(false);
            pnlAcciones.PerformLayout();
            pnlListaAsientos.ResumeLayout(false);
            pnlListaAsientos.PerformLayout();
            pnlDashHeader.ResumeLayout(false);
            pnlDashHeader.PerformLayout();
            pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLibroDiario).EndInit();
            pnlResumenInferior.ResumeLayout(false);
            pnlResumenInferior.PerformLayout();
            ResumeLayout(false);
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
        private App_Contable.Presentacion.LibroDiarioInstanciaListBox lstLibros;
        private System.Windows.Forms.Panel    pnlAcciones;
        private System.Windows.Forms.Label    lblAccionesHeader;
        private System.Windows.Forms.Button   btnDashNuevo;
        private System.Windows.Forms.Button   btnDashGuardarBD;
        private System.Windows.Forms.Button   btnDashEliminar;
        private System.Windows.Forms.Label    lblHerramientasHeader;
        private System.Windows.Forms.Button   btnDashImportar;
        private System.Windows.Forms.Button   btnDashExportar;
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

