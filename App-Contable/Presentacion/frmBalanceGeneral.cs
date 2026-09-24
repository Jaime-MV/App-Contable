using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmBalanceGeneral : Form
    {
        private readonly BalanceGeneralServicio _servicio = BalanceGeneralServicio.Instancia;
        private DatosBalanceGeneral _balanceActual = new();
        private bool _modoEjemplo = false; // MODO AUTOMÁTICO ACTIVO POR DEFECTO

        public frmBalanceGeneral()
        {
            InitializeComponent();
            ConfigurarFormulario();
            // Cargar en modo automático calculando desde el Libro Diario y Mayor
            CargarDatos(usarEjemplo: false);
        }

        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            dtpFechaCorte.Value = DateTime.Today;

            dgvBalanceGeneral.AutoGenerateColumns = false;
            dgvBalanceGeneral.DoubleBuffered(true);

            foreach (DataGridViewColumn col in dgvBalanceGeneral.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvBalanceGeneral.CellFormatting += DgvBalanceGeneral_CellFormatting;
            dgvBalanceGeneral.RowPrePaint += DgvBalanceGeneral_RowPrePaint;

            // Recalcular automáticamente si el usuario cambia la fecha de corte
            dtpFechaCorte.ValueChanged += (s, e) =>
            {
                if (!_modoEjemplo)
                {
                    CargarDatos(usarEjemplo: false);
                }
            };

            // Suscribirse a los cambios en los asientos del Libro Diario para sincronización en tiempo real
            LibroDiarioServicio.Instancia.DatosModificados += OnLibroDiarioModificado;
            this.FormClosed += (s, e) => LibroDiarioServicio.Instancia.DatosModificados -= OnLibroDiarioModificado;

            // Al mostrar el formulario, recalcular con los asientos vigentes
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible && !_modoEjemplo)
                {
                    CargarDatos(usarEjemplo: false);
                }
            };
        }

        private void OnLibroDiarioModificado()
        {
            if (!_modoEjemplo && IsHandleCreated && !IsDisposed)
            {
                BeginInvoke(new Action(() => CargarDatos(usarEjemplo: false)));
            }
        }

        public void CargarDatos(bool usarEjemplo)
        {
            _modoEjemplo = usarEjemplo;

            if (_modoEjemplo)
            {
                _balanceActual = _servicio.ObtenerDatosEjemplo();
                btnCalcularMayor.BackColor = Color.White;
                btnCalcularMayor.ForeColor = Color.FromArgb(71, 85, 105);
                btnCargarEjemplo.BackColor = Color.FromArgb(241, 245, 249);
                btnCargarEjemplo.ForeColor = Color.FromArgb(30, 41, 59);
            }
            else
            {
                // MODO AUTOMÁTICO: Extrae y calcula los saldos directamente del Libro Mayor
                _balanceActual = _servicio.CalcularDesdeMayor(dtpFechaCorte.Value.Date);
                btnCalcularMayor.BackColor = Color.FromArgb(220, 252, 231); // Verde suave indicador activo
                btnCalcularMayor.ForeColor = Color.FromArgb(22, 101, 52);
                btnCargarEjemplo.BackColor = Color.White;
                btnCargarEjemplo.ForeColor = Color.FromArgb(71, 85, 105);
            }

            var filas = _servicio.GenerarFilasVisuales(_balanceActual);
            dgvBalanceGeneral.Rows.Clear();

            foreach (var fila in filas)
            {
                int index = dgvBalanceGeneral.Rows.Add(
                    fila.Cuenta,
                    fila.Parcial.HasValue ? fila.Parcial.Value.ToString("N2") : string.Empty,
                    fila.Subtotal.HasValue ? fila.Subtotal.Value.ToString("N2") : string.Empty,
                    fila.Total.HasValue ? fila.Total.Value.ToString("N2") : string.Empty
                );

                dgvBalanceGeneral.Rows[index].Tag = fila;
            }

            ActualizarResumen();
        }

        private void DgvBalanceGeneral_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBalanceGeneral.Rows.Count) return;

            var row = dgvBalanceGeneral.Rows[e.RowIndex];
            if (row.Tag is not FilaBalanceVisual fila) return;

            switch (fila.TipoFila)
            {
                case TipoFilaBalance.TituloSeccion:
                    // Color azul suave de Excel
                    row.DefaultCellStyle.BackColor = Color.FromArgb(217, 225, 242);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaBalance.Subseccion:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(237, 242, 248);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaBalance.Cuenta:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaBalance.Subtotal:
                    // Fondo verde claro como en Excel
                    row.DefaultCellStyle.BackColor = Color.FromArgb(226, 239, 218);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaBalance.TotalPrincipal:
                    // Fondo verde destacado como en Excel
                    row.DefaultCellStyle.BackColor = Color.FromArgb(169, 208, 142);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaBalance.Separador:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    row.Height = 12;
                    break;
            }
        }

        private void DgvBalanceGeneral_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBalanceGeneral.Rows.Count) return;

            var row = dgvBalanceGeneral.Rows[e.RowIndex];
            if (row.Tag is not FilaBalanceVisual fila) return;

            // Sangría contable suave
            if (e.ColumnIndex == colCuenta.Index && e.Value is string texto)
            {
                if (fila.TipoFila == TipoFilaBalance.Cuenta)
                {
                    e.Value = "    " + texto;
                }
                else if (fila.TipoFila == TipoFilaBalance.Subseccion)
                {
                    e.Value = "  " + texto;
                }
            }
        }

        private void ActualizarResumen()
        {
            lblTotalActivo.Text = $"Total Activo: {_balanceActual.TotalActivo:C2}";
            lblTotalPasivoPatrimonio.Text = $"Total Pasivo + Pat.: {_balanceActual.TotalPasivoMasPatrimonio:C2}";

            string origen = _modoEjemplo ? "(Datos de Prueba)" : "(Automático desde Asientos / Mayor)";

            if (_balanceActual.EstaCuadrado)
            {
                lblBadgeEstado.Text = $"✓ Balance Cuadrado {origen} - Activo = Pasivo + Patrimonio";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                lblBadgeEstado.Text = $"⚠ Descuadre {origen}: {_balanceActual.Diferencia:C2}";
                lblBadgeEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        private void btnCargarEjemplo_Click(object sender, EventArgs e)
        {
            CargarDatos(usarEjemplo: true);
        }

        private void btnCalcularMayor_Click(object sender, EventArgs e)
        {
            CargarDatos(usarEjemplo: false);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos(usarEjemplo: _modoEjemplo);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatos(usarEjemplo: false);
        }
    }
}
