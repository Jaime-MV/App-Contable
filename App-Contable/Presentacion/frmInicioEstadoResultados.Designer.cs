namespace App_Contable.Presentacion
{
    partial class frmInicioEstadoResultados
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
            this.lstLibros = new App_Contable.Presentacion.LibroDiarioInstanciaListBox();
            this.txtBuscarDash = new System.Windows.Forms.TextBox();
            this.lblListaHeader = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnActualizarLista = new System.Windows.Forms.Button();
            this.btnVistaPrevia = new System.Windows.Forms.Button();
            this.btnGenerarEstadoResultados = new System.Windows.Forms.Button();
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
            this.lblBadgeTotal.Location = new System.Drawing.Point(280, 24);
            this.lblBadgeTotal.Name = "lblBadgeTotal";
            this.lblBadgeTotal.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblBadgeTotal.Size = new System.Drawing.Size(83, 19);
            this.lblBadgeTotal.TabIndex = 2;
            this.lblBadgeTotal.Text = "  0 Libro(s)  ";
            // 
            // lblDashSubtitulo
            // 
            this.lblDashSubtitulo.AutoSize = true;
            this.lblDashSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDashSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDashSubtitulo.Location = new System.Drawing.Point(34, 54);
            this.lblDashSubtitulo.Name = "lblDashSubtitulo";
            this.lblDashSubtitulo.Size = new System.Drawing.Size(490, 17);
            this.lblDashSubtitulo.TabIndex = 1;
            this.lblDashSubtitulo.Text = "Selecciona un libro diario registrado para generar automáticamente su estado de resultados.";
            // 
            // lblDashTitulo
            // 
            this.lblDashTitulo.AutoSize = true;
            this.lblDashTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDashTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDashTitulo.Location = new System.Drawing.Point(32, 18);
            this.lblDashTitulo.Name = "lblDashTitulo";
            this.lblDashTitulo.Size = new System.Drawing.Size(242, 32);
            this.lblDashTitulo.TabIndex = 0;
            this.lblDashTitulo.Text = "Gestión de Estado de Resultados";
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
            this.pnlListaAsientos.Controls.Add(this.lstLibros);
            this.pnlListaAsientos.Controls.Add(this.txtBuscarDash);
            this.pnlListaAsientos.Controls.Add(this.lblListaHeader);
            this.pnlListaAsientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaAsientos.Location = new System.Drawing.Point(24, 20);
            this.pnlListaAsientos.Name = "pnlListaAsientos";
            this.pnlListaAsientos.Padding = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlListaAsientos.Size = new System.Drawing.Size(772, 510);
            this.pnlListaAsientos.TabIndex = 0;
            // 
            // lstLibros
            // 
            this.lstLibros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLibros.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstLibros.ItemHeight = 74;
            this.lstLibros.Location = new System.Drawing.Point(0, 71);
            this.lstLibros.Name = "lstLibros";
            this.lstLibros.Size = new System.Drawing.Size(756, 439);
            this.lstLibros.TabIndex = 2;
            // 
            // txtBuscarDash
            // 
            this.txtBuscarDash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarDash.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarDash.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarDash.Location = new System.Drawing.Point(0, 36);
            this.txtBuscarDash.Margin = new System.Windows.Forms.Padding(16, 0, 16, 8);
            this.txtBuscarDash.Name = "txtBuscarDash";
            this.txtBuscarDash.PlaceholderText = "🔍  Buscar libros diarios (Alt+S)...";
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
            this.lblListaHeader.Size = new System.Drawing.Size(183, 36);
            this.lblListaHeader.TabIndex = 0;
            this.lblListaHeader.Text = "Libros Diarios Disponibles";
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Controls.Add(this.btnActualizarLista);
            this.pnlAcciones.Controls.Add(this.btnVistaPrevia);
            this.pnlAcciones.Controls.Add(this.btnGenerarEstadoResultados);
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
            this.btnActualizarLista.Location = new System.Drawing.Point(16, 155);
            this.btnActualizarLista.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnActualizarLista.Size = new System.Drawing.Size(248, 60);
            this.btnActualizarLista.TabIndex = 3;
            this.btnActualizarLista.Text = "↺  Actualizar Lista\r\nRecarga los libros disponibles.";
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
            this.btnVistaPrevia.Location = new System.Drawing.Point(16, 95);
            this.btnVistaPrevia.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVistaPrevia.Size = new System.Drawing.Size(248, 60);
            this.btnVistaPrevia.TabIndex = 2;
            this.btnVistaPrevia.Text = "👁️  Vista Rápida\r\nConsulta resumen antes de procesar.";
            this.btnVistaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVistaPrevia.UseVisualStyleBackColor = false;
            // 
            // btnGenerarEstadoResultados
            // 
            this.btnGenerarEstadoResultados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(96)))), ((int)(((byte)(255)))));
            this.btnGenerarEstadoResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarEstadoResultados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenerarEstadoResultados.FlatAppearance.BorderSize = 0;
            this.btnGenerarEstadoResultados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarEstadoResultados.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGenerarEstadoResultados.ForeColor = System.Drawing.Color.White;
            this.btnGenerarEstadoResultados.Location = new System.Drawing.Point(16, 35);
            this.btnGenerarEstadoResultados.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnGenerarEstadoResultados.Name = "btnGenerarEstadoResultados";
            this.btnGenerarEstadoResultados.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGenerarEstadoResultados.Size = new System.Drawing.Size(248, 60);
            this.btnGenerarEstadoResultados.TabIndex = 1;
            this.btnGenerarEstadoResultados.Text = "⚡  Generar Estado de Resultados\r\nCalcula ingresos, costos y gastos.";
            this.btnGenerarEstadoResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarEstadoResultados.UseVisualStyleBackColor = false;
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
            // frmInicioEstadoResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlDashContent);
            this.Controls.Add(this.pnlDashHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInicioEstadoResultados";
            this.Text = "Estado de Resultados";
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
        private App_Contable.Presentacion.LibroDiarioInstanciaListBox lstLibros;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Label lblAccionesHeader;
        private System.Windows.Forms.Button btnGenerarEstadoResultados;
        private System.Windows.Forms.Button btnVistaPrevia;
        private System.Windows.Forms.Button btnActualizarLista;
    }
}


