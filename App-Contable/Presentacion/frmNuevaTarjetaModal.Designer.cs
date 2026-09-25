namespace App_Contable.Presentacion
{
    partial class frmNuevaTarjetaModal
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
            this.lblTituloModal = new System.Windows.Forms.Label();
            this.lblSubtituloModal = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblNombreTarjeta = new System.Windows.Forms.Label();
            this.txtNombreTarjeta = new System.Windows.Forms.TextBox();
            this.lblCodigoArticulo = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.lblMetodoValuacion = new System.Windows.Forms.Label();
            this.txtMetodoValuacion = new System.Windows.Forms.TextBox();
            this.lblDestinoAlmacenamiento = new System.Windows.Forms.Label();
            this.pnlCardMemoria = new System.Windows.Forms.Panel();
            this.lblTituloMemoria = new System.Windows.Forms.Label();
            this.lblDescMemoria = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCrearYAbrir = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlCardMemoria.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlHeader.Controls.Add(this.lblSubtituloModal);
            this.pnlHeader.Controls.Add(this.lblTituloModal);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 20, 24, 16);
            this.pnlHeader.Size = new System.Drawing.Size(520, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTituloModal
            // 
            this.lblTituloModal.AutoSize = true;
            this.lblTituloModal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloModal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloModal.Location = new System.Drawing.Point(22, 16);
            this.lblTituloModal.Name = "lblTituloModal";
            this.lblTituloModal.Size = new System.Drawing.Size(306, 25);
            this.lblTituloModal.TabIndex = 0;
            this.lblTituloModal.Text = "➕ Crear Tarjeta Kardex (PEPS / FIFO)";
            // 
            // lblSubtituloModal
            // 
            this.lblSubtituloModal.AutoSize = true;
            this.lblSubtituloModal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtituloModal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtituloModal.Location = new System.Drawing.Point(24, 46);
            this.lblSubtituloModal.Name = "lblSubtituloModal";
            this.lblSubtituloModal.Size = new System.Drawing.Size(430, 15);
            this.lblSubtituloModal.TabIndex = 1;
            this.lblSubtituloModal.Text = "Valuación bajo método PEPS / FIFO. Se almacenará en memoria durante la sesión.";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.pnlCardMemoria);
            this.pnlBody.Controls.Add(this.lblDestinoAlmacenamiento);
            this.pnlBody.Controls.Add(this.txtMetodoValuacion);
            this.pnlBody.Controls.Add(this.lblMetodoValuacion);
            this.pnlBody.Controls.Add(this.txtCodigoArticulo);
            this.pnlBody.Controls.Add(this.lblCodigoArticulo);
            this.pnlBody.Controls.Add(this.txtNombreTarjeta);
            this.pnlBody.Controls.Add(this.lblNombreTarjeta);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 80);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.pnlBody.Size = new System.Drawing.Size(520, 360);
            this.pnlBody.TabIndex = 1;
            // 
            // lblNombreTarjeta
            // 
            this.lblNombreTarjeta.AutoSize = true;
            this.lblNombreTarjeta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNombreTarjeta.Location = new System.Drawing.Point(24, 14);
            this.lblNombreTarjeta.Name = "lblNombreTarjeta";
            this.lblNombreTarjeta.Size = new System.Drawing.Size(183, 15);
            this.lblNombreTarjeta.TabIndex = 0;
            this.lblNombreTarjeta.Text = "Nombre de la Tarjeta Kardex *";
            // 
            // txtNombreTarjeta
            // 
            this.txtNombreTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreTarjeta.Location = new System.Drawing.Point(27, 34);
            this.txtNombreTarjeta.Name = "txtNombreTarjeta";
            this.txtNombreTarjeta.PlaceholderText = "Ej. Inventario Varilla de Hierro 3/8";
            this.txtNombreTarjeta.Size = new System.Drawing.Size(465, 25);
            this.txtNombreTarjeta.TabIndex = 1;
            // 
            // lblCodigoArticulo
            // 
            this.lblCodigoArticulo.AutoSize = true;
            this.lblCodigoArticulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCodigoArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblCodigoArticulo.Location = new System.Drawing.Point(24, 76);
            this.lblCodigoArticulo.Name = "lblCodigoArticulo";
            this.lblCodigoArticulo.Size = new System.Drawing.Size(217, 15);
            this.lblCodigoArticulo.TabIndex = 2;
            this.lblCodigoArticulo.Text = "Artículo / Código Referencia (Opcional)";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCodigoArticulo.Location = new System.Drawing.Point(27, 96);
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.PlaceholderText = "Ej. ART-502";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(465, 25);
            this.txtCodigoArticulo.TabIndex = 3;
            // 
            // lblMetodoValuacion
            // 
            this.lblMetodoValuacion.AutoSize = true;
            this.lblMetodoValuacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMetodoValuacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMetodoValuacion.Location = new System.Drawing.Point(24, 138);
            this.lblMetodoValuacion.Name = "lblMetodoValuacion";
            this.lblMetodoValuacion.Size = new System.Drawing.Size(126, 15);
            this.lblMetodoValuacion.TabIndex = 4;
            this.lblMetodoValuacion.Text = "Método de Valuación";
            // 
            // txtMetodoValuacion
            // 
            this.txtMetodoValuacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtMetodoValuacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMetodoValuacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtMetodoValuacion.Location = new System.Drawing.Point(27, 158);
            this.txtMetodoValuacion.Name = "txtMetodoValuacion";
            this.txtMetodoValuacion.ReadOnly = true;
            this.txtMetodoValuacion.Size = new System.Drawing.Size(465, 24);
            this.txtMetodoValuacion.TabIndex = 5;
            this.txtMetodoValuacion.Text = "PEPS / FIFO (Primeras Entradas, Primeras Salidas)";
            // 
            // lblDestinoAlmacenamiento
            // 
            this.lblDestinoAlmacenamiento.AutoSize = true;
            this.lblDestinoAlmacenamiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDestinoAlmacenamiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDestinoAlmacenamiento.Location = new System.Drawing.Point(24, 202);
            this.lblDestinoAlmacenamiento.Name = "lblDestinoAlmacenamiento";
            this.lblDestinoAlmacenamiento.Size = new System.Drawing.Size(155, 15);
            this.lblDestinoAlmacenamiento.TabIndex = 6;
            this.lblDestinoAlmacenamiento.Text = "Destino de Almacenamiento";
            // 
            // pnlCardMemoria
            // 
            this.pnlCardMemoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlCardMemoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardMemoria.Controls.Add(this.lblDescMemoria);
            this.pnlCardMemoria.Controls.Add(this.lblTituloMemoria);
            this.pnlCardMemoria.Location = new System.Drawing.Point(27, 224);
            this.pnlCardMemoria.Name = "pnlCardMemoria";
            this.pnlCardMemoria.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlCardMemoria.Size = new System.Drawing.Size(465, 68);
            this.pnlCardMemoria.TabIndex = 7;
            // 
            // lblTituloMemoria
            // 
            this.lblTituloMemoria.AutoSize = true;
            this.lblTituloMemoria.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloMemoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.lblTituloMemoria.Location = new System.Drawing.Point(12, 10);
            this.lblTituloMemoria.Name = "lblTituloMemoria";
            this.lblTituloMemoria.Size = new System.Drawing.Size(262, 17);
            this.lblTituloMemoria.TabIndex = 0;
            this.lblTituloMemoria.Text = "⚡ Almacenamiento en Memoria (Sesión)";
            // 
            // lblDescMemoria
            // 
            this.lblDescMemoria.AutoSize = true;
            this.lblDescMemoria.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescMemoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDescMemoria.Location = new System.Drawing.Point(12, 34);
            this.lblDescMemoria.Name = "lblDescMemoria";
            this.lblDescMemoria.Size = new System.Drawing.Size(415, 13);
            this.lblDescMemoria.TabIndex = 1;
            this.lblDescMemoria.Text = "Los movimientos se mantienen y recalculan en memoria durante la ejecución de la app.";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlFooter.Controls.Add(this.btnCrearYAbrir);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 440);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(24, 12, 24, 16);
            this.pnlFooter.Size = new System.Drawing.Size(520, 64);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancelar.Location = new System.Drawing.Point(198, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnCrearYAbrir
            // 
            this.btnCrearYAbrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearYAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCrearYAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearYAbrir.FlatAppearance.BorderSize = 0;
            this.btnCrearYAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearYAbrir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCrearYAbrir.ForeColor = System.Drawing.Color.White;
            this.btnCrearYAbrir.Location = new System.Drawing.Point(318, 14);
            this.btnCrearYAbrir.Name = "btnCrearYAbrir";
            this.btnCrearYAbrir.Size = new System.Drawing.Size(175, 36);
            this.btnCrearYAbrir.TabIndex = 1;
            this.btnCrearYAbrir.Text = "Crear y Abrir Tarjeta";
            this.btnCrearYAbrir.UseVisualStyleBackColor = false;
            this.btnCrearYAbrir.Click += new System.EventHandler(this.btnCrearYAbrir_Click);
            // 
            // frmNuevaTarjetaModal
            // 
            this.AcceptButton = this.btnCrearYAbrir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(520, 504);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNuevaTarjetaModal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear Nueva Tarjeta Kardex (PEPS / FIFO)";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlCardMemoria.ResumeLayout(false);
            this.pnlCardMemoria.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloModal;
        private System.Windows.Forms.Label lblSubtituloModal;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblNombreTarjeta;
        private System.Windows.Forms.TextBox txtNombreTarjeta;
        private System.Windows.Forms.Label lblCodigoArticulo;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Label lblMetodoValuacion;
        private System.Windows.Forms.TextBox txtMetodoValuacion;
        private System.Windows.Forms.Label lblDestinoAlmacenamiento;
        private System.Windows.Forms.Panel pnlCardMemoria;
        private System.Windows.Forms.Label lblTituloMemoria;
        private System.Windows.Forms.Label lblDescMemoria;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCrearYAbrir;
    }
}

