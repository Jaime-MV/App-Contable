namespace App_Contable.Presentacion
{
    partial class frmBalanceGeneral
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
            System.Windows.Forms.DataGridViewCellStyle cuentaStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle montoStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.flpAccionesDerecha = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFiltroFechas = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpFechaCorte = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCargarDesdeLibro = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvBalanceGeneral = new System.Windows.Forms.DataGridView();
            this.colCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParcial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEstadoVacio = new System.Windows.Forms.Panel();
            this.pnlCardVacio = new System.Windows.Forms.Panel();
            this.lblIconoVacio = new System.Windows.Forms.Label();
            this.lblMensajeVacio = new System.Windows.Forms.Label();
            this.lblSubtituloVacio = new System.Windows.Forms.Label();
            this.btnSeleccionarVacio = new System.Windows.Forms.Button();
            this.pnlResumenInferior = new System.Windows.Forms.Panel();
            this.lblBadgeEstado = new System.Windows.Forms.Label();
            this.lblTotalPasivoPatrimonio = new System.Windows.Forms.Label();
            this.lblTotalActivo = new System.Windows.Forms.Label();

            this.pnlToolbar.SuspendLayout();
            this.flpAccionesDerecha.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanceGeneral)).BeginInit();
            this.pnlEstadoVacio.SuspendLayout();
            this.pnlCardVacio.SuspendLayout();
            this.pnlResumenInferior.SuspendLayout();
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
            this.lblTituloSeccion.Size = new System.Drawing.Size(514, 40);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "BALANCE GENERAL";
            this.lblTituloSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── flpAccionesDerecha ────────────────────────────────────────
            this.flpAccionesDerecha.AutoSize = true;
            this.flpAccionesDerecha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpAccionesDerecha.Controls.Add(this.pnlFiltroFechas);
            this.flpAccionesDerecha.Controls.Add(this.btnCargarDesdeLibro);
            this.flpAccionesDerecha.Controls.Add(this.btnActualizar);
            this.flpAccionesDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpAccionesDerecha.Location = new System.Drawing.Point(530, 12);
            this.flpAccionesDerecha.Name = "flpAccionesDerecha";
            this.flpAccionesDerecha.Size = new System.Drawing.Size(654, 40);
            this.flpAccionesDerecha.TabIndex = 1;
            this.flpAccionesDerecha.WrapContents = false;

            // ── pnlFiltroFechas ───────────────────────────────────────────
            this.pnlFiltroFechas.Controls.Add(this.btnFiltrar);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaCorte);
            this.pnlFiltroFechas.Controls.Add(this.lblPeriodo);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltroFechas.Margin = new System.Windows.Forms.Padding(0, 3, 8, 3);
            this.pnlFiltroFechas.Name = "pnlFiltroFechas";
            this.pnlFiltroFechas.Size = new System.Drawing.Size(294, 34);
            this.pnlFiltroFechas.TabIndex = 0;

            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPeriodo.Location = new System.Drawing.Point(3, 9);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(89, 15);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Fecha de Corte:";

            this.dtpFechaCorte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCorte.Location = new System.Drawing.Point(98, 6);
            this.dtpFechaCorte.Name = "dtpFechaCorte";
            this.dtpFechaCorte.Size = new System.Drawing.Size(105, 23);
            this.dtpFechaCorte.TabIndex = 1;

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnFiltrar.Location = new System.Drawing.Point(212, 4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(70, 26);
            this.btnFiltrar.TabIndex = 2;
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
            this.btnCargarDesdeLibro.Location = new System.Drawing.Point(302, 3);
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
            this.btnActualizar.Location = new System.Drawing.Point(545, 3);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 34);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "↺ Refrescar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // ── pnlGrillaContenedor ───────────────────────────────────────
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlGrillaContenedor.Controls.Add(this.dgvBalanceGeneral);
            this.pnlGrillaContenedor.Controls.Add(this.pnlEstadoVacio);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 64);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1200, 528);
            this.pnlGrillaContenedor.TabIndex = 1;

            // ── dgvBalanceGeneral ─────────────────────────────────────────
            this.dgvBalanceGeneral.AllowUserToAddRows = false;
            this.dgvBalanceGeneral.AllowUserToDeleteRows = false;
            this.dgvBalanceGeneral.AllowUserToResizeRows = false;
            this.dgvBalanceGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBalanceGeneral.BackgroundColor = System.Drawing.Color.White;
            this.dgvBalanceGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvBalanceGeneral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvBalanceGeneral.GridColor = System.Drawing.Color.FromArgb(203, 213, 225);

            hdrStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor = System.Drawing.Color.FromArgb(201, 218, 236);
            hdrStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            hdrStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(201, 218, 236);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            hdrStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvBalanceGeneral.ColumnHeadersDefaultCellStyle = hdrStyle;
            this.dgvBalanceGeneral.ColumnHeadersHeight = 36;
            this.dgvBalanceGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBalanceGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCuenta,
                this.colParcial,
                this.colSubtotal,
                this.colTotal
            });
            this.dgvBalanceGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalanceGeneral.EnableHeadersVisualStyles = false;
            this.dgvBalanceGeneral.Location = new System.Drawing.Point(16, 12);
            this.dgvBalanceGeneral.MultiSelect = false;
            this.dgvBalanceGeneral.Name = "dgvBalanceGeneral";
            this.dgvBalanceGeneral.ReadOnly = true;
            this.dgvBalanceGeneral.RowHeadersVisible = false;
            this.dgvBalanceGeneral.RowTemplate.Height = 28;
            this.dgvBalanceGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalanceGeneral.TabIndex = 0;

            // colCuenta
            cuentaStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cuentaStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colCuenta.DefaultCellStyle = cuentaStyle;
            this.colCuenta.FillWeight = 260F;
            this.colCuenta.HeaderText = "Cuenta";
            this.colCuenta.MinimumWidth = 200;
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.ReadOnly = true;
            this.colCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colParcial
            montoStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            montoStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colParcial.DefaultCellStyle = montoStyle;
            this.colParcial.FillWeight = 95F;
            this.colParcial.HeaderText = "Parcial ($)";
            this.colParcial.MinimumWidth = 90;
            this.colParcial.Name = "colParcial";
            this.colParcial.ReadOnly = true;
            this.colParcial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colSubtotal
            var subtotalStyle = new System.Windows.Forms.DataGridViewCellStyle(montoStyle);
            this.colSubtotal.DefaultCellStyle = subtotalStyle;
            this.colSubtotal.FillWeight = 95F;
            this.colSubtotal.HeaderText = "Subtotal ($)";
            this.colSubtotal.MinimumWidth = 90;
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            this.colSubtotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colTotal
            var totalStyle = new System.Windows.Forms.DataGridViewCellStyle(montoStyle);
            this.colTotal.DefaultCellStyle = totalStyle;
            this.colTotal.FillWeight = 95F;
            this.colTotal.HeaderText = "Total ($)";
            this.colTotal.MinimumWidth = 90;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

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
            this.lblIconoVacio.Text = "🏛️";
            this.lblIconoVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblMensajeVacio ───────────────────────────────────────────
            this.lblMensajeVacio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMensajeVacio.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblMensajeVacio.Location = new System.Drawing.Point(0, 72);
            this.lblMensajeVacio.Name = "lblMensajeVacio";
            this.lblMensajeVacio.Size = new System.Drawing.Size(480, 28);
            this.lblMensajeVacio.TabIndex = 1;
            this.lblMensajeVacio.Text = "No hay ningún Balance General cargado";
            this.lblMensajeVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── lblSubtituloVacio ─────────────────────────────────────────
            this.lblSubtituloVacio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtituloVacio.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtituloVacio.Location = new System.Drawing.Point(20, 104);
            this.lblSubtituloVacio.Name = "lblSubtituloVacio";
            this.lblSubtituloVacio.Size = new System.Drawing.Size(440, 44);
            this.lblSubtituloVacio.TabIndex = 2;
            this.lblSubtituloVacio.Text = "Selecciona un Libro Diario para calcular y generar automáticamente este estado financiero.";
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

            // ── pnlResumenInferior ─────────────────────────────────────────
            this.pnlResumenInferior.BackColor = System.Drawing.Color.White;
            this.pnlResumenInferior.Controls.Add(this.lblBadgeEstado);
            this.pnlResumenInferior.Controls.Add(this.lblTotalPasivoPatrimonio);
            this.pnlResumenInferior.Controls.Add(this.lblTotalActivo);
            this.pnlResumenInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumenInferior.Location = new System.Drawing.Point(0, 592);
            this.pnlResumenInferior.Name = "pnlResumenInferior";
            this.pnlResumenInferior.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlResumenInferior.Size = new System.Drawing.Size(1200, 48);
            this.pnlResumenInferior.TabIndex = 2;

            this.lblTotalActivo.AutoSize = true;
            this.lblTotalActivo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalActivo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalActivo.Location = new System.Drawing.Point(16, 15);
            this.lblTotalActivo.Name = "lblTotalActivo";
            this.lblTotalActivo.Size = new System.Drawing.Size(165, 17);
            this.lblTotalActivo.TabIndex = 0;
            this.lblTotalActivo.Text = "Total Activo: $0.00";

            this.lblTotalPasivoPatrimonio.AutoSize = true;
            this.lblTotalPasivoPatrimonio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalPasivoPatrimonio.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalPasivoPatrimonio.Location = new System.Drawing.Point(260, 15);
            this.lblTotalPasivoPatrimonio.Name = "lblTotalPasivoPatrimonio";
            this.lblTotalPasivoPatrimonio.Size = new System.Drawing.Size(225, 17);
            this.lblTotalPasivoPatrimonio.TabIndex = 1;
            this.lblTotalPasivoPatrimonio.Text = "Total Pasivo + Pat.: $0.00";

            this.lblBadgeEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadgeEstado.AutoSize = true;
            this.lblBadgeEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBadgeEstado.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblBadgeEstado.Location = new System.Drawing.Point(740, 15);
            this.lblBadgeEstado.Name = "lblBadgeEstado";
            this.lblBadgeEstado.Size = new System.Drawing.Size(440, 17);
            this.lblBadgeEstado.TabIndex = 2;
            this.lblBadgeEstado.Text = "✓ Balance General Cuadrado (Activo = Pasivo + Patrimonio)";

            // ── frmBalanceGeneral ─────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlResumenInferior);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBalanceGeneral";
            this.Text = "Balance General";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.flpAccionesDerecha.ResumeLayout(false);
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanceGeneral)).EndInit();
            this.pnlEstadoVacio.ResumeLayout(false);
            this.pnlCardVacio.ResumeLayout(false);
            this.pnlResumenInferior.ResumeLayout(false);
            this.pnlResumenInferior.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.FlowLayoutPanel flpAccionesDerecha;
        private System.Windows.Forms.Panel pnlFiltroFechas;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFechaCorte;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCargarDesdeLibro;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvBalanceGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParcial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Panel pnlEstadoVacio;
        private System.Windows.Forms.Panel pnlCardVacio;
        private System.Windows.Forms.Label lblIconoVacio;
        private System.Windows.Forms.Label lblMensajeVacio;
        private System.Windows.Forms.Label lblSubtituloVacio;
        private System.Windows.Forms.Button btnSeleccionarVacio;
        private System.Windows.Forms.Panel pnlResumenInferior;
        private System.Windows.Forms.Label lblTotalActivo;
        private System.Windows.Forms.Label lblTotalPasivoPatrimonio;
        private System.Windows.Forms.Label lblBadgeEstado;
    }
}

