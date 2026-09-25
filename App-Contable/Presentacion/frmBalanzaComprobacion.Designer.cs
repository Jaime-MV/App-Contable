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
            System.Windows.Forms.DataGridViewCellStyle hdrStyle  = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cuentaStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle montoStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlToolbar          = new System.Windows.Forms.Panel();
            this.lblTituloSeccion    = new System.Windows.Forms.Label();
            this.pnlFiltroFechas     = new System.Windows.Forms.Panel();
            this.lblPeriodo          = new System.Windows.Forms.Label();
            this.dtpFechaInicio      = new System.Windows.Forms.DateTimePicker();
            this.lblFlechaRango      = new System.Windows.Forms.Label();
            this.dtpFechaFin         = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar          = new System.Windows.Forms.Button();
            this.btnCargarEjemplo    = new System.Windows.Forms.Button();
            this.btnCalcularMayor    = new System.Windows.Forms.Button();
            this.btnActualizar       = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvBalanza          = new System.Windows.Forms.DataGridView();
            this.colCuenta           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebe             = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHaber            = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter           = new System.Windows.Forms.Panel();
            this.lblBadgeEstado      = new System.Windows.Forms.Label();
            this.lblTotalHaber       = new System.Windows.Forms.Label();
            this.lblTotalDebe        = new System.Windows.Forms.Label();
            this.lblTotalCuentas     = new System.Windows.Forms.Label();

            this.pnlToolbar.SuspendLayout();
            this.pnlFiltroFechas.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanza)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlToolbar ────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnActualizar);
            this.pnlToolbar.Controls.Add(this.btnCalcularMayor);
            this.pnlToolbar.Controls.Add(this.btnCargarEjemplo);
            this.pnlToolbar.Controls.Add(this.pnlFiltroFechas);
            this.pnlToolbar.Controls.Add(this.lblTituloSeccion);
            this.pnlToolbar.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name     = "pnlToolbar";
            this.pnlToolbar.Padding  = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size     = new System.Drawing.Size(1100, 72);
            this.pnlToolbar.TabIndex = 0;

            // ── lblTituloSeccion ──────────────────────────────────────────
            this.lblTituloSeccion.AutoSize  = true;
            this.lblTituloSeccion.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTituloSeccion.Location  = new System.Drawing.Point(16, 24);
            this.lblTituloSeccion.Name      = "lblTituloSeccion";
            this.lblTituloSeccion.TabIndex  = 0;
            this.lblTituloSeccion.Text      = "BALANZA DE COMPROBACIÓN";

            // ── pnlFiltroFechas ───────────────────────────────────────────
            this.pnlFiltroFechas.Controls.Add(this.btnFiltrar);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaFin);
            this.pnlFiltroFechas.Controls.Add(this.lblFlechaRango);
            this.pnlFiltroFechas.Controls.Add(this.dtpFechaInicio);
            this.pnlFiltroFechas.Controls.Add(this.lblPeriodo);
            this.pnlFiltroFechas.Location = new System.Drawing.Point(255, 16);
            this.pnlFiltroFechas.Name     = "pnlFiltroFechas";
            this.pnlFiltroFechas.Size     = new System.Drawing.Size(370, 38);
            this.pnlFiltroFechas.TabIndex = 1;

            this.lblPeriodo.AutoSize  = true;
            this.lblPeriodo.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPeriodo.Location  = new System.Drawing.Point(3, 11);
            this.lblPeriodo.Name      = "lblPeriodo";
            this.lblPeriodo.TabIndex  = 0;
            this.lblPeriodo.Text      = "Período:";

            this.dtpFechaInicio.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaInicio.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(58, 8);
            this.dtpFechaInicio.Name     = "dtpFechaInicio";
            this.dtpFechaInicio.Size     = new System.Drawing.Size(100, 23);
            this.dtpFechaInicio.TabIndex = 1;

            this.lblFlechaRango.AutoSize  = true;
            this.lblFlechaRango.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFlechaRango.Location  = new System.Drawing.Point(164, 11);
            this.lblFlechaRango.Name      = "lblFlechaRango";
            this.lblFlechaRango.TabIndex  = 2;
            this.lblFlechaRango.Text      = "-";

            this.dtpFechaFin.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFechaFin.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(182, 8);
            this.dtpFechaFin.Name     = "dtpFechaFin";
            this.dtpFechaFin.Size     = new System.Drawing.Size(100, 23);
            this.dtpFechaFin.TabIndex = 3;

            this.btnFiltrar.BackColor                         = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFiltrar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFiltrar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font                              = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor                         = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnFiltrar.Location                          = new System.Drawing.Point(290, 7);
            this.btnFiltrar.Name                              = "btnFiltrar";
            this.btnFiltrar.Size                              = new System.Drawing.Size(70, 25);
            this.btnFiltrar.TabIndex                          = 4;
            this.btnFiltrar.Text                              = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor           = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── btnCargarEjemplo ──────────────────────────────────────────
            this.btnCargarEjemplo.Anchor                            = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnCargarEjemplo.BackColor                         = System.Drawing.Color.White;
            this.btnCargarEjemplo.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnCargarEjemplo.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCargarEjemplo.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarEjemplo.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCargarEjemplo.ForeColor                         = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnCargarEjemplo.Location                          = new System.Drawing.Point(670, 18);
            this.btnCargarEjemplo.Name                              = "btnCargarEjemplo";
            this.btnCargarEjemplo.Size                              = new System.Drawing.Size(140, 36);
            this.btnCargarEjemplo.TabIndex                          = 2;
            this.btnCargarEjemplo.Text                              = "📥 Cargar Prueba";
            this.btnCargarEjemplo.UseVisualStyleBackColor           = false;
            this.btnCargarEjemplo.Click += new System.EventHandler(this.btnCargarEjemplo_Click);

            // ── btnCalcularMayor ──────────────────────────────────────────
            this.btnCalcularMayor.Anchor                            = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnCalcularMayor.BackColor                         = System.Drawing.Color.FromArgb(220, 252, 231);
            this.btnCalcularMayor.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularMayor.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCalcularMayor.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularMayor.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalcularMayor.ForeColor                         = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnCalcularMayor.Location                          = new System.Drawing.Point(820, 18);
            this.btnCalcularMayor.Name                              = "btnCalcularMayor";
            this.btnCalcularMayor.Size                              = new System.Drawing.Size(160, 36);
            this.btnCalcularMayor.TabIndex                          = 3;
            this.btnCalcularMayor.Text                              = "⚡ Automático (Mayor)";
            this.btnCalcularMayor.UseVisualStyleBackColor           = false;
            this.btnCalcularMayor.Click += new System.EventHandler(this.btnCalcularMayor_Click);

            // ── btnActualizar ─────────────────────────────────────────────
            this.btnActualizar.Anchor                            = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnActualizar.BackColor                         = System.Drawing.Color.White;
            this.btnActualizar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnActualizar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.ForeColor                         = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnActualizar.Location                          = new System.Drawing.Point(990, 18);
            this.btnActualizar.Name                              = "btnActualizar";
            this.btnActualizar.Size                              = new System.Drawing.Size(96, 36);
            this.btnActualizar.TabIndex                          = 4;
            this.btnActualizar.Text                              = "🔄 Refrescar";
            this.btnActualizar.UseVisualStyleBackColor           = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // ── pnlGrillaContenedor ───────────────────────────────────────
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlGrillaContenedor.Controls.Add(this.dgvBalanza);
            this.pnlGrillaContenedor.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Location  = new System.Drawing.Point(0, 72);
            this.pnlGrillaContenedor.Name      = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding   = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.Size      = new System.Drawing.Size(1100, 520);
            this.pnlGrillaContenedor.TabIndex  = 1;

            // ── dgvBalanza ────────────────────────────────────────────────
            this.dgvBalanza.AllowUserToAddRows    = false;
            this.dgvBalanza.AllowUserToDeleteRows = false;
            this.dgvBalanza.AllowUserToResizeRows = false;

            hdrStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor          = System.Drawing.Color.FromArgb(189, 215, 238);
            hdrStyle.Font               = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            hdrStyle.ForeColor          = System.Drawing.Color.FromArgb(15, 23, 42);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            hdrStyle.WrapMode           = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvBalanza.ColumnHeadersDefaultCellStyle         = hdrStyle;
            this.dgvBalanza.ColumnHeadersHeight                   = 36;
            this.dgvBalanza.ColumnHeadersHeightSizeMode           = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBalanza.AutoSizeColumnsMode                   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBalanza.BackgroundColor                       = System.Drawing.Color.White;
            this.dgvBalanza.BorderStyle                           = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvBalanza.CellBorderStyle                       = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvBalanza.GridColor                             = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dgvBalanza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCuenta, this.colDebe, this.colHaber });
            this.dgvBalanza.Dock                                  = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalanza.EnableHeadersVisualStyles             = false;
            this.dgvBalanza.Location                              = new System.Drawing.Point(16, 12);
            this.dgvBalanza.MultiSelect                           = false;
            this.dgvBalanza.Name                                  = "dgvBalanza";
            this.dgvBalanza.ReadOnly                              = true;
            this.dgvBalanza.RowHeadersVisible                     = false;
            this.dgvBalanza.RowTemplate.Height                    = 28;
            this.dgvBalanza.SelectionMode                         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalanza.TabIndex                              = 0;

            // colCuenta
            cuentaStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cuentaStyle.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colCuenta.DefaultCellStyle = cuentaStyle;
            this.colCuenta.FillWeight       = 300F;
            this.colCuenta.HeaderText       = "Cuenta";
            this.colCuenta.Name             = "colCuenta";
            this.colCuenta.ReadOnly         = true;
            this.colCuenta.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colDebe
            montoStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            montoStyle.Format    = "N2";
            montoStyle.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colDebe.DefaultCellStyle = montoStyle;
            this.colDebe.FillWeight       = 140F;
            this.colDebe.HeaderText       = "Debe";
            this.colDebe.Name             = "colDebe";
            this.colDebe.ReadOnly         = true;
            this.colDebe.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colHaber
            var haberStyle = new System.Windows.Forms.DataGridViewCellStyle();
            haberStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            haberStyle.Format    = "N2";
            haberStyle.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colHaber.DefaultCellStyle = haberStyle;
            this.colHaber.FillWeight       = 140F;
            this.colHaber.HeaderText       = "Haber";
            this.colHaber.Name             = "colHaber";
            this.colHaber.ReadOnly         = true;
            this.colHaber.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // ── pnlFooter ─────────────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblBadgeEstado);
            this.pnlFooter.Controls.Add(this.lblTotalHaber);
            this.pnlFooter.Controls.Add(this.lblTotalDebe);
            this.pnlFooter.Controls.Add(this.lblTotalCuentas);
            this.pnlFooter.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 592);
            this.pnlFooter.Name     = "pnlFooter";
            this.pnlFooter.Padding  = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlFooter.Size     = new System.Drawing.Size(1100, 48);
            this.pnlFooter.TabIndex = 2;

            this.lblTotalCuentas.AutoSize  = true;
            this.lblTotalCuentas.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCuentas.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTotalCuentas.Location  = new System.Drawing.Point(16, 15);
            this.lblTotalCuentas.Name      = "lblTotalCuentas";
            this.lblTotalCuentas.TabIndex  = 0;
            this.lblTotalCuentas.Text      = "Total Cuentas: 0";

            this.lblTotalDebe.AutoSize  = true;
            this.lblTotalDebe.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDebe.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalDebe.Location  = new System.Drawing.Point(190, 15);
            this.lblTotalDebe.Name      = "lblTotalDebe";
            this.lblTotalDebe.TabIndex  = 1;
            this.lblTotalDebe.Text      = "Total Debe: $0.00";

            this.lblTotalHaber.AutoSize  = true;
            this.lblTotalHaber.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalHaber.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalHaber.Location  = new System.Drawing.Point(380, 15);
            this.lblTotalHaber.Name      = "lblTotalHaber";
            this.lblTotalHaber.TabIndex  = 2;
            this.lblTotalHaber.Text      = "Total Haber: $0.00";

            this.lblBadgeEstado.Anchor    = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.lblBadgeEstado.AutoSize  = true;
            this.lblBadgeEstado.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBadgeEstado.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblBadgeEstado.Location  = new System.Drawing.Point(600, 15);
            this.lblBadgeEstado.Name      = "lblBadgeEstado";
            this.lblBadgeEstado.TabIndex  = 3;
            this.lblBadgeEstado.Text      = "✓ Balanza Cuadrada";

            // ── frmBalanzaComprobacion ────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "frmBalanzaComprobacion";
            this.Text                = "Balanza de Comprobación";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFiltroFechas.ResumeLayout(false);
            this.pnlFiltroFechas.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalanza)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel    pnlToolbar;
        private System.Windows.Forms.Label    lblTituloSeccion;
        private System.Windows.Forms.Panel    pnlFiltroFechas;
        private System.Windows.Forms.Label    lblPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label    lblFlechaRango;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button   btnFiltrar;
        private System.Windows.Forms.Button   btnCargarEjemplo;
        private System.Windows.Forms.Button   btnCalcularMayor;
        private System.Windows.Forms.Button   btnActualizar;
        private System.Windows.Forms.Panel    pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvBalanza;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHaber;
        private System.Windows.Forms.Panel    pnlFooter;
        private System.Windows.Forms.Label    lblTotalCuentas;
        private System.Windows.Forms.Label    lblTotalDebe;
        private System.Windows.Forms.Label    lblTotalHaber;
        private System.Windows.Forms.Label    lblBadgeEstado;
    }
}
