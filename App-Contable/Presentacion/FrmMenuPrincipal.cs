using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_Contable.Datos;

namespace App_Contable.Presentacion
{
    public partial class FrmMenuPrincipal : Form
    {
        private Form? _formularioActivo = null;
        private Button? _botonSeleccionado = null;
        private readonly DbContext _dbContext;

        // Variables de control de animación del sidebar
        private const int ANCHO_EXPANDIDO = 250;
        private const int ANCHO_COLAPSADO = 60;
        private const int VELOCIDAD_ANIMACION = 25;
        private int _targetWidth = ANCHO_EXPANDIDO;
        private bool _sidebarFijadoColapsado = false;

        public enum EstadoConexion
        {
            Desconectado,
            Conectando,
            Conectado,
            Error
        }

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            _dbContext = new DbContext();
            ActualizarEstadoConexion(EstadoConexion.Desconectado, "Estado BD: Pendiente de prueba");
        }

        /// <summary>
        /// Incrusta un formulario hijo dentro del panel contenedor central cerrando el previo si existía.
        /// </summary>
        /// <param name="formHijo">Instancia del formulario a incrustar.</param>
        public void AbrirFormularioEnPanel(Form formHijo)
        {
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
            }

            _formularioActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            pnlContenedor.Controls.Clear();
            pnlContenedor.Controls.Add(formHijo);
            pnlContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        #region Animación y Colapso del Sidebar

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            _sidebarFijadoColapsado = !_sidebarFijadoColapsado;
            _targetWidth = _sidebarFijadoColapsado ? ANCHO_COLAPSADO : ANCHO_EXPANDIDO;
            sidebarTimer.Start();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (pnlSidebar.Width < _targetWidth)
            {
                pnlSidebar.Width = Math.Min(pnlSidebar.Width + VELOCIDAD_ANIMACION, _targetWidth);
                if (pnlSidebar.Width >= _targetWidth)
                {
                    sidebarTimer.Stop();
                    AjustarVisibilidadSidebar(expandido: true);
                }
            }
            else if (pnlSidebar.Width > _targetWidth)
            {
                pnlSidebar.Width = Math.Max(pnlSidebar.Width - VELOCIDAD_ANIMACION, _targetWidth);
                if (pnlSidebar.Width <= _targetWidth)
                {
                    sidebarTimer.Stop();
                    AjustarVisibilidadSidebar(expandido: false);
                }
            }
            else
            {
                sidebarTimer.Stop();
            }
        }

        private void AjustarVisibilidadSidebar(bool expandido)
        {
            lblTituloApp.Visible = expandido;
            lblSubtituloApp.Visible = expandido;
            lblVersion.Visible = expandido;

            if (expandido)
            {
                btnToggleSidebar.Location = new Point(10, 22);
            }
            else
            {
                btnToggleSidebar.Location = new Point((ANCHO_COLAPSADO - btnToggleSidebar.Width) / 2, 22);
            }
        }

        private void pnlSidebar_MouseEnter(object sender, EventArgs e)
        {
            if (_sidebarFijadoColapsado && pnlSidebar.Width < ANCHO_EXPANDIDO)
            {
                _targetWidth = ANCHO_EXPANDIDO;
                AjustarVisibilidadSidebar(expandido: true);
                sidebarTimer.Start();
            }
        }

        private void pnlSidebar_MouseLeave(object sender, EventArgs e)
        {
            if (_sidebarFijadoColapsado)
            {
                Point mousePos = pnlSidebar.PointToClient(Cursor.Position);
                if (!pnlSidebar.ClientRectangle.Contains(mousePos))
                {
                    _targetWidth = ANCHO_COLAPSADO;
                    sidebarTimer.Start();
                }
            }
        }

        #endregion

        #region Conexión a Base de Datos

        /// <summary>
        /// Actualiza el indicador visual y la etiqueta de estado de la base de datos.
        /// </summary>
        private void ActualizarEstadoConexion(EstadoConexion estado, string mensaje)
        {
            lblEstadoConexion.Text = mensaje;

            switch (estado)
            {
                case EstadoConexion.Desconectado:
                    pnlStatusIndicator.BackColor = Color.FromArgb(156, 163, 175); // Gris
                    break;
                case EstadoConexion.Conectando:
                    pnlStatusIndicator.BackColor = Color.FromArgb(234, 179, 8);   // Amarillo / Ámbar
                    break;
                case EstadoConexion.Conectado:
                    pnlStatusIndicator.BackColor = Color.FromArgb(34, 197, 94);   // Verde
                    break;
                case EstadoConexion.Error:
                    pnlStatusIndicator.BackColor = Color.FromArgb(239, 68, 68);   // Rojo
                    break;
            }

            pnlStatusIndicator.Invalidate();
        }

        /// <summary>
        /// Dibuja el indicador de estado como un círculo suave.
        /// </summary>
        private void pnlStatusIndicator_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(pnlStatusIndicator.BackColor))
            {
                e.Graphics.FillEllipse(brush, 0, 0, pnlStatusIndicator.Width - 1, pnlStatusIndicator.Height - 1);
            }
        }

        /// <summary>
        /// Dispara la verificación de la conexión a la base de datos PostgreSQL.
        /// </summary>
        private async void btnProbarConexion_Click(object sender, EventArgs e)
        {
            btnProbarConexion.Enabled = false;
            Cursor = Cursors.WaitCursor;
            ActualizarEstadoConexion(EstadoConexion.Conectando, "Estado BD: Conectando a PostgreSQL...");

            try
            {
                var resultado = await _dbContext.ProbarConexionDetalladaAsync();

                if (resultado.Exito)
                {
                    ActualizarEstadoConexion(EstadoConexion.Conectado, "Estado BD: Conectado a PostgreSQL");
                    MessageBox.Show(
                        $"¡Conexión establecida con éxito!\n\nServidor:\n{resultado.VersionServidor}",
                        "Conexión a Base de Datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    ActualizarEstadoConexion(EstadoConexion.Error, "Estado BD: Error de conexión");
                    MessageBox.Show(
                        $"{resultado.Mensaje}",
                        "Fallo de Conexión a Base de Datos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ActualizarEstadoConexion(EstadoConexion.Error, "Estado BD: Error inesperado");
                MessageBox.Show(
                    $"Ocurrió un error inesperado al verificar la conexión:\n\n{ex.Message}",
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnProbarConexion.Enabled = true;
            }
        }

        #endregion

        /// <summary>
        /// Resalta visualmente el botón seleccionado en el menú lateral.
        /// </summary>
        private void ResaltarBotonMenu(Button boton, string tituloSeccion)
        {
            if (_botonSeleccionado != null)
            {
                _botonSeleccionado.BackColor = Color.FromArgb(24, 30, 54);
                _botonSeleccionado.ForeColor = Color.FromArgb(229, 231, 235);
                _botonSeleccionado.Font = new Font(Font.FontFamily, 9.75f, FontStyle.Regular);
            }

            _botonSeleccionado = boton;
            _botonSeleccionado.BackColor = Color.FromArgb(37, 99, 235);
            _botonSeleccionado.ForeColor = Color.White;
            _botonSeleccionado.Font = new Font(Font.FontFamily, 9.75f, FontStyle.Bold);

            lblTituloSeccion.Text = tituloSeccion;
        }

        #region Eventos del Menú de Navegación

        private void btnLibroDiario_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnLibroDiario, "Libro Diario");
        }

        private void btnLibroMayor_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnLibroMayor, "Libro Mayor");
        }

        private void btnBalanceGeneral_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnBalanceGeneral, "Balance General");
        }

        private void btnEstadoResultados_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnEstadoResultados, "Estado de Resultados");
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnKardex, "Gestión de Tarjetas Kardex");
            AbrirFormularioEnPanel(new frmInicioKardex());
        }

        private void btnBalanzaComprobacion_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnBalanzaComprobacion, "Balanza de Comprobación");
        }

        private void btnCatalogoCuentas_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu(btnCatalogoCuentas, "Catálogo de Cuentas");
        }

        #endregion
    }
}

