namespace App_Contable.Presentacion
{
    partial class frmAgregarMovimientoKardex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTituloModal = new System.Windows.Forms.Label();
            this.lblSubtituloModal = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCosto = new System.Windows.Forms.Label();
            this.numCostoUnitario = new System.Windows.Forms.NumericUpDown();
            this.pnlResumenCalculado = new System.Windows.Forms.Panel();
            this.lblTituloResumen = new System.Windows.Forms.Label();
            this.lblImporteCalculado = new System.Windows.Forms.Label();
            this.lblNuevoStockEstimado = new System.Windows.Forms.Label();
            this.lblNuevoCostoPromedio = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoUnitario)).BeginInit();
            this.pnlResumenCalculado.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.pnlHeader.Controls.Add(this.lblTituloModal);
            this.pnlHeader.Controls.Add(this.lblSubtituloModal);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(560, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTituloModal
            // 
            this.lblTituloModal.AutoSize = true;
            this.lblTituloModal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloModal.ForeColor = System.Drawing.Color.White;
            this.lblTituloModal.Location = new System.Drawing.Point(24, 15);
            this.lblTituloModal.Name = "lblTituloModal";
            this.lblTituloModal.Size = new System.Drawing.Size(294, 21);
            this.lblTituloModal.TabIndex = 0;
            this.lblTituloModal.Text = "↓ Registrar Movimiento de Kardex";
            // 
            // lblSubtituloModal
            // 
            this.lblSubtituloModal.AutoSize = true;
            this.lblSubtituloModal.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtituloModal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblSubtituloModal.Location = new System.Drawing.Point(26, 42);
            this.lblSubtituloModal.Name = "lblSubtituloModal";
            this.lblSubtituloModal.Size = new System.Drawing.Size(430, 15);
            this.lblSubtituloModal.TabIndex = 1;
            this.lblSubtituloModal.Text = "Captura manual con recálculo automático de Costo Promedio Ponderado";
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.lblFecha);
            this.pnlContenido.Controls.Add(this.dtpFecha);
            this.pnlContenido.Controls.Add(this.lblTipo);
            this.pnlContenido.Controls.Add(this.cmbTipoMovimiento);
            this.pnlContenido.Controls.Add(this.lblConcepto);
            this.pnlContenido.Controls.Add(this.txtConcepto);
            this.pnlContenido.Controls.Add(this.lblDocumento);
            this.pnlContenido.Controls.Add(this.txtDocumento);
            this.pnlContenido.Controls.Add(this.lblCantidad);
            this.pnlContenido.Controls.Add(this.numCantidad);
            this.pnlContenido.Controls.Add(this.lblCosto);
            this.pnlContenido.Controls.Add(this.numCostoUnitario);
            this.pnlContenido.Controls.Add(this.pnlResumenCalculado);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 75);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Padding = new System.Windows.Forms.Padding(24);
            this.pnlContenido.Size = new System.Drawing.Size(560, 445);
            this.pnlContenido.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFecha.Location = new System.Drawing.Point(24, 18);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(126, 15);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha de Operación:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(27, 38);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(235, 24);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTipo.Location = new System.Drawing.Point(280, 18);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(124, 15);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo de Movimiento:";
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTipoMovimiento.FormattingEnabled = true;
            this.cmbTipoMovimiento.Items.AddRange(new object[] {
            "Entrada (Compra / Saldo Inicial)",
            "Salida (Venta / Ajuste negativo)"});
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(283, 38);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(248, 24);
            this.cmbTipoMovimiento.TabIndex = 3;
            this.cmbTipoMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMovimiento_SelectedIndexChanged);
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConcepto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblConcepto.Location = new System.Drawing.Point(24, 76);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(175, 15);
            this.lblConcepto.TabIndex = 4;
            this.lblConcepto.Text = "Concepto / Detalle Operativo:";
            // 
            // txtConcepto
            // 
            this.txtConcepto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtConcepto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConcepto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConcepto.Location = new System.Drawing.Point(27, 96);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(504, 24);
            this.txtConcepto.TabIndex = 5;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblDocumento.Location = new System.Drawing.Point(24, 134);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(127, 15);
            this.lblDocumento.TabIndex = 6;
            this.lblDocumento.Text = "Ref / Nº Documento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDocumento.Location = new System.Drawing.Point(27, 154);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.PlaceholderText = "ej. F-520, OV-8102, NC-01";
            this.txtDocumento.Size = new System.Drawing.Size(504, 24);
            this.txtDocumento.TabIndex = 7;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblCantidad.Location = new System.Drawing.Point(24, 192);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(134, 15);
            this.lblCantidad.TabIndex = 8;
            this.lblCantidad.Text = "Cantidad de Unidades:";
            // 
            // numCantidad
            // 
            this.numCantidad.DecimalPlaces = 2;
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numCantidad.Location = new System.Drawing.Point(27, 212);
            this.numCantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(235, 25);
            this.numCantidad.TabIndex = 9;
            this.numCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCantidad.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numCantidad.ValueChanged += new System.EventHandler(this.numCantidad_ValueChanged);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCosto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblCosto.Location = new System.Drawing.Point(280, 192);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(155, 15);
            this.lblCosto.TabIndex = 10;
            this.lblCosto.Text = "Costo Unitario ($0.0000):";
            // 
            // numCostoUnitario
            // 
            this.numCostoUnitario.DecimalPlaces = 4;
            this.numCostoUnitario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numCostoUnitario.Location = new System.Drawing.Point(283, 212);
            this.numCostoUnitario.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCostoUnitario.Name = "numCostoUnitario";
            this.numCostoUnitario.Size = new System.Drawing.Size(248, 25);
            this.numCostoUnitario.TabIndex = 11;
            this.numCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCostoUnitario.Value = new decimal(new int[] {
            84500,
            0,
            0,
            262144});
            this.numCostoUnitario.ValueChanged += new System.EventHandler(this.numCostoUnitario_ValueChanged);
            // 
            // pnlResumenCalculado
            // 
            this.pnlResumenCalculado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlResumenCalculado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResumenCalculado.Controls.Add(this.lblTituloResumen);
            this.pnlResumenCalculado.Controls.Add(this.lblImporteCalculado);
            this.pnlResumenCalculado.Controls.Add(this.lblNuevoStockEstimado);
            this.pnlResumenCalculado.Controls.Add(this.lblNuevoCostoPromedio);
            this.pnlResumenCalculado.Location = new System.Drawing.Point(27, 260);
            this.pnlResumenCalculado.Name = "pnlResumenCalculado";
            this.pnlResumenCalculado.Padding = new System.Windows.Forms.Padding(12);
            this.pnlResumenCalculado.Size = new System.Drawing.Size(504, 160);
            this.pnlResumenCalculado.TabIndex = 12;
            // 
            // lblTituloResumen
            // 
            this.lblTituloResumen.AutoSize = true;
            this.lblTituloResumen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblTituloResumen.Location = new System.Drawing.Point(12, 10);
            this.lblTituloResumen.Name = "lblTituloResumen";
            this.lblTituloResumen.Size = new System.Drawing.Size(277, 15);
            this.lblTituloResumen.TabIndex = 0;
            this.lblTituloResumen.Text = "📊 Proyección Contable y Físico-Valorizada:";
            // 
            // lblImporteCalculado
            // 
            this.lblImporteCalculado.AutoSize = true;
            this.lblImporteCalculado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImporteCalculado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblImporteCalculado.Location = new System.Drawing.Point(14, 40);
            this.lblImporteCalculado.Name = "lblImporteCalculado";
            this.lblImporteCalculado.Size = new System.Drawing.Size(268, 17);
            this.lblImporteCalculado.TabIndex = 1;
            this.lblImporteCalculado.Text = "• Importe Total del Movimiento: $0.00";
            // 
            // lblNuevoStockEstimado
            // 
            this.lblNuevoStockEstimado.AutoSize = true;
            this.lblNuevoStockEstimado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNuevoStockEstimado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNuevoStockEstimado.Location = new System.Drawing.Point(14, 75);
            this.lblNuevoStockEstimado.Name = "lblNuevoStockEstimado";
            this.lblNuevoStockEstimado.Size = new System.Drawing.Size(276, 17);
            this.lblNuevoStockEstimado.TabIndex = 2;
            this.lblNuevoStockEstimado.Text = "• Stock Final Proyectado: 0.00 unidades";
            // 
            // lblNuevoCostoPromedio
            // 
            this.lblNuevoCostoPromedio.AutoSize = true;
            this.lblNuevoCostoPromedio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNuevoCostoPromedio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNuevoCostoPromedio.Location = new System.Drawing.Point(14, 110);
            this.lblNuevoCostoPromedio.Name = "lblNuevoCostoPromedio";
            this.lblNuevoCostoPromedio.Size = new System.Drawing.Size(326, 17);
            this.lblNuevoCostoPromedio.TabIndex = 3;
            this.lblNuevoCostoPromedio.Text = "• Nuevo Costo Promedio Ponderado: $0.0000 / u";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnCancelar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 520);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(560, 65);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(347, 14);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(184, 38);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "💾 Guardar Movimiento";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCancelar.Location = new System.Drawing.Point(227, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 38);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAgregarMovimientoKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 585);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarMovimientoKardex";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Movimiento - Tarjeta Kardex";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCostoUnitario)).EndInit();
            this.pnlResumenCalculado.ResumeLayout(false);
            this.pnlResumenCalculado.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloModal;
        private System.Windows.Forms.Label lblSubtituloModal;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.NumericUpDown numCostoUnitario;
        private System.Windows.Forms.Panel pnlResumenCalculado;
        private System.Windows.Forms.Label lblTituloResumen;
        private System.Windows.Forms.Label lblImporteCalculado;
        private System.Windows.Forms.Label lblNuevoStockEstimado;
        private System.Windows.Forms.Label lblNuevoCostoPromedio;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

