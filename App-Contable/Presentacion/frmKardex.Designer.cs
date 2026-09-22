namespace App_Contable.Presentacion
{
    partial class frmKardex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.pnlFiltroFechas = new System.Windows.Forms.Panel();
            this.lblIconoCalendario = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFlechaRango = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.pnlBotonSincronizar = new System.Windows.Forms.Panel();
            this.btnSincronizarDiario = new System.Windows.Forms.Button();
            this.lblBadgePendientes = new System.Windows.Forms.Label();
            this.btnAgregarMovimiento = new System.Windows.Forms.Button();
            this.btnFiltros = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRecalcular = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvKardex = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntradaCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalidaCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostoUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaldoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlConciliacion = new System.Windows.Forms.Panel();
            this.lblConciliacionTitulo = new System.Windows.Forms.Label();
            this.lblResumenFisico = new System.Windows.Forms.Label();
            this.lblSaldoFisicoGrande = new System.Windows.Forms.Label();
            this.lblResumenMonetario = new System.Windows.Forms.Label();
            this.lblSaldoValorGrande = new System.Windows.Forms.Label();
            this.pnlToolbar.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlBotonSincronizar.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.pnlConciliacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.lblPeriodo);
            this.pnlToolbar.Controls.Add(this.pnlFiltroFechas);
            this.pnlToolbar.Controls.Add(this.pnlBotonSincronizar);
            this.pnlToolbar.Controls.Add(this.btnAgregarMovimiento);
            this.pnlToolbar.Controls.Add(this.btnFiltros);
            this.pnlToolbar.Controls.Add(this.btnExcel);
            this.pnlToolbar.Controls.Add(this.btnRecalcular);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size = new System.Drawing.Size(1200, 72);
            this.pnlToolbar.TabIndex = 0;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPeriodo.Location = new System.Drawing.Point(16, 26);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(53, 17);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Período";
            // 
            // pnlFiltroFechas
            // 
            this.pnlFiltroFechas.BackColor = System.Drawing.Color.White;
            this.pnlFiltroFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFiltroFechas.Controls.Add(this.lblIconoCalendario);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltroFechas.Controls.Add(this.lblFlechaRango);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaFin);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(76, 16);
            this.pnlFiltroFechas.Name = "pnlFiltroFechas";
            this.pnlFiltroFechas.Padding = new System.Windows.Forms.Padding(4);
            this.pnlFiltroFechas.Size = new System.Drawing.Size(270, 38);
            this.pnlFiltroFechas.TabIndex = 1;
            // 
            // lblIconoCalendario
            // 
            this.lblIconoCalendario.AutoSize = true;
            this.lblIconoCalendario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIconoCalendario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblIconoCalendario.Location = new System.Drawing.Point(4, 8);
            this.lblIconoCalendario.Name = "lblIconoCalendario";
            this.lblIconoCalendario.Size = new System.Drawing.Size(23, 19);
            this.lblIconoCalendario.TabIndex = 0;
            this.lblIconoCalendario.Text = "📅";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(28, 6);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(102, 24);
            this.dtpFechaInicio.TabIndex = 1;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.FiltroFechas_ValueChanged);
            // 
            // lblFlechaRango
            // 
            this.lblFlechaRango.AutoSize = true;
            this.lblFlechaRango.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFlechaRango.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFlechaRango.Location = new System.Drawing.Point(133, 9);
            this.lblFlechaRango.Name = "lblFlechaRango";
            this.lblFlechaRango.Size = new System.Drawing.Size(20, 17);
            this.lblFlechaRango.TabIndex = 2;
            this.lblFlechaRango.Text = "→";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CalendarFont = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(156, 6);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(102, 24);
            this.dtpFechaFin.TabIndex = 3;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.FiltroFechas_ValueChanged);
            // 
            // pnlBotonSincronizar
            // 
            this.pnlBotonSincronizar.Controls.Add(this.btnSincronizarDiario);
            this.pnlBotonSincronizar.Controls.Add(this.lblBadgePendientes);
            this.pnlBotonSincronizar.Location = new System.Drawing.Point(360, 15);
            this.pnlBotonSincronizar.Name = "pnlBotonSincronizar";
            this.pnlBotonSincronizar.Size = new System.Drawing.Size(215, 40);
            this.pnlBotonSincronizar.TabIndex = 2;
            // 
            // btnSincronizarDiario
            // 
            this.btnSincronizarDiario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnSincronizarDiario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSincronizarDiario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSincronizarDiario.FlatAppearance.BorderSize = 0;
            this.btnSincronizarDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSincronizarDiario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSincronizarDiario.ForeColor = System.Drawing.Color.White;
            this.btnSincronizarDiario.Location = new System.Drawing.Point(0, 0);
            this.btnSincronizarDiario.Name = "btnSincronizarDiario";
            this.btnSincronizarDiario.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.btnSincronizarDiario.Size = new System.Drawing.Size(215, 40);
            this.btnSincronizarDiario.TabIndex = 0;
            this.btnSincronizarDiario.Text = "+ Sincronizar Libro Diario";
            this.btnSincronizarDiario.UseVisualStyleBackColor = false;
            this.btnSincronizarDiario.Click += new System.EventHandler(this.btnSincronizarDiario_Click);
            // 
            // lblBadgePendientes
            // 
            this.lblBadgePendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadgePendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblBadgePendientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBadgePendientes.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBadgePendientes.ForeColor = System.Drawing.Color.White;
            this.lblBadgePendientes.Location = new System.Drawing.Point(188, 2);
            this.lblBadgePendientes.Name = "lblBadgePendientes";
            this.lblBadgePendientes.Size = new System.Drawing.Size(22, 22);
            this.lblBadgePendientes.TabIndex = 1;
            this.lblBadgePendientes.Text = "3";
            this.lblBadgePendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBadgePendientes.Click += new System.EventHandler(this.btnSincronizarDiario_Click);
            // 
            // btnAgregarMovimiento
            // 
            this.btnAgregarMovimiento.BackColor = System.Drawing.Color.White;
            this.btnAgregarMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMovimiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnAgregarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMovimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAgregarMovimiento.Location = new System.Drawing.Point(588, 16);
            this.btnAgregarMovimiento.Name = "btnAgregarMovimiento";
            this.btnAgregarMovimiento.Size = new System.Drawing.Size(175, 38);
            this.btnAgregarMovimiento.TabIndex = 3;
            this.btnAgregarMovimiento.Text = "↓ Agregar Movimiento";
            this.btnAgregarMovimiento.UseVisualStyleBackColor = false;
            this.btnAgregarMovimiento.Click += new System.EventHandler(this.btnAgregarMovimiento_Click);
            // 
            // btnFiltros
            // 
            this.btnFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltros.BackColor = System.Drawing.Color.White;
            this.btnFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltros.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltros.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnFiltros.Location = new System.Drawing.Point(1096, 16);
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(88, 38);
            this.btnFiltros.TabIndex = 6;
            this.btnFiltros.Text = "⊞ Filtros";
            this.btnFiltros.UseVisualStyleBackColor = false;
            this.btnFiltros.Click += new System.EventHandler(this.btnFiltros_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnExcel.Location = new System.Drawing.Point(902, 16);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(185, 38);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "⇅ Importar / Exportar Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecalcular.BackColor = System.Drawing.Color.White;
            this.btnRecalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecalcular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnRecalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalcular.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRecalcular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnRecalcular.Location = new System.Drawing.Point(778, 16);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(115, 38);
            this.btnRecalcular.TabIndex = 4;
            this.btnRecalcular.Text = "↺ Recalcular";
            this.btnRecalcular.UseVisualStyleBackColor = false;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // pnlGrillaContenedor
            // 
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlGrillaContenedor.Controls.Add(this.dgvKardex);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 72);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1200, 528);
            this.pnlGrillaContenedor.TabIndex = 1;
            // 
            // dgvKardex
            // 
            this.dgvKardex.AllowUserToAddRows = false;
            this.dgvKardex.AllowUserToDeleteRows = false;
            this.dgvKardex.AllowUserToResizeRows = false;
            this.dgvKardex.BackgroundColor = System.Drawing.Color.White;
            this.dgvKardex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKardex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKardex.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKardex.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKardex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colConcepto,
            this.colDocumento,
            this.colEntradaCant,
            this.colSalidaCant,
            this.colSaldoCant,
            this.colCostoUnit,
            this.colDebe,
            this.colHaber,
            this.colSaldoValor,
            this.colOrigen});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKardex.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKardex.EnableHeadersVisualStyles = false;
            this.dgvKardex.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvKardex.Location = new System.Drawing.Point(16, 8);
            this.dgvKardex.MultiSelect = false;
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.ReadOnly = true;
            this.dgvKardex.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKardex.RowHeadersVisible = false;
            this.dgvKardex.RowHeadersWidth = 24;
            this.dgvKardex.RowTemplate.Height = 44;
            this.dgvKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKardex.Size = new System.Drawing.Size(1168, 512);
            this.dgvKardex.TabIndex = 0;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 105;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 110;
            // 
            // colConcepto
            // 
            this.colConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colConcepto.FillWeight = 140F;
            this.colConcepto.HeaderText = "Concepto / Detalle";
            this.colConcepto.MinimumWidth = 200;
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.ReadOnly = true;
            // 
            // colDocumento
            // 
            this.colDocumento.HeaderText = "Ref / Documento";
            this.colDocumento.MinimumWidth = 115;
            this.colDocumento.Name = "colDocumento";
            this.colDocumento.ReadOnly = true;
            this.colDocumento.Width = 125;
            // 
            // colEntradaCant
            // 
            this.colEntradaCant.HeaderText = "Entrada\n(Cant.)";
            this.colEntradaCant.MinimumWidth = 90;
            this.colEntradaCant.Name = "colEntradaCant";
            this.colEntradaCant.ReadOnly = true;
            this.colEntradaCant.Width = 95;
            // 
            // colSalidaCant
            // 
            this.colSalidaCant.HeaderText = "Salida\n(Cant.)";
            this.colSalidaCant.MinimumWidth = 90;
            this.colSalidaCant.Name = "colSalidaCant";
            this.colSalidaCant.ReadOnly = true;
            this.colSalidaCant.Width = 95;
            // 
            // colSaldoCant
            // 
            this.colSaldoCant.HeaderText = "Saldo\n(Cant.)";
            this.colSaldoCant.MinimumWidth = 90;
            this.colSaldoCant.Name = "colSaldoCant";
            this.colSaldoCant.ReadOnly = true;
            this.colSaldoCant.Width = 95;
            // 
            // colCostoUnit
            // 
            this.colCostoUnit.HeaderText = "Costo Unit.\n($0.0000)";
            this.colCostoUnit.MinimumWidth = 115;
            this.colCostoUnit.Name = "colCostoUnit";
            this.colCostoUnit.ReadOnly = true;
            this.colCostoUnit.Width = 120;
            // 
            // colDebe
            // 
            this.colDebe.HeaderText = "Debe\n($)";
            this.colDebe.MinimumWidth = 105;
            this.colDebe.Name = "colDebe";
            this.colDebe.ReadOnly = true;
            this.colDebe.Width = 110;
            // 
            // colHaber
            // 
            this.colHaber.HeaderText = "Haber\n($)";
            this.colHaber.MinimumWidth = 105;
            this.colHaber.Name = "colHaber";
            this.colHaber.ReadOnly = true;
            this.colHaber.Width = 110;
            // 
            // colSaldoValor
            // 
            this.colSaldoValor.HeaderText = "Saldo Valor\n($)";
            this.colSaldoValor.MinimumWidth = 115;
            this.colSaldoValor.Name = "colSaldoValor";
            this.colSaldoValor.ReadOnly = true;
            this.colSaldoValor.Width = 120;
            // 
            // colOrigen
            // 
            this.colOrigen.HeaderText = "Origen";
            this.colOrigen.MinimumWidth = 135;
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.ReadOnly = true;
            this.colOrigen.Width = 145;
            // 
            // pnlConciliacion
            // 
            this.pnlConciliacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlConciliacion.Controls.Add(this.lblConciliacionTitulo);
            this.pnlConciliacion.Controls.Add(this.lblResumenFisico);
            this.pnlConciliacion.Controls.Add(this.lblSaldoFisicoGrande);
            this.pnlConciliacion.Controls.Add(this.lblResumenMonetario);
            this.pnlConciliacion.Controls.Add(this.lblSaldoValorGrande);
            this.pnlConciliacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlConciliacion.Location = new System.Drawing.Point(0, 600);
            this.pnlConciliacion.Name = "pnlConciliacion";
            this.pnlConciliacion.Padding = new System.Windows.Forms.Padding(20, 0, 24, 0);
            this.pnlConciliacion.Size = new System.Drawing.Size(1200, 50);
            this.pnlConciliacion.TabIndex = 2;
            // 
            // lblConciliacionTitulo
            // 
            this.lblConciliacionTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConciliacionTitulo.AutoSize = true;
            this.lblConciliacionTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConciliacionTitulo.ForeColor = System.Drawing.Color.White;
            this.lblConciliacionTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblConciliacionTitulo.Name = "lblConciliacionTitulo";
            this.lblConciliacionTitulo.Size = new System.Drawing.Size(124, 19);
            this.lblConciliacionTitulo.TabIndex = 0;
            this.lblConciliacionTitulo.Text = "Conciliación Final";
            // 
            // lblResumenFisico
            // 
            this.lblResumenFisico.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblResumenFisico.AutoSize = true;
            this.lblResumenFisico.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResumenFisico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblResumenFisico.Location = new System.Drawing.Point(375, 16);
            this.lblResumenFisico.Name = "lblResumenFisico";
            this.lblResumenFisico.Size = new System.Drawing.Size(176, 17);
            this.lblResumenFisico.TabIndex = 1;
            this.lblResumenFisico.Text = "Ent: 0 · Sal: 0 · Saldo: 0 uds";
            this.lblResumenFisico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaldoFisicoGrande
            // 
            this.lblSaldoFisicoGrande.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSaldoFisicoGrande.AutoSize = true;
            this.lblSaldoFisicoGrande.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSaldoFisicoGrande.ForeColor = System.Drawing.Color.White;
            this.lblSaldoFisicoGrande.Location = new System.Drawing.Point(585, 14);
            this.lblSaldoFisicoGrande.Name = "lblSaldoFisicoGrande";
            this.lblSaldoFisicoGrande.Size = new System.Drawing.Size(48, 21);
            this.lblSaldoFisicoGrande.TabIndex = 2;
            this.lblSaldoFisicoGrande.Text = "0 uds";
            this.lblSaldoFisicoGrande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResumenMonetario
            // 
            this.lblResumenMonetario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblResumenMonetario.AutoSize = true;
            this.lblResumenMonetario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResumenMonetario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblResumenMonetario.Location = new System.Drawing.Point(820, 16);
            this.lblResumenMonetario.Name = "lblResumenMonetario";
            this.lblResumenMonetario.Size = new System.Drawing.Size(193, 17);
            this.lblResumenMonetario.TabIndex = 3;
            this.lblResumenMonetario.Text = "D: $0.00 — H: $0.00 = $0.00";
            this.lblResumenMonetario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaldoValorGrande
            // 
            this.lblSaldoValorGrande.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSaldoValorGrande.AutoSize = true;
            this.lblSaldoValorGrande.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSaldoValorGrande.ForeColor = System.Drawing.Color.White;
            this.lblSaldoValorGrande.Location = new System.Drawing.Point(1085, 14);
            this.lblSaldoValorGrande.Name = "lblSaldoValorGrande";
            this.lblSaldoValorGrande.Size = new System.Drawing.Size(50, 21);
            this.lblSaldoValorGrande.TabIndex = 4;
            this.lblSaldoValorGrande.Text = "$0.00";
            this.lblSaldoValorGrande.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlConciliacion);
            this.Controls.Add(this.pnlToolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKardex";
            this.Text = "Tarjeta Kardex";
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlBotonSincronizar.ResumeLayout(false);
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.pnlConciliacion.ResumeLayout(false);
            this.pnlConciliacion.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Panel pnlFiltroFechas;
        private System.Windows.Forms.Label lblIconoCalendario;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFlechaRango;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Panel pnlBotonSincronizar;
        private System.Windows.Forms.Button btnSincronizarDiario;
        private System.Windows.Forms.Label lblBadgePendientes;
        private System.Windows.Forms.Button btnAgregarMovimiento;
        private System.Windows.Forms.Button btnRecalcular;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnFiltros;
        private System.Windows.Forms.Panel pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvKardex;
        private System.Windows.Forms.Panel pnlConciliacion;
        private System.Windows.Forms.Label lblConciliacionTitulo;
        private System.Windows.Forms.Label lblResumenFisico;
        private System.Windows.Forms.Label lblSaldoFisicoGrande;
        private System.Windows.Forms.Label lblResumenMonetario;
        private System.Windows.Forms.Label lblSaldoValorGrande;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntradaCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalidaCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostoUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigen;
    }
}

