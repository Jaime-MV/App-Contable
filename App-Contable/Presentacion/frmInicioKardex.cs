using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Datos;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmInicioKardex : Form
    {
        private readonly KardexStorageService _storageService;
        private List<TarjetaKardex> _todasLasTarjetas = new();
        private string _filtroBusqueda = string.Empty;

        public frmInicioKardex()
        {
            InitializeComponent();
            _storageService = new KardexStorageService();

            ConfigurarTarjetasAccion();
            CargarTarjetas();
        }

        private void ConfigurarTarjetasAccion()
        {
            ConfigurarEfectosHover(pnlAccionNuevaTarjeta);
            ConfigurarEfectosHover(pnlAccionImportarLocal);
            ConfigurarEfectosHover(pnlAccionSincronizarBd);
        }

        private void ConfigurarEfectosHover(Panel panel)
        {
            Color bgNormal = Color.White;
            Color bgHover = Color.FromArgb(248, 250, 252);

            panel.MouseEnter += (s, e) => panel.BackColor = bgHover;
            panel.MouseLeave += (s, e) => panel.BackColor = bgNormal;

            foreach (Control c in panel.Controls)
            {
                c.MouseEnter += (s, e) => panel.BackColor = bgHover;
                c.MouseLeave += (s, e) => panel.BackColor = bgNormal;
            }
        }

        public void CargarTarjetas()
        {
            _todasLasTarjetas = _storageService.ObtenerTarjetasLocales();
            RenderizarListaTarjetas();
        }

        private void RenderizarListaTarjetas()
        {
            pnlListaContenedor.SuspendLayout();
            pnlListaContenedor.Controls.Clear();

            var tarjetasFiltradas = _todasLasTarjetas
                .Where(t => string.IsNullOrWhiteSpace(_filtroBusqueda) ||
                            t.Nombre.Contains(_filtroBusqueda, StringComparison.OrdinalIgnoreCase) ||
                            t.CodigoArticulo.Contains(_filtroBusqueda, StringComparison.OrdinalIgnoreCase) ||
                            t.MetodoValuacion.Contains(_filtroBusqueda, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (tarjetasFiltradas.Count == 0)
            {
                pnlEmptyState.Visible = true;
                pnlEmptyState.Dock = DockStyle.Fill;
                pnlListaContenedor.Controls.Add(pnlEmptyState);
                pnlListaContenedor.ResumeLayout();
                return;
            }

            pnlEmptyState.Visible = false;

            var grupos = tarjetasFiltradas
                .GroupBy(t => t.GrupoTemporal)
                .OrderBy(g => ObtenerOrdenGrupo(g.Key));

            var listaControles = new List<Control>();

            foreach (var grupo in grupos)
            {
                var pnlGrupoHeader = CrearEncabezadoGrupo(grupo.Key);
                listaControles.Add(pnlGrupoHeader);

                foreach (var tarjeta in grupo)
                {
                    var itemControl = CrearItemTarjetaControl(tarjeta);
                    listaControles.Add(itemControl);
                }
            }

            for (int i = listaControles.Count - 1; i >= 0; i--)
            {
                pnlListaContenedor.Controls.Add(listaControles[i]);
            }

            pnlListaContenedor.ResumeLayout();
        }

        private static int ObtenerOrdenGrupo(string grupo)
        {
            return grupo switch
            {
                "Hoy" => 1,
                "Esta semana" => 2,
                "Este mes" => 3,
                _ => 4
            };
        }

        private Panel CrearEncabezadoGrupo(string nombreGrupo)
        {
            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 32,
                BackColor = Color.White,
                Padding = new Padding(12, 8, 12, 2)
            };

            var lbl = new Label
            {
                Text = nombreGrupo.ToUpperInvariant(),
                Font = new Font("Segoe UI", 8.25f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.BottomLeft
            };

            pnlHeader.Controls.Add(lbl);
            return pnlHeader;
        }

        private Control CrearItemTarjetaControl(TarjetaKardex tarjeta)
        {
            var pnlItem = new Panel
            {
                Dock = DockStyle.Top,
                Height = 68,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Padding = new Padding(16, 8, 16, 8),
                Tag = tarjeta,
                Margin = new Padding(0, 0, 0, 2)
            };

            var lblNombre = new Label
            {
                Text = tarjeta.Nombre,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(14, 10),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            var lblSubtitulo = new Label
            {
                Text = tarjeta.DescripcionSecundaria,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(14, 36),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            var lblBadge = new Label
            {
                Text = "⚡ PEPS / Memoria",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Regular),
                BackColor = Color.FromArgb(239, 246, 255),
                ForeColor = Color.FromArgb(29, 78, 216),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(115, 20),
                Cursor = Cursors.Hand
            };

            string textoFecha = FormatearFechaAmigable(tarjeta.FechaModificacion);
            var lblFecha = new Label
            {
                Text = textoFecha,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(148, 163, 184),
                Dock = DockStyle.Right,
                Width = 140,
                TextAlign = ContentAlignment.MiddleRight,
                Cursor = Cursors.Hand
            };

            pnlItem.Controls.Add(lblFecha);
            pnlItem.Controls.Add(lblNombre);
            pnlItem.Controls.Add(lblSubtitulo);
            pnlItem.Controls.Add(lblBadge);

            pnlItem.SizeChanged += (s, e) =>
            {
                lblBadge.Location = new Point(lblSubtitulo.Right + 12, 35);
            };
            lblBadge.Location = new Point(lblSubtitulo.Right + 12, 35);

            Color bgNormal = Color.White;
            Color bgHover = Color.FromArgb(248, 250, 252);

            void Resaltar(bool hover)
            {
                pnlItem.BackColor = hover ? bgHover : bgNormal;
            }

            pnlItem.MouseEnter += (s, e) => Resaltar(true);
            pnlItem.MouseLeave += (s, e) => Resaltar(false);

            foreach (Control c in pnlItem.Controls)
            {
                c.MouseEnter += (s, e) => Resaltar(true);
                c.MouseLeave += (s, e) => Resaltar(false);
                c.Click += (s, e) => AbrirTarjeta(tarjeta);
                c.DoubleClick += (s, e) => AbrirTarjeta(tarjeta);
            }

            pnlItem.Click += (s, e) => AbrirTarjeta(tarjeta);
            pnlItem.DoubleClick += (s, e) => AbrirTarjeta(tarjeta);

            pnlItem.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(241, 245, 249), 1f);
                e.Graphics.DrawLine(pen, 12, pnlItem.Height - 1, pnlItem.Width - 12, pnlItem.Height - 1);
            };

            return pnlItem;
        }

        private static string FormatearFechaAmigable(DateTime fecha)
        {
            var ahora = DateTime.Now;
            if (fecha.Date == ahora.Date)
            {
                return $"Hoy, {fecha:HH:mm}";
            }
            if (fecha.Date == ahora.Date.AddDays(-1))
            {
                return $"Ayer, {fecha:HH:mm}";
            }
            return fecha.ToString("dd/MM/yyyy HH:mm");
        }

        public void AbrirTarjeta(TarjetaKardex tarjeta)
        {
            tarjeta.FechaModificacion = DateTime.Now;
            _storageService.GuardarTarjetaLocal(tarjeta);

            var formMenuPrincipal = FindForm() as FrmMenuPrincipal ?? ParentForm as FrmMenuPrincipal;
            if (formMenuPrincipal != null)
            {
                var formKardex = new frmKardex(tarjeta);
                formMenuPrincipal.AbrirFormularioEnPanel(formKardex);
            }
            else
            {
                var formKardex = new frmKardex(tarjeta);
                formKardex.Show();
            }
        }

        #region Eventos de Acciones Rápidas

        private void btnNuevaTarjeta_Click(object sender, EventArgs e)
        {
            using var modal = new frmNuevaTarjetaModal();
            if (modal.ShowDialog(this) == DialogResult.OK && modal.TarjetaCreada != null)
            {
                var nueva = modal.TarjetaCreada;
                _storageService.GuardarTarjetaLocal(nueva);
                AbrirTarjeta(nueva);
            }
        }

        private void btnRecargarEjemplos_Click(object sender, EventArgs e)
        {
            _storageService.RecargarEjemplosEnMemoria();
            CargarTarjetas();
            MessageBox.Show(
                "Se han recargado las tarjetas de ejemplo (PEPS / FIFO) en memoria.",
                "Tarjetas de Ejemplo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnLimpiarMemoria_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Desea limpiar todas las tarjetas registradas en memoria?",
                "Limpiar Memoria",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                var todas = _storageService.ObtenerTarjetasLocales();
                foreach (var t in todas)
                {
                    _storageService.EliminarTarjetaLocal(t);
                }
                CargarTarjetas();
            }
        }

        #endregion

        #region Búsqueda y Atajos de Teclado (Alt+S)

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            _filtroBusqueda = txtBuscar.Text.Trim();
            RenderizarListaTarjetas();
        }

        private void frmInicioKardex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.S)
            {
                txtBuscar.Focus();
                txtBuscar.SelectAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        #endregion
    }
}

