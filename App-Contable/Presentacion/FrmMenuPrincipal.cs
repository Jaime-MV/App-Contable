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
            ResaltarBotonMenu(btnKardex, "Tarjeta Kardex");
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

