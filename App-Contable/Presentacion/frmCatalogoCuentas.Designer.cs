namespace App_Contable.Presentacion
{
    partial class frmCatalogoCuentas
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
            System.Windows.Forms.DataGridViewCellStyle hdrStyle    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle codigoStyle  = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle nombreStyle  = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle subStyle     = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle natStyle     = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlToolbar          = new System.Windows.Forms.Panel();
            this.lblTituloSeccion    = new System.Windows.Forms.Label();
            this.pnlBusqueda         = new System.Windows.Forms.Panel();
            this.lblBuscar           = new System.Windows.Forms.Label();
            this.txtBuscar           = new System.Windows.Forms.TextBox();
            this.btnNueva            = new System.Windows.Forms.Button();
            this.btnEditar           = new System.Windows.Forms.Button();
            this.btnEliminar         = new System.Windows.Forms.Button();
            this.pnlGrillaContenedor = new System.Windows.Forms.Panel();
            this.dgvCatalogo         = new System.Windows.Forms.DataGridView();
            this.colCodigo           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre           = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubcuentas       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNaturaleza       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter           = new System.Windows.Forms.Panel();
            this.lblTotalCuentas     = new System.Windows.Forms.Label();
            this.lblAyuda            = new System.Windows.Forms.Label();

            this.pnlToolbar.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlGrillaContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlToolbar ────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnEliminar);
            this.pnlToolbar.Controls.Add(this.btnEditar);
            this.pnlToolbar.Controls.Add(this.btnNueva);
            this.pnlToolbar.Controls.Add(this.pnlBusqueda);
            this.pnlToolbar.Controls.Add(this.lblTituloSeccion);
            this.pnlToolbar.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Name     = "pnlToolbar";
            this.pnlToolbar.Padding  = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size     = new System.Drawing.Size(1100, 72);
            this.pnlToolbar.TabIndex = 0;

            this.pnlToolbar.Paint += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, ((System.Windows.Forms.Panel)s!).Height - 1,
                    ((System.Windows.Forms.Panel)s!).Width, ((System.Windows.Forms.Panel)s!).Height - 1);
            };

            // ── lblTituloSeccion ──────────────────────────────────────────
            this.lblTituloSeccion.AutoSize  = true;
            this.lblTituloSeccion.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTituloSeccion.Location  = new System.Drawing.Point(16, 24);
            this.lblTituloSeccion.Name      = "lblTituloSeccion";
            this.lblTituloSeccion.TabIndex  = 0;
            this.lblTituloSeccion.Text      = "CATÁLOGO DE CUENTAS";

            // ── pnlBusqueda ───────────────────────────────────────────────
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.lblBuscar);
            this.pnlBusqueda.Location = new System.Drawing.Point(250, 16);
            this.pnlBusqueda.Name     = "pnlBusqueda";
            this.pnlBusqueda.Size     = new System.Drawing.Size(280, 38);
            this.pnlBusqueda.TabIndex = 1;

            this.lblBuscar.AutoSize  = true;
            this.lblBuscar.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblBuscar.Location  = new System.Drawing.Point(3, 11);
            this.lblBuscar.Name      = "lblBuscar";
            this.lblBuscar.Text      = "🔍 Buscar:";

            this.txtBuscar.Font             = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBuscar.Location         = new System.Drawing.Point(70, 8);
            this.txtBuscar.Name             = "txtBuscar";
            this.txtBuscar.PlaceholderText  = "Código o nombre...";
            this.txtBuscar.Size             = new System.Drawing.Size(200, 23);
            this.txtBuscar.TabIndex         = 0;
            this.txtBuscar.BorderStyle      = System.Windows.Forms.BorderStyle.FixedSingle;

            // ── btnNueva ──────────────────────────────────────────────────
            this.btnNueva.Anchor                            = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnNueva.BackColor                         = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNueva.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnNueva.FlatAppearance.BorderSize         = 0;
            this.btnNueva.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnNueva.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNueva.ForeColor                         = System.Drawing.Color.White;
            this.btnNueva.Location                          = new System.Drawing.Point(590, 18);
            this.btnNueva.Name                              = "btnNueva";
            this.btnNueva.Size                              = new System.Drawing.Size(140, 36);
            this.btnNueva.TabIndex                          = 2;
            this.btnNueva.Text                              = "➕ Nueva Cuenta";
            this.btnNueva.UseVisualStyleBackColor           = false;

            // ── btnEditar ─────────────────────────────────────────────────
            this.btnEditar.Anchor                            = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnEditar.BackColor                         = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnEditar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnEditar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.ForeColor                         = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnEditar.Location                          = new System.Drawing.Point(740, 18);
            this.btnEditar.Name                              = "btnEditar";
            this.btnEditar.Size                              = new System.Drawing.Size(130, 36);
            this.btnEditar.TabIndex                          = 3;
            this.btnEditar.Text                              = "✏ Editar Cuenta";
            this.btnEditar.UseVisualStyleBackColor           = false;

            // ── btnEliminar ───────────────────────────────────────────────
            this.btnEliminar.Anchor                            = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnEliminar.BackColor                         = System.Drawing.Color.FromArgb(254, 242, 242);
            this.btnEliminar.Cursor                            = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor        = System.Drawing.Color.FromArgb(254, 202, 202);
            this.btnEliminar.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font                              = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.ForeColor                         = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminar.Location                          = new System.Drawing.Point(880, 18);
            this.btnEliminar.Name                              = "btnEliminar";
            this.btnEliminar.Size                              = new System.Drawing.Size(130, 36);
            this.btnEliminar.TabIndex                          = 4;
            this.btnEliminar.Text                              = "🗑 Eliminar Cuenta";
            this.btnEliminar.UseVisualStyleBackColor           = false;

            // ── pnlGrillaContenedor ───────────────────────────────────────
            this.pnlGrillaContenedor.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlGrillaContenedor.Controls.Add(this.dgvCatalogo);
            this.pnlGrillaContenedor.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrillaContenedor.Name      = "pnlGrillaContenedor";
            this.pnlGrillaContenedor.Padding   = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlGrillaContenedor.TabIndex  = 1;

            // ── dgvCatalogo ───────────────────────────────────────────────
            this.dgvCatalogo.AllowUserToAddRows    = false;
            this.dgvCatalogo.AllowUserToDeleteRows = false;
            this.dgvCatalogo.AllowUserToResizeRows = false;

            hdrStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle.BackColor          = System.Drawing.Color.FromArgb(189, 215, 238);
            hdrStyle.Font               = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            hdrStyle.ForeColor          = System.Drawing.Color.FromArgb(15, 23, 42);
            hdrStyle.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            hdrStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            hdrStyle.WrapMode           = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvCatalogo.ColumnHeadersDefaultCellStyle       = hdrStyle;
            this.dgvCatalogo.ColumnHeadersHeight                  = 36;
            this.dgvCatalogo.ColumnHeadersHeightSizeMode          = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCatalogo.AutoSizeColumnsMode                  = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCatalogo.BackgroundColor                      = System.Drawing.Color.White;
            this.dgvCatalogo.BorderStyle                          = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvCatalogo.CellBorderStyle                      = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvCatalogo.GridColor                            = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dgvCatalogo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCodigo, this.colNombre, this.colSubcuentas, this.colNaturaleza });
            this.dgvCatalogo.Dock                                 = System.Windows.Forms.DockStyle.Fill;
            this.dgvCatalogo.EnableHeadersVisualStyles            = false;
            this.dgvCatalogo.MultiSelect                          = false;
            this.dgvCatalogo.Name                                 = "dgvCatalogo";
            this.dgvCatalogo.ReadOnly                             = true;
            this.dgvCatalogo.RowHeadersVisible                    = false;
            this.dgvCatalogo.RowTemplate.Height                   = 30;
            this.dgvCatalogo.SelectionMode                        = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.TabIndex                             = 0;

            // colCodigo
            codigoStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            codigoStyle.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.colCodigo.DefaultCellStyle = codigoStyle;
            this.colCodigo.FillWeight       = 80F;
            this.colCodigo.HeaderText       = "Código";
            this.colCodigo.Name             = "colCodigo";
            this.colCodigo.ReadOnly         = true;
            this.colCodigo.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colNombre
            nombreStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            nombreStyle.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colNombre.DefaultCellStyle = nombreStyle;
            this.colNombre.FillWeight       = 200F;
            this.colNombre.HeaderText       = "Nombre de la Cuenta";
            this.colNombre.Name             = "colNombre";
            this.colNombre.ReadOnly         = true;
            this.colNombre.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colSubcuentas
            subStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            subStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            subStyle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.colSubcuentas.DefaultCellStyle = subStyle;
            this.colSubcuentas.FillWeight       = 260F;
            this.colSubcuentas.HeaderText       = "Subcuentas";
            this.colSubcuentas.Name             = "colSubcuentas";
            this.colSubcuentas.ReadOnly         = true;
            this.colSubcuentas.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // colNaturaleza
            natStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            natStyle.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.colNaturaleza.DefaultCellStyle = natStyle;
            this.colNaturaleza.FillWeight       = 90F;
            this.colNaturaleza.HeaderText       = "Naturaleza";
            this.colNaturaleza.Name             = "colNaturaleza";
            this.colNaturaleza.ReadOnly         = true;
            this.colNaturaleza.SortMode         = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            // ── pnlFooter ─────────────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblAyuda);
            this.pnlFooter.Controls.Add(this.lblTotalCuentas);
            this.pnlFooter.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Name     = "pnlFooter";
            this.pnlFooter.Padding  = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlFooter.Size     = new System.Drawing.Size(1100, 48);
            this.pnlFooter.TabIndex = 2;

            this.pnlFooter.Paint += (s, e) =>
            {
                using var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, ((System.Windows.Forms.Panel)s!).Width, 0);
            };

            this.lblTotalCuentas.AutoSize  = true;
            this.lblTotalCuentas.Font      = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCuentas.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalCuentas.Location  = new System.Drawing.Point(16, 15);
            this.lblTotalCuentas.Name      = "lblTotalCuentas";
            this.lblTotalCuentas.TabIndex  = 0;
            this.lblTotalCuentas.Text      = "Total Cuentas: 0";

            this.lblAyuda.Anchor    = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.lblAyuda.AutoSize  = true;
            this.lblAyuda.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblAyuda.Location  = new System.Drawing.Point(500, 15);
            this.lblAyuda.Name      = "lblAyuda";
            this.lblAyuda.TabIndex  = 1;
            this.lblAyuda.Text      = "💡 Doble clic sobre una fila para editar rápidamente · Los cambios se reflejan en nuevos asientos";

            // ── frmCatalogoCuentas ────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlGrillaContenedor);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlToolbar);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.Name                = "frmCatalogoCuentas";
            this.Text                = "Catálogo de Cuentas";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlGrillaContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel    pnlToolbar;
        private System.Windows.Forms.Label    lblTituloSeccion;
        private System.Windows.Forms.Panel    pnlBusqueda;
        private System.Windows.Forms.Label    lblBuscar;
        private System.Windows.Forms.TextBox  txtBuscar;
        private System.Windows.Forms.Button   btnNueva;
        private System.Windows.Forms.Button   btnEditar;
        private System.Windows.Forms.Button   btnEliminar;
        private System.Windows.Forms.Panel    pnlGrillaContenedor;
        private System.Windows.Forms.DataGridView dgvCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubcuentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNaturaleza;
        private System.Windows.Forms.Panel    pnlFooter;
        private System.Windows.Forms.Label    lblTotalCuentas;
        private System.Windows.Forms.Label    lblAyuda;
    }
}
