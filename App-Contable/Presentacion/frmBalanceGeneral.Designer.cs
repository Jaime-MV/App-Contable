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
            this.dtpFechaCorte = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnCargarEjemplo = new System.Windows.Forms.Button();
            this.btnCalcularMayor = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvBalanceGeneral = new System.Windows.Forms.DataGridView();
            this.colCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParcial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumenInferior = new System.Windows.Forms.Panel();
            this.lblBadgeEstado = new System.Windows.Forms.Label();
            this.lblTotalPasivoPatrimonio = new System.Windows.Forms.Label();
            this.lblTotalActivo = new System.Windows.Forms.Label();
            this.pnlToolbar.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanceGeneral)).BeginInit();
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
            this.lblTituloSeccion.Size = new System.Drawing.Size(160, 21);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "BALANCE GENERAL";

            // ── pnlFiltroFechas ───────────────────────────────────────────
            this.pnlFiltroFechas.Controls.Add(this.btnFiltrar);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaCorte);
            this.pnlFiltroFechas.Controls.Add(this.lblPeriodo);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(290, 16);
            this.pnlFiltroFechas.Name = "pnlFiltroFechas";
            this.pnlFiltroFechas.Size = new System.Drawing.Size(290, 38);
            this.pnlFiltroFechas.TabIndex = 1;

            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPeriodo.Location = new System.Drawing.Point(3, 11);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(90, 15);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Fecha de Corte:";

            this.dtpFechaCorte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCorte.Location = new System.Drawing.Point(97, 8);
            this.dtpFechaCorte.Name = "dtpFechaCorte";
            this.dtpFechaCorte.Size = new System.Drawing.Size(105, 23);
            this.dtpFechaCorte.TabIndex = 1;

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnFiltrar.Location = new System.Drawing.Point(210, 7);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(70, 25);
            this.btnFiltrar.TabIndex = 2;
            this.btnFiltrar.Text = "Aplicar";
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
            this.btnCargarEjemplo.Location = new System.Drawing.Point(685, 18);
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
            this.btnCalcularMayor.Location = new System.Drawing.Point(825, 18);
            this.btnCalcularMayor.Name = "btnCalcularMayor";
            this.btnCalcularMayor.Size = new System.Drawing.Size(145, 36);
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
            this.pnlGrillaContenedor.Controls.Add(this.dgvBalanceGeneral);
            this.pnlGrillaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location = new System.Drawing.Point(0, 72);
            this.pnlGrillaContenedor.Name = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.Size = new System.Drawing.Size(1100, 520);
            this.pnlGrillaContenedor.TabIndex = 1;

            // ── dgvBalanceGeneral ─────────────────────────────────────────
            this.dgvBalanceGeneral.AllowUserToAddRows = false;
            this.dgvBalanceGeneral.AllowUserToDeleteRows = false;
            this.dgvBalanceGeneral.AllowUserToResizeRows = false;
            this.dgvBalanceGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBalanceGeneral.BackgroundColor = System.Drawing.Color.White;
            this.dgvBalanceGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvBalanceGeneral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvBalanceGeneral.GridColor = System.Drawing.Color.FromArgb(180, 198, 215);

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBalanceGeneral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBalanceGeneral.ColumnHeadersHeight = 36;
            this.dgvBalanceGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBalanceGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCuenta,
            this.colParcial,
            this.colSubtotal,
            this.colTotal});
            this.dgvBalanceGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalanceGeneral.EnableHeadersVisualStyles = false;
            this.dgvBalanceGeneral.Location = new System.Drawing.Point(16, 12);
            this.dgvBalanceGeneral.MultiSelect = false;
            this.dgvBalanceGeneral.Name = "dgvBalanceGeneral";
            this.dgvBalanceGeneral.ReadOnly = true;
            this.dgvBalanceGeneral.RowHeadersVisible = false;
            this.dgvBalanceGeneral.RowTemplate.Height = 26;
            this.dgvBalanceGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalanceGeneral.Size = new System.Drawing.Size(1068, 496);
            this.dgvBalanceGeneral.TabIndex = 0;

            // colCuenta
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCuenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCuenta.FillWeight = 260F;
            this.colCuenta.HeaderText = "Cuenta";
            this.colCuenta.Name = "colCuenta";
            this.colCuenta.ReadOnly = true;
            this.colCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

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
            this.pnlResumenInferior.Controls.Add(this.lblTotalPasivoPatrimonio);
            this.pnlResumenInferior.Controls.Add(this.lblTotalActivo);
            this.pnlResumenInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumenInferior.Location = new System.Drawing.Point(0, 592);
            this.pnlResumenInferior.Name = "pnlResumenInferior";
            this.pnlResumenInferior.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlResumenInferior.Size = new System.Drawing.Size(1100, 48);
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
            this.lblBadgeEstado.Size = new System.Drawing.Size(340, 17);
            this.lblBadgeEstado.TabIndex = 2;
            this.lblBadgeEstado.Text = "✓ Balance General Cuadrado (Activo = Pasivo + Patrimonio)";

            // ── frmBalanceGeneral ─────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlResumenInferior);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBalanceGeneral";
            this.Text = "Balance General";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanceGeneral)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dtpFechaCorte;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCargarEjemplo;
        private System.Windows.Forms.Button btnCalcularMayor;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvBalanceGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParcial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Panel pnlResumenInferior;
        private System.Windows.Forms.Label lblTotalActivo;
        private System.Windows.Forms.Label lblTotalPasivoPatrimonio;
        private System.Windows.Forms.Label lblBadgeEstado;
    }
}
