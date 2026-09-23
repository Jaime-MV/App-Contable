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
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFlecha = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlCuentas = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTotalHaber = new System.Windows.Forms.Label();
            this.lblTotalDebe = new System.Windows.Forms.Label();
            this.lblTotalCuentas = new System.Windows.Forms.Label();

            this.pnlToolbar.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlToolbar ────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.btnRefrescar);
            this.pnlToolbar.Controls.Add(this.pnlFiltro);
            this.pnlToolbar.Controls.Add(this.lblTituloSeccion);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 72;
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16, 16, 16, 8);

            // ── lblTituloSeccion ──────────────────────────────────────────
            this.lblTituloSeccion.AutoSize = true;
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI Semibold", 14f, System.Drawing.FontStyle.Bold);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTituloSeccion.Location = new System.Drawing.Point(16, 16);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Text = "MAYORIZACIÓN";

            // ── pnlFiltro ─────────────────────────────────────────────────
            this.pnlFiltro.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.pnlFiltro.Controls.Add(this.btnFiltrar);
            this.pnlFiltro.Controls.Add(this.dtpHasta);
            this.pnlFiltro.Controls.Add(this.lblFlecha);
            this.pnlFiltro.Controls.Add(this.dtpDesde);
            this.pnlFiltro.Controls.Add(this.lblDesde);
            this.pnlFiltro.Location = new System.Drawing.Point(300, 18);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(420, 36);

            // Período label
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDesde.Location = new System.Drawing.Point(0, 10);
            this.lblDesde.Text = "Período:";

            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 6);
            this.dtpDesde.Size = new System.Drawing.Size(100, 23);

            this.lblFlecha.AutoSize = true;
            this.lblFlecha.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFlecha.Location = new System.Drawing.Point(165, 10);
            this.lblFlecha.Text = "—";

            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(180, 6);
            this.dtpHasta.Size = new System.Drawing.Size(100, 23);

            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.btnFiltrar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnFiltrar.Location = new System.Drawing.Point(288, 4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(70, 27);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // ── btnRefrescar ──────────────────────────────────────────────
            this.btnRefrescar.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnRefrescar.BackColor = System.Drawing.Color.White;
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnRefrescar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnRefrescar.Location = new System.Drawing.Point(960, 20);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 32);
            this.btnRefrescar.Text = "🔄 Refrescar";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // ── pnlScroll (contiene pnlCuentas con scroll) ────────────────
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlScroll.Controls.Add(this.pnlCuentas);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Padding = new System.Windows.Forms.Padding(0);

            // ── pnlCuentas (scroll vertical, tarjetas dinámicas) ──────────
            this.pnlCuentas.AutoScroll = true;
            this.pnlCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuentas.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlCuentas.Name = "pnlCuentas";
            this.pnlCuentas.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);

            // ── pnlFooter ─────────────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblEstado);
            this.pnlFooter.Controls.Add(this.lblTotalHaber);
            this.pnlFooter.Controls.Add(this.lblTotalDebe);
            this.pnlFooter.Controls.Add(this.lblTotalCuentas);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 44;
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);

            this.lblTotalCuentas.AutoSize = true;
            this.lblTotalCuentas.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.lblTotalCuentas.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTotalCuentas.Location = new System.Drawing.Point(16, 14);
            this.lblTotalCuentas.Text = "Cuentas: 0";

            this.lblTotalDebe.AutoSize = true;
            this.lblTotalDebe.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5f, System.Drawing.FontStyle.Bold);
            this.lblTotalDebe.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalDebe.Location = new System.Drawing.Point(140, 14);
            this.lblTotalDebe.Text = "Total Debe: 0.00";

            this.lblTotalHaber.AutoSize = true;
            this.lblTotalHaber.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5f, System.Drawing.FontStyle.Bold);
            this.lblTotalHaber.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblTotalHaber.Location = new System.Drawing.Point(380, 14);
            this.lblTotalHaber.Text = "Total Haber: 0.00";

            this.lblEstado.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5f, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblEstado.Location = new System.Drawing.Point(820, 14);
            this.lblEstado.Text = "✓ Mayorización Cuadrada";

            // ── frmMayorizacion ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 640);
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
            this.pnlScroll.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblFlecha;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.Panel pnlCuentas;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTotalHaber;
        private System.Windows.Forms.Label lblTotalDebe;
        private System.Windows.Forms.Label lblTotalCuentas;
    }
}
