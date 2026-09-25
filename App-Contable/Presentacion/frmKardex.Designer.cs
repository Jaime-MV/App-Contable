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
            this.btnVolver = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.pnlFiltroFechas = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFlechaRango = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCargarEjemplo = new System.Windows.Forms.Button();
            this.btnSubirMovimiento = new System.Windows.Forms.Button();
            this.btnBajarMovimiento = new System.Windows.Forms.Button();
            this.btnEditarMovimiento = new System.Windows.Forms.Button();
            this.btnEliminarMovimiento = new System.Windows.Forms.Button();
            this.btnNuevoMovimiento = new System.Windows.Forms.Button();
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
            this.pnlResumenInferior = new System.Windows.Forms.Panel();
            this.lblTotalMovimientos = new System.Windows.Forms.Label();
            this.lblTotalEntradas = new System.Windows.Forms.Label();
            this.lblTotalSalidas = new System.Windows.Forms.Label();
            this.lblSaldoFinal = new System.Windows.Forms.Label();
            this.lblBadgeEstado = new System.Windows.Forms.Label();
            this.pnlToolbar.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.pnlResumenInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnVolver);
            this.pnlToolbar.Controls.Add(this.btnSubirMovimiento);
            this.pnlToolbar.Controls.Add(this.btnBajarMovimiento);
            this.pnlToolbar.Controls.Add(this.btnEditarMovimiento);
            this.pnlToolbar.Controls.Add(this.btnCargarEjemplo);
            this.pnlToolbar.Controls.Add(this.btnEliminarMovimiento);
            this.pnlToolbar.Controls.Add(this.btnNuevoMovimiento);
            this.pnlToolbar.Controls.Add(this.pnlFiltroFechas);
            this.pnlToolbar.Controls.Add(this.lblTituloSeccion);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size = new System.Drawing.Size(1200, 72);
            this.pnlToolbar.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnVolver.Location = new System.Drawing.Point(16, 18);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(90, 36);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.Text = "← Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblTituloSeccion
            // 
            this.lblTituloSeccion.AutoSize = true;
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloSeccion.Location = new System.Drawing.Point(118, 25);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(147, 21);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "TARJETA KARDEX";
            // 
            // pnlFiltroFechas
            // 
            this.pnlFiltroFechas.Controls.Add(this.btnFiltrar);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaFin);
            this.pnlFiltroFechas.Controls.Add(this.lblFlechaRango);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltroFechas.Controls.Add(this.lblPeriodo);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(272, 16);
            this.pnlFiltroFechas.Name = "pnlFiltroFechas";
            this.pnlFiltroFechas.Size = new System.Drawing.Size(370, 38);
            this.pnlFiltroFechas.TabIndex = 1;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPeriodo.Location = new System.Drawing.Point(3, 11);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(51, 15);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Período:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(58, 8);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFlechaRango
            // 
            this.lblFlechaRango.AutoSize = true;
            this.lblFlechaRango.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFlechaRango.Location = new System.Drawing.Point(164, 11);
            this.lblFlechaRango.Name = "lblFlechaRango";
            this.lblFlechaRango.Size = new System.Drawing.Size(12, 15);
            this.lblFlechaRango.TabIndex = 2;
            this.lblFlechaRango.Text = "-";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(182, 8);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnFiltrar.Location = new System.Drawing.Point(290, 7);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(70, 25);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCargarEjemplo
            // 
            this.btnCargarEjemplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarEjemplo.BackColor = System.Drawing.Color.White;
            this.btnCargarEjemplo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarEjemplo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCargarEjemplo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarEjemplo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCargarEjemplo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCargarEjemplo.Location = new System.Drawing.Point(620, 18);
            this.btnCargarEjemplo.Name = "btnCargarEjemplo";
            this.btnCargarEjemplo.Size = new System.Drawing.Size(125, 36);
            this.btnCargarEjemplo.TabIndex = 4;
            this.btnCargarEjemplo.Text = "↺ Cargar Ejemplo";
            this.btnCargarEjemplo.UseVisualStyleBackColor = false;
            this.btnCargarEjemplo.Click += new System.EventHandler(this.btnCargarEjemplo_Click);
            // 
            // btnSubirMovimiento
            // 
            this.btnSubirMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubirMovimiento.BackColor = System.Drawing.Color.White;
            this.btnSubirMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirMovimiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSubirMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSubirMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSubirMovimiento.Location = new System.Drawing.Point(755, 18);
            this.btnSubirMovimiento.Name = "btnSubirMovimiento";
            this.btnSubirMovimiento.Size = new System.Drawing.Size(45, 36);
            this.btnSubirMovimiento.TabIndex = 8;
            this.btnSubirMovimiento.Text = "⬆️";
            this.btnSubirMovimiento.UseVisualStyleBackColor = false;
            this.btnSubirMovimiento.Click += new System.EventHandler(this.btnSubirMovimiento_Click);
            // 
            // btnBajarMovimiento
            // 
            this.btnBajarMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBajarMovimiento.BackColor = System.Drawing.Color.White;
            this.btnBajarMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBajarMovimiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnBajarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajarMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBajarMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnBajarMovimiento.Location = new System.Drawing.Point(805, 18);
            this.btnBajarMovimiento.Name = "btnBajarMovimiento";
            this.btnBajarMovimiento.Size = new System.Drawing.Size(45, 36);
            this.btnBajarMovimiento.TabIndex = 7;
            this.btnBajarMovimiento.Text = "⬇️";
            this.btnBajarMovimiento.UseVisualStyleBackColor = false;
            this.btnBajarMovimiento.Click += new System.EventHandler(this.btnBajarMovimiento_Click);
            // 
            // btnEditarMovimiento
            // 
            this.btnEditarMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarMovimiento.BackColor = System.Drawing.Color.White;
            this.btnEditarMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarMovimiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnEditarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditarMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnEditarMovimiento.Location = new System.Drawing.Point(855, 18);
            this.btnEditarMovimiento.Name = "btnEditarMovimiento";
            this.btnEditarMovimiento.Size = new System.Drawing.Size(100, 36);
            this.btnEditarMovimiento.TabIndex = 6;
            this.btnEditarMovimiento.Text = "✏️ Editar";
            this.btnEditarMovimiento.UseVisualStyleBackColor = false;
            this.btnEditarMovimiento.Click += new System.EventHandler(this.btnEditarMovimiento_Click);
            // 
            // btnEliminarMovimiento
            // 
            this.btnEliminarMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarMovimiento.BackColor = System.Drawing.Color.White;
            this.btnEliminarMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarMovimiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminarMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnEliminarMovimiento.Location = new System.Drawing.Point(960, 18);
            this.btnEliminarMovimiento.Name = "btnEliminarMovimiento";
            this.btnEliminarMovimiento.Size = new System.Drawing.Size(100, 36);
            this.btnEliminarMovimiento.TabIndex = 3;
            this.btnEliminarMovimiento.Text = "🗑️ Eliminar";
            this.btnEliminarMovimiento.UseVisualStyleBackColor = false;
            this.btnEliminarMovimiento.Click += new System.EventHandler(this.btnEliminarMovimiento_Click);
            // 
            // btnNuevoMovimiento
            // 
            this.btnNuevoMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoMovimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnNuevoMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoMovimiento.FlatAppearance.BorderSize = 0;
            this.btnNuevoMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoMovimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevoMovimiento.ForeColor = System.Drawing.Color.White;
            this.btnNuevoMovimiento.Location = new System.Drawing.Point(1065, 18);
            this.btnNuevoMovimiento.Name = "btnNuevoMovimiento";
            this.btnNuevoMovimiento.Size = new System.Drawing.Size(115, 36);
            this.btnNuevoMovimiento.TabIndex = 2;
            this.btnNuevoMovimiento.Text = "➕ Nuevo";
            this.btnNuevoMovimiento.UseVisualStyleBackColor = false;
            this.btnNuevoMovimiento.Click += new System.EventHandler(this.btnNuevoMovimiento_Click);
            // 
            // pnlGrillaContenedor
            // 
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.White;
            this.pnlGrillaContenedor.Controls.Add(this.dgvKardex);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 72);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1200, 520);
            this.pnlGrillaContenedor.TabIndex = 1;
            // 
            // dgvKardex
            // 
            this.dgvKardex.AllowUserToAddRows = false;
            this.dgvKardex.AllowUserToDeleteRows = false;
            this.dgvKardex.AllowUserToResizeRows = false;
            this.dgvKardex.BackgroundColor = System.Drawing.Color.White;
            this.dgvKardex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvKardex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvKardex.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(218)))), ((int)(((byte)(236)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(218)))), ((int)(((byte)(236)))));
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKardex.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKardex.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKardex.EnableHeadersVisualStyles = false;
            this.dgvKardex.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.dgvKardex.Location = new System.Drawing.Point(16, 8);
            this.dgvKardex.MultiSelect = false;
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.ReadOnly = true;
            this.dgvKardex.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKardex.RowHeadersVisible = false;
            this.dgvKardex.RowHeadersWidth = 24;
            this.dgvKardex.RowTemplate.Height = 28;
            this.dgvKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKardex.Size = new System.Drawing.Size(1168, 504);
            this.dgvKardex.TabIndex = 0;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 95;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 100;
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
            this.colDocumento.MinimumWidth = 110;
            this.colDocumento.Name = "colDocumento";
            this.colDocumento.ReadOnly = true;
            this.colDocumento.Width = 120;
            // 
            // colEntradaCant
            // 
            this.colEntradaCant.HeaderText = "Entrada\n(Cant.)";
            this.colEntradaCant.MinimumWidth = 85;
            this.colEntradaCant.Name = "colEntradaCant";
            this.colEntradaCant.ReadOnly = true;
            this.colEntradaCant.Width = 90;
            // 
            // colSalidaCant
            // 
            this.colSalidaCant.HeaderText = "Salida\n(Cant.)";
            this.colSalidaCant.MinimumWidth = 85;
            this.colSalidaCant.Name = "colSalidaCant";
            this.colSalidaCant.ReadOnly = true;
            this.colSalidaCant.Width = 90;
            // 
            // colSaldoCant
            // 
            this.colSaldoCant.HeaderText = "Saldo\n(Cant.)";
            this.colSaldoCant.MinimumWidth = 85;
            this.colSaldoCant.Name = "colSaldoCant";
            this.colSaldoCant.ReadOnly = true;
            this.colSaldoCant.Width = 90;
            // 
            // colCostoUnit
            // 
            this.colCostoUnit.HeaderText = "Costo Unit.\n($0.0000)";
            this.colCostoUnit.MinimumWidth = 110;
            this.colCostoUnit.Name = "colCostoUnit";
            this.colCostoUnit.ReadOnly = true;
            this.colCostoUnit.Width = 115;
            // 
            // colDebe
            // 
            this.colDebe.HeaderText = "Debe\n($)";
            this.colDebe.MinimumWidth = 100;
            this.colDebe.Name = "colDebe";
            this.colDebe.ReadOnly = true;
            this.colDebe.Width = 105;
            // 
            // colHaber
            // 
            this.colHaber.HeaderText = "Haber\n($)";
            this.colHaber.MinimumWidth = 100;
            this.colHaber.Name = "colHaber";
            this.colHaber.ReadOnly = true;
            this.colHaber.Width = 105;
            // 
            // colSaldoValor
            // 
            this.colSaldoValor.HeaderText = "Saldo Valor\n($)";
            this.colSaldoValor.MinimumWidth = 110;
            this.colSaldoValor.Name = "colSaldoValor";
            this.colSaldoValor.ReadOnly = true;
            this.colSaldoValor.Width = 115;
            // 
            // colOrigen
            // 
            this.colOrigen.HeaderText = "Origen";
            this.colOrigen.MinimumWidth = 130;
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.ReadOnly = true;
            this.colOrigen.Width = 140;
            // 
            // pnlResumenInferior
            // 
            this.pnlResumenInferior.BackColor = System.Drawing.Color.White;
            this.pnlResumenInferior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResumenInferior.Controls.Add(this.lblBadgeEstado);
            this.pnlResumenInferior.Controls.Add(this.lblSaldoFinal);
            this.pnlResumenInferior.Controls.Add(this.lblTotalSalidas);
            this.pnlResumenInferior.Controls.Add(this.lblTotalEntradas);
            this.pnlResumenInferior.Controls.Add(this.lblTotalMovimientos);
            this.pnlResumenInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumenInferior.Location = new System.Drawing.Point(0, 592);
            this.pnlResumenInferior.Name = "pnlResumenInferior";
            this.pnlResumenInferior.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlResumenInferior.Size = new System.Drawing.Size(1200, 48);
            this.pnlResumenInferior.TabIndex = 2;
            // 
            // lblTotalMovimientos
            // 
            this.lblTotalMovimientos.AutoSize = true;
            this.lblTotalMovimientos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalMovimientos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTotalMovimientos.Location = new System.Drawing.Point(16, 15);
            this.lblTotalMovimientos.Name = "lblTotalMovimientos";
            this.lblTotalMovimientos.Size = new System.Drawing.Size(95, 17);
            this.lblTotalMovimientos.TabIndex = 0;
            this.lblTotalMovimientos.Text = "Movimientos: 0";
            // 
            // lblTotalEntradas
            // 
            this.lblTotalEntradas.AutoSize = true;
            this.lblTotalEntradas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblTotalEntradas.Location = new System.Drawing.Point(150, 15);
            this.lblTotalEntradas.Name = "lblTotalEntradas";
            this.lblTotalEntradas.Size = new System.Drawing.Size(185, 17);
            this.lblTotalEntradas.TabIndex = 1;
            this.lblTotalEntradas.Text = "Entradas: 0 uds ($0.00)";
            // 
            // lblTotalSalidas
            // 
            this.lblTotalSalidas.AutoSize = true;
            this.lblTotalSalidas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSalidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblTotalSalidas.Location = new System.Drawing.Point(365, 15);
            this.lblTotalSalidas.Name = "lblTotalSalidas";
            this.lblTotalSalidas.Size = new System.Drawing.Size(175, 17);
            this.lblTotalSalidas.TabIndex = 2;
            this.lblTotalSalidas.Text = "Salidas: 0 uds ($0.00)";
            // 
            // lblSaldoFinal
            // 
            this.lblSaldoFinal.AutoSize = true;
            this.lblSaldoFinal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSaldoFinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSaldoFinal.Location = new System.Drawing.Point(575, 15);
            this.lblSaldoFinal.Name = "lblSaldoFinal";
            this.lblSaldoFinal.Size = new System.Drawing.Size(195, 17);
            this.lblSaldoFinal.TabIndex = 3;
            this.lblSaldoFinal.Text = "Saldo Final: 0 uds ($0.00)";
            // 
            // lblBadgeEstado
            // 
            this.lblBadgeEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadgeEstado.AutoSize = true;
            this.lblBadgeEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBadgeEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblBadgeEstado.Location = new System.Drawing.Point(920, 15);
            this.lblBadgeEstado.Name = "lblBadgeEstado";
            this.lblBadgeEstado.Size = new System.Drawing.Size(255, 17);
            this.lblBadgeEstado.TabIndex = 4;
            this.lblBadgeEstado.Text = "✓ Valuado (Costo Promedio Ponderado)";
            // 
            // frmKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlResumenInferior);
            this.Controls.Add(this.pnlToolbar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKardex";
            this.Text = "Tarjeta Kardex";
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.pnlResumenInferior.ResumeLayout(false);
            this.pnlResumenInferior.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Panel pnlFiltroFechas;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFlechaRango;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCargarEjemplo;
        private System.Windows.Forms.Button btnSubirMovimiento;
        private System.Windows.Forms.Button btnBajarMovimiento;
        private System.Windows.Forms.Button btnEditarMovimiento;
        private System.Windows.Forms.Button btnEliminarMovimiento;
        private System.Windows.Forms.Button btnNuevoMovimiento;
        private System.Windows.Forms.Panel pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvKardex;
        private System.Windows.Forms.Panel pnlResumenInferior;
        private System.Windows.Forms.Label lblTotalMovimientos;
        private System.Windows.Forms.Label lblTotalEntradas;
        private System.Windows.Forms.Label lblTotalSalidas;
        private System.Windows.Forms.Label lblSaldoFinal;
        private System.Windows.Forms.Label lblBadgeEstado;
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

