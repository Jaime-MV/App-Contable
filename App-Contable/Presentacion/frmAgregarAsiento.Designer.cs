namespace App_Contable.Presentacion
{
    partial class frmAgregarAsiento
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtNumeroAsiento = new System.Windows.Forms.TextBox();
            this.lblNumeroAsiento = new System.Windows.Forms.Label();
            this.gbMovimiento = new System.Windows.Forms.GroupBox();
            this.btnAgregarMovimiento = new System.Windows.Forms.Button();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.rbHaber = new System.Windows.Forms.RadioButton();
            this.rbDebe = new System.Windows.Forms.RadioButton();
            this.lblTipoMov = new System.Windows.Forms.Label();
            this.lblAvisoSubcuenta = new System.Windows.Forms.Label();
            this.cmbSubcuenta = new System.Windows.Forms.ComboBox();
            this.lblSubcuenta = new System.Windows.Forms.Label();
            this.cmbCuentaPrincipal = new System.Windows.Forms.ComboBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubcuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblEstadoCuadre = new System.Windows.Forms.Label();
            this.lblTotalHaber = new System.Windows.Forms.Label();
            this.lblTotalDebe = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.gbDatosGenerales.SuspendLayout();
            this.gbMovimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            this.gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.pnlHeader.Size = new System.Drawing.Size(920, 68);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(21, 38);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(395, 15);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Registro de partida contable aplicando catálogo oficial y ley de partida doble";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(267, 25);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Nuevo Asiento de Libro Diario";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gbDetalle);
            this.pnlMain.Controls.Add(this.gbMovimiento);
            this.pnlMain.Controls.Add(this.gbDatosGenerales);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 68);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(18, 12, 18, 10);
            this.pnlMain.Size = new System.Drawing.Size(920, 526);
            this.pnlMain.TabIndex = 1;
            // 
            // gbDatosGenerales
            // 
            this.gbDatosGenerales.Controls.Add(this.txtConcepto);
            this.gbDatosGenerales.Controls.Add(this.lblConcepto);
            this.gbDatosGenerales.Controls.Add(this.dtpFecha);
            this.gbDatosGenerales.Controls.Add(this.lblFecha);
            this.gbDatosGenerales.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDatosGenerales.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbDatosGenerales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.gbDatosGenerales.Location = new System.Drawing.Point(18, 12);
            this.gbDatosGenerales.Name = "gbDatosGenerales";
            this.gbDatosGenerales.Size = new System.Drawing.Size(884, 82);
            this.gbDatosGenerales.TabIndex = 0;
            this.gbDatosGenerales.TabStop = false;
            this.gbDatosGenerales.Text = "Datos de la Partida";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConcepto.Location = new System.Drawing.Point(315, 42);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.PlaceholderText = "Ej: Por venta de mercadería al contado según factura N° 102...";
            this.txtConcepto.Size = new System.Drawing.Size(550, 24);
            this.txtConcepto.TabIndex = 5;
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConcepto.Location = new System.Drawing.Point(315, 23);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(155, 15);
            this.lblConcepto.TabIndex = 4;
            this.lblConcepto.Text = "Concepto / Glosa de Asiento:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(18, 42);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(150, 24);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFecha.Location = new System.Drawing.Point(18, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtNumeroAsiento
            // 
            this.txtNumeroAsiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtNumeroAsiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNumeroAsiento.Location = new System.Drawing.Point(18, 42);
            this.txtNumeroAsiento.Name = "txtNumeroAsiento";
            this.txtNumeroAsiento.ReadOnly = true;
            this.txtNumeroAsiento.Size = new System.Drawing.Size(105, 24);
            this.txtNumeroAsiento.TabIndex = 1;
            this.txtNumeroAsiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroAsiento.Visible = false;
            // 
            // lblNumeroAsiento
            // 
            this.lblNumeroAsiento.AutoSize = true;
            this.lblNumeroAsiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroAsiento.Location = new System.Drawing.Point(18, 23);
            this.lblNumeroAsiento.Name = "lblNumeroAsiento";
            this.lblNumeroAsiento.Size = new System.Drawing.Size(69, 15);
            this.lblNumeroAsiento.TabIndex = 0;
            this.lblNumeroAsiento.Text = "Asiento N°:";
            this.lblNumeroAsiento.Visible = false;
            // 
            // gbMovimiento
            // 
            this.gbMovimiento.Controls.Add(this.btnAgregarMovimiento);
            this.gbMovimiento.Controls.Add(this.numMonto);
            this.gbMovimiento.Controls.Add(this.lblMonto);
            this.gbMovimiento.Controls.Add(this.rbHaber);
            this.gbMovimiento.Controls.Add(this.rbDebe);
            this.gbMovimiento.Controls.Add(this.lblTipoMov);
            this.gbMovimiento.Controls.Add(this.lblAvisoSubcuenta);
            this.gbMovimiento.Controls.Add(this.cmbSubcuenta);
            this.gbMovimiento.Controls.Add(this.lblSubcuenta);
            this.gbMovimiento.Controls.Add(this.cmbCuentaPrincipal);
            this.gbMovimiento.Controls.Add(this.lblCuenta);
            this.gbMovimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMovimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.gbMovimiento.Location = new System.Drawing.Point(18, 94);
            this.gbMovimiento.Name = "gbMovimiento";
            this.gbMovimiento.Size = new System.Drawing.Size(884, 108);
            this.gbMovimiento.TabIndex = 1;
            this.gbMovimiento.TabStop = false;
            this.gbMovimiento.Text = "Agregar Movimiento de Cuenta";
            // 
            // btnAgregarMovimiento
            // 
            this.btnAgregarMovimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAgregarMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMovimiento.FlatAppearance.BorderSize = 0;
            this.btnAgregarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMovimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarMovimiento.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMovimiento.Location = new System.Drawing.Point(745, 47);
            this.btnAgregarMovimiento.Name = "btnAgregarMovimiento";
            this.btnAgregarMovimiento.Size = new System.Drawing.Size(120, 32);
            this.btnAgregarMovimiento.TabIndex = 10;
            this.btnAgregarMovimiento.Text = "➕ Agregar";
            this.btnAgregarMovimiento.UseVisualStyleBackColor = false;
            this.btnAgregarMovimiento.Click += new System.EventHandler(this.btnAgregarMovimiento_Click);
            // 
            // numMonto
            // 
            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMonto.Location = new System.Drawing.Point(600, 52);
            this.numMonto.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(125, 24);
            this.numMonto.TabIndex = 9;
            this.numMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMonto.ThousandsSeparator = true;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMonto.Location = new System.Drawing.Point(600, 30);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(65, 15);
            this.lblMonto.TabIndex = 8;
            this.lblMonto.Text = "Monto ($):";
            // 
            // rbHaber
            // 
            this.rbHaber.AutoSize = true;
            this.rbHaber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbHaber.Location = new System.Drawing.Point(505, 54);
            this.rbHaber.Name = "rbHaber";
            this.rbHaber.Size = new System.Drawing.Size(57, 19);
            this.rbHaber.TabIndex = 7;
            this.rbHaber.Text = "Haber";
            this.rbHaber.UseVisualStyleBackColor = true;
            // 
            // rbDebe
            // 
            this.rbDebe.AutoSize = true;
            this.rbDebe.Checked = true;
            this.rbDebe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rbDebe.Location = new System.Drawing.Point(448, 54);
            this.rbDebe.Name = "rbDebe";
            this.rbDebe.Size = new System.Drawing.Size(52, 19);
            this.rbDebe.TabIndex = 6;
            this.rbDebe.TabStop = true;
            this.rbDebe.Text = "Debe";
            this.rbDebe.UseVisualStyleBackColor = true;
            // 
            // lblTipoMov
            // 
            this.lblTipoMov.AutoSize = true;
            this.lblTipoMov.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTipoMov.Location = new System.Drawing.Point(445, 30);
            this.lblTipoMov.Name = "lblTipoMov";
            this.lblTipoMov.Size = new System.Drawing.Size(76, 15);
            this.lblTipoMov.TabIndex = 5;
            this.lblTipoMov.Text = "Movimiento:";
            // 
            // lblAvisoSubcuenta
            // 
            this.lblAvisoSubcuenta.AutoSize = true;
            this.lblAvisoSubcuenta.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblAvisoSubcuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblAvisoSubcuenta.Location = new System.Drawing.Point(232, 80);
            this.lblAvisoSubcuenta.Name = "lblAvisoSubcuenta";
            this.lblAvisoSubcuenta.Size = new System.Drawing.Size(130, 13);
            this.lblAvisoSubcuenta.TabIndex = 4;
            this.lblAvisoSubcuenta.Text = "Irá a la columna 'Parcial'";
            // 
            // cmbSubcuenta
            // 
            this.cmbSubcuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubcuenta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSubcuenta.FormattingEnabled = true;
            this.cmbSubcuenta.Location = new System.Drawing.Point(232, 52);
            this.cmbSubcuenta.Name = "cmbSubcuenta";
            this.cmbSubcuenta.Size = new System.Drawing.Size(195, 25);
            this.cmbSubcuenta.TabIndex = 3;
            // 
            // lblSubcuenta
            // 
            this.lblSubcuenta.AutoSize = true;
            this.lblSubcuenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubcuenta.Location = new System.Drawing.Point(232, 30);
            this.lblSubcuenta.Name = "lblSubcuenta";
            this.lblSubcuenta.Size = new System.Drawing.Size(115, 15);
            this.lblSubcuenta.TabIndex = 2;
            this.lblSubcuenta.Text = "Subcuenta (Parcial):";
            // 
            // cmbCuentaPrincipal
            // 
            this.cmbCuentaPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuentaPrincipal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCuentaPrincipal.FormattingEnabled = true;
            this.cmbCuentaPrincipal.Location = new System.Drawing.Point(18, 52);
            this.cmbCuentaPrincipal.Name = "cmbCuentaPrincipal";
            this.cmbCuentaPrincipal.Size = new System.Drawing.Size(195, 25);
            this.cmbCuentaPrincipal.TabIndex = 1;
            this.cmbCuentaPrincipal.SelectedIndexChanged += new System.EventHandler(this.cmbCuentaPrincipal_SelectedIndexChanged);
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCuenta.Location = new System.Drawing.Point(18, 30);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(97, 15);
            this.lblCuenta.TabIndex = 0;
            this.lblCuenta.Text = "Cuenta Principal:";
            // 
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.dgvMovimientos);
            this.gbDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetalle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.gbDetalle.Location = new System.Drawing.Point(18, 202);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Padding = new System.Windows.Forms.Padding(10);
            this.gbDetalle.Size = new System.Drawing.Size(884, 314);
            this.gbDetalle.TabIndex = 2;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Renglones del Asiento";
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimientos.ColumnHeadersHeight = 32;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCuenta,
            this.colSubcuenta,
            this.colTipo,
            this.colDebe,
            this.colHaber,
            this.colQuitar});
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.EnableHeadersVisualStyles = false;
            this.dgvMovimientos.Location = new System.Drawing.Point(10, 27);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowTemplate.Height = 28;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(864, 277);
            this.dgvMovimientos.TabIndex = 0;
            this.dgvMovimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMovimientos_CellContentClick);
            // 
            // colCuenta
            // 
            this.colCuenta.FillWeight = 140F;
            this.colCuenta.HeaderText = "Cuenta";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.ReadOnly = true;
            // 
            // colSubcuenta
            // 
            this.colSubcuenta.FillWeight = 110F;
            this.colSubcuenta.HeaderText = "Subcuenta (Parcial)";
            this.colSubcuenta.Name = "colSubcuenta";
            this.colSubcuenta.ReadOnly = true;
            // 
            // colTipo
            // 
            this.colTipo.FillWeight = 50F;
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            // 
            // colDebe
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.colDebe.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDebe.FillWeight = 70F;
            this.colDebe.HeaderText = "Debe ($)";
            this.colDebe.Name = "colDebe";
            this.colDebe.ReadOnly = true;
            // 
            // colHaber
            // 
            this.colHaber.DefaultCellStyle = dataGridViewCellStyle2;
            this.colHaber.FillWeight = 70F;
            this.colHaber.HeaderText = "Haber ($)";
            this.colHaber.Name = "colHaber";
            this.colHaber.ReadOnly = true;
            // 
            // colQuitar
            // 
            this.colQuitar.FillWeight = 45F;
            this.colQuitar.HeaderText = "Acción";
            this.colQuitar.Name = "colQuitar";
            this.colQuitar.ReadOnly = true;
            this.colQuitar.Text = "✕ Quitar";
            this.colQuitar.UseColumnTextForButtonValue = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlFooter.Controls.Add(this.lblEstadoCuadre);
            this.pnlFooter.Controls.Add(this.lblTotalHaber);
            this.pnlFooter.Controls.Add(this.lblTotalDebe);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 594);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlFooter.Size = new System.Drawing.Size(920, 68);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblEstadoCuadre
            // 
            this.lblEstadoCuadre.AutoSize = true;
            this.lblEstadoCuadre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEstadoCuadre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblEstadoCuadre.Location = new System.Drawing.Point(18, 38);
            this.lblEstadoCuadre.Name = "lblEstadoCuadre";
            this.lblEstadoCuadre.Size = new System.Drawing.Size(262, 17);
            this.lblEstadoCuadre.TabIndex = 4;
            this.lblEstadoCuadre.Text = "⚠ Asiento descuadrado: Diferencia $0.00";
            // 
            // lblTotalHaber
            // 
            this.lblTotalHaber.AutoSize = true;
            this.lblTotalHaber.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalHaber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalHaber.Location = new System.Drawing.Point(180, 14);
            this.lblTotalHaber.Name = "lblTotalHaber";
            this.lblTotalHaber.Size = new System.Drawing.Size(126, 17);
            this.lblTotalHaber.TabIndex = 3;
            this.lblTotalHaber.Text = "Total Haber: $0.00";
            // 
            // lblTotalDebe
            // 
            this.lblTotalDebe.AutoSize = true;
            this.lblTotalDebe.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDebe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalDebe.Location = new System.Drawing.Point(18, 14);
            this.lblTotalDebe.Name = "lblTotalDebe";
            this.lblTotalDebe.Size = new System.Drawing.Size(121, 17);
            this.lblTotalDebe.TabIndex = 2;
            this.lblTotalDebe.Text = "Total Debe: $0.00";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCancelar.Location = new System.Drawing.Point(620, 17);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(745, 17);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(155, 36);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "💾 Guardar Asiento";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmAgregarAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 662);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarAsiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Asiento Contable";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.gbDatosGenerales.ResumeLayout(false);
            this.gbDatosGenerales.PerformLayout();
            this.gbMovimiento.ResumeLayout(false);
            this.gbMovimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.gbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbDatosGenerales;
        private System.Windows.Forms.Label lblNumeroAsiento;
        private System.Windows.Forms.TextBox txtNumeroAsiento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.GroupBox gbMovimiento;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cmbCuentaPrincipal;
        private System.Windows.Forms.Label lblSubcuenta;
        private System.Windows.Forms.ComboBox cmbSubcuenta;
        private System.Windows.Forms.Label lblAvisoSubcuenta;
        private System.Windows.Forms.Label lblTipoMov;
        private System.Windows.Forms.RadioButton rbDebe;
        private System.Windows.Forms.RadioButton rbHaber;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Button btnAgregarMovimiento;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubcuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHaber;
        private System.Windows.Forms.DataGridViewButtonColumn colQuitar;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotalDebe;
        private System.Windows.Forms.Label lblTotalHaber;
        private System.Windows.Forms.Label lblEstadoCuadre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}
