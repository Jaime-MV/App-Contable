namespace App_Contable.Presentacion
{
    partial class frmInicioKardex
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
            this.pnlDashHeader = new System.Windows.Forms.Panel();
            this.lblBadgeTotal = new System.Windows.Forms.Label();
            this.lblDashSubtitulo = new System.Windows.Forms.Label();
            this.lblDashTitulo = new System.Windows.Forms.Label();
            this.pnlDashContent = new System.Windows.Forms.Panel();
            this.pnlListaAsientos = new System.Windows.Forms.Panel();
            this.lstRegistros = new App_Contable.Presentacion.KardexDashboardListBox();
            this.txtBuscarDash = new System.Windows.Forms.TextBox();
            this.lblListaHeader = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnActualizarLista = new System.Windows.Forms.Button();
            this.btnVistaPrevia = new System.Windows.Forms.Button();
            this.btnKardexManual = new System.Windows.Forms.Button();
            this.btnGenerarKardex = new System.Windows.Forms.Button();
            this.lblAccionesHeader = new System.Windows.Forms.Label();
            this.pnlDashHeader.SuspendLayout();
            this.pnlDashContent.SuspendLayout();
            this.pnlListaAsientos.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDashHeader
            // 
            this.pnlDashHeader.BackColor = System.Drawing.Color.White;
            this.pnlDashHeader.Controls.Add(this.lblBadgeTotal);
            this.pnlDashHeader.Controls.Add(this.lblDashSubtitulo);
            this.pnlDashHeader.Controls.Add(this.lblDashTitulo);
            this.pnlDashHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDashHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDashHeader.Name = "pnlDashHeader";
            this.pnlDashHeader.Padding = new System.Windows.Forms.Padding(32, 20, 32, 20);
            this.pnlDashHeader.Size = new System.Drawing.Size(1100, 90);
            this.pnlDashHeader.TabIndex = 0;
            // 
            // lblBadgeTotal
            // 
            this.lblBadgeTotal.AutoSize = true;
            this.lblBadgeTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblBadgeTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblBadgeTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblBadgeTotal.Location = new System.Drawing.Point(310, 24);
            this.lblBadgeTotal.Name = "lblBadgeTotal";
            this.lblBadgeTotal.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblBadgeTotal.Size = new System.Drawing.Size(95, 19);
            this.lblBadgeTotal.TabIndex = 2;
            this.lblBadgeTotal.Text = "  0 Registro(s)  ";
            // 
            // lblDashSubtitulo
            // 
            this.lblDashSubtitulo.AutoSize = true;
            this.lblDashSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDashSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDashSubtitulo.Location = new System.Drawing.Point(34, 54);
            this.lblDashSubtitulo.Name = "lblDashSubtitulo";
            this.lblDashSubtitulo.Size = new System.Drawing.Size(560, 17);
            this.lblDashSubtitulo.TabIndex = 1;
            this.lblDashSubtitulo.Text = "Selecciona un libro diario para generar automáticamente su tarjeta Kardex o abre una tarjeta guardada.";
            // 
            // lblDashTitulo
            // 
            this.lblDashTitulo.AutoSize = true;
            this.lblDashTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDashTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDashTitulo.Location = new System.Drawing.Point(32, 18);
            this.lblDashTitulo.Name = "lblDashTitulo";
            this.lblDashTitulo.Size = new System.Drawing.Size(265, 32);
            this.lblDashTitulo.TabIndex = 0;
            this.lblDashTitulo.Text = "Gestión de Tarjetas Kardex";
            // 
            // pnlDashContent
            // 
            this.pnlDashContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlDashContent.Controls.Add(this.pnlListaAsientos);
            this.pnlDashContent.Controls.Add(this.pnlAcciones);
            this.pnlDashContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashContent.Location = new System.Drawing.Point(0, 90);
            this.pnlDashContent.Name = "pnlDashContent";
            this.pnlDashContent.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
            this.pnlDashContent.Size = new System.Drawing.Size(1100, 550);
            this.pnlDashContent.TabIndex = 1;
            // 
            // pnlListaAsientos
            // 
            this.pnlListaAsientos.BackColor = System.Drawing.Color.White;
            this.pnlListaAsientos.Controls.Add(this.lstRegistros);
            this.pnlListaAsientos.Controls.Add(this.txtBuscarDash);
            this.pnlListaAsientos.Controls.Add(this.lblListaHeader);
            this.pnlListaAsientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaAsientos.Location = new System.Drawing.Point(24, 20);
            this.pnlListaAsientos.Name = "pnlListaAsientos";
            this.pnlListaAsientos.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlListaAsientos.Size = new System.Drawing.Size(772, 510);
            this.pnlListaAsientos.TabIndex = 0;
            // 
            // lstRegistros
            // 
            this.lstRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRegistros.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstRegistros.ItemHeight = 76;
            this.lstRegistros.Location = new System.Drawing.Point(0, 71);
            this.lstRegistros.Name = "lstRegistros";
            this.lstRegistros.Size = new System.Drawing.Size(756, 439);
            this.lstRegistros.TabIndex = 2;
            // 
            // txtBuscarDash
            // 
            this.txtBuscarDash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarDash.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarDash.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarDash.Location = new System.Drawing.Point(0, 36);
            this.txtBuscarDash.Margin = new System.Windows.Forms.Padding(16, 0, 16, 8);
            this.txtBuscarDash.Name = "txtBuscarDash";
            this.txtBuscarDash.PlaceholderText = "🔍  Buscar tarjetas kardex o libros diarios (Alt+S)...";
            this.txtBuscarDash.Size = new System.Drawing.Size(756, 24);
            this.txtBuscarDash.TabIndex = 1;
            // 
            // lblListaHeader
            // 
            this.lblListaHeader.AutoSize = true;
            this.lblListaHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListaHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblListaHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblListaHeader.Location = new System.Drawing.Point(0, 0);
            this.lblListaHeader.Name = "lblListaHeader";
            this.lblListaHeader.Padding = new System.Windows.Forms.Padding(16, 12, 0, 8);
            this.lblListaHeader.Size = new System.Drawing.Size(370, 36);
            this.lblListaHeader.TabIndex = 0;
            this.lblListaHeader.Text = "Registros Disponibles (Tarjetas Kardex y Libros Diarios)";
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Controls.Add(this.btnActualizarLista);
            this.pnlAcciones.Controls.Add(this.btnVistaPrevia);
            this.pnlAcciones.Controls.Add(this.btnKardexManual);
            this.pnlAcciones.Controls.Add(this.btnGenerarKardex);
            this.pnlAcciones.Controls.Add(this.lblAccionesHeader);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlAcciones.Location = new System.Drawing.Point(796, 20);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlAcciones.Size = new System.Drawing.Size(280, 510);
            this.pnlAcciones.TabIndex = 1;
            // 
            // btnActualizarLista
            // 
            this.btnActualizarLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnActualizarLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarLista.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActualizarLista.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnActualizarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarLista.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnActualizarLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnActualizarLista.Location = new System.Drawing.Point(16, 215);
            this.btnActualizarLista.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnActualizarLista.Size = new System.Drawing.Size(248, 60);
            this.btnActualizarLista.TabIndex = 4;
            this.btnActualizarLista.Text = "↺  Actualizar\r\nRecarga registros disponibles.";
            this.btnActualizarLista.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarLista.UseVisualStyleBackColor = false;
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnVistaPrevia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVistaPrevia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVistaPrevia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaPrevia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnVistaPrevia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnVistaPrevia.Location = new System.Drawing.Point(16, 155);
            this.btnVistaPrevia.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVistaPrevia.Size = new System.Drawing.Size(248, 60);
            this.btnVistaPrevia.TabIndex = 3;
            this.btnVistaPrevia.Text = "👁️  Vista Rápida\r\nConsulta resumen antes de abrir.";
            this.btnVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVistaPrevia.UseVisualStyleBackColor = false;
            // 
            // btnKardexManual
            // 
            this.btnKardexManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.btnKardexManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKardexManual.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKardexManual.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnKardexManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKardexManual.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnKardexManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnKardexManual.Location = new System.Drawing.Point(16, 95);
            this.btnKardexManual.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnKardexManual.Name = "btnKardexManual";
            this.btnKardexManual.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnKardexManual.Size = new System.Drawing.Size(248, 60);
            this.btnKardexManual.TabIndex = 2;
            this.btnKardexManual.Text = "➕  Tarjeta Kardex Manual\r\nCrea un kardex en blanco.";
            this.btnKardexManual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKardexManual.UseVisualStyleBackColor = false;
            // 
            // btnGenerarKardex
            // 
            this.btnGenerarKardex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(96)))), ((int)(((byte)(255)))));
            this.btnGenerarKardex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarKardex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenerarKardex.FlatAppearance.BorderSize = 0;
            this.btnGenerarKardex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarKardex.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGenerarKardex.ForeColor = System.Drawing.Color.White;
            this.btnGenerarKardex.Location = new System.Drawing.Point(16, 35);
            this.btnGenerarKardex.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnGenerarKardex.Name = "btnGenerarKardex";
            this.btnGenerarKardex.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGenerarKardex.Size = new System.Drawing.Size(248, 60);
            this.btnGenerarKardex.TabIndex = 1;
            this.btnGenerarKardex.Text = "⚡  Generar Kardex desde Libro Diario\r\nExtrae movimientos de inventario.";
            this.btnGenerarKardex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarKardex.UseVisualStyleBackColor = false;
            // 
            // lblAccionesHeader
            // 
            this.lblAccionesHeader.AutoSize = true;
            this.lblAccionesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAccionesHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblAccionesHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblAccionesHeader.Location = new System.Drawing.Point(16, 12);
            this.lblAccionesHeader.Name = "lblAccionesHeader";
            this.lblAccionesHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.lblAccionesHeader.Size = new System.Drawing.Size(68, 23);
            this.lblAccionesHeader.TabIndex = 0;
            this.lblAccionesHeader.Text = "Comenzar";
            // 
            // frmInicioKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlDashContent);
            this.Controls.Add(this.pnlDashHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInicioKardex";
            this.Text = "Gestión de Kardex";
            this.pnlDashHeader.ResumeLayout(false);
            this.pnlDashHeader.PerformLayout();
            this.pnlDashContent.ResumeLayout(false);
            this.pnlListaAsientos.ResumeLayout(false);
            this.pnlListaAsientos.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDashHeader;
        private System.Windows.Forms.Label lblBadgeTotal;
        private System.Windows.Forms.Label lblDashSubtitulo;
        private System.Windows.Forms.Label lblDashTitulo;
        private System.Windows.Forms.Panel pnlDashContent;
        private System.Windows.Forms.Panel pnlListaAsientos;
        private System.Windows.Forms.Label lblListaHeader;
        private System.Windows.Forms.TextBox txtBuscarDash;
        private App_Contable.Presentacion.KardexDashboardListBox lstRegistros;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Label lblAccionesHeader;
        private System.Windows.Forms.Button btnGenerarKardex;
        private System.Windows.Forms.Button btnKardexManual;
        private System.Windows.Forms.Button btnVistaPrevia;
        private System.Windows.Forms.Button btnActualizarLista;
    }
}

