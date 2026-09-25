namespace App_Contable.Presentacion
{
    partial class frmSeleccionarLibroDiarioModal
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlBuscador = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.lstLibros = new App_Contable.Presentacion.LibroDiarioInstanciaListBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBuscador.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.pnlHeader.Size = new System.Drawing.Size(540, 68);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(434, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Escoge un libro diario para procesar automáticamente su Balanza de Comprobación.";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitulo.Location = new System.Drawing.Point(18, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(206, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Seleccionar Libro Diario";
            // 
            // pnlBuscador
            // 
            this.pnlBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBuscador.Controls.Add(this.txtBuscar);
            this.pnlBuscador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBuscador.Location = new System.Drawing.Point(0, 68);
            this.pnlBuscador.Name = "pnlBuscador";
            this.pnlBuscador.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlBuscador.Size = new System.Drawing.Size(540, 46);
            this.pnlBuscador.TabIndex = 1;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(20, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "🔍  Buscar libro por nombre, período o empresa...";
            this.txtBuscar.Size = new System.Drawing.Size(500, 24);
            this.txtBuscar.TabIndex = 0;
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.lstLibros);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 114);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.pnlContenido.Size = new System.Drawing.Size(540, 286);
            this.pnlContenido.TabIndex = 2;
            // 
            // lstLibros
            // 
            this.lstLibros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLibros.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstLibros.ItemHeight = 74;
            this.lstLibros.Location = new System.Drawing.Point(20, 8);
            this.lstLibros.Name = "lstLibros";
            this.lstLibros.Size = new System.Drawing.Size(500, 270);
            this.lstLibros.TabIndex = 0;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnAceptar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 400);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(20, 12, 20, 14);
            this.pnlBotones.Size = new System.Drawing.Size(540, 60);
            this.pnlBotones.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancelar.Location = new System.Drawing.Point(264, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(384, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(136, 36);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "⚡ Aceptar / Cargar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmSeleccionarLibroDiarioModal
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(540, 460);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlBuscador);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeleccionarLibroDiarioModal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccionar Libro Diario";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBuscador.ResumeLayout(false);
            this.pnlBuscador.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlBuscador;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlContenido;
        private App_Contable.Presentacion.LibroDiarioInstanciaListBox lstLibros;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}

