using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Datos;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmInicioMayorizacion : Form
    {
        private readonly LibroDiarioStorageService _storageService = new();

        public frmInicioMayorizacion()
        {
            InitializeComponent();
            ConfigurarFormulario();
            this.Load += (s, e) => RefrescarListaLibros();
        }

        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            // Eventos de botones
            btnGenerarMayor.Click += (s, e) => AbrirMayorizacionSeleccionada();
            btnVistaPrevia.Click += (s, e) => MostrarVistaPrevia();
            btnActualizarLista.Click += (s, e) => RefrescarListaLibros();

            // Búsqueda en tiempo real
            txtBuscarDash.TextChanged += (s, e) => RefrescarListaLibros();

            // Doble clic en la lista para procesar directamente
            lstLibros.DoubleClick += (s, e) => AbrirMayorizacionSeleccionada();

            // Bordes y divisores personalizados
            pnlDashHeader.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, pnlDashHeader.Height - 1, pnlDashHeader.Width, pnlDashHeader.Height - 1);
            };

            pnlAcciones.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, 0, pnlAcciones.Height);
            };
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Atajo Alt+S para ir a la barra de búsqueda
            if (keyData == (Keys.Alt | Keys.S))
            {
                txtBuscarDash.Focus();
                txtBuscarDash.SelectAll();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Recarga la lista de libros diarios desde el almacenamiento en memoria y aplica filtros de búsqueda.
        /// </summary>
        public void RefrescarListaLibros()
        {
            var libros = _storageService.ObtenerLibros();
            string filtro = txtBuscarDash.Text.Trim().ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                libros = libros.Where(l =>
                    l.Nombre.ToLowerInvariant().Contains(filtro) ||
                    l.Empresa.ToLowerInvariant().Contains(filtro) ||
                    l.TextoPeriodo.ToLowerInvariant().Contains(filtro) ||
                    l.TextoBadgeDestino.ToLowerInvariant().Contains(filtro)
                ).ToList();
            }

            lblBadgeTotal.Text = $"  {libros.Count} Libro(s)  ";

            lstLibros.BeginUpdate();
            lstLibros.Items.Clear();

            if (!libros.Any())
            {
                lstLibros.Items.Add(new LibroDiarioListItem
                {
                    EsPlaceholder = true,
                    Titulo = string.IsNullOrWhiteSpace(filtro)
                        ? "No hay libros diarios registrados aún."
                        : "No se encontraron libros diarios que coincidan con la búsqueda.",
                    Subtitulo = "Crea o registra un libro diario en el módulo de Libro Diario para generar su mayorización."
                });
                lstLibros.EndUpdate();
                return;
            }

            // Agrupar temporalmente (Hoy, Esta semana, Este mes, Anteriores)
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
        }

        private static int OrdenGrupo(string grupo) => grupo switch
        {
            "Hoy" => 0,
            "Esta semana" => 1,
            "Este mes" => 2,
            _ => 3
        };

        private LibroDiarioInstancia? ObtenerLibroSeleccionado()
        {
            if (lstLibros.SelectedItem is LibroDiarioListItem item && item.Instancia != null)
            {
                return item.Instancia;
            }
            return null;
        }

        private void AbrirMayorizacionSeleccionada()
        {
            var libro = ObtenerLibroSeleccionado();
            if (libro == null)
            {
                MessageBox.Show(
                    "Por favor, selecciona un libro diario de la lista para generar sus esquemas de mayor.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Navegación fluida dentro del contenedor principal
            NavegacionHelper.NavegarA(this, new frmMayorizacion(libro));
        }

        private void MostrarVistaPrevia()
        {
            var libro = ObtenerLibroSeleccionado();
            if (libro == null)
            {
                MessageBox.Show(
                    "Selecciona un libro diario de la lista para consultar su vista previa.",
                    "Vista Rápida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            bool cuadrado = libro.Asientos.Count > 0 && Math.Round(libro.TotalDebe, 2) == Math.Round(libro.TotalHaber, 2);
            string estadoTexto = cuadrado ? "✓ Asientos Dobles Cuadrados" : "⚠ Partidas con descuadre";

            string mensaje = $"═══════════════════════════════════════\n" +
                             $"  INFORMACIÓN DEL LIBRO DIARIO\n" +
                             $"═══════════════════════════════════════\n\n" +
                             $"• Nombre: {libro.Nombre}\n" +
                             $"• Empresa: {(string.IsNullOrWhiteSpace(libro.Empresa) ? "Principal" : libro.Empresa)}\n" +
                             $"• Período Contable: {libro.TextoPeriodo}\n" +
                             $"• Cantidad de Asientos: {libro.Asientos.Count}\n" +
                             $"• Destino Almacenamiento: {libro.TextoBadgeDestino}\n" +
                             $"• Sumatoria Total Debe: {libro.TotalDebe:C2}\n" +
                             $"• Sumatoria Total Haber: {libro.TotalHaber:C2}\n" +
                             $"• Estado de Cuadre: {estadoTexto}\n\n" +
                             $"¿Deseas abrir la mayorización completa de este libro?";

            var respuesta = MessageBox.Show(
                mensaje,
                "Vista Rápida — " + libro.Nombre,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (respuesta == DialogResult.Yes)
            {
                AbrirMayorizacionSeleccionada();
            }
        }
    }
}

