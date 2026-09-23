using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmAgregarAsiento : Form
    {
        private readonly List<MovimientoContable> _movimientos = new();
        private readonly LibroDiarioServicio _servicio = LibroDiarioServicio.Instancia;

        private bool _esEdicion = false;

        public frmAgregarAsiento()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        public frmAgregarAsiento(AsientoContable asientoExistente) : this()
        {
            _esEdicion = true;
            this.Text = "Editar Asiento Contable";
            txtNumeroAsiento.Text = asientoExistente.NumeroAsiento.ToString();
            dtpFecha.Value = asientoExistente.Fecha;
            txtConcepto.Text = asientoExistente.Concepto;
            
            _movimientos.Clear();
            foreach (var mov in asientoExistente.Movimientos)
            {
                _movimientos.Add(new MovimientoContable
                {
                    CuentaPrincipal = mov.CuentaPrincipal,
                    Subcuenta = mov.Subcuenta,
                    Movimiento = mov.Movimiento,
                    Monto = mov.Monto
                });
            }
            
            RefrescarGrillaDetalles();
            ActualizarBalance();
        }

        private void InicializarFormulario()
        {
            txtNumeroAsiento.Text = _servicio.ObtenerSiguienteNumero().ToString();
            dtpFecha.Value = DateTime.Today;

            // Cargar Cuentas Principales autorizadas en el ComboBox
            cmbCuentaPrincipal.DataSource = CatalogoCuentasConfig.CuentasPermitidas.Select(c => c.Nombre).ToList();
            if (cmbCuentaPrincipal.Items.Count > 0)
            {
                cmbCuentaPrincipal.SelectedIndex = 0;
            }

            ActualizarSubcuentas();
            ActualizarBalance();
        }

        private void cmbCuentaPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarSubcuentas();
        }

        private void ActualizarSubcuentas()
        {
            string? cuentaSeleccionada = cmbCuentaPrincipal.SelectedItem as string;
            if (string.IsNullOrEmpty(cuentaSeleccionada)) return;

            var def = CatalogoCuentasConfig.ObtenerPorNombre(cuentaSeleccionada);
            if (def != null && def.TieneSubcuentas && def.Subcuentas.Any())
            {
                cmbSubcuenta.Enabled = true;
                cmbSubcuenta.DataSource = def.Subcuentas.ToList();
                lblAvisoSubcuenta.Text = "Obligatoria para esta cuenta (Irá a 'Parcial')";
                lblAvisoSubcuenta.ForeColor = Color.FromArgb(37, 99, 235);
            }
            else
            {
                cmbSubcuenta.DataSource = null;
                cmbSubcuenta.Items.Clear();
                cmbSubcuenta.Items.Add("(Sin subcuenta)");
                cmbSubcuenta.SelectedIndex = 0;
                cmbSubcuenta.Enabled = false;
                lblAvisoSubcuenta.Text = "Esta cuenta no utiliza subcuenta en libro diario";
                lblAvisoSubcuenta.ForeColor = Color.FromArgb(100, 116, 139);
            }

            // Sugerir naturaleza (Debe/Haber) según la cuenta
            if (def != null)
            {
                if (def.NaturalezaPredeterminada == CuentaDefinicion.TipoNaturaleza.Deudora)
                    rbDebe.Checked = true;
                else
                    rbHaber.Checked = true;
            }
        }

        private void btnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            string? cuentaPrincipal = cmbCuentaPrincipal.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(cuentaPrincipal))
            {
                MessageBox.Show("Por favor seleccione una cuenta principal.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var def = CatalogoCuentasConfig.ObtenerPorNombre(cuentaPrincipal);
            string? subcuenta = null;

            if (def != null && def.TieneSubcuentas)
            {
                subcuenta = cmbSubcuenta.SelectedItem as string;
                if (string.IsNullOrWhiteSpace(subcuenta) || subcuenta == "(Sin subcuenta)")
                {
                    MessageBox.Show($"La cuenta '{cuentaPrincipal}' requiere seleccionar una subcuenta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (numMonto.Value <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMonto.Focus();
                return;
            }

            var movimiento = new MovimientoContable
            {
                CuentaPrincipal = cuentaPrincipal,
                Subcuenta = subcuenta,
                Movimiento = rbDebe.Checked ? TipoMovimiento.Debe : TipoMovimiento.Haber,
                Monto = numMonto.Value
            };

            _movimientos.Add(movimiento);
            RefrescarGrillaDetalles();
            ActualizarBalance();

            // Limpiar campo monto para siguiente entrada
            numMonto.Value = 0;
            numMonto.Focus();
        }

        private void RefrescarGrillaDetalles()
        {
            dgvMovimientos.Rows.Clear();

            foreach (var mov in _movimientos)
            {
                int index = dgvMovimientos.Rows.Add(
                    mov.CuentaPrincipal,
                    mov.Subcuenta ?? "-",
                    mov.Movimiento == TipoMovimiento.Debe ? "DEBE" : "HABER",
                    mov.Debe > 0 ? mov.Debe : null,
                    mov.Haber > 0 ? mov.Haber : null
                );
                dgvMovimientos.Rows[index].Tag = mov;
            }
        }

        private void dgvMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colQuitar.Index)
            {
                if (dgvMovimientos.Rows[e.RowIndex].Tag is MovimientoContable mov)
                {
                    _movimientos.Remove(mov);
                    RefrescarGrillaDetalles();
                    ActualizarBalance();
                }
            }
        }

        private void ActualizarBalance()
        {
            decimal totalDebe = _movimientos.Where(m => m.Movimiento == TipoMovimiento.Debe).Sum(m => m.Monto);
            decimal totalHaber = _movimientos.Where(m => m.Movimiento == TipoMovimiento.Haber).Sum(m => m.Monto);
            decimal diferencia = Math.Abs(totalDebe - totalHaber);

            lblTotalDebe.Text = $"Total Debe: {totalDebe:C2}";
            lblTotalHaber.Text = $"Total Haber: {totalHaber:C2}";

            bool cuadrado = totalDebe > 0 && Math.Round(totalDebe, 2) == Math.Round(totalHaber, 2);

            if (cuadrado)
            {
                lblEstadoCuadre.Text = "✓ Asiento Cuadrado (Cumple Ley de Partida Doble)";
                lblEstadoCuadre.ForeColor = Color.FromArgb(22, 163, 74); // Verde
                btnGuardar.Enabled = true;
            }
            else
            {
                lblEstadoCuadre.Text = $"⚠ Asiento Descuadrado: Diferencia de {diferencia:C2}";
                lblEstadoCuadre.ForeColor = Color.FromArgb(220, 38, 38); // Rojo
                btnGuardar.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConcepto.Text))
            {
                MessageBox.Show("Debe ingresar el concepto o glosa del asiento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConcepto.Focus();
                return;
            }

            if (!_movimientos.Any())
            {
                MessageBox.Show("Debe ingresar al menos dos renglones de cuentas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numeroAsiento = int.TryParse(txtNumeroAsiento.Text, out int n) ? n : _servicio.ObtenerSiguienteNumero();

            var nuevoAsiento = new AsientoContable
            {
                NumeroAsiento = numeroAsiento,
                Fecha = dtpFecha.Value.Date,
                Concepto = txtConcepto.Text.Trim(),
                Movimientos = new List<MovimientoContable>(_movimientos)
            };

            bool exito;
            string error;
            if (_esEdicion)
            {
                exito = _servicio.ActualizarAsiento(nuevoAsiento, out error);
            }
            else
            {
                exito = _servicio.AgregarAsiento(nuevoAsiento, out error);
            }

            if (exito)
            {
                MessageBox.Show($"¡Asiento N° {nuevoAsiento.NumeroAsiento} guardado con éxito!", "Libro Diario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show($"No se pudo guardar el asiento:\n{error}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
