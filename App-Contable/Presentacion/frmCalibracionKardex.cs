using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmCalibracionKardex : Form
    {
        private static readonly CultureInfo UsCulture = new("en-US");
        private readonly LibroDiarioInstancia _libro;
        private readonly List<ItemCalibracionKardex> _items = new();

        /// <summary>
        /// Instancia generada y valuada del Kardex tras la confirmación de la calibración.
        /// </summary>
        public KardexInstancia? KardexGenerado { get; private set; }

        public MetodoValuacion MetodoSeleccionado =>
            cboMetodoValuacion.SelectedIndex == 1 ? MetodoValuacion.PEPS : MetodoValuacion.PromedioPonderado;

        public frmCalibracionKardex(LibroDiarioInstancia libro)
        {
            InitializeComponent();
            _libro = libro ?? throw new ArgumentNullException(nameof(libro));

            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            // Métodos de valuación disponibles
            cboMetodoValuacion.Items.Clear();
            cboMetodoValuacion.Items.Add("Costo Promedio Ponderado");
            cboMetodoValuacion.Items.Add("PEPS / FIFO (Primeras Entradas, Primeras Salidas)");
            cboMetodoValuacion.SelectedIndex = 0;
            cboMetodoValuacion.SelectedIndexChanged += (s, e) => ActualizarResumenPreview();

            // Configuración del DataGridView
            dgvCalibracion.AutoGenerateColumns = false;
            dgvCalibracion.DoubleBuffered(true);

            dgvCalibracion.CellValueChanged += DgvCalibracion_CellValueChanged;
            dgvCalibracion.CellEndEdit += (s, e) => ActualizarResumenPreview();

            btnProcesar.Click += (s, e) => ProcesarGeneracion();
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            // Bordes y separadores estéticos
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

        private void CargarDatos()
        {
            _items.Clear();
            var itemsExtraidos = KardexServicio.ExtraerItemsParaCalibracion(_libro);

            if (!itemsExtraidos.Any())
            {
                // Si no se detectaron movimientos automáticos, agregar una fila por defecto
                _items.Add(new ItemCalibracionKardex
                {
                    NumeroAsiento = 1,
                    Fecha = _libro.FechaInicio,
                    TipoMovimiento = TipoMovimientoKardex.InventarioInicial,
                    TipoMovimientoTexto = "Inventario Inicial",
                    Concepto = "Inventario Inicial",
                    MontoContable = 6000.00m,
                    Cantidad = 678m,
                    CostoUnitario = 8.85m,
                    EsEntrada = true
                });
            }
            else
            {
                _items.AddRange(itemsExtraidos);
            }

            RenderizarGrilla();
            ActualizarResumenPreview();
        }

        private void RenderizarGrilla()
        {
            dgvCalibracion.Rows.Clear();

            foreach (var itm in _items)
            {
                int rIdx = dgvCalibracion.Rows.Add();
                var row = dgvCalibracion.Rows[rIdx];
                row.Tag = itm;

                row.Cells[0].Value = itm.PartidaTexto;
                row.Cells[1].Value = itm.FechaTexto;
                row.Cells[2].Value = itm.TipoMovimientoTexto;
                row.Cells[3].Value = itm.MontoContable.ToString("$#,##0.00", UsCulture);
                row.Cells[4].Value = itm.Cantidad.ToString("N0", UsCulture);
                row.Cells[5].Value = itm.CostoUnitario.ToString("$#,##0.00", UsCulture);

                // Destacar celdas editables
                row.Cells[4].Style.BackColor = Color.FromArgb(240, 253, 244);
                row.Cells[4].Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                row.Cells[4].Style.ForeColor = Color.FromArgb(21, 128, 61);

                row.Cells[5].Style.BackColor = Color.FromArgb(254, 242, 242);
                row.Cells[5].Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                row.Cells[5].Style.ForeColor = Color.FromArgb(185, 28, 28);
            }
        }

        private void DgvCalibracion_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCalibracion.Rows.Count) return;

            var row = dgvCalibracion.Rows[e.RowIndex];
            if (row.Tag is not ItemCalibracionKardex itm) return;

            // Edición de Cantidad (Columna 4)
            if (e.ColumnIndex == 4)
            {
                string raw = row.Cells[4].Value?.ToString() ?? string.Empty;
                raw = raw.Replace(",", "").Trim();
                if (decimal.TryParse(raw, NumberStyles.Any, UsCulture, out decimal cant) && cant > 0)
                {
                    itm.Cantidad = cant;
                }
                else
                {
                    row.Cells[4].Value = itm.Cantidad.ToString("N0", UsCulture);
                }
            }
            // Edición de Costo Unitario (Columna 5)
            else if (e.ColumnIndex == 5)
            {
                string raw = row.Cells[5].Value?.ToString() ?? string.Empty;
                raw = raw.Replace("$", "").Replace(",", "").Trim();
                if (decimal.TryParse(raw, NumberStyles.Any, UsCulture, out decimal costo) && costo > 0)
                {
                    itm.CostoUnitario = costo;
                }
                else
                {
                    row.Cells[5].Value = itm.CostoUnitario.ToString("$#,##0.00", UsCulture);
                }
            }

            ActualizarResumenPreview();
        }

        private void ActualizarResumenPreview()
        {
            decimal totalEntradas = _items.Where(i => i.EsEntrada).Sum(i => i.Cantidad);
            decimal totalSalidas = _items.Where(i => !i.EsEntrada).Sum(i => i.Cantidad);
            decimal saldoFinal = totalEntradas - totalSalidas;

            decimal costoVentasEstimado = _items
                .Where(i => i.TipoMovimiento == TipoMovimientoKardex.Venta)
                .Sum(i => i.Cantidad * i.CostoUnitario) -
                _items.Where(i => i.TipoMovimiento == TipoMovimientoKardex.DevolucionVenta)
                .Sum(i => i.Cantidad * i.CostoUnitario);

            lblResumenPreview.Text = $"📊 Resumen Físico: Entradas: {totalEntradas:N0} uds | Salidas: {totalSalidas:N0} uds | Saldo Final Estimado: {saldoFinal:N0} uds | Costo de Ventas Estimado: {costoVentasEstimado.ToString("$#,##0.00", UsCulture)}";
        }

        private void ProcesarGeneracion()
        {
            // Validar que todas las cantidades y costos sean válidos
            foreach (DataGridViewRow row in dgvCalibracion.Rows)
            {
                if (row.Tag is not ItemCalibracionKardex itm) continue;

                if (itm.Cantidad <= 0)
                {
                    MessageBox.Show(
                        $"La cantidad para la '{itm.PartidaTexto}' debe ser mayor a 0.",
                        "Validación Requerida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (itm.CostoUnitario <= 0)
                {
                    MessageBox.Show(
                        $"El costo unitario para la '{itm.PartidaTexto}' debe ser mayor a 0.",
                        "Validación Requerida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            // Generar Kardex
            var resultado = KardexServicio.GenerarKardexDesdeCalibracion(
                _items,
                MetodoSeleccionado,
                _libro.FechaInicio,
                _libro.FechaFin,
                $"Kardex — {_libro.Nombre}",
                _libro.Empresa);

            KardexGenerado = resultado.Instancia;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

