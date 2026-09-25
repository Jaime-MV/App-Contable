namespace App_Contable.Presentacion
{
    partial class frmBalanzaComprobacion
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
            System.Windows.Forms.DataGridViewCellStyle hdrStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle codigoStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cuentaStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle montoStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.flpAccionesDerecha = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFiltroFechas = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFlechaRango = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCargarDesdeLibro = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvBalanza = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoDeudor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoAcreedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEstadoVacio = new System.Windows.Forms.Panel();
            this.pnlCardVacio = new System.Windows.Forms.Panel();
            this.lblIconoVacio = new System.Windows.Forms.Label();
            this.lblMensajeVacio = new System.Windows.Forms.Label();
            this.lblSubtituloVacio = new System.Windows.Forms.Label();
            this.btnSeleccionarVacio = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblBadgeEstado = new System.Windows.Forms.Label();
            this.lblTotalSaldoAcreedor = new System.Windows.Forms.Label();
            this.lblTotalSaldoDeudor = new System.Windows.Forms.Label();
            this.lblTotalMovHaber = new System.Windows.Forms.Label();
            this.lblTotalMovDebe = new System.Windows.Forms.Label();
            this.lblTotalCuentas = new System.Windows.Forms.Label();

            this.pnlToolbar.SuspendLayout();
            this.flpAccionesDerecha.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanza)).BeginInit();
            this.pnlEstadoVacio.SuspendLayout();
            this.pnlCardVacio.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlToolbar ────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.lblTituloSeccion);
            this.pnlToolbar.Controls.Add(this.flpAccionesDerecha);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size = new System.Drawing.Size(1200, 64);
            this.pnlToolbar.TabIndex = 0;

            // ── lblTituloSeccion ──────────────────────────────────────────
            this.lblTituloSeccion.AutoEllipsis = true;
            this.lblTituloSeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTituloSeccion.Location = new System.Drawing.Point(16, 12);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(438, 40);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "BALANZA DE COMPROBACIÓN";
            this.lblTituloSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── flpAccionesDerecha ────────────────────────────────────────
            this.flpAccionesDerecha.AutoSize = true;
            this.flpAccionesDerecha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpAccionesDerecha.Controls.Add(this.pnlFiltroFechas);
            this.flpAccionesDerecha.Controls.Add(this.btnCargarDesdeLibro);
            this.flpAccionesDerecha.Controls.Add(this.btnActualizar);
            this.flpAccionesDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpAccionesDerecha.Location = new System.Drawing.Point(454, 12);
            this.flpAccionesDerecha.Name = "flpAccionesDerecha";
            this.flpAccionesDerecha.Size = new System.Drawing.Size(730, 40);
            this.flpAccionesDerecha.TabIndex = 1;
            this.flpAccionesDerecha.WrapContents = false;

            // ── pnlFiltroFechas ───────────────────────────────────────────
            this.pnlFiltroFechas.Controls.Add(this.btnFiltrar);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaFin);
            this.pnlFiltroFechas.Controls.Add(this.lblFlechaRango);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltroFechas.Controls.Add(this.lblPeriodo);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltroFechas.Margin = new System.Windows.Forms.Padding(0, 3, 8, 3);
            this.pnlFiltroFechas.Name = "pnlFiltroFechas";
            this.pnlFiltroFechas.Size = new System.Drawing.Size(370, 34);
            this.pnlFiltroFechas.TabIndex = 0;

            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPeriodo.Location = new System.Drawing.Point(3, 9);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(51, 15);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Período:";

            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(58, 6);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaInicio.TabIndex = 1;

            this.lblFlechaRango.AutoSize = true;
            this.lblFlechaRango.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFlechaRango.Location = new System.Drawing.Point(164, 9);
            this.lblFlechaRango.Name = "lblFlechaRango";
            this.lblFlechaRango.Size = new System.Drawing.Size(12, 15);
            this.lblFlechaRango.TabIndex = 2;
            this.lblFlechaRango.Text = "-";

            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(182, 6);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaFin.TabIndex = 3;

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnFiltrar.Location = new System.Drawing.Point(290, 4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(70, 26);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── btnCargarDesdeLibro ────────────────────────────────────────
            this.btnCargarDesdeLibro.BackColor = System.Drawing.Color.FromArgb(30, 96, 255);
            this.btnCargarDesdeLibro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarDesdeLibro.FlatAppearance.BorderSize = 0;
            this.btnCargarDesdeLibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarDesdeLibro.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnCargarDesdeLibro.ForeColor = System.Drawing.Color.White;
            this.btnCargarDesdeLibro.Location = new System.Drawing.Point(378, 3);
            this.btnCargarDesdeLibro.Margin = new System.Windows.Forms.Padding(0, 3, 8, 3);
            this.btnCargarDesdeLibro.Name = "btnCargarDesdeLibro";
            this.btnCargarDesdeLibro.Size = new System.Drawing.Size(235, 34);
            this.btnCargarDesdeLibro.TabIndex = 1;
            this.btnCargarDesdeLibro.Text = "⚡ Cargar desde Libro Diario";
            this.btnCargarDesdeLibro.UseVisualStyleBackColor = false;
            this.btnCargarDesdeLibro.Click += new System.EventHandler(this.btnCargarDesdeLibro_Click);

            // ── btnActualizar ─────────────────────────────────────────────
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnActualizar.Location = new System.Drawing.Point(621, 3);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 34);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "↺ Refrescar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // ── pnlGrillaContenedor ───────────────────────────────────────
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlGrillaContenedor.Controls.Add(this.dgvBalanza);
            this.pnlGrillaContenedor.Controls.Add(this.pnlEstadoVacio);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 64);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1200, 528);
            this.pnlGrillaContenedor.TabIndex = 1;

            // ── dgvBalanza ────────────────────────────────────────────────
            this.dgvBalanza.AllowUserToAddRows = false;
            this.dgvBalanza.AllowUserToDeleteRows = false;
            this.dgvBalanza.AllowUserToResizeRows = false;

            hdrStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            hdrStyle.BackColor = System.Drawing.Color.FromArgb(201, 218, 236);
            hdrStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            hdrStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(201, 218, 236);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            hdrStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvBalanza.ColumnHeadersDefaultCellStyle = hdrStyle;
            this.dgvBalanza.ColumnHeadersHeight = 42;
            this.dgvBalanza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBalanza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBalanza.BackgroundColor = System.Drawing.Color.White;
            this.dgvBalanza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvBalanza.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvBalanza.GridColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dgvBalanza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCodigo, this.colCuenta, this.colMovDebe, this.colMovHaber, this.colSaldoDeudor, this.colSaldoAcreedor });
            this.dgvBalanza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalanza.EnableHeadersVisualStyles = false;
            this.dgvBalanza.Location = new System.Drawing.Point(16, 12);
            this.dgvBalanza.MultiSelect = false;
            this.dgvBalanza.Name = "dgvBalanza";
            this.dgvBalanza.ReadOnly = true;
            this.dgvBalanza.RowHeadersVisible = false;
            this.dgvBalanza.RowTemplate.Height = 28;
            this.dgvBalanza.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalanza.TabIndex = 0;

            // colCodigo
            codigoStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            codigoStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colCodigo.DefaultCellStyle = codigoStyle;
            this.colCodigo.FillWeight = 65F;
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.MinimumWidth = 65;
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colCuenta
            cuentaStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cuentaStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colCuenta.DefaultCellStyle = cuentaStyle;
            this.colCuenta.FillWeight = 235F;
            this.colCuenta.HeaderText = "Cuenta / Nombre";
            this.colCuenta.MinimumWidth = 180;
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.ReadOnly = true;
            this.colCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colMovDebe
            montoStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            montoStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colMovDebe.DefaultCellStyle = montoStyle;
            this.colMovDebe.FillWeight = 110F;
            this.colMovDebe.HeaderText = "Movimiento\nDebe ($)";
            this.colMovDebe.MinimumWidth = 100;
            this.colMovDebe.Name = "colMovDebe";
            this.colMovDebe.ReadOnly = true;
            this.colMovDebe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colMovHaber
            var haberStyle = new System.Windows.Forms.DataGridViewCellStyle();
            haberStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            haberStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colMovHaber.DefaultCellStyle = haberStyle;
            this.colMovHaber.FillWeight = 110F;
            this.colMovHaber.HeaderText = "Movimiento\nHaber ($)";
            this.colMovHaber.MinimumWidth = 100;
            this.colMovHaber.Name = "colMovHaber";
            this.colMovHaber.ReadOnly = true;
            this.colMovHaber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colSaldoDeudor
            var sDeudorStyle = new System.Windows.Forms.DataGridViewCellStyle();
            sDeudorStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            sDeudorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colSaldoDeudor.DefaultCellStyle = sDeudorStyle;
            this.colSaldoDeudor.FillWeight = 110F;
            this.colSaldoDeudor.HeaderText = "Saldo\nDeudor ($)";
            this.colSaldoDeudor.MinimumWidth = 100;
            this.colSaldoDeudor.Name = "colSaldoDeudor";
            this.colSaldoDeudor.ReadOnly = true;
            this.colSaldoDeudor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colSaldoAcreedor
            var sAcreedorStyle = new System.Windows.Forms.DataGridViewCellStyle();
            sAcreedorStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            sAcreedorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colSaldoAcreedor.DefaultCellStyle = sAcreedorStyle;
            this.colSaldoAcreedor.FillWeight = 110F;
            this.colSaldoAcreedor.HeaderText = "Saldo\nAcreedor ($)";
            this.colSaldoAcreedor.MinimumWidth = 100;
            this.colSaldoAcreedor.Name = "colSaldoAcreedor";
            this.colSaldoAcreedor.ReadOnly = true;
            this.colSaldoAcreedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // ── pnlEstadoVacio ────────────────────────────────────────────
            this.pnlEstadoVacio.BackColor = System.Drawing.Color.White;
            this.pnlEstadoVacio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEstadoVacio.Controls.Add(this.pnlCardVacio);
            this.pnlEstadoVacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEstadoVacio.Location = new System.Drawing.Point(16, 12);
            this.pnlEstadoVacio.Name = "pnlEstadoVacio";
            this.pnlEstadoVacio.Size = new System.Drawing.Size(1168, 504);
            this.pnlEstadoVacio.TabIndex = 1;

            // ── pnlCardVacio ──────────────────────────────────────────────
            this.pnlCardVacio.BackColor = System.Drawing.Color.White;
            this.pnlCardVacio.Controls.Add(this.btnSeleccionarVacio);
            this.pnlCardVacio.Controls.Add(this.lblSubtituloVacio);
            this.pnlCardVacio.Controls.Add(this.lblMensajeVacio);
            this.pnlCardVacio.Controls.Add(this.lblIconoVacio);
            this.pnlCardVacio.Location = new System.Drawing.Point(344, 120);
            this.pnlCardVacio.Name = "pnlCardVacio";
            this.pnlCardVacio.Size = new System.Drawing.Size(480, 240);
            this.pnlCardVacio.TabIndex = 0;

            // ── lblIconoVacio ─────────────────────────────────────────────
            this.lblIconoVacio.Font = new System.Drawing.Font("Segoe UI Emoji", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIconoVacio.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblIconoVacio.Location = new System.Drawing.Point(0, 8);
            this.lblIconoVacio.Name = "lblIconoVacio";
            this.lblIconoVacio.Size = new System.Drawing.Size(480, 58);
            this.lblIconoVacio.TabIndex = 0;
            this.lblIconoVacio.Text = "⚖️";
            this.lblIconoVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblMensajeVacio ───────────────────────────────────────────
            this.lblMensajeVacio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMensajeVacio.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblMensajeVacio.Location = new System.Drawing.Point(0, 72);
            this.lblMensajeVacio.Name = "lblMensajeVacio";
            this.lblMensajeVacio.Size = new System.Drawing.Size(480, 28);
            this.lblMensajeVacio.TabIndex = 1;
            this.lblMensajeVacio.Text = "No hay ninguna Balanza de Comprobación cargada";
            this.lblMensajeVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblSubtituloVacio ─────────────────────────────────────────
            this.lblSubtituloVacio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtituloVacio.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtituloVacio.Location = new System.Drawing.Point(20, 104);
            this.lblSubtituloVacio.Name = "lblSubtituloVacio";
            this.lblSubtituloVacio.Size = new System.Drawing.Size(440, 44);
            this.lblSubtituloVacio.TabIndex = 2;
            this.lblSubtituloVacio.Text = "Selecciona un Libro Diario para calcular y generar automáticamente la balanza de " +
    "comprobación.";
            this.lblSubtituloVacio.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // ── btnSeleccionarVacio ───────────────────────────────────────
            this.btnSeleccionarVacio.BackColor = System.Drawing.Color.FromArgb(30, 96, 255);
            this.btnSeleccionarVacio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarVacio.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarVacio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarVacio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionarVacio.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarVacio.Location = new System.Drawing.Point(125, 160);
            this.btnSeleccionarVacio.Name = "btnSeleccionarVacio";
            this.btnSeleccionarVacio.Size = new System.Drawing.Size(230, 40);
            this.btnSeleccionarVacio.TabIndex = 3;
            this.btnSeleccionarVacio.Text = "⚡ Seleccionar Libro Diario";
            this.btnSeleccionarVacio.UseVisualStyleBackColor = false;
            this.btnSeleccionarVacio.Click += new System.EventHandler(this.btnCargarDesdeLibro_Click);

            // ── pnlFooter ─────────────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblBadgeEstado);
            this.pnlFooter.Controls.Add(this.lblTotalSaldoAcreedor);
            this.pnlFooter.Controls.Add(this.lblTotalSaldoDeudor);
            this.pnlFooter.Controls.Add(this.lblTotalMovHaber);
            this.pnlFooter.Controls.Add(this.lblTotalMovDebe);
            this.pnlFooter.Controls.Add(this.lblTotalCuentas);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 592);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlFooter.Size = new System.Drawing.Size(1200, 48);
            this.pnlFooter.TabIndex = 2;

            this.lblTotalCuentas.AutoSize = true;
            this.lblTotalCuentas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCuentas.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTotalCuentas.Location = new System.Drawing.Point(16, 16);
            this.lblTotalCuentas.Name = "lblTotalCuentas";
            this.lblTotalCuentas.Size = new System.Drawing.Size(64, 15);
            this.lblTotalCuentas.TabIndex = 0;
            this.lblTotalCuentas.Text = "Cuentas: 0";

            this.lblTotalMovDebe.AutoSize = true;
            this.lblTotalMovDebe.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalMovDebe.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalMovDebe.Location = new System.Drawing.Point(120, 16);
            this.lblTotalMovDebe.Name = "lblTotalMovDebe";
            this.lblTotalMovDebe.Size = new System.Drawing.Size(117, 15);
            this.lblTotalMovDebe.TabIndex = 1;
            this.lblTotalMovDebe.Text = "Mov. Debe: $0.00";

            this.lblTotalMovHaber.AutoSize = true;
            this.lblTotalMovHaber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalMovHaber.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalMovHaber.Location = new System.Drawing.Point(295, 16);
            this.lblTotalMovHaber.Name = "lblTotalMovHaber";
            this.lblTotalMovHaber.Size = new System.Drawing.Size(121, 15);
            this.lblTotalMovHaber.TabIndex = 2;
            this.lblTotalMovHaber.Text = "Mov. Haber: $0.00";

            this.lblTotalSaldoDeudor.AutoSize = true;
            this.lblTotalSaldoDeudor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSaldoDeudor.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalSaldoDeudor.Location = new System.Drawing.Point(475, 16);
            this.lblTotalSaldoDeudor.Name = "lblTotalSaldoDeudor";
            this.lblTotalSaldoDeudor.Size = new System.Drawing.Size(126, 15);
            this.lblTotalSaldoDeudor.TabIndex = 3;
            this.lblTotalSaldoDeudor.Text = "Saldo Deudor: $0.00";

            this.lblTotalSaldoAcreedor.AutoSize = true;
            this.lblTotalSaldoAcreedor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSaldoAcreedor.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalSaldoAcreedor.Location = new System.Drawing.Point(665, 16);
            this.lblTotalSaldoAcreedor.Name = "lblTotalSaldoAcreedor";
            this.lblTotalSaldoAcreedor.Size = new System.Drawing.Size(135, 15);
            this.lblTotalSaldoAcreedor.TabIndex = 4;
            this.lblTotalSaldoAcreedor.Text = "Saldo Acreedor: $0.00";

            this.lblBadgeEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.lblBadgeEstado.AutoSize = true;
            this.lblBadgeEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBadgeEstado.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblBadgeEstado.Location = new System.Drawing.Point(920, 15);
            this.lblBadgeEstado.Name = "lblBadgeEstado";
            this.lblBadgeEstado.Size = new System.Drawing.Size(260, 17);
            this.lblBadgeEstado.TabIndex = 5;
            this.lblBadgeEstado.Text = "✓ Balanza Cuadrada";

            // ── frmBalanzaComprobacion ────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBalanzaComprobacion";
            this.Text = "Balanza de Comprobación";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.flpAccionesDerecha.ResumeLayout(false);
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanza)).EndInit();
            this.pnlEstadoVacio.ResumeLayout(false);
            this.pnlCardVacio.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.FlowLayoutPanel flpAccionesDerecha;
        private System.Windows.Forms.Panel pnlFiltroFechas;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFlechaRango;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCargarDesdeLibro;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvBalanza;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoDeudor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoAcreedor;
        private System.Windows.Forms.Panel pnlEstadoVacio;
        private System.Windows.Forms.Panel pnlCardVacio;
        private System.Windows.Forms.Label lblIconoVacio;
        private System.Windows.Forms.Label lblMensajeVacio;
        private System.Windows.Forms.Label lblSubtituloVacio;
        private System.Windows.Forms.Button btnSeleccionarVacio;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotalCuentas;
        private System.Windows.Forms.Label lblTotalMovDebe;
        private System.Windows.Forms.Label lblTotalMovHaber;
        private System.Windows.Forms.Label lblTotalSaldoDeudor;
        private System.Windows.Forms.Label lblTotalSaldoAcreedor;
        private System.Windows.Forms.Label lblBadgeEstado;
    }
}

