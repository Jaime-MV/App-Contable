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
            this.pnlBarraHerramientas = new System.Windows.Forms.Panel();
            this.pnlIzquierda = new System.Windows.Forms.FlowLayoutPanel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblNombreTarjeta = new System.Windows.Forms.Label();
            this.pnlDerecha = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCargarEjemplo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
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
            this.pnlBarraHerramientas.SuspendLayout();
            this.pnlIzquierda.SuspendLayout();
            this.pnlDerecha.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.pnlResumenInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBarraHerramientas
            // 
            this.pnlBarraHerramientas.BackColor = System.Drawing.Color.White;
            this.pnlBarraHerramientas.Controls.Add(this.pnlIzquierda);
            this.pnlBarraHerramientas.Controls.Add(this.pnlDerecha);
            this.pnlBarraHerramientas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraHerramientas.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraHerramientas.Name = "pnlBarraHerramientas";
            this.pnlBarraHerramientas.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlBarraHerramientas.Size = new System.Drawing.Size(1200, 56);
            this.pnlBarraHerramientas.TabIndex = 0;
            // 
            // pnlIzquierda
            // 
            this.pnlIzquierda.AutoSize = true;
            this.pnlIzquierda.Controls.Add(this.btnVolver);
            this.pnlIzquierda.Controls.Add(this.btnGuardar);
            this.pnlIzquierda.Controls.Add(this.lblNombreTarjeta);
            this.pnlIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierda.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlIzquierda.Location = new System.Drawing.Point(16, 10);
            this.pnlIzquierda.Name = "pnlIzquierda";
            this.pnlIzquierda.Size = new System.Drawing.Size(430, 36);
            this.pnlIzquierda.TabIndex = 0;
            this.pnlIzquierda.WrapContents = false;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnVolver.Location = new System.Drawing.Point(0, 0);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(85, 34);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "← Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(93, 0);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(85, 34);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblNombreTarjeta
            // 
            this.lblNombreTarjeta.AutoSize = true;
            this.lblNombreTarjeta.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblNombreTarjeta.Location = new System.Drawing.Point(194, 6);
            this.lblNombreTarjeta.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblNombreTarjeta.Name = "lblNombreTarjeta";
            this.lblNombreTarjeta.Size = new System.Drawing.Size(155, 21);
            this.lblNombreTarjeta.TabIndex = 2;
            this.lblNombreTarjeta.Text = "KARDEX — PRUEBA";
            // 
            // pnlDerecha
            // 
            this.pnlDerecha.AutoSize = true;
            this.pnlDerecha.Controls.Add(this.lblPeriodo);
            this.pnlDerecha.Controls.Add(this.dtpDesde);
            this.pnlDerecha.Controls.Add(this.lblSeparador);
            this.pnlDerecha.Controls.Add(this.dtpHasta);
            this.pnlDerecha.Controls.Add(this.btnFiltrar);
            this.pnlDerecha.Controls.Add(this.btnCargarEjemplo);
            this.pnlDerecha.Controls.Add(this.btnEditar);
            this.pnlDerecha.Controls.Add(this.btnEliminar);
            this.pnlDerecha.Controls.Add(this.btnNuevoMovimiento);
            this.pnlDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDerecha.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlDerecha.Location = new System.Drawing.Point(474, 10);
            this.pnlDerecha.Name = "pnlDerecha";
            this.pnlDerecha.Size = new System.Drawing.Size(710, 36);
            this.pnlDerecha.TabIndex = 1;
            this.pnlDerecha.WrapContents = false;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPeriodo.Location = new System.Drawing.Point(0, 7);
            this.lblPeriodo.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(51, 15);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Período:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(57, 1);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(105, 32);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblSeparador
            // 
            this.lblSeparador.AutoSize = true;
            this.lblSeparador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeparador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSeparador.Location = new System.Drawing.Point(166, 7);
            this.lblSeparador.Margin = new System.Windows.Forms.Padding(4, 7, 4, 0);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(12, 15);
            this.lblSeparador.TabIndex = 2;
            this.lblSeparador.Text = "-";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(182, 1);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(105, 32);
            this.dtpHasta.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnFiltrar.Location = new System.Drawing.Point(295, 1);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(8, 1, 0, 1);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(70, 32);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnCargarEjemplo
            // 
            this.btnCargarEjemplo.AutoSize = true;
            this.btnCargarEjemplo.BackColor = System.Drawing.Color.White;
            this.btnCargarEjemplo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarEjemplo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCargarEjemplo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarEjemplo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCargarEjemplo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCargarEjemplo.Location = new System.Drawing.Point(371, 1);
            this.btnCargarEjemplo.Margin = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.btnCargarEjemplo.Name = "btnCargarEjemplo";
            this.btnCargarEjemplo.Size = new System.Drawing.Size(120, 32);
            this.btnCargarEjemplo.TabIndex = 5;
            this.btnCargarEjemplo.Text = "↺ Cargar Ejemplo";
            this.btnCargarEjemplo.UseVisualStyleBackColor = false;
            this.btnCargarEjemplo.Click += new System.EventHandler(this.btnCargarEjemplo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = true;
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnEditar.Location = new System.Drawing.Point(497, 1);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(76, 32);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "✏️ Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnEliminar.Location = new System.Drawing.Point(579, 1);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(38, 32);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "🗑️";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevoMovimiento
            // 
            this.btnNuevoMovimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(96)))), ((int)(((byte)(255)))));
            this.btnNuevoMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoMovimiento.FlatAppearance.BorderSize = 0;
            this.btnNuevoMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoMovimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNuevoMovimiento.ForeColor = System.Drawing.Color.White;
            this.btnNuevoMovimiento.Location = new System.Drawing.Point(623, 1);
            this.btnNuevoMovimiento.Margin = new System.Windows.Forms.Padding(8, 1, 0, 1);
            this.btnNuevoMovimiento.Name = "btnNuevoMovimiento";
            this.btnNuevoMovimiento.Size = new System.Drawing.Size(90, 32);
            this.btnNuevoMovimiento.TabIndex = 8;
            this.btnNuevoMovimiento.Text = "+ Nuevo";
            this.btnNuevoMovimiento.UseVisualStyleBackColor = false;
            this.btnNuevoMovimiento.Click += new System.EventHandler(this.btnNuevoMovimiento_Click);
            // 
            // pnlGrillaContenedor
            // 
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.White;
            this.pnlGrillaContenedor.Controls.Add(this.dgvKardex);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 56);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1200, 536);
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKardex.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.dgvKardex.Size = new System.Drawing.Size(1168, 520);
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
            this.lblBadgeEstado.Text = "✓ Valuado (PEPS / FIFO)";
            // 
            // frmKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlResumenInferior);
            this.Controls.Add(this.pnlBarraHerramientas);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKardex";
            this.Text = "Tarjeta Kardex";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKardex_FormClosing);
            this.pnlBarraHerramientas.ResumeLayout(false);
            this.pnlBarraHerramientas.PerformLayout();
            this.pnlIzquierda.ResumeLayout(false);
            this.pnlIzquierda.PerformLayout();
            this.pnlDerecha.ResumeLayout(false);
            this.pnlDerecha.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.pnlResumenInferior.ResumeLayout(false);
            this.pnlResumenInferior.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlBarraHerramientas;
        private System.Windows.Forms.FlowLayoutPanel pnlIzquierda;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblNombreTarjeta;
        private System.Windows.Forms.FlowLayoutPanel pnlDerecha;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCargarEjemplo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
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

