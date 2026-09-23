namespace App_Contable.Presentacion
{
    partial class frmLibroDiario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.pnlFiltroFechas = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFlechaRango = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnNuevoAsiento = new System.Windows.Forms.Button();
            this.btnEliminarAsiento = new System.Windows.Forms.Button();
            this.btnCargarEjemplo = new System.Windows.Forms.Button();
            this.btnBajarAsiento = new System.Windows.Forms.Button();
            this.btnSubirAsiento = new System.Windows.Forms.Button();
            this.btnEditarAsiento = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvLibroDiario = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParcial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumenInferior = new System.Windows.Forms.Panel();
            this.lblBadgeEstado = new System.Windows.Forms.Label();
            this.lblTotalHaberGlobal = new System.Windows.Forms.Label();
            this.lblTotalDebeGlobal = new System.Windows.Forms.Label();
            this.lblTotalAsientos = new System.Windows.Forms.Label();
            this.pnlToolbar.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibroDiario)).BeginInit();
            this.pnlResumenInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnSubirAsiento);
            this.pnlToolbar.Controls.Add(this.btnBajarAsiento);
            this.pnlToolbar.Controls.Add(this.btnEditarAsiento);
            this.pnlToolbar.Controls.Add(this.btnActualizar);
            this.pnlToolbar.Controls.Add(this.btnCargarEjemplo);
            this.pnlToolbar.Controls.Add(this.btnEliminarAsiento);
            this.pnlToolbar.Controls.Add(this.btnNuevoAsiento);
            this.pnlToolbar.Controls.Add(this.pnlFiltroFechas);
            this.pnlToolbar.Controls.Add(this.lblTituloSeccion);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size = new System.Drawing.Size(1100, 72);
            this.pnlToolbar.TabIndex = 0;
            // 
            // lblTituloSeccion
            // 
            this.lblTituloSeccion.AutoSize = true;
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloSeccion.Location = new System.Drawing.Point(16, 24);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(120, 21);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "LIBRO DIARIO";
            // 
            // pnlFiltroFechas
            // 
            this.pnlFiltroFechas.Controls.Add(this.btnFiltrar);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaFin);
            this.pnlFiltroFechas.Controls.Add(this.lblFlechaRango);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltroFechas.Controls.Add(this.lblPeriodo);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(160, 16);
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
            // btnNuevoAsiento
            // 
            this.btnNuevoAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoAsiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnNuevoAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoAsiento.FlatAppearance.BorderSize = 0;
            this.btnNuevoAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoAsiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevoAsiento.ForeColor = System.Drawing.Color.White;
            this.btnNuevoAsiento.Location = new System.Drawing.Point(965, 18);
            this.btnNuevoAsiento.Name = "btnNuevoAsiento";
            this.btnNuevoAsiento.Size = new System.Drawing.Size(115, 36);
            this.btnNuevoAsiento.TabIndex = 2;
            this.btnNuevoAsiento.Text = "➕ Nuevo";
            this.btnNuevoAsiento.UseVisualStyleBackColor = false;
            this.btnNuevoAsiento.Click += new System.EventHandler(this.btnNuevoAsiento_Click);
            // 
            // btnEliminarAsiento
            // 
            this.btnEliminarAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarAsiento.BackColor = System.Drawing.Color.White;
            this.btnEliminarAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarAsiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminarAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarAsiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminarAsiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnEliminarAsiento.Location = new System.Drawing.Point(860, 18);
            this.btnEliminarAsiento.Name = "btnEliminarAsiento";
            this.btnEliminarAsiento.Size = new System.Drawing.Size(100, 36);
            this.btnEliminarAsiento.TabIndex = 3;
            this.btnEliminarAsiento.Text = "🗑️ Eliminar";
            this.btnEliminarAsiento.UseVisualStyleBackColor = false;
            this.btnEliminarAsiento.Click += new System.EventHandler(this.btnEliminarAsiento_Click);
            // 
            // btnEditarAsiento
            // 
            this.btnEditarAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarAsiento.BackColor = System.Drawing.Color.White;
            this.btnEditarAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarAsiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnEditarAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarAsiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditarAsiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnEditarAsiento.Location = new System.Drawing.Point(755, 18);
            this.btnEditarAsiento.Name = "btnEditarAsiento";
            this.btnEditarAsiento.Size = new System.Drawing.Size(100, 36);
            this.btnEditarAsiento.TabIndex = 6;
            this.btnEditarAsiento.Text = "✏️ Editar";
            this.btnEditarAsiento.UseVisualStyleBackColor = false;
            this.btnEditarAsiento.Click += new System.EventHandler(this.btnEditarAsiento_Click);
            // 
            // btnBajarAsiento
            // 
            this.btnBajarAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBajarAsiento.BackColor = System.Drawing.Color.White;
            this.btnBajarAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBajarAsiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnBajarAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajarAsiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBajarAsiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnBajarAsiento.Location = new System.Drawing.Point(705, 18);
            this.btnBajarAsiento.Name = "btnBajarAsiento";
            this.btnBajarAsiento.Size = new System.Drawing.Size(45, 36);
            this.btnBajarAsiento.TabIndex = 7;
            this.btnBajarAsiento.Text = "⬇️";
            this.btnBajarAsiento.UseVisualStyleBackColor = false;
            this.btnBajarAsiento.Click += new System.EventHandler(this.btnBajarAsiento_Click);
            // 
            // btnSubirAsiento
            // 
            this.btnSubirAsiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubirAsiento.BackColor = System.Drawing.Color.White;
            this.btnSubirAsiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirAsiento.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnSubirAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirAsiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSubirAsiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnSubirAsiento.Location = new System.Drawing.Point(655, 18);
            this.btnSubirAsiento.Name = "btnSubirAsiento";
            this.btnSubirAsiento.Size = new System.Drawing.Size(45, 36);
            this.btnSubirAsiento.TabIndex = 8;
            this.btnSubirAsiento.Text = "⬆️";
            this.btnSubirAsiento.UseVisualStyleBackColor = false;
            this.btnSubirAsiento.Click += new System.EventHandler(this.btnSubirAsiento_Click);
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
            this.btnCargarEjemplo.Location = new System.Drawing.Point(545, 18);
            this.btnCargarEjemplo.Name = "btnCargarEjemplo";
            this.btnCargarEjemplo.Size = new System.Drawing.Size(105, 36);
            this.btnCargarEjemplo.TabIndex = 4;
            this.btnCargarEjemplo.Text = "📥 Ejemplo";
            this.btnCargarEjemplo.UseVisualStyleBackColor = false;
            this.btnCargarEjemplo.Click += new System.EventHandler(this.btnCargarEjemplo_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnActualizar.Location = new System.Drawing.Point(445, 18);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(95, 36);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "🔄 Refrescar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pnlGrillaContenedor
            // 
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlGrillaContenedor.Controls.Add(this.dgvLibroDiario);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 72);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1100, 520);
            this.pnlGrillaContenedor.TabIndex = 1;
            // 
            // dgvLibroDiario
            // 
            this.dgvLibroDiario.AllowUserToAddRows = false;
            this.dgvLibroDiario.AllowUserToDeleteRows = false;
            this.dgvLibroDiario.AllowUserToResizeRows = false;
            this.dgvLibroDiario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLibroDiario.BackgroundColor = System.Drawing.Color.White;
            this.dgvLibroDiario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvLibroDiario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvLibroDiario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(198)))), ((int)(((byte)(215)))));
            // 
            // Estilo exacto del encabezado estilo libro contable / imagen usuario
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLibroDiario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLibroDiario.ColumnHeadersHeight = 36;
            this.dgvLibroDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLibroDiario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colCuenta,
            this.colParcial,
            this.colDebe,
            this.colHaber});
            this.dgvLibroDiario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLibroDiario.EnableHeadersVisualStyles = false;
            this.dgvLibroDiario.Location = new System.Drawing.Point(16, 12);
            this.dgvLibroDiario.MultiSelect = false;
            this.dgvLibroDiario.Name = "dgvLibroDiario";
            this.dgvLibroDiario.ReadOnly = true;
            this.dgvLibroDiario.RowHeadersVisible = false;
            this.dgvLibroDiario.RowTemplate.Height = 26;
            this.dgvLibroDiario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLibroDiario.Size = new System.Drawing.Size(1068, 496);
            this.dgvLibroDiario.TabIndex = 0;
            // 
            // colFecha
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFecha.FillWeight = 85F;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCuenta
            // 
            this.colCuenta.FillWeight = 260F;
            this.colCuenta.HeaderText = "Cuenta";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.ReadOnly = true;
            this.colCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colParcial
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.colParcial.DefaultCellStyle = dataGridViewCellStyle3;
            this.colParcial.FillWeight = 95F;
            this.colParcial.HeaderText = "Parcial";
            this.colParcial.Name = "colParcial";
            this.colParcial.ReadOnly = true;
            this.colParcial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDebe
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.colDebe.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDebe.FillWeight = 95F;
            this.colDebe.HeaderText = "Debe";
            this.colDebe.Name = "colDebe";
            this.colDebe.ReadOnly = true;
            this.colDebe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colHaber
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.colHaber.DefaultCellStyle = dataGridViewCellStyle5;
            this.colHaber.FillWeight = 95F;
            this.colHaber.HeaderText = "Haber";
            this.colHaber.Name = "colHaber";
            this.colHaber.ReadOnly = true;
            this.colHaber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlResumenInferior
            // 
            this.pnlResumenInferior.BackColor = System.Drawing.Color.White;
            this.pnlResumenInferior.Controls.Add(this.lblBadgeEstado);
            this.pnlResumenInferior.Controls.Add(this.lblTotalHaberGlobal);
            this.pnlResumenInferior.Controls.Add(this.lblTotalDebeGlobal);
            this.pnlResumenInferior.Controls.Add(this.lblTotalAsientos);
            this.pnlResumenInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumenInferior.Location = new System.Drawing.Point(0, 592);
            this.pnlResumenInferior.Name = "pnlResumenInferior";
            this.pnlResumenInferior.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlResumenInferior.Size = new System.Drawing.Size(1100, 48);
            this.pnlResumenInferior.TabIndex = 2;
            // 
            // lblBadgeEstado
            // 
            this.lblBadgeEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadgeEstado.AutoSize = true;
            this.lblBadgeEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBadgeEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblBadgeEstado.Location = new System.Drawing.Point(890, 15);
            this.lblBadgeEstado.Name = "lblBadgeEstado";
            this.lblBadgeEstado.Size = new System.Drawing.Size(190, 17);
            this.lblBadgeEstado.TabIndex = 3;
            this.lblBadgeEstado.Text = "✓ Asientos Dobles Cuadrados";
            // 
            // lblTotalHaberGlobal
            // 
            this.lblTotalHaberGlobal.AutoSize = true;
            this.lblTotalHaberGlobal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalHaberGlobal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalHaberGlobal.Location = new System.Drawing.Point(400, 15);
            this.lblTotalHaberGlobal.Name = "lblTotalHaberGlobal";
            this.lblTotalHaberGlobal.Size = new System.Drawing.Size(167, 17);
            this.lblTotalHaberGlobal.TabIndex = 2;
            this.lblTotalHaberGlobal.Text = "Total Haber: $0.00";
            // 
            // lblTotalDebeGlobal
            // 
            this.lblTotalDebeGlobal.AutoSize = true;
            this.lblTotalDebeGlobal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDebeGlobal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalDebeGlobal.Location = new System.Drawing.Point(190, 15);
            this.lblTotalDebeGlobal.Name = "lblTotalDebeGlobal";
            this.lblTotalDebeGlobal.Size = new System.Drawing.Size(162, 17);
            this.lblTotalDebeGlobal.TabIndex = 1;
            this.lblTotalDebeGlobal.Text = "Total Debe: $0.00";
            // 
            // lblTotalAsientos
            // 
            this.lblTotalAsientos.AutoSize = true;
            this.lblTotalAsientos.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalAsientos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTotalAsientos.Location = new System.Drawing.Point(16, 15);
            this.lblTotalAsientos.Name = "lblTotalAsientos";
            this.lblTotalAsientos.Size = new System.Drawing.Size(117, 17);
            this.lblTotalAsientos.TabIndex = 0;
            this.lblTotalAsientos.Text = "Asientos: 0";
            // 
            // frmLibroDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlResumenInferior);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLibroDiario";
            this.Text = "Libro Diario";
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibroDiario)).EndInit();
            this.pnlResumenInferior.ResumeLayout(false);
            this.pnlResumenInferior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Panel pnlFiltroFechas;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFlechaRango;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCargarEjemplo;
        private System.Windows.Forms.Button btnEliminarAsiento;
        private System.Windows.Forms.Button btnNuevoAsiento;
        private System.Windows.Forms.Button btnSubirAsiento;
        private System.Windows.Forms.Button btnBajarAsiento;
        private System.Windows.Forms.Button btnEditarAsiento;
        private System.Windows.Forms.Panel pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvLibroDiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParcial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHaber;
        private System.Windows.Forms.Panel pnlResumenInferior;
        private System.Windows.Forms.Label lblTotalAsientos;
        private System.Windows.Forms.Label lblTotalDebeGlobal;
        private System.Windows.Forms.Label lblTotalHaberGlobal;
        private System.Windows.Forms.Label lblBadgeEstado;
    }
}
