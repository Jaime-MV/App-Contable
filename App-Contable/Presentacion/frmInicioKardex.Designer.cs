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
            this.pnlEncabezadoSuperior = new System.Windows.Forms.Panel();
            this.lblSubtituloPrincipal = new System.Windows.Forms.Label();
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();
            this.pnlColumnaIzquierda = new System.Windows.Forms.Panel();
            this.pnlListaContenedor = new System.Windows.Forms.Panel();
            this.pnlEmptyState = new System.Windows.Forms.Panel();
            this.lblEmptyStateSub = new System.Windows.Forms.Label();
            this.lblEmptyStateTitulo = new System.Windows.Forms.Label();
            this.lblEmptyStateIcono = new System.Windows.Forms.Label();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblIconoBuscar = new System.Windows.Forms.Label();
            this.lblTituloHistorial = new System.Windows.Forms.Label();
            this.splitterColumnas = new System.Windows.Forms.Splitter();
            this.pnlColumnaDerecha = new System.Windows.Forms.Panel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.pnlAccionSincronizarBd = new System.Windows.Forms.Panel();
            this.lblDescSincronizarBd = new System.Windows.Forms.Label();
            this.lblTituloSincronizarBd = new System.Windows.Forms.Label();
            this.lblIconoSincronizarBd = new System.Windows.Forms.Label();
            this.pnlAccionImportarLocal = new System.Windows.Forms.Panel();
            this.lblDescImportarLocal = new System.Windows.Forms.Label();
            this.lblTituloImportarLocal = new System.Windows.Forms.Label();
            this.lblIconoImportarLocal = new System.Windows.Forms.Label();
            this.pnlAccionNuevaTarjeta = new System.Windows.Forms.Panel();
            this.lblDescNuevaTarjeta = new System.Windows.Forms.Label();
            this.lblTituloNuevaTarjeta = new System.Windows.Forms.Label();
            this.lblIconoNuevaTarjeta = new System.Windows.Forms.Label();
            this.lblTituloAcciones = new System.Windows.Forms.Label();
            this.pnlEncabezadoSuperior.SuspendLayout();
            this.pnlContenedorPrincipal.SuspendLayout();
            this.pnlColumnaIzquierda.SuspendLayout();
            this.pnlListaContenedor.SuspendLayout();
            this.pnlEmptyState.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlColumnaDerecha.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlAccionSincronizarBd.SuspendLayout();
            this.pnlAccionImportarLocal.SuspendLayout();
            this.pnlAccionNuevaTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezadoSuperior
            // 
            this.pnlEncabezadoSuperior.BackColor = System.Drawing.Color.White;
            this.pnlEncabezadoSuperior.Controls.Add(this.lblSubtituloPrincipal);
            this.pnlEncabezadoSuperior.Controls.Add(this.lblTituloPrincipal);
            this.pnlEncabezadoSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezadoSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezadoSuperior.Name = "pnlEncabezadoSuperior";
            this.pnlEncabezadoSuperior.Padding = new System.Windows.Forms.Padding(36, 28, 36, 20);
            this.pnlEncabezadoSuperior.Size = new System.Drawing.Size(1100, 100);
            this.pnlEncabezadoSuperior.TabIndex = 0;
            // 
            // lblSubtituloPrincipal
            // 
            this.lblSubtituloPrincipal.AutoSize = true;
            this.lblSubtituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtituloPrincipal.Location = new System.Drawing.Point(36, 62);
            this.lblSubtituloPrincipal.Name = "lblSubtituloPrincipal";
            this.lblSubtituloPrincipal.Size = new System.Drawing.Size(534, 19);
            this.lblSubtituloPrincipal.TabIndex = 1;
            this.lblSubtituloPrincipal.Text = "Selecciona una tarjeta existente o crea una nueva para comenzar a registrar movimientos.";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.AutoSize = true;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloPrincipal.Location = new System.Drawing.Point(34, 20);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(370, 37);
            this.lblTituloPrincipal.TabIndex = 0;
            this.lblTituloPrincipal.Text = "Gestión de Tarjetas Kardex";
            // 
            // pnlContenedorPrincipal
            // 
            this.pnlContenedorPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlContenedorPrincipal.Controls.Add(this.pnlColumnaIzquierda);
            this.pnlContenedorPrincipal.Controls.Add(this.splitterColumnas);
            this.pnlContenedorPrincipal.Controls.Add(this.pnlColumnaDerecha);
            this.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPrincipal.Location = new System.Drawing.Point(0, 100);
            this.pnlContenedorPrincipal.Name = "pnlContenedorPrincipal";
            this.pnlContenedorPrincipal.Padding = new System.Windows.Forms.Padding(36, 16, 36, 24);
            this.pnlContenedorPrincipal.Size = new System.Drawing.Size(1100, 600);
            this.pnlContenedorPrincipal.TabIndex = 1;
            // 
            // pnlColumnaIzquierda
            // 
            this.pnlColumnaIzquierda.Controls.Add(this.pnlListaContenedor);
            this.pnlColumnaIzquierda.Controls.Add(this.pnlBusqueda);
            this.pnlColumnaIzquierda.Controls.Add(this.lblTituloHistorial);
            this.pnlColumnaIzquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColumnaIzquierda.Location = new System.Drawing.Point(36, 16);
            this.pnlColumnaIzquierda.Name = "pnlColumnaIzquierda";
            this.pnlColumnaIzquierda.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.pnlColumnaIzquierda.Size = new System.Drawing.Size(684, 560);
            this.pnlColumnaIzquierda.TabIndex = 0;
            // 
            // pnlListaContenedor
            // 
            this.pnlListaContenedor.AutoScroll = true;
            this.pnlListaContenedor.BackColor = System.Drawing.Color.White;
            this.pnlListaContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListaContenedor.Controls.Add(this.pnlEmptyState);
            this.pnlListaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListaContenedor.Location = new System.Drawing.Point(0, 78);
            this.pnlListaContenedor.Name = "pnlListaContenedor";
            this.pnlListaContenedor.Padding = new System.Windows.Forms.Padding(8);
            this.pnlListaContenedor.Size = new System.Drawing.Size(660, 482);
            this.pnlListaContenedor.TabIndex = 2;
            // 
            // pnlEmptyState
            // 
            this.pnlEmptyState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlEmptyState.BackColor = System.Drawing.Color.Transparent;
            this.pnlEmptyState.Controls.Add(this.lblEmptyStateSub);
            this.pnlEmptyState.Controls.Add(this.lblEmptyStateTitulo);
            this.pnlEmptyState.Controls.Add(this.lblEmptyStateIcono);
            this.pnlEmptyState.Location = new System.Drawing.Point(85, 130);
            this.pnlEmptyState.Name = "pnlEmptyState";
            this.pnlEmptyState.Size = new System.Drawing.Size(480, 160);
            this.pnlEmptyState.TabIndex = 0;
            this.pnlEmptyState.Visible = false;
            // 
            // lblEmptyStateSub
            // 
            this.lblEmptyStateSub.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmptyStateSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblEmptyStateSub.Location = new System.Drawing.Point(10, 85);
            this.lblEmptyStateSub.Name = "lblEmptyStateSub";
            this.lblEmptyStateSub.Size = new System.Drawing.Size(460, 45);
            this.lblEmptyStateSub.TabIndex = 2;
            this.lblEmptyStateSub.Text = "No hay tarjetas registradas aún o ninguna coincide con tu búsqueda.\r\nCrea una nue" +
    "va desde el menú de la derecha.";
            this.lblEmptyStateSub.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEmptyStateTitulo
            // 
            this.lblEmptyStateTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmptyStateTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblEmptyStateTitulo.Location = new System.Drawing.Point(10, 55);
            this.lblEmptyStateTitulo.Name = "lblEmptyStateTitulo";
            this.lblEmptyStateTitulo.Size = new System.Drawing.Size(460, 24);
            this.lblEmptyStateTitulo.TabIndex = 1;
            this.lblEmptyStateTitulo.Text = "No se encontraron tarjetas Kardex";
            this.lblEmptyStateTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmptyStateIcono
            // 
            this.lblEmptyStateIcono.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmptyStateIcono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblEmptyStateIcono.Location = new System.Drawing.Point(10, 8);
            this.lblEmptyStateIcono.Name = "lblEmptyStateIcono";
            this.lblEmptyStateIcono.Size = new System.Drawing.Size(460, 42);
            this.lblEmptyStateIcono.TabIndex = 0;
            this.lblEmptyStateIcono.Text = "📋";
            this.lblEmptyStateIcono.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.White;
            this.pnlBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.lblIconoBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 32);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.pnlBusqueda.Size = new System.Drawing.Size(660, 36);
            this.pnlBusqueda.TabIndex = 1;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBuscar.Location = new System.Drawing.Point(34, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PlaceholderText = "Buscar tarjetas kardex (Alt+S)...";
            this.txtBuscar.Size = new System.Drawing.Size(616, 18);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblIconoBuscar
            // 
            this.lblIconoBuscar.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblIconoBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIconoBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblIconoBuscar.Location = new System.Drawing.Point(8, 4);
            this.lblIconoBuscar.Name = "lblIconoBuscar";
            this.lblIconoBuscar.Size = new System.Drawing.Size(26, 26);
            this.lblIconoBuscar.TabIndex = 0;
            this.lblIconoBuscar.Text = "🔍";
            this.lblIconoBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloHistorial.Location = new System.Drawing.Point(0, 0);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(660, 32);
            this.lblTituloHistorial.TabIndex = 0;
            this.lblTituloHistorial.Text = "Tarjetas Recientes y Guardadas";
            this.lblTituloHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterColumnas
            // 
            this.splitterColumnas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.splitterColumnas.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterColumnas.Location = new System.Drawing.Point(720, 16);
            this.splitterColumnas.MinExtra = 250;
            this.splitterColumnas.MinSize = 250;
            this.splitterColumnas.Name = "splitterColumnas";
            this.splitterColumnas.Size = new System.Drawing.Size(2, 560);
            this.splitterColumnas.TabIndex = 1;
            this.splitterColumnas.TabStop = false;
            // 
            // pnlColumnaDerecha
            // 
            this.pnlColumnaDerecha.Controls.Add(this.pnlAcciones);
            this.pnlColumnaDerecha.Controls.Add(this.lblTituloAcciones);
            this.pnlColumnaDerecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlColumnaDerecha.Location = new System.Drawing.Point(722, 16);
            this.pnlColumnaDerecha.Name = "pnlColumnaDerecha";
            this.pnlColumnaDerecha.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.pnlColumnaDerecha.Size = new System.Drawing.Size(342, 560);
            this.pnlColumnaDerecha.TabIndex = 2;
            // 
            // pnlAcciones
            // 
            this.pnlAcciones.Controls.Add(this.pnlAccionSincronizarBd);
            this.pnlAcciones.Controls.Add(this.pnlAccionImportarLocal);
            this.pnlAcciones.Controls.Add(this.pnlAccionNuevaTarjeta);
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAcciones.Location = new System.Drawing.Point(24, 32);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(318, 528);
            this.pnlAcciones.TabIndex = 1;
            // 
            // pnlAccionSincronizarBd
            // 
            this.pnlAccionSincronizarBd.BackColor = System.Drawing.Color.White;
            this.pnlAccionSincronizarBd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccionSincronizarBd.Controls.Add(this.lblDescSincronizarBd);
            this.pnlAccionSincronizarBd.Controls.Add(this.lblTituloSincronizarBd);
            this.pnlAccionSincronizarBd.Controls.Add(this.lblIconoSincronizarBd);
            this.pnlAccionSincronizarBd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAccionSincronizarBd.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccionSincronizarBd.Location = new System.Drawing.Point(0, 172);
            this.pnlAccionSincronizarBd.Name = "pnlAccionSincronizarBd";
            this.pnlAccionSincronizarBd.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlAccionSincronizarBd.Size = new System.Drawing.Size(318, 76);
            this.pnlAccionSincronizarBd.TabIndex = 2;
            this.pnlAccionSincronizarBd.Click += new System.EventHandler(this.btnLimpiarMemoria_Click);
            // 
            // lblDescSincronizarBd
            // 
            this.lblDescSincronizarBd.AutoEllipsis = true;
            this.lblDescSincronizarBd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescSincronizarBd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDescSincronizarBd.Location = new System.Drawing.Point(48, 34);
            this.lblDescSincronizarBd.Name = "lblDescSincronizarBd";
            this.lblDescSincronizarBd.Size = new System.Drawing.Size(252, 32);
            this.lblDescSincronizarBd.TabIndex = 2;
            this.lblDescSincronizarBd.Text = "Vacía las tarjetas de la sesión actual de memoria.";
            this.lblDescSincronizarBd.Click += new System.EventHandler(this.btnLimpiarMemoria_Click);
            // 
            // lblTituloSincronizarBd
            // 
            this.lblTituloSincronizarBd.AutoSize = true;
            this.lblTituloSincronizarBd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSincronizarBd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloSincronizarBd.Location = new System.Drawing.Point(48, 12);
            this.lblTituloSincronizarBd.Name = "lblTituloSincronizarBd";
            this.lblTituloSincronizarBd.Size = new System.Drawing.Size(183, 17);
            this.lblTituloSincronizarBd.TabIndex = 1;
            this.lblTituloSincronizarBd.Text = "Limpiar Tarjetas en Memoria";
            this.lblTituloSincronizarBd.Click += new System.EventHandler(this.btnLimpiarMemoria_Click);
            // 
            // lblIconoSincronizarBd
            // 
            this.lblIconoSincronizarBd.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIconoSincronizarBd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblIconoSincronizarBd.Location = new System.Drawing.Point(8, 16);
            this.lblIconoSincronizarBd.Name = "lblIconoSincronizarBd";
            this.lblIconoSincronizarBd.Size = new System.Drawing.Size(34, 38);
            this.lblIconoSincronizarBd.TabIndex = 0;
            this.lblIconoSincronizarBd.Text = "🗑️";
            this.lblIconoSincronizarBd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIconoSincronizarBd.Click += new System.EventHandler(this.btnLimpiarMemoria_Click);
            // 
            // pnlAccionImportarLocal
            // 
            this.pnlAccionImportarLocal.BackColor = System.Drawing.Color.White;
            this.pnlAccionImportarLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccionImportarLocal.Controls.Add(this.lblDescImportarLocal);
            this.pnlAccionImportarLocal.Controls.Add(this.lblTituloImportarLocal);
            this.pnlAccionImportarLocal.Controls.Add(this.lblIconoImportarLocal);
            this.pnlAccionImportarLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAccionImportarLocal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccionImportarLocal.Location = new System.Drawing.Point(0, 86);
            this.pnlAccionImportarLocal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlAccionImportarLocal.Name = "pnlAccionImportarLocal";
            this.pnlAccionImportarLocal.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlAccionImportarLocal.Size = new System.Drawing.Size(318, 76);
            this.pnlAccionImportarLocal.TabIndex = 1;
            this.pnlAccionImportarLocal.Click += new System.EventHandler(this.btnRecargarEjemplos_Click);
            // 
            // lblDescImportarLocal
            // 
            this.lblDescImportarLocal.AutoEllipsis = true;
            this.lblDescImportarLocal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescImportarLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDescImportarLocal.Location = new System.Drawing.Point(48, 34);
            this.lblDescImportarLocal.Name = "lblDescImportarLocal";
            this.lblDescImportarLocal.Size = new System.Drawing.Size(252, 32);
            this.lblDescImportarLocal.TabIndex = 2;
            this.lblDescImportarLocal.Text = "Carga las tarjetas demostrativas con movimientos calculados con PEPS.";
            this.lblDescImportarLocal.Click += new System.EventHandler(this.btnRecargarEjemplos_Click);
            // 
            // lblTituloImportarLocal
            // 
            this.lblTituloImportarLocal.AutoSize = true;
            this.lblTituloImportarLocal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloImportarLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloImportarLocal.Location = new System.Drawing.Point(48, 12);
            this.lblTituloImportarLocal.Name = "lblTituloImportarLocal";
            this.lblTituloImportarLocal.Size = new System.Drawing.Size(182, 17);
            this.lblTituloImportarLocal.TabIndex = 1;
            this.lblTituloImportarLocal.Text = "Cargar Tarjetas de Ejemplo";
            this.lblTituloImportarLocal.Click += new System.EventHandler(this.btnRecargarEjemplos_Click);
            // 
            // lblIconoImportarLocal
            // 
            this.lblIconoImportarLocal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIconoImportarLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblIconoImportarLocal.Location = new System.Drawing.Point(8, 16);
            this.lblIconoImportarLocal.Name = "lblIconoImportarLocal";
            this.lblIconoImportarLocal.Size = new System.Drawing.Size(34, 38);
            this.lblIconoImportarLocal.TabIndex = 0;
            this.lblIconoImportarLocal.Text = "↺";
            this.lblIconoImportarLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIconoImportarLocal.Click += new System.EventHandler(this.btnRecargarEjemplos_Click);
            // 
            // pnlAccionNuevaTarjeta
            // 
            this.pnlAccionNuevaTarjeta.BackColor = System.Drawing.Color.White;
            this.pnlAccionNuevaTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccionNuevaTarjeta.Controls.Add(this.lblDescNuevaTarjeta);
            this.pnlAccionNuevaTarjeta.Controls.Add(this.lblTituloNuevaTarjeta);
            this.pnlAccionNuevaTarjeta.Controls.Add(this.lblIconoNuevaTarjeta);
            this.pnlAccionNuevaTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAccionNuevaTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccionNuevaTarjeta.Location = new System.Drawing.Point(0, 0);
            this.pnlAccionNuevaTarjeta.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlAccionNuevaTarjeta.Name = "pnlAccionNuevaTarjeta";
            this.pnlAccionNuevaTarjeta.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlAccionNuevaTarjeta.Size = new System.Drawing.Size(318, 76);
            this.pnlAccionNuevaTarjeta.TabIndex = 0;
            this.pnlAccionNuevaTarjeta.Click += new System.EventHandler(this.btnNuevaTarjeta_Click);
            // 
            // lblDescNuevaTarjeta
            // 
            this.lblDescNuevaTarjeta.AutoEllipsis = true;
            this.lblDescNuevaTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDescNuevaTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDescNuevaTarjeta.Location = new System.Drawing.Point(48, 34);
            this.lblDescNuevaTarjeta.Name = "lblDescNuevaTarjeta";
            this.lblDescNuevaTarjeta.Size = new System.Drawing.Size(252, 32);
            this.lblDescNuevaTarjeta.TabIndex = 2;
            this.lblDescNuevaTarjeta.Text = "Crea una tarjeta en blanco para registrar entradas y salidas con PEPS.";
            this.lblDescNuevaTarjeta.Click += new System.EventHandler(this.btnNuevaTarjeta_Click);
            // 
            // lblTituloNuevaTarjeta
            // 
            this.lblTituloNuevaTarjeta.AutoSize = true;
            this.lblTituloNuevaTarjeta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloNuevaTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTituloNuevaTarjeta.Location = new System.Drawing.Point(48, 12);
            this.lblTituloNuevaTarjeta.Name = "lblTituloNuevaTarjeta";
            this.lblTituloNuevaTarjeta.Size = new System.Drawing.Size(175, 17);
            this.lblTituloNuevaTarjeta.TabIndex = 1;
            this.lblTituloNuevaTarjeta.Text = "Crear nueva tarjeta (PEPS)";
            this.lblTituloNuevaTarjeta.Click += new System.EventHandler(this.btnNuevaTarjeta_Click);
            // 
            // lblIconoNuevaTarjeta
            // 
            this.lblIconoNuevaTarjeta.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIconoNuevaTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblIconoNuevaTarjeta.Location = new System.Drawing.Point(8, 16);
            this.lblIconoNuevaTarjeta.Name = "lblIconoNuevaTarjeta";
            this.lblIconoNuevaTarjeta.Size = new System.Drawing.Size(34, 38);
            this.lblIconoNuevaTarjeta.TabIndex = 0;
            this.lblIconoNuevaTarjeta.Text = "➕";
            this.lblIconoNuevaTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIconoNuevaTarjeta.Click += new System.EventHandler(this.btnNuevaTarjeta_Click);
            // 
            // lblTituloAcciones
            // 
            this.lblTituloAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloAcciones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloAcciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTituloAcciones.Location = new System.Drawing.Point(24, 0);
            this.lblTituloAcciones.Name = "lblTituloAcciones";
            this.lblTituloAcciones.Size = new System.Drawing.Size(318, 32);
            this.lblTituloAcciones.TabIndex = 0;
            this.lblTituloAcciones.Text = "Comenzar";
            this.lblTituloAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmInicioKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlContenedorPrincipal);
            this.Controls.Add(this.pnlEncabezadoSuperior);
            this.KeyPreview = true;
            this.Name = "frmInicioKardex";
            this.Text = "Gestión de Tarjetas Kardex";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInicioKardex_KeyDown);
            this.pnlEncabezadoSuperior.ResumeLayout(false);
            this.pnlEncabezadoSuperior.PerformLayout();
            this.pnlContenedorPrincipal.ResumeLayout(false);
            this.pnlColumnaIzquierda.ResumeLayout(false);
            this.pnlListaContenedor.ResumeLayout(false);
            this.pnlEmptyState.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlColumnaDerecha.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false);
            this.pnlAccionSincronizarBd.ResumeLayout(false);
            this.pnlAccionSincronizarBd.PerformLayout();
            this.pnlAccionImportarLocal.ResumeLayout(false);
            this.pnlAccionImportarLocal.PerformLayout();
            this.pnlAccionNuevaTarjeta.ResumeLayout(false);
            this.pnlAccionNuevaTarjeta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezadoSuperior;
        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.Label lblSubtituloPrincipal;
        private System.Windows.Forms.Panel pnlContenedorPrincipal;
        private System.Windows.Forms.Panel pnlColumnaIzquierda;
        private System.Windows.Forms.Label lblTituloHistorial;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Label lblIconoBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlListaContenedor;
        private System.Windows.Forms.Splitter splitterColumnas;
        private System.Windows.Forms.Panel pnlColumnaDerecha;
        private System.Windows.Forms.Label lblTituloAcciones;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlAccionNuevaTarjeta;
        private System.Windows.Forms.Label lblIconoNuevaTarjeta;
        private System.Windows.Forms.Label lblTituloNuevaTarjeta;
        private System.Windows.Forms.Label lblDescNuevaTarjeta;
        private System.Windows.Forms.Panel pnlAccionImportarLocal;
        private System.Windows.Forms.Label lblIconoImportarLocal;
        private System.Windows.Forms.Label lblTituloImportarLocal;
        private System.Windows.Forms.Label lblDescImportarLocal;
        private System.Windows.Forms.Panel pnlAccionSincronizarBd;
        private System.Windows.Forms.Label lblIconoSincronizarBd;
        private System.Windows.Forms.Label lblTituloSincronizarBd;
        private System.Windows.Forms.Label lblDescSincronizarBd;
        private System.Windows.Forms.Panel pnlEmptyState;
        private System.Windows.Forms.Label lblEmptyStateIcono;
        private System.Windows.Forms.Label lblEmptyStateTitulo;
        private System.Windows.Forms.Label lblEmptyStateSub;
    }
}

