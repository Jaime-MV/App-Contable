namespace App_Contable.Presentacion
{
    partial class frmCalibracionKardex
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
            this.cboMetodoValuacion = new System.Windows.Forms.ComboBox();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvCalibracion = new System.Windows.Forms.DataGridView();
            this.colPartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlResumenPreview = new System.Windows.Forms.Panel();
            this.lblResumenPreview = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalibracion)).BeginInit();
            this.pnlResumenPreview.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.cboMetodoValuacion);
            this.pnlHeader.Controls.Add(this.lblMetodo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.pnlHeader.Size = new System.Drawing.Size(764, 110);
            this.pnlHeader.TabIndex = 0;
            // 
            // cboMetodoValuacion
            // 
            this.cboMetodoValuacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoValuacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMetodoValuacion.FormattingEnabled = true;
            this.cboMetodoValuacion.Location = new System.Drawing.Point(145, 76);
            this.cboMetodoValuacion.Name = "cboMetodoValuacion";
            this.cboMetodoValuacion.Size = new System.Drawing.Size(260, 23);
            this.cboMetodoValuacion.TabIndex = 3;
            // 
            // lblMetodo
            // 
            this.lblMetodo.AutoSize = true;
            this.lblMetodo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblMetodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblMetodo.Location = new System.Drawing.Point(20, 79);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(121, 15);
            this.lblMetodo.TabIndex = 2;
            this.lblMetodo.Text = "Método de Valuación:";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(20, 36);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(720, 34);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "El Libro Diario registra movimientos contables a precios globales o de venta. Confirma o ajusta las cantidades físicas y costos unitarios de las partidas involucradas para generar la tarjeta Kardex.";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitulo.Location = new System.Drawing.Point(18, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(434, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "⚡  Calibración de Unidades Físicas y Costos para Kardex";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.dgvCalibracion);
            this.pnlContent.Controls.Add(this.pnlResumenPreview);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 110);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.pnlContent.Size = new System.Drawing.Size(764, 385);
            this.pnlContent.TabIndex = 1;
            // 
            // dgvCalibracion
            // 
            this.dgvCalibracion.AllowUserToAddRows = false;
            this.dgvCalibracion.AllowUserToDeleteRows = false;
            this.dgvCalibracion.AllowUserToResizeRows = false;
            this.dgvCalibracion.BackgroundColor = System.Drawing.Color.White;
            this.dgvCalibracion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCalibracion.ColumnHeadersHeight = 36;
            this.dgvCalibracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCalibracion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPartida,
            this.colFecha,
            this.colTipo,
            this.colMonto,
            this.colCantidad,
            this.colCosto});
            this.dgvCalibracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalibracion.EnableHeadersVisualStyles = false;
            this.dgvCalibracion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvCalibracion.Location = new System.Drawing.Point(20, 8);
            this.dgvCalibracion.MultiSelect = false;
            this.dgvCalibracion.Name = "dgvCalibracion";
            this.dgvCalibracion.RowHeadersVisible = false;
            this.dgvCalibracion.RowTemplate.Height = 32;
            this.dgvCalibracion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCalibracion.Size = new System.Drawing.Size(724, 329);
            this.dgvCalibracion.TabIndex = 0;
            // 
            // colPartida
            // 
            this.colPartida.HeaderText = "Partida";
            this.colPartida.Name = "colPartida";
            this.colPartida.ReadOnly = true;
            this.colPartida.Width = 90;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 85;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo Movimiento";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 155;
            // 
            // colMonto
            // 
            this.colMonto.HeaderText = "Monto Libro ($)";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            this.colMonto.Width = 115;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Unidades (Cant.)";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 120;
            // 
            // colCosto
            // 
            this.colCosto.HeaderText = "Costo Unit. ($)";
            this.colCosto.Name = "colCosto";
            this.colCosto.Width = 120;
            // 
            // pnlResumenPreview
            // 
            this.pnlResumenPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlResumenPreview.Controls.Add(this.lblResumenPreview);
            this.pnlResumenPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResumenPreview.Location = new System.Drawing.Point(20, 337);
            this.pnlResumenPreview.Name = "pnlResumenPreview";
            this.pnlResumenPreview.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.pnlResumenPreview.Size = new System.Drawing.Size(724, 40);
            this.pnlResumenPreview.TabIndex = 1;
            // 
            // lblResumenPreview
            // 
            this.lblResumenPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumenPreview.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblResumenPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.lblResumenPreview.Location = new System.Drawing.Point(12, 6);
            this.lblResumenPreview.Name = "lblResumenPreview";
            this.lblResumenPreview.Size = new System.Drawing.Size(700, 28);
            this.lblResumenPreview.TabIndex = 0;
            this.lblResumenPreview.Text = "📊 Resumen Físico: Entradas: 0 uds | Salidas: 0 uds | Saldo Final: 0 uds";
            this.lblResumenPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnProcesar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 495);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlBotones.Size = new System.Drawing.Size(764, 55);
            this.pnlBotones.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancelar.Location = new System.Drawing.Point(404, 10);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(96)))), ((int)(((byte)(255)))));
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.Location = new System.Drawing.Point(504, 10);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(240, 35);
            this.btnProcesar.TabIndex = 0;
            this.btnProcesar.Text = "⚡  Procesar y Generar Kardex";
            this.btnProcesar.UseVisualStyleBackColor = false;
            // 
            // frmCalibracionKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 550);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 520);
            this.Name = "frmCalibracionKardex";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calibración de Unidades y Costos para Kardex";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalibracion)).EndInit();
            this.pnlResumenPreview.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.ComboBox cboMetodoValuacion;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvCalibracion;
        private System.Windows.Forms.Panel pnlResumenPreview;
        private System.Windows.Forms.Label lblResumenPreview;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCosto;
    }
}

