namespace App_Contable.Presentacion
{
    partial class FrmMenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlNavMenu = new System.Windows.Forms.Panel();
            this.btnCatalogoCuentas = new System.Windows.Forms.Button();
            this.btnBalanzaComprobacion = new System.Windows.Forms.Button();
            this.btnKardex = new System.Windows.Forms.Button();
            this.btnEstadoResultados = new System.Windows.Forms.Button();
            this.btnBalanceGeneral = new System.Windows.Forms.Button();
            this.btnLibroMayor = new System.Windows.Forms.Button();
            this.btnLibroDiario = new System.Windows.Forms.Button();
            this.pnlSidebarFooter = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnToggleSidebar = new System.Windows.Forms.Button();
            this.pnlLogoDivider = new System.Windows.Forms.Panel();
            this.lblSubtituloApp = new System.Windows.Forms.Label();
            this.lblTituloApp = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlStatusContainer = new System.Windows.Forms.Panel();
            this.lblEstadoConexion = new System.Windows.Forms.Label();
            this.pnlStatusIndicator = new System.Windows.Forms.Panel();
            this.btnProbarConexion = new System.Windows.Forms.Button();
            this.pnlTopBarDivider = new System.Windows.Forms.Panel();
            this.lblTituloSeccion = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlBienvenida = new System.Windows.Forms.Panel();
            this.lblBienvenidaSub = new System.Windows.Forms.Label();
            this.lblBienvenidaTitulo = new System.Windows.Forms.Label();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.pnlNavMenu.SuspendLayout();
            this.pnlSidebarFooter.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlStatusContainer.SuspendLayout();
            this.pnlContenedor.SuspendLayout();
            this.pnlBienvenida.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.pnlSidebar.Controls.Add(this.pnlNavMenu);
            this.pnlSidebar.Controls.Add(this.pnlSidebarFooter);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 700);
            this.pnlSidebar.TabIndex = 0;
            this.pnlSidebar.MouseEnter += new System.EventHandler(this.pnlSidebar_MouseEnter);
            this.pnlSidebar.MouseLeave += new System.EventHandler(this.pnlSidebar_MouseLeave);
            // 
            // pnlNavMenu
            // 
            this.pnlNavMenu.AutoScroll = true;
            this.pnlNavMenu.Controls.Add(this.btnCatalogoCuentas);
            this.pnlNavMenu.Controls.Add(this.btnBalanzaComprobacion);
            this.pnlNavMenu.Controls.Add(this.btnKardex);
            this.pnlNavMenu.Controls.Add(this.btnEstadoResultados);
            this.pnlNavMenu.Controls.Add(this.btnBalanceGeneral);
            this.pnlNavMenu.Controls.Add(this.btnLibroMayor);
            this.pnlNavMenu.Controls.Add(this.btnLibroDiario);
            this.pnlNavMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavMenu.Location = new System.Drawing.Point(0, 85);
            this.pnlNavMenu.Name = "pnlNavMenu";
            this.pnlNavMenu.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlNavMenu.Size = new System.Drawing.Size(250, 565);
            this.pnlNavMenu.TabIndex = 1;
            this.pnlNavMenu.MouseEnter += new System.EventHandler(this.pnlSidebar_MouseEnter);
            this.pnlNavMenu.MouseLeave += new System.EventHandler(this.pnlSidebar_MouseLeave);
            // 
            // btnCatalogoCuentas
            // 
            this.btnCatalogoCuentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatalogoCuentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCatalogoCuentas.FlatAppearance.BorderSize = 0;
            this.btnCatalogoCuentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.btnCatalogoCuentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.btnCatalogoCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogoCuentas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCatalogoCuentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnCatalogoCuentas.Location = new System.Drawing.Point(0, 298);
            this.btnCatalogoCuentas.Name = "btnCatalogoCuentas";
            this.btnCatalogoCuentas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnCatalogoCuentas.Size = new System.Drawing.Size(250, 48);
            this.btnCatalogoCuentas.TabIndex = 6;
            this.btnCatalogoCuentas.Text = "  📁  Catálogo de Cuentas";
            this.btnCatalogoCuentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatalogoCuentas.UseVisualStyleBackColor = true;
            this.btnCatalogoCuentas.Click += new System.EventHandler(this.btnCatalogoCuentas_Click);
            // 
            // btnBalanzaComprobacion
            // 
            this.btnBalanzaComprobacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBalanzaComprobacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBalanzaComprobacion.FlatAppearance.BorderSize = 0;
            this.btnBalanzaComprobacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.btnBalanzaComprobacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.btnBalanzaComprobacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanzaComprobacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBalanzaComprobacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnBalanzaComprobacion.Location = new System.Drawing.Point(0, 250);
            this.btnBalanzaComprobacion.Name = "btnBalanzaComprobacion";
            this.btnBalanzaComprobacion.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnBalanzaComprobacion.Size = new System.Drawing.Size(250, 48);
            this.btnBalanzaComprobacion.TabIndex = 5;
            this.btnBalanzaComprobacion.Text = "  ⚖️  Balanza de Comprobación";
            this.btnBalanzaComprobacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanzaComprobacion.UseVisualStyleBackColor = true;
            this.btnBalanzaComprobacion.Click += new System.EventHandler(this.btnBalanzaComprobacion_Click);
            // 
            // btnKardex
            // 
            this.btnKardex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKardex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKardex.FlatAppearance.BorderSize = 0;
            this.btnKardex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.btnKardex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.btnKardex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKardex.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKardex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnKardex.Location = new System.Drawing.Point(0, 202);
            this.btnKardex.Name = "btnKardex";
            this.btnKardex.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnKardex.Size = new System.Drawing.Size(250, 48);
            this.btnKardex.TabIndex = 4;
            this.btnKardex.Text = "  📦  Tarjeta Kardex";
            this.btnKardex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKardex.UseVisualStyleBackColor = true;
            this.btnKardex.Click += new System.EventHandler(this.btnKardex_Click);
            // 
            // btnEstadoResultados
            // 
            this.btnEstadoResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoResultados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstadoResultados.FlatAppearance.BorderSize = 0;
            this.btnEstadoResultados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.btnEstadoResultados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.btnEstadoResultados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoResultados.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEstadoResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnEstadoResultados.Location = new System.Drawing.Point(0, 154);
            this.btnEstadoResultados.Name = "btnEstadoResultados";
            this.btnEstadoResultados.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnEstadoResultados.Size = new System.Drawing.Size(250, 48);
            this.btnEstadoResultados.TabIndex = 3;
            this.btnEstadoResultados.Text = "  📈  Estado de Resultados";
            this.btnEstadoResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadoResultados.UseVisualStyleBackColor = true;
            this.btnEstadoResultados.Click += new System.EventHandler(this.btnEstadoResultados_Click);
            // 
            // btnBalanceGeneral
            // 
            this.btnBalanceGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBalanceGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBalanceGeneral.FlatAppearance.BorderSize = 0;
            this.btnBalanceGeneral.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.btnBalanceGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.btnBalanceGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceGeneral.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBalanceGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnBalanceGeneral.Location = new System.Drawing.Point(0, 106);
            this.btnBalanceGeneral.Name = "btnBalanceGeneral";
            this.btnBalanceGeneral.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnBalanceGeneral.Size = new System.Drawing.Size(250, 48);
            this.btnBalanceGeneral.TabIndex = 2;
            this.btnBalanceGeneral.Text = "  🏛️  Balance General";
            this.btnBalanceGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalanceGeneral.UseVisualStyleBackColor = true;
            this.btnBalanceGeneral.Click += new System.EventHandler(this.btnBalanceGeneral_Click);
            // 
            // btnLibroMayor
            // 
            this.btnLibroMayor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibroMayor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLibroMayor.FlatAppearance.BorderSize = 0;
            this.btnLibroMayor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.btnLibroMayor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.btnLibroMayor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibroMayor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLibroMayor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnLibroMayor.Location = new System.Drawing.Point(0, 58);
            this.btnLibroMayor.Name = "btnLibroMayor";
            this.btnLibroMayor.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnLibroMayor.Size = new System.Drawing.Size(250, 48);
            this.btnLibroMayor.TabIndex = 1;
            this.btnLibroMayor.Text = "  📖  Libro Mayor";
            this.btnLibroMayor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLibroMayor.UseVisualStyleBackColor = true;
            this.btnLibroMayor.Click += new System.EventHandler(this.btnLibroMayor_Click);
            // 
            // btnLibroDiario
            // 
            this.btnLibroDiario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibroDiario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLibroDiario.FlatAppearance.BorderSize = 0;
            this.btnLibroDiario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(63)))), ((int)(((byte)(99)))));
            this.btnLibroDiario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.btnLibroDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibroDiario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLibroDiario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnLibroDiario.Location = new System.Drawing.Point(0, 10);
            this.btnLibroDiario.Name = "btnLibroDiario";
            this.btnLibroDiario.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnLibroDiario.Size = new System.Drawing.Size(250, 48);
            this.btnLibroDiario.TabIndex = 0;
            this.btnLibroDiario.Text = "  📝  Libro Diario";
            this.btnLibroDiario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLibroDiario.UseVisualStyleBackColor = true;
            this.btnLibroDiario.Click += new System.EventHandler(this.btnLibroDiario_Click);
            // 
            // pnlSidebarFooter
            // 
            this.pnlSidebarFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.pnlSidebarFooter.Controls.Add(this.lblVersion);
            this.pnlSidebarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSidebarFooter.Location = new System.Drawing.Point(0, 650);
            this.pnlSidebarFooter.Name = "pnlSidebarFooter";
            this.pnlSidebarFooter.Size = new System.Drawing.Size(250, 50);
            this.pnlSidebarFooter.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblVersion.Location = new System.Drawing.Point(0, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(250, 50);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = ".NET 8  •  PostgreSQL";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.pnlLogo.Controls.Add(this.btnToggleSidebar);
            this.pnlLogo.Controls.Add(this.pnlLogoDivider);
            this.pnlLogo.Controls.Add(this.lblSubtituloApp);
            this.pnlLogo.Controls.Add(this.lblTituloApp);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(250, 85);
            this.pnlLogo.TabIndex = 0;
            // 
            // btnToggleSidebar
            // 
            this.btnToggleSidebar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleSidebar.FlatAppearance.BorderSize = 0;
            this.btnToggleSidebar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.btnToggleSidebar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnToggleSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleSidebar.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnToggleSidebar.ForeColor = System.Drawing.Color.White;
            this.btnToggleSidebar.Location = new System.Drawing.Point(10, 22);
            this.btnToggleSidebar.Name = "btnToggleSidebar";
            this.btnToggleSidebar.Size = new System.Drawing.Size(38, 38);
            this.btnToggleSidebar.TabIndex = 0;
            this.btnToggleSidebar.Text = "☰";
            this.btnToggleSidebar.UseVisualStyleBackColor = true;
            this.btnToggleSidebar.Click += new System.EventHandler(this.btnToggleSidebar_Click);
            // 
            // pnlLogoDivider
            // 
            this.pnlLogoDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.pnlLogoDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLogoDivider.Location = new System.Drawing.Point(0, 84);
            this.pnlLogoDivider.Name = "pnlLogoDivider";
            this.pnlLogoDivider.Size = new System.Drawing.Size(250, 1);
            this.pnlLogoDivider.TabIndex = 2;
            // 
            // lblSubtituloApp
            // 
            this.lblSubtituloApp.AutoSize = true;
            this.lblSubtituloApp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtituloApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.lblSubtituloApp.Location = new System.Drawing.Point(54, 48);
            this.lblSubtituloApp.Name = "lblSubtituloApp";
            this.lblSubtituloApp.Size = new System.Drawing.Size(125, 13);
            this.lblSubtituloApp.TabIndex = 2;
            this.lblSubtituloApp.Text = "Gestión Financiera v1.0";
            // 
            // lblTituloApp
            // 
            this.lblTituloApp.AutoSize = true;
            this.lblTituloApp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloApp.ForeColor = System.Drawing.Color.White;
            this.lblTituloApp.Location = new System.Drawing.Point(54, 25);
            this.lblTituloApp.Name = "lblTituloApp";
            this.lblTituloApp.Size = new System.Drawing.Size(152, 20);
            this.lblTituloApp.TabIndex = 1;
            this.lblTituloApp.Text = "SISTEMA CONTABLE";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.pnlStatusContainer);
            this.pnlTopBar.Controls.Add(this.pnlTopBarDivider);
            this.pnlTopBar.Controls.Add(this.lblTituloSeccion);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(250, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(950, 70);
            this.pnlTopBar.TabIndex = 1;
            // 
            // pnlStatusContainer
            // 
            this.pnlStatusContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatusContainer.Controls.Add(this.lblEstadoConexion);
            this.pnlStatusContainer.Controls.Add(this.pnlStatusIndicator);
            this.pnlStatusContainer.Controls.Add(this.btnProbarConexion);
            this.pnlStatusContainer.Location = new System.Drawing.Point(490, 12);
            this.pnlStatusContainer.Name = "pnlStatusContainer";
            this.pnlStatusContainer.Size = new System.Drawing.Size(445, 45);
            this.pnlStatusContainer.TabIndex = 3;
            // 
            // lblEstadoConexion
            // 
            this.lblEstadoConexion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEstadoConexion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblEstadoConexion.Location = new System.Drawing.Point(10, 12);
            this.lblEstadoConexion.Name = "lblEstadoConexion";
            this.lblEstadoConexion.Size = new System.Drawing.Size(260, 20);
            this.lblEstadoConexion.TabIndex = 0;
            this.lblEstadoConexion.Text = "Estado BD: Pendiente de prueba";
            this.lblEstadoConexion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlStatusIndicator
            // 
            this.pnlStatusIndicator.BackColor = System.Drawing.Color.Gray;
            this.pnlStatusIndicator.Location = new System.Drawing.Point(276, 15);
            this.pnlStatusIndicator.Name = "pnlStatusIndicator";
            this.pnlStatusIndicator.Size = new System.Drawing.Size(14, 14);
            this.pnlStatusIndicator.TabIndex = 1;
            this.pnlStatusIndicator.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStatusIndicator_Paint);
            // 
            // btnProbarConexion
            // 
            this.btnProbarConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnProbarConexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProbarConexion.FlatAppearance.BorderSize = 0;
            this.btnProbarConexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProbarConexion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProbarConexion.ForeColor = System.Drawing.Color.White;
            this.btnProbarConexion.Location = new System.Drawing.Point(302, 5);
            this.btnProbarConexion.Name = "btnProbarConexion";
            this.btnProbarConexion.Size = new System.Drawing.Size(135, 34);
            this.btnProbarConexion.TabIndex = 2;
            this.btnProbarConexion.Text = "Probar Conexión";
            this.btnProbarConexion.UseVisualStyleBackColor = false;
            this.btnProbarConexion.Click += new System.EventHandler(this.btnProbarConexion_Click);
            // 
            // pnlTopBarDivider
            // 
            this.pnlTopBarDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlTopBarDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopBarDivider.Location = new System.Drawing.Point(0, 69);
            this.pnlTopBarDivider.Name = "pnlTopBarDivider";
            this.pnlTopBarDivider.Size = new System.Drawing.Size(950, 1);
            this.pnlTopBarDivider.TabIndex = 2;
            // 
            // lblTituloSeccion
            // 
            this.lblTituloSeccion.AutoSize = true;
            this.lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTituloSeccion.Location = new System.Drawing.Point(24, 22);
            this.lblTituloSeccion.Name = "lblTituloSeccion";
            this.lblTituloSeccion.Size = new System.Drawing.Size(148, 25);
            this.lblTituloSeccion.TabIndex = 0;
            this.lblTituloSeccion.Text = "Panel Principal";
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlContenedor.Controls.Add(this.pnlBienvenida);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(250, 70);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContenedor.Size = new System.Drawing.Size(950, 630);
            this.pnlContenedor.TabIndex = 2;
            // 
            // pnlBienvenida
            // 
            this.pnlBienvenida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBienvenida.BackColor = System.Drawing.Color.White;
            this.pnlBienvenida.Controls.Add(this.lblBienvenidaSub);
            this.pnlBienvenida.Controls.Add(this.lblBienvenidaTitulo);
            this.pnlBienvenida.Location = new System.Drawing.Point(225, 200);
            this.pnlBienvenida.Name = "pnlBienvenida";
            this.pnlBienvenida.Size = new System.Drawing.Size(500, 180);
            this.pnlBienvenida.TabIndex = 0;
            // 
            // lblBienvenidaSub
            // 
            this.lblBienvenidaSub.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBienvenidaSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBienvenidaSub.Location = new System.Drawing.Point(30, 80);
            this.lblBienvenidaSub.Name = "lblBienvenidaSub";
            this.lblBienvenidaSub.Size = new System.Drawing.Size(440, 60);
            this.lblBienvenidaSub.TabIndex = 1;
            this.lblBienvenidaSub.Text = "Selecciona una opción del menú lateral izquierdo para comenzar a gestionar los registros contables y estados financieros.";
            this.lblBienvenidaSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBienvenidaTitulo
            // 
            this.lblBienvenidaTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBienvenidaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblBienvenidaTitulo.Location = new System.Drawing.Point(30, 30);
            this.lblBienvenidaTitulo.Name = "lblBienvenidaTitulo";
            this.lblBienvenidaTitulo.Size = new System.Drawing.Size(440, 35);
            this.lblBienvenidaTitulo.TabIndex = 0;
            this.lblBienvenidaTitulo.Text = "Bienvenido al Sistema Contable";
            this.lblBienvenidaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Contable - Gestión Financiera";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlNavMenu.ResumeLayout(false);
            this.pnlSidebarFooter.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlStatusContainer.ResumeLayout(false);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlBienvenida.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Button btnToggleSidebar;
        private System.Windows.Forms.Label lblTituloApp;
        private System.Windows.Forms.Label lblSubtituloApp;
        private System.Windows.Forms.Panel pnlLogoDivider;
        private System.Windows.Forms.Panel pnlNavMenu;
        private System.Windows.Forms.Button btnLibroDiario;
        private System.Windows.Forms.Button btnLibroMayor;
        private System.Windows.Forms.Button btnBalanceGeneral;
        private System.Windows.Forms.Button btnEstadoResultados;
        private System.Windows.Forms.Button btnKardex;
        private System.Windows.Forms.Button btnBalanzaComprobacion;
        private System.Windows.Forms.Button btnCatalogoCuentas;
        private System.Windows.Forms.Panel pnlSidebarFooter;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Panel pnlTopBarDivider;
        private System.Windows.Forms.Panel pnlStatusContainer;
        private System.Windows.Forms.Label lblEstadoConexion;
        private System.Windows.Forms.Panel pnlStatusIndicator;
        private System.Windows.Forms.Button btnProbarConexion;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlBienvenida;
        private System.Windows.Forms.Label lblBienvenidaTitulo;
        private System.Windows.Forms.Label lblBienvenidaSub;
        private System.Windows.Forms.Timer sidebarTimer;
    }
}

