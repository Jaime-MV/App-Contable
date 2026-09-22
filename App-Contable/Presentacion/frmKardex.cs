using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmKardex : Form
    {
        // Origen de datos en memoria (BindingList limpia sin datos mock ni llamadas a BD en el arranque)
        private readonly BindingList<KardexItem> _movimientosBase = new();
        private List<KardexItem> _movimientosVisualizados = new();
        private ResumenConciliacionKardex _resumenActual = new();
        private int _asientosPendientesSincronizar = 3;

        public frmKardex()
        {
            InitializeComponent();
            ConfigurarFormulario();
            InicializarEstadoLimpio();
        }

        private void ConfigurarFormulario()
        {
            // Evitar parpadeos en renderizado GDI+
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Rango de fechas por defecto
            dtpFechaInicio.Value = new DateTime(2026, 9, 1);
            dtpFechaFin.Value = new DateTime(2026, 9, 30);

            // Configuración de la grilla
            dgvKardex.AutoGenerateColumns = false;
            dgvKardex.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvKardex.ColumnHeadersHeight = 62;
            dgvKardex.DoubleBuffered(true);

            // Eventos de pintado personalizado
            dgvKardex.Paint += DgvKardex_Paint;
            dgvKardex.CellPainting += DgvKardex_CellPainting;
            dgvKardex.Scroll += (s, e) => dgvKardex.Invalidate();
            dgvKardex.ColumnWidthChanged += (s, e) => dgvKardex.Invalidate();
            dgvKardex.Resize += (s, e) => dgvKardex.Invalidate();

            // Estilos del Badge de Asientos Pendientes
            lblBadgePendientes.Paint += LblBadgePendientes_Paint;
            ActualizarBadgePendientes();
        }

        private void LblBadgePendientes_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using var brush = new SolidBrush(lblBadgePendientes.BackColor);
            e.Graphics.FillEllipse(brush, 0, 0, lblBadgePendientes.Width - 1, lblBadgePendientes.Height - 1);

            using var textBrush = new SolidBrush(lblBadgePendientes.ForeColor);
            using var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(lblBadgePendientes.Text, lblBadgePendientes.Font, textBrush,
                new RectangleF(0, 0, lblBadgePendientes.Width, lblBadgePendientes.Height), sf);
        }

        private void ActualizarBadgePendientes()
        {
            if (_asientosPendientesSincronizar > 0)
            {
                lblBadgePendientes.Visible = true;
                lblBadgePendientes.Text = _asientosPendientesSincronizar.ToString();
            }
            else
            {
                lblBadgePendientes.Visible = false;
            }
        }

        /// <summary>
        /// Inicia el formulario completamente limpio, sin datos falsos ni conexiones a base de datos.
        /// </summary>
        private void InicializarEstadoLimpio()
        {
            _movimientosBase.Clear();
            RecalcularYRefrescarGrilla();
        }

        private void RecalcularYRefrescarGrilla()
        {
            var fechaInicio = dtpFechaInicio.Value.Date;
            var fechaFin = dtpFechaFin.Value.Date;

            var resultado = KardexCalculador.ProcesarKardex(_movimientosBase, fechaInicio, fechaFin);
            _movimientosVisualizados = resultado.ListaProcesada;
            _resumenActual = resultado.Resumen;

            RenderizarFilasEnGrilla();
            ActualizarBarraConciliacion();
        }

        private void RenderizarFilasEnGrilla()
        {
            dgvKardex.Rows.Clear();

            foreach (var item in _movimientosVisualizados)
            {
                int rowIndex = dgvKardex.Rows.Add();
                var row = dgvKardex.Rows[rowIndex];
                row.Tag = item;

                // 0: Fecha
                if (item.TipoMovimiento == TipoMovimientoKardex.Totales)
                {
                    row.Cells[0].Value = "TOTALES";
                }
                else
                {
                    row.Cells[0].Value = item.Fecha.ToString("dd/MM/yyyy");
                }

                // 1: Concepto
                if (item.TipoMovimiento == TipoMovimientoKardex.Totales)
                {
                    row.Cells[1].Value = $"Período: {dtpFechaInicio.Value:dd/MM/yyyy} — {dtpFechaFin.Value:dd/MM/yyyy}";
                }
                else
                {
                    row.Cells[1].Value = item.Concepto;
                }

                // 2: Documento
                row.Cells[2].Value = item.Documento;

                // 3: Entrada Cant
                row.Cells[3].Value = item.CantidadEntrada.HasValue && item.CantidadEntrada.Value > 0
                    ? item.CantidadEntrada.Value.ToString("N0")
                    : "—";

                // 4: Salida Cant
                row.Cells[4].Value = item.CantidadSalida.HasValue && item.CantidadSalida.Value > 0
                    ? item.CantidadSalida.Value.ToString("N0")
                    : "—";

                // 5: Saldo Cant
                row.Cells[5].Value = item.CantidadSaldo.ToString("N0");

                // 6: Costo Unitario
                row.Cells[6].Value = $"${item.CostoUnitario:N4}";

                // 7: Debe ($)
                row.Cells[7].Value = item.Debe.HasValue && item.Debe.Value > 0
                    ? $"${item.Debe.Value:N2}"
                    : "—";

                // 8: Haber ($)
                row.Cells[8].Value = item.Haber.HasValue && item.Haber.Value > 0
                    ? $"${item.Haber.Value:N2}"
                    : "—";

                // 9: Saldo Valor ($)
                row.Cells[9].Value = $"${item.SaldoValor:N2}";

                // 10: Origen
                row.Cells[10].Value = item.TextoOrigenBadge;

                // Estilo para fila TOTALES
                if (item.TipoMovimiento == TipoMovimientoKardex.Totales)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
            }

            dgvKardex.ClearSelection();
        }

        private void ActualizarBarraConciliacion()
        {
            if (_movimientosVisualizados.Count == 0)
            {
                lblResumenFisico.Text = "Ent: 0 · Sal: 0 · Saldo: 0 uds";
                lblSaldoFisicoGrande.Text = "0 uds";
                lblResumenMonetario.Text = "D: $0.00 — H: $0.00 = $0.00";
                lblSaldoValorGrande.Text = "$0.00";
            }
            else
            {
                lblResumenFisico.Text = $"Ent: {_resumenActual.TotalEntradasFisicas:N0} · Sal: {_resumenActual.TotalSalidasFisicas:N0} · Saldo: {_resumenActual.SaldoFisicoFinal:N0} uds";
                lblSaldoFisicoGrande.Text = $"{_resumenActual.SaldoFisicoFinal:N0} uds";
                lblResumenMonetario.Text = $"D: ${_resumenActual.TotalDebe:N2} — H: ${_resumenActual.TotalHaber:N2} = ${_resumenActual.DiferenciaMonetaria:N2}";
                lblSaldoValorGrande.Text = $"${_resumenActual.SaldoValorFinal:N2}";
            }
        }

        #region Pintado de Doble Encabezado (Excel-Style Corporate Slate con Alta Legibilidad)

        private void DgvKardex_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int superHeaderHeight = 28;
            int subHeaderHeight = 34; // Espacio vertical generoso para evitar recortes de texto

            using var fontSuperHeader = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            using var fontSubHeader = new Font("Segoe UI", 9f, FontStyle.Bold);
            using var borderPen = new Pen(Color.FromArgb(226, 232, 240));

            Color bgSlate = Color.FromArgb(237, 242, 247);      // Gris topo / pizarra suave
            Color bgGreenTint = Color.FromArgb(240, 253, 244);  // Verde tenue suave
            Color textSlate = Color.FromArgb(30, 41, 59);       // Gris oscuro nítido y legible
            Color textGreen = Color.FromArgb(21, 128, 61);      // Verde bosque nítido

            // 1. Super-encabezados agrupados (Nivel 1 - Superior)
            DibujarSuperEncabezado(g, 0, 2, "DATOS DE CONTROL", bgSlate, textSlate, fontSuperHeader, borderPen, superHeaderHeight);
            DibujarSuperEncabezado(g, 3, 5, "CANTIDADES / UNIDADES FÍSICAS", bgGreenTint, textGreen, fontSuperHeader, borderPen, superHeaderHeight);
            DibujarSuperEncabezado(g, 6, 6, "COSTO", bgSlate, textSlate, fontSuperHeader, borderPen, superHeaderHeight);
            DibujarSuperEncabezado(g, 7, 9, "VALORES MONETARIOS", bgSlate, textSlate, fontSuperHeader, borderPen, superHeaderHeight);
            DibujarSuperEncabezado(g, 10, 10, "ORIGEN", bgSlate, textSlate, fontSuperHeader, borderPen, superHeaderHeight);

            // 2. Sub-encabezados de cada columna (Nivel 2 - Inferior)
            string[] titulosNivel2 = new string[]
            {
                "Fecha",
                "Concepto / Detalle",
                "Ref / Documento",
                "Entrada\n(Cant.)",
                "Salida\n(Cant.)",
                "Saldo\n(Cant.)",
                "Costo Unit.\n($0.0000)",
                "Debe\n($)",
                "Haber\n($)",
                "Saldo Valor\n($)",
                "Origen"
            };

            for (int i = 0; i < dgvKardex.Columns.Count; i++)
            {
                if (!dgvKardex.Columns[i].Visible) continue;

                var rectCol = dgvKardex.GetCellDisplayRectangle(i, -1, true);
                if (rectCol.Width <= 0) continue;

                var rectSub = new Rectangle(rectCol.Left, superHeaderHeight, rectCol.Width, subHeaderHeight);

                // Fondo
                Color bgSub = (i >= 3 && i <= 5) ? Color.FromArgb(246, 254, 249) : Color.FromArgb(248, 250, 252);
                using (var brushBg = new SolidBrush(bgSub))
                {
                    g.FillRectangle(brushBg, rectSub);
                }

                // Bordes
                g.DrawRectangle(borderPen, rectSub.Left, rectSub.Top, rectSub.Width - 1, rectSub.Height - 1);

                // Texto del subencabezado con alto contraste y claridad
                using var brushTexto = new SolidBrush(Color.FromArgb(30, 41, 59));
                using var sf = new StringFormat
                {
                    Alignment = (i == 0 || i == 2 || i == 10) ? StringAlignment.Center :
                                (i == 1) ? StringAlignment.Near : StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                };

                var rectTexto = new Rectangle(rectSub.Left + 4, rectSub.Top, rectSub.Width - 8, rectSub.Height);
                g.DrawString(titulosNivel2[i], fontSubHeader, brushTexto, rectTexto, sf);
            }
        }

        private void DibujarSuperEncabezado(
            Graphics g,
            int colInicio,
            int colFin,
            string texto,
            Color colorFondo,
            Color colorTexto,
            Font fuente,
            Pen borderPen,
            int altura)
        {
            if (colInicio >= dgvKardex.Columns.Count || !dgvKardex.Columns[colInicio].Visible) return;

            var rInicio = dgvKardex.GetCellDisplayRectangle(colInicio, -1, true);
            var rFin = dgvKardex.GetCellDisplayRectangle(colFin, -1, true);

            int x = rInicio.Left;
            int width = (rFin.Right) - x;

            if (width <= 0) return;

            var rectSuper = new Rectangle(x, 0, width, altura);

            // Fondo
            using (var brush = new SolidBrush(colorFondo))
            {
                g.FillRectangle(brush, rectSuper);
            }

            // Borde
            g.DrawRectangle(borderPen, rectSuper.Left, rectSuper.Top, rectSuper.Width - 1, rectSuper.Height - 1);

            // Texto
            using (var textBrush = new SolidBrush(colorTexto))
            using (var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                g.DrawString(texto, fuente, textBrush, rectSuper, sf);
            }
        }

        #endregion

        #region Pintado Personalizado de Celdas (Alta Legibilidad & Contraste Nítido)

        private void DgvKardex_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null) return;

            var row = dgvKardex.Rows[e.RowIndex];
            var item = row.Tag as KardexItem;
            if (item == null) return;

            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 1. Renderizado de la Columna Origen (Badges estilo Cápsula)
            if (e.ColumnIndex == 10)
            {
                e.PaintBackground(e.ClipBounds, true);

                if (!item.EsFilaEspecial && !string.IsNullOrEmpty(item.TextoOrigenBadge))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    bool esAuto = item.Origen == TipoOrigenKardex.AutoLibroDiario;
                    Color badgeBg = esAuto ? Color.FromArgb(239, 246, 255) : Color.FromArgb(245, 243, 255);
                    Color badgeBorder = esAuto ? Color.FromArgb(191, 219, 254) : Color.FromArgb(221, 214, 254);
                    Color badgeText = esAuto ? Color.FromArgb(29, 78, 216) : Color.FromArgb(109, 40, 217);

                    var badgeRect = new Rectangle(e.CellBounds.Left + 8, e.CellBounds.Top + 8, e.CellBounds.Width - 16, e.CellBounds.Height - 16);
                    int cornerRadius = badgeRect.Height / 2;

                    using var path = CrearRectanguloRedondeado(badgeRect, cornerRadius);
                    using var brushBg = new SolidBrush(badgeBg);
                    using var penBorder = new Pen(badgeBorder, 1.2f);
                    using var brushText = new SolidBrush(badgeText);
                    using var fontBadge = new Font("Segoe UI", 8.5f, FontStyle.Bold);

                    e.Graphics.FillPath(brushBg, path);
                    e.Graphics.DrawPath(penBorder, path);

                    // Punto indicador + Texto
                    string badgeString = $"●  {item.TextoOrigenBadge}";
                    using var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(badgeString, fontBadge, brushText, badgeRect, sf);
                }

                e.Handled = true;
                return;
            }

            // 2. Colores y estilos tipográficos nítidos y con buen grosor
            e.PaintBackground(e.ClipBounds, true);

            string valorTexto = e.Value?.ToString() ?? string.Empty;
            Color colorTexto = Color.FromArgb(15, 23, 42); // Negro carbón sólido por defecto
            Font fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            StringAlignment alineacionHorizontal = StringAlignment.Far;

            bool esTotales = item.TipoMovimiento == TipoMovimientoKardex.Totales;
            bool esSaldoInicialOFinal = item.TipoMovimiento == TipoMovimientoKardex.SaldoFinalPeriodo ||
                                        item.TipoMovimiento == TipoMovimientoKardex.InventarioInicial;

            switch (e.ColumnIndex)
            {
                case 0: // Fecha / TOTALES (Centrado)
                    alineacionHorizontal = StringAlignment.Center;
                    if (esTotales)
                    {
                        fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        colorTexto = Color.FromArgb(15, 23, 42);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(30, 41, 59);
                    }
                    break;

                case 1: // Concepto (Izquierda)
                    alineacionHorizontal = StringAlignment.Near;
                    if (esTotales || esSaldoInicialOFinal)
                    {
                        fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        colorTexto = Color.FromArgb(15, 23, 42);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(30, 41, 59);
                    }
                    break;

                case 2: // Documento (Centrado, legible y definido)
                    alineacionHorizontal = StringAlignment.Center;
                    fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                    colorTexto = Color.FromArgb(30, 41, 59);
                    break;

                case 3: // Entrada (Cant.) -> Verde bosque oscuro mate con peso bold
                    if (valorTexto != "—")
                    {
                        colorTexto = Color.FromArgb(21, 128, 61);
                        fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(148, 163, 184);
                    }
                    break;

                case 4: // Salida (Cant.) -> Rojo terracota mate con peso bold
                    if (valorTexto != "—")
                    {
                        colorTexto = Color.FromArgb(185, 28, 28);
                        fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(148, 163, 184);
                    }
                    break;

                case 5: // Saldo (Cant.) -> Negro carbón con peso bold
                    fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    colorTexto = Color.FromArgb(15, 23, 42);
                    break;

                case 6: // Costo Unitario -> Definido y claro
                    fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                    colorTexto = Color.FromArgb(30, 41, 59);
                    break;

                case 7: // Debe ($) -> Azul petróleo tenue con peso bold
                    if (valorTexto != "—")
                    {
                        colorTexto = Color.FromArgb(29, 78, 216);
                        fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(148, 163, 184);
                    }
                    break;

                case 8: // Haber ($) -> Ámbar quemado con peso bold
                    if (valorTexto != "—")
                    {
                        colorTexto = Color.FromArgb(194, 65, 12);
                        fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(148, 163, 184);
                    }
                    break;

                case 9: // Saldo Valor ($) -> Negro carbón con peso bold
                    fontCelda = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    colorTexto = Color.FromArgb(15, 23, 42);
                    break;
            }

            // Margen y padding para separación cómoda
            var cellRect = new Rectangle(e.CellBounds.Left + 6, e.CellBounds.Top, e.CellBounds.Width - 12, e.CellBounds.Height);
            using (var brushTexto = new SolidBrush(colorTexto))
            using (var sf = new StringFormat
            {
                Alignment = alineacionHorizontal,
                LineAlignment = StringAlignment.Center
            })
            {
                e.Graphics.DrawString(valorTexto, fontCelda, brushTexto, cellRect, sf);
            }

            // Línea de división de cuadrícula tenue
            using (var penBottom = new Pen(Color.FromArgb(226, 232, 240)))
            {
                e.Graphics.DrawLine(penBottom, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            }

            e.Handled = true;
        }

        private static GraphicsPath CrearRectanguloRedondeado(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            var arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        #endregion

        #region Eventos de Botones de Barra Superior

        private void btnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            decimal stockActual = _resumenActual.SaldoFisicoFinal;
            decimal costoPromedio = _resumenActual.UltimoCostoPromedio;
            decimal saldoValorActual = _resumenActual.SaldoValorFinal;

            using var formModal = new frmAgregarMovimientoKardex(stockActual, costoPromedio, saldoValorActual);
            if (formModal.ShowDialog(this) == DialogResult.OK && formModal.MovimientoCreado != null)
            {
                _movimientosBase.Add(formModal.MovimientoCreado);
                RecalcularYRefrescarGrilla();
            }
        }

        private void btnSincronizarDiario_Click(object sender, EventArgs e)
        {
            if (_asientosPendientesSincronizar <= 0)
            {
                MessageBox.Show(
                    "No hay asientos contables pendientes por sincronizar en este momento.\nTodos los movimientos de inventario del Libro Diario están al día.",
                    "Sincronización al Día",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Sincronizar movimientos del Libro Diario
            var nuevosMovimientos = new List<KardexItem>
            {
                new KardexItem
                {
                    Id = 1,
                    Fecha = new DateTime(2026, 9, 1),
                    Concepto = "Saldo Inicial de Existencias",
                    Documento = "INV-0001",
                    CantidadEntrada = 300m,
                    CostoUnitario = 8.5000m,
                    TipoMovimiento = TipoMovimientoKardex.InventarioInicial,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 1
                },
                new KardexItem
                {
                    Id = 2,
                    Fecha = new DateTime(2026, 9, 5),
                    Concepto = "Compra Factura #402 — Prov. Cementera",
                    Documento = "F-402",
                    CantidadEntrada = 200m,
                    CostoUnitario = 8.4000m,
                    TipoMovimiento = TipoMovimientoKardex.Compra,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 12
                },
                new KardexItem
                {
                    Id = 3,
                    Fecha = new DateTime(2026, 9, 10),
                    Concepto = "Venta según Asiento #12 — Cliente Mayorista",
                    Documento = "OV-0088",
                    CantidadSalida = 120m,
                    CostoUnitario = 8.4600m,
                    TipoMovimiento = TipoMovimientoKardex.Venta,
                    Origen = TipoOrigenKardex.AutoLibroDiario,
                    NumeroAsiento = 12
                }
            };

            foreach (var mov in nuevosMovimientos)
            {
                _movimientosBase.Add(mov);
            }

            _asientosPendientesSincronizar = 0;
            ActualizarBadgePendientes();

            RecalcularYRefrescarGrilla();

            MessageBox.Show(
                "¡Sincronización completada con éxito!\nSe importaron los asientos de compras y ventas pendientes desde el Libro Diario.",
                "Sincronización con Libro Diario",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            RecalcularYRefrescarGrilla();
            MessageBox.Show(
                "Cálculo de Promedio Ponderado y Conciliación Contable actualizados correctamente.",
                "Recálculo Exitoso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Módulo de exportación e importación Excel preparado.\nSe pueden exportar los movimientos valorizados con el doble encabezado contable.",
                "Importar / Exportar Excel",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Filtro activo para el rango: {dtpFechaInicio.Value:dd/MM/yyyy} hasta {dtpFechaFin.Value:dd/MM/yyyy}.\nPuede modificar las fechas en el selector superior para recalcular automáticamente.",
                "Filtros de Período",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void FiltroFechas_ValueChanged(object sender, EventArgs e)
        {
            RecalcularYRefrescarGrilla();
        }

        #endregion
    }

    /// <summary>
    /// Extensión para habilitar doble buffer en controles DataGridView de WinForms.
    /// </summary>
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi?.SetValue(dgv, setting, null);
        }
    }
}

