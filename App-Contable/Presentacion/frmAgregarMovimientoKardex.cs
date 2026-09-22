using System;
using System.Drawing;
using System.Windows.Forms;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmAgregarMovimientoKardex : Form
    {
        private readonly decimal _stockActual;
        private readonly decimal _costoPromedioActual;
        private readonly decimal _saldoValorActual;

        public KardexItem? MovimientoCreado { get; private set; }

        public frmAgregarMovimientoKardex(decimal stockActual = 0m, decimal costoPromedioActual = 0m, decimal saldoValorActual = 0m)
        {
            InitializeComponent();
            _stockActual = stockActual;
            _costoPromedioActual = costoPromedioActual;
            _saldoValorActual = saldoValorActual;

            ConfigurarAutocompletado();
            InicializarValores();
        }

        private void ConfigurarAutocompletado()
        {
            txtConcepto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtConcepto.AutoCompleteSource = AutoCompleteSource.CustomSource;

            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
            {
                "Compra Factura #...",
                "Compra Factura #402 — Prov. Cementera",
                "Compra Factura #519 — Prov. Cementera",
                "Compra Factura #520 — Prov. Ferretería",
                "Venta según Factura #...",
                "Venta según Asiento #12 — Cliente Mayorista",
                "Venta según Asiento #18 — Distribuidora Central",
                "Venta según Factura #F-600 — Constructora Delta",
                "Devolución en compra s/ Factura...",
                "Devolución en venta s/ Factura...",
                "Ajuste de inventario por merma o deterioro",
                "Ajuste de inventario por sobrante de conteo físico",
                "Inventario Inicial / Apertura de Ejercicio"
            });

            txtConcepto.AutoCompleteCustomSource = source;
        }

        private void InicializarValores()
        {
            dtpFecha.Value = new DateTime(2026, 9, 23);
            cmbTipoMovimiento.SelectedIndex = 0; // Entrada por defecto
            numCostoUnitario.Value = _costoPromedioActual > 0 ? _costoPromedioActual : 8.5000m;
            numCantidad.Value = 100m;

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
                lblCosto.Text = "Costo Promedio Vigente ($ - Auto):";
                numCostoUnitario.Value = _costoPromedioActual;
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
            decimal costoUnitario = numCostoUnitario.Value;
            decimal importe = Math.Round(cantidad * costoUnitario, 2, MidpointRounding.AwayFromZero);

            decimal nuevoStock;
            decimal nuevoSaldoValor;
            decimal nuevoCostoPromedio;

            if (esEntrada)
            {
                nuevoStock = _stockActual + cantidad;
                nuevoSaldoValor = _saldoValorActual + importe;
                nuevoCostoPromedio = nuevoStock > 0 ? Math.Round(nuevoSaldoValor / nuevoStock, 4, MidpointRounding.AwayFromZero) : costoUnitario;

                lblImporteCalculado.Text = $"• Importe Total del Movimiento: ${importe:N2} (Imputación: DEBE en Inventario)";
                lblImporteCalculado.ForeColor = Color.FromArgb(21, 128, 61); // Verde bosque mate (#15803D)

                lblNuevoStockEstimado.Text = $"• Stock Proyectado: {_stockActual:N2} + {cantidad:N2} = {nuevoStock:N2} unidades";
                lblNuevoStockEstimado.ForeColor = Color.FromArgb(51, 65, 85);

                lblNuevoCostoPromedio.Text = $"• Nuevo Costo Promedio Ponderado: ${nuevoCostoPromedio:N4} / unidad";
                lblNuevoCostoPromedio.ForeColor = Color.FromArgb(30, 64, 175); // Azul corporativo (#1E40AF)
            }
            else
            {
                nuevoStock = _stockActual - cantidad;
                nuevoSaldoValor = Math.Max(0, _saldoValorActual - importe);
                nuevoCostoPromedio = nuevoStock > 0 ? _costoPromedioActual : 0m;

                lblImporteCalculado.Text = $"• Importe Total del Movimiento: ${importe:N2} (Imputación: HABER / Costo de Venta)";
                lblImporteCalculado.ForeColor = Color.FromArgb(194, 65, 12); // Ámbar quemado (#C2410C)

                if (nuevoStock < 0)
                {
                    lblNuevoStockEstimado.Text = $"• ⚠ Stock Insuficiente: {_stockActual:N2} - {cantidad:N2} = {nuevoStock:N2} unidades (Déficit)";
                    lblNuevoStockEstimado.ForeColor = Color.FromArgb(185, 28, 28); // Rojo óxido (#B91C1C)
                }
                else
                {
                    lblNuevoStockEstimado.Text = $"• Stock Proyectado: {_stockActual:N2} - {cantidad:N2} = {nuevoStock:N2} unidades";
                    lblNuevoStockEstimado.ForeColor = Color.FromArgb(51, 65, 85);
                }

                lblNuevoCostoPromedio.Text = $"• Costo Promedio Mantenido: ${_costoPromedioActual:N4} / unidad";
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

            if (!esEntrada && numCantidad.Value > _stockActual)
            {
                MessageBox.Show(
                    $"No es posible registrar la salida.\n\nEl stock físico actual es de {_stockActual:N2} unidades y se intentan egresar {numCantidad.Value:N2} unidades.",
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
                Id = DateTime.Now.Ticks,
                Fecha = dtpFecha.Value.Date,
                Concepto = txtConcepto.Text.Trim(),
                Documento = txtDocumento.Text.Trim(),
                CantidadEntrada = esEntrada ? numCantidad.Value : null,
                CantidadSalida = !esEntrada ? numCantidad.Value : null,
                CostoUnitario = esEntrada ? numCostoUnitario.Value : _costoPromedioActual,
                Origen = TipoOrigenKardex.Manual,
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

