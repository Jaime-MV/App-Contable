namespace App_Contable.Presentacion
{
    partial class frmEstadoResultados
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
            this.btnCalcularMayor = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvEstadoResultados = new System.Windows.Forms.DataGridView();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParcial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumenInferior = new System.Windows.Forms.Panel();
            this.lblBadgeEstado = new System.Windows.Forms.Label();
            this.lblUtilidadOperacional = new System.Windows.Forms.Label();
            this.lblUtilidadBruta = new System.Windows.Forms.Label();
            this.lblCostoVentas = new System.Windows.Forms.Label();
            this.lblVentasNetas = new System.Windows.Forms.Label();
            this.pnlToolbar.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoResultados)).BeginInit();
            this.pnlResumenInferior.SuspendLayout();
            this.SuspendLayout();

            // ── pnlToolbar ────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnActualizar);
            this.pnlToolbar.Controls.Add(this.btnCalcularMayor);
            this.pnlToolbar.Controls.Add(this.btnCargarEjemplo);
            this.pnlToolbar.Controls.Add(this.pnlFiltroFechas);
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
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTituloSeccion.Location = new System.Drawing.Point(115, 24);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(205, 21);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "ESTADO DE RESULTADOS";

            // ── pnlFiltroFechas ───────────────────────────────────────────
            this.pnlFiltroFechas.Controls.Add(this.btnFiltrar);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaFin);
            this.pnlFiltroFechas.Controls.Add(this.lblFlechaRango);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltroFechas.Controls.Add(this.lblPeriodo);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(330, 16);
            this.pnlFiltroFechas.Name = "pnlFiltroFechas";
            this.pnlFiltroFechas.Size = new System.Drawing.Size(370, 38);
            this.pnlFiltroFechas.TabIndex = 1;

            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPeriodo.Location = new System.Drawing.Point(3, 11);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(51, 15);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Período:";

            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(58, 8);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaInicio.TabIndex = 1;

            this.lblFlechaRango.AutoSize = true;
            this.lblFlechaRango.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFlechaRango.Location = new System.Drawing.Point(164, 11);
            this.lblFlechaRango.Name = "lblFlechaRango";
            this.lblFlechaRango.Size = new System.Drawing.Size(12, 15);
            this.lblFlechaRango.TabIndex = 2;
            this.lblFlechaRango.Text = "-";

            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(182, 8);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 23);
            this.dtpFechaFin.TabIndex = 3;

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnFiltrar.Location = new System.Drawing.Point(290, 7);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(70, 25);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── btnCargarEjemplo ──────────────────────────────────────────
            this.btnCargarEjemplo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarEjemplo.BackColor = System.Drawing.Color.White;
            this.btnCargarEjemplo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarEjemplo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCargarEjemplo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarEjemplo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCargarEjemplo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCargarEjemplo.Location = new System.Drawing.Point(670, 18);
            this.btnCargarEjemplo.Name = "btnCargarEjemplo";
            this.btnCargarEjemplo.Size = new System.Drawing.Size(140, 36);
            this.btnCargarEjemplo.TabIndex = 2;
            this.btnCargarEjemplo.Text = "📥 Cargar Prueba";
            this.btnCargarEjemplo.UseVisualStyleBackColor = false;
            this.btnCargarEjemplo.Click += new System.EventHandler(this.btnCargarEjemplo_Click);

            // ── btnCalcularMayor ──────────────────────────────────────────
            this.btnCalcularMayor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcularMayor.BackColor = System.Drawing.Color.White;
            this.btnCalcularMayor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularMayor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCalcularMayor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularMayor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalcularMayor.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCalcularMayor.Location = new System.Drawing.Point(820, 18);
            this.btnCalcularMayor.Name = "btnCalcularMayor";
            this.btnCalcularMayor.Size = new System.Drawing.Size(150, 36);
            this.btnCalcularMayor.TabIndex = 3;
            this.btnCalcularMayor.Text = "⚡ Automático (Mayor)";
            this.btnCalcularMayor.UseVisualStyleBackColor = false;
            this.btnCalcularMayor.Click += new System.EventHandler(this.btnCalcularMayor_Click);

            // ── btnActualizar ─────────────────────────────────────────────
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnActualizar.Location = new System.Drawing.Point(980, 18);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 36);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "🔄 Refrescar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // ── pnlGrillaContenedor ───────────────────────────────────────
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlGrillaContenedor.Controls.Add(this.dgvEstadoResultados);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 72);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1100, 520);
            this.pnlGrillaContenedor.TabIndex = 1;

            // ── dgvEstadoResultados ───────────────────────────────────────
            this.dgvEstadoResultados.AllowUserToAddRows = false;
            this.dgvEstadoResultados.AllowUserToDeleteRows = false;
            this.dgvEstadoResultados.AllowUserToResizeRows = false;
            this.dgvEstadoResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEstadoResultados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstadoResultados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvEstadoResultados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvEstadoResultados.GridColor = System.Drawing.Color.FromArgb(180, 198, 215);

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEstadoResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEstadoResultados.ColumnHeadersHeight = 36;
            this.dgvEstadoResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEstadoResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConcepto,
            this.colParcial,
            this.colSubtotal,
            this.colTotal});
            this.dgvEstadoResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEstadoResultados.EnableHeadersVisualStyles = false;
            this.dgvEstadoResultados.Location = new System.Drawing.Point(16, 12);
            this.dgvEstadoResultados.MultiSelect = false;
            this.dgvEstadoResultados.Name = "dgvEstadoResultados";
            this.dgvEstadoResultados.ReadOnly = true;
            this.dgvEstadoResultados.RowHeadersVisible = false;
            this.dgvEstadoResultados.RowTemplate.Height = 26;
            this.dgvEstadoResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstadoResultados.Size = new System.Drawing.Size(1068, 496);
            this.dgvEstadoResultados.TabIndex = 0;

            // colConcepto
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colConcepto.DefaultCellStyle = dataGridViewCellStyle2;
            this.colConcepto.FillWeight = 260F;
            this.colConcepto.HeaderText = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.ReadOnly = true;
            this.colConcepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colParcial
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.colParcial.DefaultCellStyle = dataGridViewCellStyle3;
            this.colParcial.FillWeight = 95F;
            this.colParcial.HeaderText = "Parcial";
            this.colParcial.Name = "colParcial";
            this.colParcial.ReadOnly = true;
            this.colParcial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colSubtotal
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.colSubtotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSubtotal.FillWeight = 95F;
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            this.colSubtotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colTotal
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotal.FillWeight = 95F;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // ── pnlResumenInferior ─────────────────────────────────────────
            this.pnlResumenInferior.BackColor = System.Drawing.Color.White;
            this.pnlResumenInferior.Controls.Add(this.lblBadgeEstado);
            this.pnlResumenInferior.Controls.Add(this.lblUtilidadOperacional);
            this.pnlResumenInferior.Controls.Add(this.lblUtilidadBruta);
            this.pnlResumenInferior.Controls.Add(this.lblCostoVentas);
            this.pnlResumenInferior.Controls.Add(this.lblVentasNetas);
            this.pnlResumenInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumenInferior.Location = new System.Drawing.Point(0, 592);
            this.pnlResumenInferior.Name = "pnlResumenInferior";
            this.pnlResumenInferior.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlResumenInferior.Size = new System.Drawing.Size(1100, 48);
            this.pnlResumenInferior.TabIndex = 2;

            this.lblVentasNetas.AutoSize = true;
            this.lblVentasNetas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVentasNetas.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblVentasNetas.Location = new System.Drawing.Point(16, 15);
            this.lblVentasNetas.Name = "lblVentasNetas";
            this.lblVentasNetas.Size = new System.Drawing.Size(130, 17);
            this.lblVentasNetas.TabIndex = 0;
            this.lblVentasNetas.Text = "Ventas Netas: $0.00";

            this.lblCostoVentas.AutoSize = true;
            this.lblCostoVentas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCostoVentas.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCostoVentas.Location = new System.Drawing.Point(180, 15);
            this.lblCostoVentas.Name = "lblCostoVentas";
            this.lblCostoVentas.Size = new System.Drawing.Size(130, 17);
            this.lblCostoVentas.TabIndex = 1;
            this.lblCostoVentas.Text = "Costo Ventas: $0.00";

            this.lblUtilidadBruta.AutoSize = true;
            this.lblUtilidadBruta.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUtilidadBruta.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblUtilidadBruta.Location = new System.Drawing.Point(340, 15);
            this.lblUtilidadBruta.Name = "lblUtilidadBruta";
            this.lblUtilidadBruta.Size = new System.Drawing.Size(138, 17);
            this.lblUtilidadBruta.TabIndex = 2;
            this.lblUtilidadBruta.Text = "Utilidad Bruta: $0.00";

            this.lblUtilidadOperacional.AutoSize = true;
            this.lblUtilidadOperacional.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUtilidadOperacional.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.lblUtilidadOperacional.Location = new System.Drawing.Point(510, 15);
            this.lblUtilidadOperacional.Name = "lblUtilidadOperacional";
            this.lblUtilidadOperacional.Size = new System.Drawing.Size(180, 17);
            this.lblUtilidadOperacional.TabIndex = 3;
            this.lblUtilidadOperacional.Text = "Utilidad Operacional: $0.00";

            this.lblBadgeEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBadgeEstado.AutoSize = true;
            this.lblBadgeEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBadgeEstado.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblBadgeEstado.Location = new System.Drawing.Point(780, 15);
            this.lblBadgeEstado.Name = "lblBadgeEstado";
            this.lblBadgeEstado.Size = new System.Drawing.Size(300, 17);
            this.lblBadgeEstado.TabIndex = 4;
            this.lblBadgeEstado.Text = "✓ Estado de Resultados Calculado";

            // ── frmEstadoResultados ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlResumenInferior);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEstadoResultados";
            this.Text = "Estado de Resultados";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadoResultados)).EndInit();
            this.pnlResumenInferior.ResumeLayout(false);
            this.pnlResumenInferior.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Panel pnlFiltroFechas;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFlechaRango;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCargarEjemplo;
        private System.Windows.Forms.Button btnCalcularMayor;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvEstadoResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParcial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Panel pnlResumenInferior;
        private System.Windows.Forms.Label lblVentasNetas;
        private System.Windows.Forms.Label lblCostoVentas;
        private System.Windows.Forms.Label lblUtilidadBruta;
        private System.Windows.Forms.Label lblUtilidadOperacional;
        private System.Windows.Forms.Label lblBadgeEstado;
    }
}
