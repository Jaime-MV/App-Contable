namespace App_Contable.Presentacion
{
    partial class frmCrearLibroDiarioModal
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
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.pnlFechas = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.gbDestino = new System.Windows.Forms.GroupBox();
            this.lblDestinoPgHelp = new System.Windows.Forms.Label();
            this.rbPostgreSQL = new System.Windows.Forms.RadioButton();
            this.lblDestinoLocalHelp = new System.Windows.Forms.Label();
            this.rbLocal = new System.Windows.Forms.RadioButton();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.pnlFechas.SuspendLayout();
            this.gbDestino.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlHeader.Controls.Add(this.lblTituloModal);
            this.pnlHeader.Controls.Add(this.lblSubtituloModal);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 18, 24, 18);
            this.pnlHeader.Size = new System.Drawing.Size(520, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTituloModal
            // 
            this.lblTituloModal.AutoSize = true;
            this.lblTituloModal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloModal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloModal.Location = new System.Drawing.Point(22, 14);
            this.lblTituloModal.Name = "lblTituloModal";
            this.lblTituloModal.Size = new System.Drawing.Size(225, 25);
            this.lblTituloModal.TabIndex = 0;
            this.lblTituloModal.Text = "Crear Nuevo Libro Diario";
            // 
            // lblSubtituloModal
            // 
            this.lblSubtituloModal.AutoSize = true;
            this.lblSubtituloModal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtituloModal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtituloModal.Location = new System.Drawing.Point(24, 44);
            this.lblSubtituloModal.Name = "lblSubtituloModal";
            this.lblSubtituloModal.Size = new System.Drawing.Size(377, 15);
            this.lblSubtituloModal.TabIndex = 1;
            this.lblSubtituloModal.Text = "Ingresa los parámetros contables para iniciar una nueva instancia del libro.";
            // 
            // pnlCuerpo
            // 
            this.pnlCuerpo.BackColor = System.Drawing.Color.White;
            this.pnlCuerpo.Controls.Add(this.lblNombre);
            this.pnlCuerpo.Controls.Add(this.txtNombre);
            this.pnlCuerpo.Controls.Add(this.lblEmpresa);
            this.pnlCuerpo.Controls.Add(this.txtEmpresa);
            this.pnlCuerpo.Controls.Add(this.lblPeriodo);
            this.pnlCuerpo.Controls.Add(this.pnlFechas);
            this.pnlCuerpo.Controls.Add(this.gbDestino);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Location = new System.Drawing.Point(0, 80);
            this.pnlCuerpo.Name = "pnlCuerpo";
            this.pnlCuerpo.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.pnlCuerpo.Size = new System.Drawing.Size(520, 390);
            this.pnlCuerpo.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNombre.Location = new System.Drawing.Point(24, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(170, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre del Libro Diario * :";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.Location = new System.Drawing.Point(27, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Ej: Libro Diario — Octubre 2026";
            this.txtNombre.Size = new System.Drawing.Size(465, 24);
            this.txtNombre.TabIndex = 1;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblEmpresa.Location = new System.Drawing.Point(24, 72);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(164, 17);
            this.lblEmpresa.TabIndex = 2;
            this.lblEmpresa.Text = "Empresa / Razón Social :";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmpresa.Location = new System.Drawing.Point(27, 94);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.PlaceholderText = "Ej: Comercializadora del Valle S.A. de C.V.";
            this.txtEmpresa.Size = new System.Drawing.Size(465, 24);
            this.txtEmpresa.TabIndex = 3;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblPeriodo.Location = new System.Drawing.Point(24, 132);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(127, 17);
            this.lblPeriodo.TabIndex = 4;
            this.lblPeriodo.Text = "Rango de Período :";
            // 
            // pnlFechas
            // 
            this.pnlFechas.Controls.Add(this.lblDesde);
            this.pnlFechas.Controls.Add(this.dtpDesde);
            this.pnlFechas.Controls.Add(this.lblHasta);
            this.pnlFechas.Controls.Add(this.dtpHasta);
            this.pnlFechas.Location = new System.Drawing.Point(27, 154);
            this.pnlFechas.Name = "pnlFechas";
            this.pnlFechas.Size = new System.Drawing.Size(465, 34);
            this.pnlFechas.TabIndex = 5;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDesde.Location = new System.Drawing.Point(0, 9);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(48, 5);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(160, 23);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblHasta.Location = new System.Drawing.Point(235, 9);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(40, 15);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(281, 5);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(160, 23);
            this.dtpHasta.TabIndex = 3;
            // 
            // gbDestino
            // 
            this.gbDestino.Controls.Add(this.lblDestinoPgHelp);
            this.gbDestino.Controls.Add(this.rbPostgreSQL);
            this.gbDestino.Controls.Add(this.lblDestinoLocalHelp);
            this.gbDestino.Controls.Add(this.rbLocal);
            this.gbDestino.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.gbDestino.Location = new System.Drawing.Point(27, 204);
            this.gbDestino.Name = "gbDestino";
            this.gbDestino.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.gbDestino.Size = new System.Drawing.Size(465, 160);
            this.gbDestino.TabIndex = 6;
            this.gbDestino.TabStop = false;
            this.gbDestino.Text = "Destino de Almacenamiento";
            // 
            // lblDestinoPgHelp
            // 
            this.lblDestinoPgHelp.AutoSize = true;
            this.lblDestinoPgHelp.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDestinoPgHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDestinoPgHelp.Location = new System.Drawing.Point(36, 124);
            this.lblDestinoPgHelp.Name = "lblDestinoPgHelp";
            this.lblDestinoPgHelp.Size = new System.Drawing.Size(380, 13);
            this.lblDestinoPgHelp.TabIndex = 3;
            this.lblDestinoPgHelp.Text = "Se registrará en el servidor PostgreSQL para acceso multiusuario y en red.";
            // 
            // rbPostgreSQL
            // 
            this.rbPostgreSQL.AutoSize = true;
            this.rbPostgreSQL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbPostgreSQL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.rbPostgreSQL.Location = new System.Drawing.Point(16, 100);
            this.rbPostgreSQL.Name = "rbPostgreSQL";
            this.rbPostgreSQL.Size = new System.Drawing.Size(342, 21);
            this.rbPostgreSQL.TabIndex = 2;
            this.rbPostgreSQL.Text = "Guardar en Base de Datos (PostgreSQL - Próximamente)";
            this.rbPostgreSQL.UseVisualStyleBackColor = true;
            // 
            // lblDestinoLocalHelp
            // 
            this.lblDestinoLocalHelp.AutoSize = true;
            this.lblDestinoLocalHelp.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDestinoLocalHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDestinoLocalHelp.Location = new System.Drawing.Point(36, 56);
            this.lblDestinoLocalHelp.Name = "lblDestinoLocalHelp";
            this.lblDestinoLocalHelp.Size = new System.Drawing.Size(386, 13);
            this.lblDestinoLocalHelp.TabIndex = 1;
            this.lblDestinoLocalHelp.Text = "Se almacena en la memoria y archivos locales de la sesión activa de trabajo.";
            // 
            // rbLocal
            // 
            this.rbLocal.AutoSize = true;
            this.rbLocal.Checked = true;
            this.rbLocal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rbLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.rbLocal.Location = new System.Drawing.Point(16, 32);
            this.rbLocal.Name = "rbLocal";
            this.rbLocal.Size = new System.Drawing.Size(250, 21);
            this.rbLocal.TabIndex = 0;
            this.rbLocal.TabStop = true;
            this.rbLocal.Text = "Guardar Localmente (JSON / Memoria)";
            this.rbLocal.UseVisualStyleBackColor = true;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnCrear);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 470);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.pnlBotones.Size = new System.Drawing.Size(520, 64);
            this.pnlBotones.TabIndex = 2;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancelar.Location = new System.Drawing.Point(254, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnCrear
            // 
            this.btnCrear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(362, 14);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(130, 36);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear Libro";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // frmCrearLibroDiarioModal
            // 
            this.AcceptButton = this.btnCrear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(520, 534);
            this.Controls.Add(this.pnlCuerpo);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCrearLibroDiarioModal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear Nuevo Libro Diario";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.pnlFechas.ResumeLayout(false);
            this.pnlFechas.PerformLayout();
            this.gbDestino.ResumeLayout(false);
            this.gbDestino.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTituloModal;
        private System.Windows.Forms.Label lblSubtituloModal;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Panel pnlFechas;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.GroupBox gbDestino;
        private System.Windows.Forms.RadioButton rbLocal;
        private System.Windows.Forms.Label lblDestinoLocalHelp;
        private System.Windows.Forms.RadioButton rbPostgreSQL;
        private System.Windows.Forms.Label lblDestinoPgHelp;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCrear;
    }
}

