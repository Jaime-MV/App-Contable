using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    public partial class frmEstadoResultados : Form
    {
        private readonly EstadoResultadosServicio _servicio = EstadoResultadosServicio.Instancia;
        private DatosEstadoResultados _estadoActual = new();
        private bool _modoEjemplo = false; // Modo automático activo por defecto

        public frmEstadoResultados()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarDatos(usarEjemplo: false);
        }

        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            var hoy = DateTime.Today;
            dtpFechaInicio.Value = new DateTime(hoy.Year, 1, 1);
            dtpFechaFin.Value = hoy;

            dgvEstadoResultados.AutoGenerateColumns = false;
            dgvEstadoResultados.DoubleBuffered(true);

            foreach (DataGridViewColumn col in dgvEstadoResultados.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvEstadoResultados.CellFormatting += DgvEstadoResultados_CellFormatting;
            dgvEstadoResultados.RowPrePaint += DgvEstadoResultados_RowPrePaint;

            // Recalcular al cambiar el rango de fechas
            dtpFechaInicio.ValueChanged += (s, e) => { if (!_modoEjemplo) CargarDatos(usarEjemplo: false); };
            dtpFechaFin.ValueChanged += (s, e) => { if (!_modoEjemplo) CargarDatos(usarEjemplo: false); };

            // Suscribirse a cambios en los asientos contables para sincronización en tiempo real
            LibroDiarioServicio.Instancia.DatosModificados += OnLibroDiarioModificado;
            this.FormClosed += (s, e) => LibroDiarioServicio.Instancia.DatosModificados -= OnLibroDiarioModificado;

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
                _estadoActual = _servicio.ObtenerDatosEjemplo();
                btnCalcularMayor.BackColor = Color.White;
                btnCalcularMayor.ForeColor = Color.FromArgb(71, 85, 105);
                btnCargarEjemplo.BackColor = Color.FromArgb(241, 245, 249);
                btnCargarEjemplo.ForeColor = Color.FromArgb(30, 41, 59);
            }
            else
            {
                _estadoActual = _servicio.CalcularDesdeMayor(dtpFechaInicio.Value.Date, dtpFechaFin.Value.Date);
                btnCalcularMayor.BackColor = Color.FromArgb(220, 252, 231);
                btnCalcularMayor.ForeColor = Color.FromArgb(22, 101, 52);
                btnCargarEjemplo.BackColor = Color.White;
                btnCargarEjemplo.ForeColor = Color.FromArgb(71, 85, 105);
            }

            var filas = _servicio.GenerarFilasVisuales(_estadoActual);
            dgvEstadoResultados.Rows.Clear();

            foreach (var fila in filas)
            {
                int index = dgvEstadoResultados.Rows.Add(
                    fila.Concepto,
                    fila.Parcial.HasValue ? fila.Parcial.Value.ToString("N2") : string.Empty,
                    fila.Subtotal.HasValue ? fila.Subtotal.Value.ToString("N2") : string.Empty,
                    fila.Total.HasValue ? fila.Total.Value.ToString("N2") : string.Empty
                );

                dgvEstadoResultados.Rows[index].Tag = fila;
            }

            ActualizarResumen();
        }

        private void DgvEstadoResultados_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEstadoResultados.Rows.Count) return;

            var row = dgvEstadoResultados.Rows[e.RowIndex];
            if (row.Tag is not FilaEstadoResultadosVisual fila) return;

            switch (fila.TipoFila)
            {
                case TipoFilaEstadoResultados.ResultadoIntermedio:
                    // Fondo verde claro como en Excel para Ventas netas, Compras netas, etc.
                    row.DefaultCellStyle.BackColor = Color.FromArgb(226, 239, 218);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaEstadoResultados.ResultadoFinal:
                    // Fondo verde destacado para la Utilidad operacional
                    row.DefaultCellStyle.BackColor = Color.FromArgb(169, 208, 142);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaEstadoResultados.Subtotal:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaEstadoResultados.Concepto:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaEstadoResultados.Separador:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    row.Height = 12;
                    break;
            }
        }

        private void DgvEstadoResultados_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEstadoResultados.Rows.Count) return;

            var row = dgvEstadoResultados.Rows[e.RowIndex];
            if (row.Tag is not FilaEstadoResultadosVisual fila) return;

            // Indentación contable estética
            if (e.ColumnIndex == colConcepto.Index && e.Value is string texto)
            {
                if (fila.TipoFila == TipoFilaEstadoResultados.Concepto && (texto.StartsWith("(-)") || texto.StartsWith("(+)")))
                {
                    e.Value = "  " + texto;
                }
                else if (fila.TipoFila == TipoFilaEstadoResultados.Concepto && texto == "Gastos financieros")
                {
                    e.Value = "    " + texto;
                }
            }
        }

        private void ActualizarResumen()
        {
            lblVentasNetas.Text = $"Ventas Netas: {_estadoActual.VentasNetas:C2}";
            lblCostoVentas.Text = $"Costo Ventas: {_estadoActual.CostoDeVentas:C2}";
            lblUtilidadBruta.Text = $"Utilidad Bruta: {_estadoActual.UtilidadBruta:C2}";
            lblUtilidadOperacional.Text = $"Utilidad Operacional: {_estadoActual.UtilidadOperacional:C2}";

            string origen = _modoEjemplo ? "(Datos de Prueba)" : "(Automático desde Asientos / Mayor)";

            if (_estadoActual.UtilidadOperacional >= 0)
            {
                lblBadgeEstado.Text = $"✓ Utilidad Operacional {origen}";
                lblBadgeEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else
            {
                lblBadgeEstado.Text = $"⚠ Pérdida Operacional {origen}";
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
