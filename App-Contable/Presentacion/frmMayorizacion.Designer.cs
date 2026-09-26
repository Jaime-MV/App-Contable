namespace App_Contable.Presentacion
{
    partial class frmMayorizacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFlecha = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cmbCuentas = new System.Windows.Forms.ComboBox();
            this.btnCambiarVista = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvMayorizacion = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNaturaleza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlCuentas = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTotalHaber = new System.Windows.Forms.Label();
            this.lblTotalDebe = new System.Windows.Forms.Label();
            this.lblTotalCuentas = new System.Windows.Forms.Label();

            this.pnlToolbar.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMayorizacion)).BeginInit();
            this.pnlScroll.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlToolbar ────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnRefrescar);
            this.pnlToolbar.Controls.Add(this.btnCopiar);
            this.pnlToolbar.Controls.Add(this.btnCambiarVista);
            this.pnlToolbar.Controls.Add(this.cmbCuentas);
            this.pnlToolbar.Controls.Add(this.pnlFiltro);
            this.pnlToolbar.Controls.Add(this.lblTituloSeccion);
            this.pnlToolbar.Controls.Add(this.btnVolver);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size = new System.Drawing.Size(1100, 72);
            this.pnlToolbar.TabIndex = 0;

            // ── btnVolver ─────────────────────────────────────────────────
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnVolver.Location = new System.Drawing.Point(16, 18);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(85, 36);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "← Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // ── lblTituloSeccion ──────────────────────────────────────────
            this.lblTituloSeccion.AutoSize = true;
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTituloSeccion.Location = new System.Drawing.Point(112, 25);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(125, 21);
            this.lblTituloSeccion.TabIndex = 1;
            this.lblTituloSeccion.Text = "LIBRO MAYOR";

            // ── pnlFiltro ─────────────────────────────────────────────────
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Controls.Add(this.dtpHasta);
            this.pnlFiltro.Controls.Add(this.lblFlecha);
            this.pnlFiltro.Controls.Add(this.dtpDesde);
            this.pnlFiltro.Controls.Add(this.lblDesde);
            this.pnlFiltro.Location = new System.Drawing.Point(400, 16);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(270, 38);
            this.pnlFiltro.TabIndex = 2;

            // Período label
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDesde.Location = new System.Drawing.Point(3, 11);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(51, 15);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Período:";

            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(54, 8);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(88, 23);
            this.dtpDesde.TabIndex = 1;

            this.lblFlecha.AutoSize = true;
            this.lblFlecha.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFlecha.Location = new System.Drawing.Point(144, 11);
            this.lblFlecha.Name = "lblFlecha";
            this.lblFlecha.Size = new System.Drawing.Size(12, 15);
            this.lblFlecha.TabIndex = 2;
            this.lblFlecha.Text = "-";

            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(156, 8);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(88, 23);
            this.dtpHasta.TabIndex = 3;

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnFiltrar.Location = new System.Drawing.Point(248, 7);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(55, 25);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── cmbCuentas (Filtro por cuenta específica) ──────────────────
            this.cmbCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuentas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCuentas.FormattingEnabled = true;
            this.cmbCuentas.Location = new System.Drawing.Point(590, 23);
            this.cmbCuentas.Name = "cmbCuentas";
            this.cmbCuentas.Size = new System.Drawing.Size(140, 23);
            this.cmbCuentas.TabIndex = 3;
            this.cmbCuentas.SelectedIndexChanged += new System.EventHandler(this.cmbCuentas_SelectedIndexChanged);

            // ── btnCambiarVista ───────────────────────────────────────────
            this.btnCambiarVista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiarVista.BackColor = System.Drawing.Color.White;
            this.btnCambiarVista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarVista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCambiarVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarVista.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCambiarVista.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCambiarVista.Location = new System.Drawing.Point(740, 18);
            this.btnCambiarVista.Name = "btnCambiarVista";
            this.btnCambiarVista.Size = new System.Drawing.Size(130, 36);
            this.btnCambiarVista.TabIndex = 3;
            this.btnCambiarVista.Text = "🗂️ Vista Tarjetas";
            this.btnCambiarVista.UseVisualStyleBackColor = false;
            this.btnCambiarVista.Click += new System.EventHandler(this.btnCambiarVista_Click);

            // ── btnCopiar ─────────────────────────────────────────────────
            this.btnCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiar.BackColor = System.Drawing.Color.White;
            this.btnCopiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCopiar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCopiar.Location = new System.Drawing.Point(880, 18);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(95, 36);
            this.btnCopiar.TabIndex = 4;
            this.btnCopiar.Text = "📋 Copiar";
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);

            // ── btnRefrescar ──────────────────────────────────────────────
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.BackColor = System.Drawing.Color.White;
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefrescar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnRefrescar.Location = new System.Drawing.Point(985, 18);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(95, 36);
            this.btnRefrescar.TabIndex = 5;
            this.btnRefrescar.Text = "🔄 Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // ── pnlGrillaContenedor (VISTA PRINCIPAL: Idéntica al Libro Diario)
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlGrillaContenedor.Controls.Add(this.dgvMayorizacion);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 72);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1100, 520);
            this.pnlGrillaContenedor.TabIndex = 1;

            // ── dgvMayorizacion (Grilla continua estilo Libro Diario) ──────
            this.dgvMayorizacion.AllowUserToAddRows = false;
            this.dgvMayorizacion.AllowUserToDeleteRows = false;
            this.dgvMayorizacion.AllowUserToResizeRows = false;
            this.dgvMayorizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMayorizacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvMayorizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvMayorizacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvMayorizacion.GridColor = System.Drawing.Color.FromArgb(180, 198, 215);
            
            // Encabezado contable idéntico a Libro Diario
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMayorizacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMayorizacion.ColumnHeadersHeight = 36;
            this.dgvMayorizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMayorizacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colReferencia,
            this.colDescripcion,
            this.colDebe,
            this.colHaber,
            this.colSaldo,
            this.colNaturaleza});
            this.dgvMayorizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMayorizacion.EnableHeadersVisualStyles = false;
            this.dgvMayorizacion.Location = new System.Drawing.Point(16, 12);
            this.dgvMayorizacion.MultiSelect = false;
            this.dgvMayorizacion.Name = "dgvMayorizacion";
            this.dgvMayorizacion.ReadOnly = true;
            this.dgvMayorizacion.RowHeadersVisible = false;
            this.dgvMayorizacion.RowTemplate.Height = 26;
            this.dgvMayorizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMayorizacion.Size = new System.Drawing.Size(1068, 496);
            this.dgvMayorizacion.TabIndex = 0;

            // colFecha
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFecha.FillWeight = 75F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colReferencia
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colReferencia.DefaultCellStyle = dataGridViewCellStyle3;
            this.colReferencia.FillWeight = 65F;
            this.colReferencia.HeaderText = "Partida";
            this.colReferencia.Name = "colReferencia";
            this.colReferencia.ReadOnly = true;
            this.colReferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colDescripcion
            this.colDescripcion.FillWeight = 260F;
            this.colDescripcion.HeaderText = "Cuenta / Detalle";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colDebe
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.colDebe.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDebe.FillWeight = 95F;
            this.colDebe.HeaderText = "Debe";
            this.colDebe.Name = "colDebe";
            this.colDebe.ReadOnly = true;
            this.colDebe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colHaber
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.colHaber.DefaultCellStyle = dataGridViewCellStyle5;
            this.colHaber.FillWeight = 95F;
            this.colHaber.HeaderText = "Haber";
            this.colHaber.Name = "colHaber";
            this.colHaber.ReadOnly = true;
            this.colHaber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colSaldo
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.colSaldo.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSaldo.FillWeight = 95F;
            this.colSaldo.HeaderText = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.ReadOnly = true;
            this.colSaldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colNaturaleza
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNaturaleza.DefaultCellStyle = dataGridViewCellStyle7;
            this.colNaturaleza.FillWeight = 35F;
            this.colNaturaleza.HeaderText = "Nat.";
            this.colNaturaleza.Name = "colNaturaleza";
            this.colNaturaleza.ReadOnly = true;
            this.colNaturaleza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // ── pnlScroll (VISTA SECUNDARIA: Tarjetas individuales) ────────
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlScroll.Controls.Add(this.pnlCuentas);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 72);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlScroll.Size = new System.Drawing.Size(1100, 520);
            this.pnlScroll.TabIndex = 2;
            this.pnlScroll.Visible = false;

            // ── pnlCuentas (tarjetas dentro del scroll) ───────────────────
            this.pnlCuentas.AutoScroll = true;
            this.pnlCuentas.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuentas.Location = new System.Drawing.Point(16, 12);
            this.pnlCuentas.Name = "pnlCuentas";
            this.pnlCuentas.Padding = new System.Windows.Forms.Padding(0, 0, 8, 20);
            this.pnlCuentas.Size = new System.Drawing.Size(1068, 496);
            this.pnlCuentas.TabIndex = 0;

            // ── pnlFooter ─────────────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblEstado);
            this.pnlFooter.Controls.Add(this.lblTotalHaber);
            this.pnlFooter.Controls.Add(this.lblTotalDebe);
            this.pnlFooter.Controls.Add(this.lblTotalCuentas);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 592);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlFooter.Size = new System.Drawing.Size(1100, 48);
            this.pnlFooter.TabIndex = 3;

            this.lblTotalCuentas.AutoSize = true;
            this.lblTotalCuentas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCuentas.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTotalCuentas.Location = new System.Drawing.Point(16, 15);
            this.lblTotalCuentas.Name = "lblTotalCuentas";
            this.lblTotalCuentas.Size = new System.Drawing.Size(117, 17);
            this.lblTotalCuentas.TabIndex = 0;
            this.lblTotalCuentas.Text = "Cuentas: 0";

            this.lblTotalDebe.AutoSize = true;
            this.lblTotalDebe.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDebe.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalDebe.Location = new System.Drawing.Point(190, 15);
            this.lblTotalDebe.Name = "lblTotalDebe";
            this.lblTotalDebe.Size = new System.Drawing.Size(162, 17);
            this.lblTotalDebe.TabIndex = 1;
            this.lblTotalDebe.Text = "Total Debe: $0.00";

            this.lblTotalHaber.AutoSize = true;
            this.lblTotalHaber.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalHaber.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalHaber.Location = new System.Drawing.Point(400, 15);
            this.lblTotalHaber.Name = "lblTotalHaber";
            this.lblTotalHaber.Size = new System.Drawing.Size(167, 17);
            this.lblTotalHaber.TabIndex = 2;
            this.lblTotalHaber.Text = "Total Haber: $0.00";

            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblEstado.Location = new System.Drawing.Point(890, 15);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(190, 17);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "✓ Mayorización Cuadrada";

            // ── frmMayorizacion ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlScroll);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMayorizacion";
            this.Text = "Mayorización";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMayorizacion)).EndInit();
            this.pnlScroll.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblFlecha;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cmbCuentas;
        private System.Windows.Forms.Button btnCambiarVista;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.ToolTip toolTipAyuda;
        private System.Windows.Forms.Panel pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvMayorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaturaleza;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlCuentas;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTotalHaber;
        private System.Windows.Forms.Label lblTotalDebe;
        private System.Windows.Forms.Label lblTotalCuentas;
    }
}

