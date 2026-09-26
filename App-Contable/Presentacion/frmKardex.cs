using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmKardex : Form
    {
        private static readonly CultureInfo UsCulture = new("en-US");

        // Origen de datos en memoria (BindingList sin llamadas a base de datos)
        private readonly BindingList<KardexItem> _movimientosBase = new();
        private List<KardexItem> _movimientosVisualizados = new();
        private ResumenConciliacionKardex _resumenActual = new();
        private MetodoValuacion _metodoValuacion = MetodoValuacion.PromedioPonderado;

        public frmKardex()
        {
            InitializeComponent();
            ConfigurarFormulario();
            InicializarEstado();
        }

        public frmKardex(LibroDiarioInstancia libro)
        {
            InitializeComponent();
            ConfigurarFormulario();

            lblTituloSeccion.Text = $"KARDEX — {libro.Nombre}";
            dtpFechaInicio.Value = libro.FechaInicio;
            dtpFechaFin.Value = libro.FechaFin;

            _movimientosBase.Clear();
            var resultadoExtraccion = KardexServicio.GenerarKardexDesdeLibroDiario(libro, _metodoValuacion);
            foreach (var m in resultadoExtraccion.MovimientosBase)
            {
                _movimientosBase.Add(m);
            }

            RecalcularYRefrescarGrilla();
        }

        public frmKardex(KardexInstancia tarjeta)
        {
            InitializeComponent();
            ConfigurarFormulario();

            lblTituloSeccion.Text = $"KARDEX — {tarjeta.Nombre}";
            _metodoValuacion = tarjeta.Metodo;
            dtpFechaInicio.Value = tarjeta.FechaInicio;
            dtpFechaFin.Value = tarjeta.FechaFin;

            _movimientosBase.Clear();
            foreach (var m in tarjeta.Movimientos.Where(x => !x.EsFilaEspecial))
            {
                _movimientosBase.Add(m);
            }

            RecalcularYRefrescarGrilla();
        }

        public frmKardex(IEnumerable<KardexItem> movimientos, string titulo, DateTime? inicio = null, DateTime? fin = null)
        {
            InitializeComponent();
            ConfigurarFormulario();

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                lblTituloSeccion.Text = titulo;
            }

            if (inicio.HasValue) dtpFechaInicio.Value = inicio.Value;
            if (fin.HasValue) dtpFechaFin.Value = fin.Value;

            _movimientosBase.Clear();
            foreach (var m in movimientos.Where(x => !x.EsFilaEspecial))
            {
                _movimientosBase.Add(m);
            }

            RecalcularYRefrescarGrilla();
        }

        private void ConfigurarFormulario()
        {
            // Reducir parpadeos de pintado GDI+
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Rango de fechas por defecto
            var hoy = new DateTime(2026, 9, 1);
            dtpFechaInicio.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpFechaFin.Value = new DateTime(hoy.Year, hoy.Month, DateTime.DaysInMonth(hoy.Year, hoy.Month));

            // Configuración de la grilla contable tradicional
            dgvKardex.AutoGenerateColumns = false;
            dgvKardex.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvKardex.ColumnHeadersHeight = 56;
            dgvKardex.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvKardex.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvKardex.DoubleBuffered(true);

            // Desactivar ordenamiento por columnas para preservar la cronología del inventario
            foreach (DataGridViewColumn col in dgvKardex.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Eventos de pintado personalizado e interacción
            dgvKardex.Paint += DgvKardex_Paint;
            dgvKardex.CellPainting += DgvKardex_CellPainting;
            dgvKardex.CellDoubleClick += DgvKardex_CellDoubleClick;
            dgvKardex.Scroll += (s, e) => dgvKardex.Invalidate();
            dgvKardex.ColumnWidthChanged += (s, e) => dgvKardex.Invalidate();
            dgvKardex.Resize += (s, e) => dgvKardex.Invalidate();
        }

        private void InicializarEstado()
        {
            _movimientosBase.Clear();
            RecalcularYRefrescarGrilla();
        }

        private void RecalcularYRefrescarGrilla()
        {
            var fechaInicio = dtpFechaInicio.Value.Date;
            var fechaFin = dtpFechaFin.Value.Date;

            var resultado = KardexServicio.ValuarMovimientos(_movimientosBase, fechaInicio, fechaFin, _metodoValuacion);
            _movimientosVisualizados = resultado.ListaProcesada;
            _resumenActual = resultado.Resumen;

            RenderizarFilasEnGrilla();
            ActualizarBarraResumen();
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
                    ? item.CantidadEntrada.Value.ToString("N0", UsCulture)
                    : "—";

                // 4: Salida Cant
                row.Cells[4].Value = item.CantidadSalida.HasValue && item.CantidadSalida.Value > 0
                    ? item.CantidadSalida.Value.ToString("N0", UsCulture)
                    : "—";

                // 5: Saldo Cant
                row.Cells[5].Value = item.CantidadSaldo.ToString("N0", UsCulture);

                // 6: Costo Unitario (Forzado en USD $#,##0.0000)
                row.Cells[6].Value = item.CostoUnitario.ToString("$#,##0.0000", UsCulture);

                // 7: Debe ($) (Forzado en USD $#,##0.00)
                row.Cells[7].Value = item.Debe.HasValue && item.Debe.Value > 0
                    ? item.Debe.Value.ToString("$#,##0.00", UsCulture)
                    : "—";

                // 8: Haber ($) (Forzado en USD $#,##0.00)
                row.Cells[8].Value = item.Haber.HasValue && item.Haber.Value > 0
                    ? item.Haber.Value.ToString("$#,##0.00", UsCulture)
                    : "—";

                // 9: Saldo Valor ($) (Forzado en USD $#,##0.00)
                row.Cells[9].Value = item.SaldoValor.ToString("$#,##0.00", UsCulture);

                // 10: Origen
                row.Cells[10].Value = item.TextoOrigenBadge;

                // Estilo para fila TOTALES
                if (item.TipoMovimiento == TipoMovimientoKardex.Totales)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }

            dgvKardex.ClearSelection();
        }

        private void ActualizarBarraResumen()
        {
            int cantidadMovimientos = _movimientosBase.Count;
            lblTotalMovimientos.Text = $"Movimientos: {cantidadMovimientos}";

            if (cantidadMovimientos == 0)
            {
                lblTotalEntradas.Text = "Entradas: 0 uds ($0.00)";
                lblTotalSalidas.Text = "Salidas: 0 uds ($0.00)";
                lblSaldoFinal.Text = "Saldo Final: 0 uds ($0.00)";
                lblBadgeEstado.Text = "✓ Kardex Inicializado";
                lblBadgeEstado.ForeColor = Color.FromArgb(71, 85, 105);
            }
            else
            {
                string metodoTexto = _metodoValuacion == MetodoValuacion.PEPS ? "PEPS (FIFO)" : "Costo Promedio Ponderado";
                lblTotalEntradas.Text = $"Entradas: {_resumenActual.TotalEntradasFisicas.ToString("N0", UsCulture)} uds ({_resumenActual.TotalDebe.ToString("$#,##0.00", UsCulture)})";
                lblTotalSalidas.Text = $"Salidas: {_resumenActual.TotalSalidasFisicas.ToString("N0", UsCulture)} uds ({_resumenActual.TotalHaber.ToString("$#,##0.00", UsCulture)})";
                lblSaldoFinal.Text = $"Saldo Final: {_resumenActual.SaldoFisicoFinal.ToString("N0", UsCulture)} uds ({_resumenActual.SaldoValorFinal.ToString("$#,##0.00", UsCulture)})";

                if (_resumenActual.SaldoFisicoFinal < 0)
                {
                    lblBadgeEstado.Text = "⚠ Alerta: Existencias Negativas";
                    lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
                }
                else
                {
                    string costoVentasInfo = _resumenActual.CostoDeVentas > 0 ? $" · Costo Ventas: {_resumenActual.CostoDeVentas.ToString("$#,##0.00", UsCulture)}" : string.Empty;
                    lblBadgeEstado.Text = $"✓ Valuado ({metodoTexto}){costoVentasInfo}";
                    lblBadgeEstado.ForeColor = Color.FromArgb(21, 128, 61);
                }
            }
        }

        #region Doble Encabezado Unificado (Celeste Pastel #C9DAEC Estilo Tradicional)

        private void DgvKardex_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int superHeaderHeight = 28;
            int subHeaderHeight = 28;

            using var fontHeader = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            using var borderPen = new Pen(Color.FromArgb(203, 213, 225)); // Borde #CBD5E1

            Color bgEncabezadoUnificado = Color.FromArgb(201, 218, 236); // Celeste pastel unificado #C9DAEC
            Color textEncabezado = Color.FromArgb(30, 41, 59);          // Texto oscuro nítido #1E293B

            // 1. Super-encabezados agrupados (Nivel 1 - Superior)
            DibujarSuperEncabezado(g, 0, 2, "DATOS DE CONTROL", bgEncabezadoUnificado, textEncabezado, fontHeader, borderPen, superHeaderHeight);
            DibujarSuperEncabezado(g, 3, 5, "CANTIDADES / UNIDADES FÍSICAS", bgEncabezadoUnificado, textEncabezado, fontHeader, borderPen, superHeaderHeight);
            DibujarSuperEncabezado(g, 6, 6, "COSTO", bgEncabezadoUnificado, textEncabezado, fontHeader, borderPen, superHeaderHeight);
            DibujarSuperEncabezado(g, 7, 9, "VALORES MONETARIOS (USD)", bgEncabezadoUnificado, textEncabezado, fontHeader, borderPen, superHeaderHeight);
            DibujarSuperEncabezado(g, 10, 10, "ORIGEN", bgEncabezadoUnificado, textEncabezado, fontHeader, borderPen, superHeaderHeight);

            // 2. Sub-encabezados de cada columna (Nivel 2 - Inferior)
            string[] titulosNivel2 = new string[]
            {
                "Fecha",
                "Concepto / Detalle",
                "Ref / Documento",
                "Entrada (Cant.)",
                "Salida (Cant.)",
                "Saldo (Cant.)",
                "Costo Unit. ($)",
                "Debe ($)",
                "Haber ($)",
                "Saldo Valor ($)",
                "Origen"
            };

            for (int i = 0; i < dgvKardex.Columns.Count; i++)
            {
                if (!dgvKardex.Columns[i].Visible) continue;

                var rectCol = dgvKardex.GetCellDisplayRectangle(i, -1, true);
                if (rectCol.Width <= 0) continue;

                var rectSub = new Rectangle(rectCol.Left, superHeaderHeight, rectCol.Width, subHeaderHeight);

                // Fondo unificado celeste pastel
                using (var brushBg = new SolidBrush(bgEncabezadoUnificado))
                {
                    g.FillRectangle(brushBg, rectSub);
                }

                // Líneas de división de 1px
                g.DrawRectangle(borderPen, rectSub.Left, rectSub.Top, rectSub.Width - 1, rectSub.Height - 1);

                // Texto del subencabezado
                using var brushTexto = new SolidBrush(textEncabezado);
                using var sf = new StringFormat
                {
                    Alignment = (i == 0 || i == 2 || i == 10) ? StringAlignment.Center :
                                (i == 1) ? StringAlignment.Near : StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                };

                var rectTexto = new Rectangle(rectSub.Left + 4, rectSub.Top, rectSub.Width - 8, rectSub.Height);
                g.DrawString(titulosNivel2[i], fontHeader, brushTexto, rectTexto, sf);
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

            using (var brush = new SolidBrush(colorFondo))
            {
                g.FillRectangle(brush, rectSuper);
            }

            g.DrawRectangle(borderPen, rectSuper.Left, rectSuper.Top, rectSuper.Width - 1, rectSuper.Height - 1);

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

        #region Pintado de Celdas (Cuadrícula Contable Tradicional y Etiquetas Rectangulares Planas)

        private void DgvKardex_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null) return;

            var row = dgvKardex.Rows[e.RowIndex];
            var item = row.Tag as KardexItem;
            if (item == null) return;

            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 1. Columna "Origen" (Etiqueta Rectangular Plana y Sobria con Bordes Rectos de 1px)
            if (e.ColumnIndex == 10)
            {
                e.PaintBackground(e.ClipBounds, true);

                if (!item.EsFilaEspecial && !string.IsNullOrEmpty(item.TextoOrigenBadge))
                {
                    bool esAuto = item.Origen == TipoOrigenKardex.AutoLibroDiario;

                    // Colores planos y sobrios
                    Color badgeBg = esAuto ? Color.FromArgb(241, 245, 249) : Color.FromArgb(250, 245, 255);       // Fondo #F1F5F9 o #FAF5FF
                    Color badgeBorder = esAuto ? Color.FromArgb(203, 213, 225) : Color.FromArgb(221, 214, 254);   // Borde #CBD5E1 o #DDD6FE
                    Color badgeText = esAuto ? Color.FromArgb(51, 65, 85) : Color.FromArgb(109, 40, 217);          // Texto #334155 o #6D28D9

                    var badgeRect = new Rectangle(e.CellBounds.Left + 6, e.CellBounds.Top + 4, e.CellBounds.Width - 12, e.CellBounds.Height - 8);

                    using var brushBg = new SolidBrush(badgeBg);
                    using var penBorder = new Pen(badgeBorder, 1f);
                    using var brushText = new SolidBrush(badgeText);
                    using var fontBadge = new Font("Segoe UI", 8.25f, FontStyle.Regular);

                    // Relleno rectangular plano
                    e.Graphics.FillRectangle(brushBg, badgeRect);
                    // Borde recto de 1px
                    e.Graphics.DrawRectangle(penBorder, badgeRect.Left, badgeRect.Top, badgeRect.Width - 1, badgeRect.Height - 1);

                    // Texto centrado limpio
                    using var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(item.TextoOrigenBadge, fontBadge, brushText, badgeRect, sf);
                }

                // Dibujar líneas divisorias de la cuadrícula contable de 1px
                using (var penGrid = new Pen(Color.FromArgb(203, 213, 225), 1f))
                {
                    e.Graphics.DrawLine(penGrid, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(penGrid, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                }

                e.Handled = true;
                return;
            }

            // 2. Fondo blanco y formato de valores sobre la cuadrícula
            e.PaintBackground(e.ClipBounds, true);

            string valorTexto = e.Value?.ToString() ?? string.Empty;
            Color colorTexto = Color.FromArgb(30, 41, 59);
            Font fontCelda = new Font("Segoe UI", 9f, FontStyle.Regular);
            StringAlignment alineacionHorizontal = StringAlignment.Far;

            bool esTotales = item.TipoMovimiento == TipoMovimientoKardex.Totales;
            bool esSaldoInicialOFinal = item.TipoMovimiento == TipoMovimientoKardex.SaldoFinalPeriodo ||
                                        item.TipoMovimiento == TipoMovimientoKardex.InventarioInicial;

            switch (e.ColumnIndex)
            {
                case 0: // Fecha / TOTALES
                    alineacionHorizontal = StringAlignment.Center;
                    if (esTotales)
                    {
                        fontCelda = new Font("Segoe UI", 9f, FontStyle.Bold);
                        colorTexto = Color.FromArgb(15, 23, 42);
                    }
                    break;

                case 1: // Concepto
                    alineacionHorizontal = StringAlignment.Near;
                    if (esTotales || esSaldoInicialOFinal)
                    {
                        fontCelda = new Font("Segoe UI", 9f, FontStyle.Bold);
                        colorTexto = Color.FromArgb(15, 23, 42);
                    }
                    break;

                case 2: // Ref / Documento
                    alineacionHorizontal = StringAlignment.Center;
                    colorTexto = Color.FromArgb(71, 85, 105);
                    break;

                case 3: // Entrada (Cant.) -> Verde bosque mate (#15803D)
                    if (valorTexto != "—")
                    {
                        colorTexto = Color.FromArgb(21, 128, 61);
                        fontCelda = new Font("Segoe UI", 9f, FontStyle.Bold);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(148, 163, 184);
                    }
                    break;

                case 4: // Salida (Cant.) -> Rojo teja (#B91C1C)
                    if (valorTexto != "—")
                    {
                        colorTexto = Color.FromArgb(185, 28, 28);
                        fontCelda = new Font("Segoe UI", 9f, FontStyle.Bold);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(148, 163, 184);
                    }
                    break;

                case 5: // Saldo (Cant.) -> Negro carbón (#0F172A)
                    fontCelda = new Font("Segoe UI", 9f, FontStyle.Bold);
                    colorTexto = Color.FromArgb(15, 23, 42);
                    break;

                case 6: // Costo Unitario
                    colorTexto = Color.FromArgb(30, 41, 59);
                    break;

                case 7: // Debe ($) -> Azul contable (#1D4ED8)
                    if (valorTexto != "—")
                    {
                        colorTexto = Color.FromArgb(29, 78, 216);
                        fontCelda = new Font("Segoe UI", 9f, FontStyle.Bold);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(148, 163, 184);
                    }
                    break;

                case 8: // Haber ($) -> Naranja quemado (#C2410C)
                    if (valorTexto != "—")
                    {
                        colorTexto = Color.FromArgb(194, 65, 12);
                        fontCelda = new Font("Segoe UI", 9f, FontStyle.Bold);
                    }
                    else
                    {
                        colorTexto = Color.FromArgb(148, 163, 184);
                    }
                    break;

                case 9: // Saldo Valor ($) -> Negro carbón (#0F172A)
                    fontCelda = new Font("Segoe UI", 9f, FontStyle.Bold);
                    colorTexto = Color.FromArgb(15, 23, 42);
                    break;
            }

            // Margen y alineación del texto
            var cellRect = new Rectangle(e.CellBounds.Left + 4, e.CellBounds.Top, e.CellBounds.Width - 8, e.CellBounds.Height);
            using (var brushTexto = new SolidBrush(colorTexto))
            using (var sf = new StringFormat
            {
                Alignment = alineacionHorizontal,
                LineAlignment = StringAlignment.Center
            })
            {
                e.Graphics.DrawString(valorTexto, fontCelda, brushTexto, cellRect, sf);
            }

            // Dibujar líneas de cuadrícula contable de 1px (#CBD5E1)
            using (var penGrid = new Pen(Color.FromArgb(203, 213, 225), 1f))
            {
                e.Graphics.DrawLine(penGrid, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                e.Graphics.DrawLine(penGrid, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
            }

            e.Handled = true;
        }

        #endregion

        #region Eventos de Botones de Acción (Volver, Nuevo, Editar, Eliminar, Reordenar, Cargar Ejemplo)

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            NavegacionHelper.NavegarA(this, new frmInicioKardex());
        }

        private void btnNuevoMovimiento_Click(object sender, EventArgs e)
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

        private void btnEditarMovimiento_Click(object sender, EventArgs e)
        {
            if (dgvKardex.CurrentRow?.Tag is not KardexItem item || item.EsFilaEspecial)
            {
                MessageBox.Show("Por favor seleccione un movimiento operativo para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var itemExistente = _movimientosBase.FirstOrDefault(m => m.Id == item.Id);
            if (itemExistente == null)
            {
                MessageBox.Show("No se encontró el registro seleccionado en la lista de movimientos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal stockActual = _resumenActual.SaldoFisicoFinal;
            decimal costoPromedio = _resumenActual.UltimoCostoPromedio;
            decimal saldoValorActual = _resumenActual.SaldoValorFinal;

            using var formModal = new frmAgregarMovimientoKardex(itemExistente, stockActual, costoPromedio, saldoValorActual);
            if (formModal.ShowDialog(this) == DialogResult.OK && formModal.MovimientoCreado != null)
            {
                int index = _movimientosBase.IndexOf(itemExistente);
                if (index >= 0)
                {
                    _movimientosBase[index] = formModal.MovimientoCreado;
                }
                RecalcularYRefrescarGrilla();
            }
        }

        private void DgvKardex_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditarMovimiento_Click(this, EventArgs.Empty);
            }
        }

        private void btnEliminarMovimiento_Click(object sender, EventArgs e)
        {
            if (dgvKardex.CurrentRow?.Tag is not KardexItem item || item.EsFilaEspecial)
            {
                MessageBox.Show("Por favor seleccione un movimiento operativo para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el movimiento?\n\n• Concepto: {item.Concepto}\n• Documento: {item.Documento}\n• Fecha: {item.Fecha:dd/MM/yyyy}",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                var itemAEliminar = _movimientosBase.FirstOrDefault(m => m.Id == item.Id);
                if (itemAEliminar != null)
                {
                    _movimientosBase.Remove(itemAEliminar);
                    RecalcularYRefrescarGrilla();
                    MessageBox.Show("Movimiento eliminado correctamente y saldos recalculados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSubirMovimiento_Click(object sender, EventArgs e)
        {
            if (dgvKardex.CurrentRow?.Tag is not KardexItem item || item.EsFilaEspecial) return;

            var itemObj = _movimientosBase.FirstOrDefault(m => m.Id == item.Id);
            if (itemObj == null) return;

            int index = _movimientosBase.IndexOf(itemObj);
            if (index > 0)
            {
                _movimientosBase.RemoveAt(index);
                _movimientosBase.Insert(index - 1, itemObj);
                RecalcularYRefrescarGrilla();
                SeleccionarFilaPorId(itemObj.Id);
            }
        }

        private void btnBajarMovimiento_Click(object sender, EventArgs e)
        {
            if (dgvKardex.CurrentRow?.Tag is not KardexItem item || item.EsFilaEspecial) return;

            var itemObj = _movimientosBase.FirstOrDefault(m => m.Id == item.Id);
            if (itemObj == null) return;

            int index = _movimientosBase.IndexOf(itemObj);
            if (index >= 0 && index < _movimientosBase.Count - 1)
            {
                _movimientosBase.RemoveAt(index);
                _movimientosBase.Insert(index + 1, itemObj);
                RecalcularYRefrescarGrilla();
                SeleccionarFilaPorId(itemObj.Id);
            }
        }

        private void SeleccionarFilaPorId(long id)
        {
            foreach (DataGridViewRow row in dgvKardex.Rows)
            {
                if (row.Tag is KardexItem k && k.Id == id)
                {
                    row.Selected = true;
                    dgvKardex.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void btnCargarEjemplo_Click(object sender, EventArgs e)
        {
            _movimientosBase.Clear();
            var demo = KardexCalculador.ObtenerDatosSemillaEjemplo();
            foreach (var d in demo)
            {
                _movimientosBase.Add(d);
            }
            RecalcularYRefrescarGrilla();
            MessageBox.Show("Se han cargado los movimientos de ejemplo en la Tarjeta Kardex.", "Datos Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            RecalcularYRefrescarGrilla();
        }

        #endregion
    }

    /// <summary>
    /// Extensión para habilitar doble buffer en controles DataGridView de WinForms sin modificar CreateParams ni WndProc.
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

