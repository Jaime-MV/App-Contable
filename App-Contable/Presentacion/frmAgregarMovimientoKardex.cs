using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmAgregarMovimientoKardex : Form
    {
        private readonly decimal _stockActual;
        private readonly decimal _costoPromedioActual;
        private readonly decimal _saldoValorActual;
        private readonly List<KardexItem> _movimientosExistentes;

        private readonly KardexItem? _itemEnEdicion;
        private readonly bool _esEdicion;

        public KardexItem? MovimientoCreado { get; private set; }

        public frmAgregarMovimientoKardex(
            decimal stockActual = 0m,
            decimal costoPromedioActual = 0m,
            decimal saldoValorActual = 0m,
            IEnumerable<KardexItem>? movimientos = null)
        {
            InitializeComponent();
            _stockActual = stockActual;
            _costoPromedioActual = costoPromedioActual;
            _saldoValorActual = saldoValorActual;
            _movimientosExistentes = movimientos?.ToList() ?? new List<KardexItem>();
            _esEdicion = false;

            ConfigurarAutocompletado();
            InicializarValores();
        }

        public frmAgregarMovimientoKardex(
            KardexItem itemExistente,
            decimal stockActual = 0m,
            decimal costoPromedioActual = 0m,
            decimal saldoValorActual = 0m,
            IEnumerable<KardexItem>? movimientos = null)
        {
            InitializeComponent();
            _itemEnEdicion = itemExistente;
            _esEdicion = true;
            _stockActual = stockActual;
            _costoPromedioActual = costoPromedioActual;
            _saldoValorActual = saldoValorActual;
            _movimientosExistentes = movimientos?.Where(m => m.Id != itemExistente.Id).ToList() ?? new List<KardexItem>();

            ConfigurarAutocompletado();
            CargarDatosEdicion(itemExistente);
        }

        private void ConfigurarAutocompletado()
        {
            txtConcepto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtConcepto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
            {
                "Inventario Inicial / Apertura de Ejercicio",
                "Compra Factura #402 — Prov. Cementera",
                "Compra Factura #519 — Prov. Cementera",
                "Compra Factura #520 — Prov. Ferretería",
                "Compra Factura #630 — Aceros de Centroamérica",
                "Venta según Factura #...",
                "Venta según Asiento #12 — Cliente Mayorista",
                "Venta según Asiento #18 — Distribuidora Central",
                "Venta según Factura #F-600 — Constructora Delta",
                "Devolución en compra s/ Factura...",
                "Devolución en venta s/ Factura...",
                "Ajuste de inventario por merma o deterioro",
                "Ajuste de inventario por sobrante de conteo físico"
            });

            txtConcepto.AutoCompleteCustomSource = source;
        }

        private void InicializarValores()
        {
            lblTituloModal.Text = "↓ Registrar Movimiento de Kardex (PEPS / FIFO)";
            lblSubtituloModal.Text = "Captura de movimiento valuado bajo método Primeras Entradas, Primeras Salidas.";
            btnGuardar.Text = "💾 Guardar Movimiento";
            dtpFecha.Value = new DateTime(2026, 9, 23);
            cmbTipoMovimiento.SelectedIndex = 0; // Entrada por defecto
            numCostoUnitario.Value = _costoPromedioActual > 0 ? _costoPromedioActual : 8.5000m;
            numCantidad.Value = 100m;

            RecalcularProyecciones();
        }

        private void CargarDatosEdicion(KardexItem item)
        {
            lblTituloModal.Text = "✏️ Editar Movimiento de Kardex (PEPS / FIFO)";
            lblSubtituloModal.Text = $"Modificando movimiento Ref: {item.Documento} ({item.Concepto})";
            btnGuardar.Text = "💾 Guardar Cambios";

            dtpFecha.Value = item.Fecha;
            bool esEntrada = item.CantidadEntrada.HasValue && item.CantidadEntrada.Value > 0;
            cmbTipoMovimiento.SelectedIndex = esEntrada ? 0 : 1;

            txtConcepto.Text = item.Concepto;
            txtDocumento.Text = item.Documento;

            numCantidad.Value = esEntrada ? (item.CantidadEntrada ?? 100m) : (item.CantidadSalida ?? 100m);
            numCostoUnitario.Value = item.CostoUnitario > 0 ? item.CostoUnitario : (_costoPromedioActual > 0 ? _costoPromedioActual : 8.5000m);

            if (!esEntrada)
            {
                lblCosto.Text = "Costo Unitario PEPS ($ - Calculado):";
                numCostoUnitario.Enabled = false;
                numCostoUnitario.ReadOnly = true;
                numCostoUnitario.BackColor = Color.FromArgb(243, 244, 246);
            }

            RecalcularProyecciones();
        }

        private void cmbTipoMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esEntrada = cmbTipoMovimiento.SelectedIndex == 0;

            if (esEntrada)
            {
                lblCosto.Text = "Costo Unitario de Adquisición ($):";
                numCostoUnitario.Enabled = true;
                numCostoUnitario.ReadOnly = false;
                numCostoUnitario.BackColor = Color.White;
            }
            else
            {
                lblCosto.Text = "Costo Unitario PEPS ($ - Calculado):";
                numCostoUnitario.Enabled = false;
                numCostoUnitario.ReadOnly = true;
                numCostoUnitario.BackColor = Color.FromArgb(243, 244, 246);
            }

            RecalcularProyecciones();
        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            RecalcularProyecciones();
        }

        private void numCostoUnitario_ValueChanged(object sender, EventArgs e)
        {
            RecalcularProyecciones();
        }

        private void RecalcularProyecciones()
        {
            bool esEntrada = cmbTipoMovimiento.SelectedIndex == 0;
            decimal cantidad = numCantidad.Value;

            if (esEntrada)
            {
                decimal costoUnitario = numCostoUnitario.Value;
                decimal importe = Math.Round(cantidad * costoUnitario, 2, MidpointRounding.AwayFromZero);

                decimal nuevoStock = _stockActual + cantidad;
                decimal nuevoSaldoValor = _saldoValorActual + importe;

                lblImporteCalculado.Text = $"• Importe Total del Movimiento: ${importe:N2} (Imputación: DEBE en Inventario)";
                lblImporteCalculado.ForeColor = Color.FromArgb(21, 128, 61); // Verde bosque mate (#15803D)

                lblNuevoStockEstimado.Text = $"• Stock Proyectado: {_stockActual:N0} + {cantidad:N0} = {nuevoStock:N0} unidades";
                lblNuevoStockEstimado.ForeColor = Color.FromArgb(51, 65, 85);

                lblNuevoCostoPromedio.Text = $"• Nueva Capa PEPS Creada: {cantidad:N0} unidades a ${costoUnitario:N4} c/u";
                lblNuevoCostoPromedio.ForeColor = Color.FromArgb(30, 64, 175); // Azul corporativo (#1E40AF)
            }
            else
            {
                var (importeHaber, costoUnitarioPeps, desgloseCapas) =
                    KardexCalculador.SimularCostoSalidaPeps(_movimientosExistentes, cantidad);

                numCostoUnitario.Value = costoUnitarioPeps > 0 ? costoUnitarioPeps : (_costoPromedioActual > 0 ? _costoPromedioActual : 8.5000m);

                decimal nuevoStock = _stockActual - cantidad;
                decimal nuevoSaldoValor = Math.Max(0, _saldoValorActual - importeHaber);

                lblImporteCalculado.Text = $"• Importe Total del Movimiento: ${importeHaber:N2} (Imputación: HABER / Costo de Venta PEPS)";
                lblImporteCalculado.ForeColor = Color.FromArgb(194, 65, 12); // Ámbar quemado (#C2410C)

                if (nuevoStock < 0 && !_esEdicion)
                {
                    lblNuevoStockEstimado.Text = $"• ⚠ Stock Insuficiente: {_stockActual:N0} - {cantidad:N0} = {nuevoStock:N0} unidades (Déficit)";
                    lblNuevoStockEstimado.ForeColor = Color.FromArgb(185, 28, 28); // Rojo óxido (#B91C1C)
                }
                else
                {
                    lblNuevoStockEstimado.Text = $"• Stock Proyectado: {_stockActual:N0} - {cantidad:N0} = {nuevoStock:N0} unidades";
                    lblNuevoStockEstimado.ForeColor = Color.FromArgb(51, 65, 85);
                }

                lblNuevoCostoPromedio.Text = $"• Asignación de Capas PEPS: {desgloseCapas}";
                lblNuevoCostoPromedio.ForeColor = Color.FromArgb(71, 85, 105);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConcepto.Text))
            {
                MessageBox.Show("Por favor, ingrese un concepto o detalle para el movimiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConcepto.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Por favor, ingrese el documento o referencia de respaldo (ej. F-520, OV-8102).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Focus();
                return;
            }

            bool esEntrada = cmbTipoMovimiento.SelectedIndex == 0;

            if (!_esEdicion && !esEntrada && numCantidad.Value > _stockActual)
            {
                MessageBox.Show(
                    $"No es posible registrar la salida.\n\nEl stock físico actual es de {_stockActual:N0} unidades y se intentan egresar {numCantidad.Value:N0} unidades.",
                    "Stock Insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                numCantidad.Focus();
                return;
            }

            if (esEntrada && numCostoUnitario.Value <= 0)
            {
                MessageBox.Show("El costo unitario de entrada debe ser mayor a $0.0000.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCostoUnitario.Focus();
                return;
            }

            MovimientoCreado = new KardexItem
            {
                Id = _esEdicion && _itemEnEdicion != null ? _itemEnEdicion.Id : DateTime.Now.Ticks,
                Fecha = dtpFecha.Value.Date,
                Concepto = txtConcepto.Text.Trim(),
                Documento = txtDocumento.Text.Trim(),
                CantidadEntrada = esEntrada ? numCantidad.Value : null,
                CantidadSalida = !esEntrada ? numCantidad.Value : null,
                CostoUnitario = esEntrada ? numCostoUnitario.Value : numCostoUnitario.Value,
                Origen = _esEdicion && _itemEnEdicion != null ? _itemEnEdicion.Origen : TipoOrigenKardex.Manual,
                NumeroAsiento = _esEdicion && _itemEnEdicion != null ? _itemEnEdicion.NumeroAsiento : null,
                TipoMovimiento = esEntrada ? TipoMovimientoKardex.Compra : TipoMovimientoKardex.Venta,
                EsFilaEspecial = false
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

