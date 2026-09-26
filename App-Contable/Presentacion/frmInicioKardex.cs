using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Datos;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmInicioKardex : Form
    {
        private static readonly CultureInfo UsCulture = new("en-US");
        private readonly LibroDiarioStorageService _libroStorage = new();
        private readonly KardexStorageService _kardexStorage = new();

        public frmInicioKardex()
        {
            InitializeComponent();
            ConfigurarFormulario();
            this.Load += (s, e) => RefrescarLista();
        }

        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            // Eventos de botones
            btnGenerarKardex.Click += (s, e) => ProcesarSeleccionOPrimero();
            btnKardexManual.Click += (s, e) => AbrirKardexManual();
            btnVistaPrevia.Click += (s, e) => MostrarVistaPrevia();
            btnActualizarLista.Click += (s, e) => RefrescarLista();

            // Búsqueda en tiempo real
            txtBuscarDash.TextChanged += (s, e) => RefrescarLista();

            // Doble clic en la lista para abrir directamente
            lstRegistros.DoubleClick += (s, e) => ProcesarSeleccionOPrimero();

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
        /// Recarga la lista combinada de tarjetas Kardex guardadas y libros diarios disponibles.
        /// </summary>
        public void RefrescarLista()
        {
            var tarjetas = _kardexStorage.ObtenerTarjetas();
            var libros = _libroStorage.ObtenerLibros();
            string filtro = txtBuscarDash.Text.Trim().ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                tarjetas = tarjetas.Where(t =>
                    t.Nombre.ToLowerInvariant().Contains(filtro) ||
                    t.CodigoArticulo.ToLowerInvariant().Contains(filtro) ||
                    t.Empresa.ToLowerInvariant().Contains(filtro) ||
                    t.TextoPeriodo.ToLowerInvariant().Contains(filtro)
                ).ToList();

                libros = libros.Where(l =>
                    l.Nombre.ToLowerInvariant().Contains(filtro) ||
                    l.Empresa.ToLowerInvariant().Contains(filtro) ||
                    l.TextoPeriodo.ToLowerInvariant().Contains(filtro) ||
                    l.TextoBadgeDestino.ToLowerInvariant().Contains(filtro)
                ).ToList();
            }

            int totalRegistros = tarjetas.Count + libros.Count;
            lblBadgeTotal.Text = $"  {totalRegistros} Registro(s)  ";

            lstRegistros.BeginUpdate();
            lstRegistros.Items.Clear();

            if (totalRegistros == 0)
            {
                lstRegistros.Items.Add(new KardexDashboardListItem
                {
                    EsPlaceholder = true,
                    Titulo = string.IsNullOrWhiteSpace(filtro)
                        ? "No hay registros disponibles."
                        : "No se encontraron registros que coincidan con la búsqueda.",
                    Subtitulo = "Crea una tarjeta Kardex manual o registra un libro diario para generar automáticamente su inventario."
                });
                lstRegistros.EndUpdate();
                return;
            }

            // 1. Grupo: Tarjetas Kardex Guardadas
            if (tarjetas.Any())
            {
                lstRegistros.Items.Add(new KardexDashboardListItem
                {
                    EsEncabezadoGrupo = true,
                    Titulo = "TARJETAS KARDEX GUARDADAS"
                });

                foreach (var t in tarjetas)
                {
                    lstRegistros.Items.Add(new KardexDashboardListItem
                    {
                        InstanciaKardex = t,
                        Titulo = t.Nombre,
                        Subtitulo = t.DescripcionSecundaria,
                        BadgeTipo = "[Tarjeta Kardex]",
                        BadgeDestino = t.TextoBadgeDestino,
                        EsTarjetaKardex = true,
                        MontoPrincipal = t.SaldoValorActual,
                        UnidadesTexto = $"{t.StockActual:N0} uds",
                        FechaModTexto = $"Modificado: {t.FechaModificacion:dd/MM/yyyy HH:mm}"
                    });
                }
            }

            // 2. Grupo: Libros Diarios Disponibles
            if (libros.Any())
            {
                lstRegistros.Items.Add(new KardexDashboardListItem
                {
                    EsEncabezadoGrupo = true,
                    Titulo = "LIBROS DIARIOS DISPONIBLES PARA GENERAR KARDEX"
                });

                foreach (var l in libros)
                {
                    lstRegistros.Items.Add(new KardexDashboardListItem
                    {
                        InstanciaLibro = l,
                        Titulo = l.Nombre,
                        Subtitulo = l.DescripcionSecundaria,
                        BadgeTipo = "[Libro Diario]",
                        BadgeDestino = l.TextoBadgeDestino,
                        EsTarjetaKardex = false,
                        MontoPrincipal = l.TotalDebe,
                        UnidadesTexto = $"{l.Asientos.Count} asiento(s)",
                        FechaModTexto = $"Modificado: {l.FechaModificacion:dd/MM/yyyy HH:mm}"
                    });
                }
            }

            lstRegistros.EndUpdate();
        }

        private void ProcesarSeleccionOPrimero()
        {
            if (lstRegistros.SelectedItem is not KardexDashboardListItem item || item.EsPlaceholder || item.EsEncabezadoGrupo)
            {
                // Si no hay selección, intentar seleccionar el primer libro diario disponible
                var primerLibro = _libroStorage.ObtenerLibros().FirstOrDefault();
                if (primerLibro != null)
                {
                    AbrirKardexDesdeLibro(primerLibro);
                    return;
                }

                using var modalSel = new frmSeleccionarLibroDiarioModal("Selecciona un Libro Diario para calibrar y generar su Tarjeta Kardex.");
                if (modalSel.ShowDialog(this) == DialogResult.OK && modalSel.LibroSeleccionado != null)
                {
                    AbrirKardexDesdeLibro(modalSel.LibroSeleccionado);
                    return;
                }

                MessageBox.Show(
                    "Por favor, selecciona un libro diario o una tarjeta Kardex de la lista.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (item.EsTarjetaKardex && item.InstanciaKardex != null)
            {
                NavegacionHelper.NavegarA(this, new frmKardex(item.InstanciaKardex));
            }
            else if (item.InstanciaLibro != null)
            {
                AbrirKardexDesdeLibro(item.InstanciaLibro);
            }
        }

        private void AbrirKardexDesdeLibro(LibroDiarioInstancia libro)
        {
            using var modalCalibracion = new frmCalibracionKardex(libro);
            if (modalCalibracion.ShowDialog(this) == DialogResult.OK && modalCalibracion.KardexGenerado != null)
            {
                _kardexStorage.GuardarTarjeta(modalCalibracion.KardexGenerado);
                NavegacionHelper.NavegarA(this, new frmKardex(modalCalibracion.KardexGenerado));
            }
        }

        private void AbrirKardexManual()
        {
            var formKardex = new frmKardex();
            NavegacionHelper.NavegarA(this, formKardex);
        }

        private void MostrarVistaPrevia()
        {
            if (lstRegistros.SelectedItem is not KardexDashboardListItem item || item.EsPlaceholder || item.EsEncabezadoGrupo)
            {
                MessageBox.Show(
                    "Selecciona un elemento de la lista para consultar su vista previa.",
                    "Vista Rápida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (item.EsTarjetaKardex && item.InstanciaKardex != null)
            {
                var k = item.InstanciaKardex;
                string mensaje = $"═══════════════════════════════════════\n" +
                                 $"  INFORMACIÓN DE TARJETA KARDEX\n" +
                                 $"═══════════════════════════════════════\n\n" +
                                 $"• Nombre: {k.Nombre}\n" +
                                 $"• Artículo: {(string.IsNullOrWhiteSpace(k.CodigoArticulo) ? "General" : k.CodigoArticulo)}\n" +
                                 $"• Empresa: {(string.IsNullOrWhiteSpace(k.Empresa) ? "Principal" : k.Empresa)}\n" +
                                 $"• Método de Valuación: {k.MetodoValuacionTexto}\n" +
                                 $"• Período: {k.TextoPeriodo}\n" +
                                 $"• Movimientos Operativos: {k.Movimientos.Count(m => !m.EsFilaEspecial)}\n" +
                                 $"• Stock Final: {k.StockActual:N0} unidades\n" +
                                 $"• Saldo Valor Final: {k.SaldoValorActual.ToString("$#,##0.00", UsCulture)}\n\n" +
                                 $"¿Deseas abrir esta tarjeta Kardex?";

                if (MessageBox.Show(mensaje, "Vista Rápida — " + k.Nombre, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    NavegacionHelper.NavegarA(this, new frmKardex(k));
                }
            }
            else if (item.InstanciaLibro != null)
            {
                var l = item.InstanciaLibro;
                int movsInventario = l.Asientos.Sum(a => a.Movimientos.Count(m => KardexServicio.EsCuentaInventarioOMercaderia(m.CuentaPrincipal, m.Subcuenta)));

                string mensaje = $"═══════════════════════════════════════\n" +
                                 $"  INFORMACIÓN DEL LIBRO DIARIO\n" +
                                 $"═══════════════════════════════════════\n\n" +
                                 $"• Nombre: {l.Nombre}\n" +
                                 $"• Empresa: {(string.IsNullOrWhiteSpace(l.Empresa) ? "Principal" : l.Empresa)}\n" +
                                 $"• Período: {l.TextoPeriodo}\n" +
                                 $"• Total Asientos: {l.Asientos.Count}\n" +
                                 $"• Movimientos de Inventario detectados: {movsInventario}\n" +
                                 $"• Total Debe: {l.TotalDebe.ToString("$#,##0.00", UsCulture)}\n" +
                                 $"• Total Haber: {l.TotalHaber.ToString("$#,##0.00", UsCulture)}\n\n" +
                                 $"¿Deseas generar la tarjeta Kardex automáticamente a partir de este libro diario?";

                if (MessageBox.Show(mensaje, "Vista Rápida — " + l.Nombre, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    AbrirKardexDesdeLibro(l);
                }
            }
        }
    }

    /// <summary>
    /// Modelo de datos para los elementos del listbox del dashboard de Kardex.
    /// </summary>
    public class KardexDashboardListItem
    {
        public KardexInstancia? InstanciaKardex { get; set; }
        public LibroDiarioInstancia? InstanciaLibro { get; set; }

        public string Titulo { get; set; } = string.Empty;
        public string Subtitulo { get; set; } = string.Empty;
        public string BadgeTipo { get; set; } = string.Empty;
        public string BadgeDestino { get; set; } = string.Empty;
        public bool EsTarjetaKardex { get; set; }
        public decimal MontoPrincipal { get; set; }
        public string UnidadesTexto { get; set; } = string.Empty;
        public string FechaModTexto { get; set; } = string.Empty;
        public bool EsEncabezadoGrupo { get; set; }
        public bool EsPlaceholder { get; set; }
    }

    /// <summary>
    /// Control ListBox personalizado con renderizado estilizado para tarjetas Kardex y Libros Diarios.
    /// </summary>
    public class KardexDashboardListBox : ListBox
    {
        private static readonly CultureInfo UsCulture = new("en-US");
        private static readonly Font _fntTitulo = new("Segoe UI Semibold", 10.5f, FontStyle.Bold);
        private static readonly Font _fntSub = new("Segoe UI", 8.5f);
        private static readonly Font _fntBadge = new("Segoe UI", 8f, FontStyle.Regular);
        private static readonly Font _fntMonto = new("Segoe UI Semibold", 9.5f, FontStyle.Bold);
        private static readonly Font _fntGrupo = new("Segoe UI", 8.5f, FontStyle.Bold);
        private static readonly Font _fntPlaceholder = new("Segoe UI", 9.5f, FontStyle.Italic);

        public KardexDashboardListBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            DoubleBuffered = true;
            BorderStyle = BorderStyle.None;
            ItemHeight = 76;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count) return;
            if (Items[e.Index] is KardexDashboardListItem item && item.EsEncabezadoGrupo)
                e.ItemHeight = 28;
            else
                e.ItemHeight = 76;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count) return;
            if (Items[e.Index] is not KardexDashboardListItem item) return;

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var bounds = e.Bounds;

            // 1. Encabezado de grupo
            if (item.EsEncabezadoGrupo)
            {
                using var brBg = new SolidBrush(Color.FromArgb(241, 245, 249));
                g.FillRectangle(brBg, bounds);
                using var brText = new SolidBrush(Color.FromArgb(100, 116, 139));
                g.DrawString(item.Titulo, _fntGrupo, brText, bounds.X + 16, bounds.Y + 6);

                using var penLine = new Pen(Color.FromArgb(226, 232, 240));
                g.DrawLine(penLine, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
                return;
            }

            // 2. Placeholder
            if (item.EsPlaceholder)
            {
                g.FillRectangle(Brushes.White, bounds);
                using var brText = new SolidBrush(Color.FromArgb(148, 163, 184));
                g.DrawString(item.Titulo, _fntPlaceholder, brText, bounds.X + 20, bounds.Y + 16);
                g.DrawString(item.Subtitulo, _fntSub, brText, bounds.X + 20, bounds.Y + 38);
                return;
            }

            // 3. Item normal
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color bg = selected ? Color.FromArgb(239, 246, 255) : Color.White;
            using (var brBg = new SolidBrush(bg))
            {
                g.FillRectangle(brBg, bounds);
            }

            // Acento lateral: Verde para Kardex, Azul para Libro Diario
            Color accentColor = item.EsTarjetaKardex ? Color.FromArgb(16, 185, 129) : Color.FromArgb(37, 99, 235);
            using (var brAccent = new SolidBrush(accentColor))
            {
                g.FillRectangle(brAccent, bounds.X, bounds.Y + 4, 4, bounds.Height - 8);
            }

            int x = bounds.X + 16;
            int y = bounds.Y + 10;

            // Título
            using (var brTitulo = new SolidBrush(Color.FromArgb(15, 23, 42)))
            {
                g.DrawString(item.Titulo, _fntTitulo, brTitulo, x, y);
            }
            y += 22;

            // Subtítulo
            using (var brSub = new SolidBrush(Color.FromArgb(71, 85, 105)))
            {
                g.DrawString(item.Subtitulo, _fntSub, brSub, x, y);
            }
            y += 18;

            // Badges
            // Badge 1: Tipo ([Tarjeta Kardex] o [Libro Diario])
            Color b1Bg = item.EsTarjetaKardex ? Color.FromArgb(236, 253, 245) : Color.FromArgb(239, 246, 255);
            Color b1Border = item.EsTarjetaKardex ? Color.FromArgb(167, 243, 208) : Color.FromArgb(191, 219, 254);
            Color b1Fg = item.EsTarjetaKardex ? Color.FromArgb(6, 95, 70) : Color.FromArgb(29, 78, 216);

            var sizeB1 = g.MeasureString(item.BadgeTipo, _fntBadge);
            var rectB1 = new RectangleF(x, y, sizeB1.Width + 8, 18);

            using (var brB1 = new SolidBrush(b1Bg))
            using (var penB1 = new Pen(b1Border))
            using (var brB1Text = new SolidBrush(b1Fg))
            {
                g.FillRectangle(brB1, rectB1);
                g.DrawRectangle(penB1, rectB1.X, rectB1.Y, rectB1.Width, rectB1.Height);
                g.DrawString(item.BadgeTipo, _fntBadge, brB1Text, rectB1.X + 4, rectB1.Y + 2);
            }

            // Badge 2: Destino ([Local] o [PostgreSQL])
            float xB2 = rectB1.Right + 8;
            var sizeB2 = g.MeasureString(item.BadgeDestino, _fntBadge);
            var rectB2 = new RectangleF(xB2, y, sizeB2.Width + 8, 18);

            using (var brB2 = new SolidBrush(Color.FromArgb(241, 245, 249)))
            using (var penB2 = new Pen(Color.FromArgb(203, 213, 225)))
            using (var brB2Text = new SolidBrush(Color.FromArgb(51, 65, 85)))
            {
                g.FillRectangle(brB2, rectB2);
                g.DrawRectangle(penB2, rectB2.X, rectB2.Y, rectB2.Width, rectB2.Height);
                g.DrawString(item.BadgeDestino, _fntBadge, brB2Text, rectB2.X + 4, rectB2.Y + 2);
            }

            // Datos a la derecha (Monto / Unidades)
            int rightMargin = bounds.Right - 20;
            string montoTexto = item.MontoPrincipal.ToString("$#,##0.00", UsCulture);
            var sizeMonto = g.MeasureString(montoTexto, _fntMonto);

            using (var brMonto = new SolidBrush(Color.FromArgb(30, 41, 59)))
            {
                g.DrawString(montoTexto, _fntMonto, brMonto, rightMargin - sizeMonto.Width, bounds.Y + 12);
            }

            string unitsText = item.UnidadesTexto;
            var sizeUnits = g.MeasureString(unitsText, _fntSub);
            using (var brUnits = new SolidBrush(Color.FromArgb(100, 116, 139)))
            {
                g.DrawString(unitsText, _fntSub, brUnits, rightMargin - sizeUnits.Width, bounds.Y + 32);
            }

            // Línea separadora inferior de 1px
            using (var penBottom = new Pen(Color.FromArgb(241, 245, 249)))
            {
                g.DrawLine(penBottom, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
            }
        }
    }
}

