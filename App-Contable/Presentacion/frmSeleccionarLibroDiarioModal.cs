using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Datos;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmSeleccionarLibroDiarioModal : Form
    {
        private readonly LibroDiarioStorageService _storageService = new();

        /// <summary>
        /// Instancia del Libro Diario seleccionada por el usuario para cargar en la Balanza de Comprobación.
        /// </summary>
        public LibroDiarioInstancia? LibroSeleccionado { get; private set; }

        public frmSeleccionarLibroDiarioModal(string? subtitulo = null)
        {
            InitializeComponent();
            if (!string.IsNullOrWhiteSpace(subtitulo))
            {
                lblSubtitulo.Text = subtitulo;
            }
            ConfigurarModal();
            this.Load += (s, e) => CargarLibros();
        }

        private void ConfigurarModal()
        {
            txtBuscar.TextChanged += (s, e) => CargarLibros();
            lstLibros.DoubleClick += (s, e) => ConfirmarSeleccion();

            pnlHeader.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            };

            pnlBotones.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, pnlBotones.Width, 0);
            };
        }

        private void CargarLibros()
        {
            var libros = _storageService.ObtenerLibros();
            string filtro = txtBuscar.Text.Trim().ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                libros = libros.Where(l =>
                    l.Nombre.ToLowerInvariant().Contains(filtro) ||
                    l.Empresa.ToLowerInvariant().Contains(filtro) ||
                    l.TextoPeriodo.ToLowerInvariant().Contains(filtro) ||
                    l.TextoBadgeDestino.ToLowerInvariant().Contains(filtro)
                ).ToList();
            }

            lstLibros.BeginUpdate();
            lstLibros.Items.Clear();

            if (!libros.Any())
            {
                lstLibros.Items.Add(new LibroDiarioListItem
                {
                    EsPlaceholder = true,
                    Titulo = string.IsNullOrWhiteSpace(filtro)
                        ? "No hay libros diarios registrados."
                        : "No se encontraron libros que coincidan con la búsqueda.",
                    Subtitulo = "Registra partidas en el módulo de Libro Diario para generar su balanza."
                });
                lstLibros.EndUpdate();
                return;
            }

            // Agrupar temporalmente ("Hoy", "Esta semana", "Este mes", "Anteriores")
            var grupos = libros
                .GroupBy(l => l.GrupoTemporal)
                .OrderBy(g => OrdenGrupo(g.Key));

            foreach (var grupo in grupos)
            {
                lstLibros.Items.Add(new LibroDiarioListItem
                {
                    EsEncabezadoGrupo = true,
                    Titulo = grupo.Key.ToUpperInvariant()
                });

                foreach (var libro in grupo)
                {
                    lstLibros.Items.Add(new LibroDiarioListItem
                    {
                        Instancia = libro,
                        Titulo = libro.Nombre,
                        Subtitulo = libro.DescripcionSecundaria,
                        BadgeTexto = libro.TextoBadgeDestino,
                        Destino = libro.DestinoGuardado,
                        FechaModTexto = $"Modificado: {libro.FechaModificacion:dd/MM/yyyy HH:mm}",
                        TotalDebe = libro.TotalDebe,
                        CantidadAsientos = libro.Asientos.Count
                    });
                }
            }

            lstLibros.EndUpdate();

            // Seleccionar primer elemento válido si existe
            for (int i = 0; i < lstLibros.Items.Count; i++)
            {
                if (lstLibros.Items[i] is LibroDiarioListItem itm && itm.Instancia != null)
                {
                    lstLibros.SelectedIndex = i;
                    break;
                }
            }
        }

        private static int OrdenGrupo(string grupo) => grupo switch
        {
            "Hoy" => 0,
            "Esta semana" => 1,
            "Este mes" => 2,
            _ => 3
        };

        private void ConfirmarSeleccion()
        {
            if (lstLibros.SelectedItem is LibroDiarioListItem item && item.Instancia != null)
            {
                LibroSeleccionado = item.Instancia;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "Por favor, selecciona un libro diario válido de la lista.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }
    }
}

