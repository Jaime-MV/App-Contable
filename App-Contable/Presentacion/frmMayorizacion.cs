using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Logica;

namespace App_Contable.Presentacion
{
    public partial class frmMayorizacion : Form
    {
        private readonly MayorizacionServicio _servicio = new();
        private List<FilaMayorTablaVisual> _filasActuales = new();
        private bool _cargandoCombo = false;

        public frmMayorizacion()
        {
            InitializeComponent();
            ConfigurarFormulario();
            this.Load += (s, e) =>
            {
                CargarComboCuentas();
                CargarDatos();
            };
            this.Shown += (s, e) => AjustarAnchoTarjetas();
            pnlCuentas.SizeChanged += (s, e) => AjustarAnchoTarjetas();
        }

        private void ConfigurarFormulario()
        {
            // Reducir parpadeos de pintado GDI+
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Fechas por defecto para el filtro (mes actual) igual que en Libro Diario
            var hoy = DateTime.Today;
            dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1);
            dtpHasta.Value = new DateTime(hoy.Year, hoy.Month, DateTime.DaysInMonth(hoy.Year, hoy.Month));

            // Configuración avanzada de la grilla continua (idéntica a Libro Diario)
            dgvMayorizacion.AutoGenerateColumns = false;
            dgvMayorizacion.DoubleBuffered(true);

            // Desactivar ordenamiento para preservar la estructura contable de las partidas
            foreach (DataGridViewColumn col in dgvMayorizacion.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvMayorizacion.CellFormatting += DgvMayorizacion_CellFormatting;
            dgvMayorizacion.RowPrePaint += DgvMayorizacion_RowPrePaint;
        }

        private void CargarComboCuentas()
        {
            _cargandoCombo = true;
            cmbCuentas.Items.Clear();
            cmbCuentas.Items.Add("Todas las Cuentas");

            var todas = _servicio.GenerarMayor();
            foreach (var c in todas)
            {
                string nombre = string.IsNullOrWhiteSpace(c.NombreSubcuenta)
                    ? c.NombreCuenta
                    : $"{c.NombreCuenta} › {c.NombreSubcuenta}";

                if (!cmbCuentas.Items.Contains(nombre))
                {
                    cmbCuentas.Items.Add(nombre);
                }
            }

            cmbCuentas.SelectedIndex = 0;
            _cargandoCombo = false;
        }

        private void CargarDatos(DateTime? desde = null, DateTime? hasta = null)
        {
            string? filtroCuenta = cmbCuentas.SelectedItem?.ToString();
            if (filtroCuenta == "Todas las Cuentas") filtroCuenta = null;

            // 1. Cargar Grilla Continua Principal (Estilo Libro Diario)
            _filasActuales = _servicio.GenerarFilasVisualesTabla(desde, hasta, filtroCuenta);
            dgvMayorizacion.Rows.Clear();

            foreach (var fila in _filasActuales)
            {
                int index = dgvMayorizacion.Rows.Add(
                    fila.Fecha,
                    fila.Referencia,
                    fila.Descripcion,
                    fila.Debe.HasValue ? fila.Debe.Value.ToString("N2") : string.Empty,
                    fila.Haber.HasValue ? fila.Haber.Value.ToString("N2") : string.Empty,
                    fila.Saldo.HasValue ? fila.Saldo.Value.ToString("N2") : string.Empty,
                    fila.Naturaleza
                );

                dgvMayorizacion.Rows[index].Tag = fila;
            }

            // 2. Cargar Vista Secundaria de Tarjetas
            CargarTarjetasCuentas(desde, hasta, filtroCuenta);

            // 3. Actualizar totales del footer
            var cuentasMayor = _servicio.GenerarMayor(desde, hasta);
            if (!string.IsNullOrWhiteSpace(filtroCuenta))
            {
                cuentasMayor = cuentasMayor.Where(c => c.NombreCuenta.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase) ||
                                                       (!string.IsNullOrEmpty(c.NombreSubcuenta) && c.NombreSubcuenta.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase)))
                                           .ToList();
            }
            ActualizarResumen(cuentasMayor);
        }

        private void DgvMayorizacion_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvMayorizacion.Rows.Count) return;

            var row = dgvMayorizacion.Rows[e.RowIndex];
            if (row.Tag is not FilaMayorTablaVisual fila) return;

            switch (fila.TipoFila)
            {
                case TipoFilaMayorVisual.EncabezadoCuenta:
                    // Idéntico a EncabezadoPartida del Libro Diario
                    row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249); // Gris azulado suave
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaMayorVisual.Movimiento:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;

                case TipoFilaMayorVisual.TotalCuenta:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                    break;

                case TipoFilaMayorVisual.Separador:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
                    row.Height = 10;
                    break;

                case TipoFilaMayorVisual.TotalSumasIguales:
                    // Idéntico a TotalSumasIguales del Libro Diario
                    row.DefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
                    break;
            }
        }

        private void DgvMayorizacion_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvMayorizacion.Rows.Count) return;

            var row = dgvMayorizacion.Rows[e.RowIndex];
            if (row.Tag is not FilaMayorTablaVisual fila) return;

            // Formato y colores en columna Naturaleza
            if (e.CellStyle != null && e.ColumnIndex == colNaturaleza.Index && !string.IsNullOrEmpty(fila.Naturaleza))
            {
                if (fila.Naturaleza == "D")
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235); // Azul
                else if (fila.Naturaleza == "A")
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38); // Rojo
                else if (fila.Naturaleza == "✓")
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); // Verde
            }
        }

        private void CargarTarjetasCuentas(DateTime? desde, DateTime? hasta, string? filtroCuenta)
        {
            var cuentas = _servicio.GenerarMayor(desde, hasta);
            if (!string.IsNullOrWhiteSpace(filtroCuenta))
            {
                cuentas = cuentas.Where(c => c.NombreCuenta.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase) ||
                                             (!string.IsNullOrEmpty(c.NombreSubcuenta) && c.NombreSubcuenta.Equals(filtroCuenta, StringComparison.OrdinalIgnoreCase)))
                                 .ToList();
            }

            pnlCuentas.Controls.Clear();
            pnlCuentas.SuspendLayout();

            if (!cuentas.Any())
            {
                var lbl = new Label
                {
                    Text = "No hay asientos registrados en el Libro Diario para generar la Mayorización.",
                    ForeColor = Color.FromArgb(100, 116, 139),
                    Font = new Font("Segoe UI", 11f, FontStyle.Italic),
                    AutoSize = false,
                    Width = Math.Max(300, pnlCuentas.ClientSize.Width - 40),
                    Height = 60,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(20, 40)
                };
                pnlCuentas.Controls.Add(lbl);
                pnlCuentas.ResumeLayout();
                return;
            }

            int y = 14;
            foreach (var cuenta in cuentas)
            {
                var card = CrearTarjetaCuenta(cuenta, y);
                pnlCuentas.Controls.Add(card);
                y += card.Height + 16;
            }

            pnlCuentas.ResumeLayout();
            AjustarAnchoTarjetas();
        }

        private void AjustarAnchoTarjetas()
        {
            if (pnlCuentas == null || pnlCuentas.Controls.Count == 0) return;

            int cardWidth = Math.Max(300, pnlCuentas.ClientSize.Width - 16);

            pnlCuentas.SuspendLayout();
            foreach (Control ctrl in pnlCuentas.Controls)
            {
                if (ctrl is Panel card)
                {
                    card.Width = cardWidth;
                    foreach (Control child in card.Controls)
                    {
                        if (child is Panel pnlHeader)
                        {
                            foreach (Control subCtrl in pnlHeader.Controls)
                            {
                                if (subCtrl is Label lblTitulo && subCtrl.Dock == DockStyle.Left)
                                {
                                    lblTitulo.Width = Math.Max(100, cardWidth - 240);
                                }
                            }
                        }
                    }
                }
            }
            pnlCuentas.ResumeLayout();
        }

        private Panel CrearTarjetaCuenta(CuentaMayor cuenta, int top)
        {
            int cardWidth = Math.Max(300, pnlCuentas.ClientSize.Width - 16);

            var card = new Panel
            {
                BackColor = Color.White,
                Location = new Point(8, top),
                Width = cardWidth,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(0)
            };

            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 38,
                BackColor = Color.FromArgb(30, 41, 59),
                Padding = new Padding(4, 0, 0, 0)
            };

            string tituloTexto = string.IsNullOrWhiteSpace(cuenta.NombreSubcuenta)
                ? cuenta.NombreCuenta
                : $"{cuenta.NombreCuenta} › {cuenta.NombreSubcuenta}";

            var lblTitulo = new Label
            {
                Text = $"  📊  {tituloTexto.ToUpper()}",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold),
                Dock = DockStyle.Left,
                AutoSize = false,
                Width = Math.Max(100, cardWidth - 240),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            string naturalezaTexto = cuenta.NaturalezaSaldo == "Deudor" ? "Saldo Deudor" : "Saldo Acreedor";
            Color naturalezaColor = cuenta.NaturalezaSaldo == "Deudor"
                ? Color.FromArgb(37, 99, 235)
                : Color.FromArgb(220, 38, 38);

            var lblNaturaleza = new Label
            {
                Text = $"{naturalezaTexto}: ${cuenta.SaldoFinal:N2}",
                ForeColor = Color.White,
                BackColor = naturalezaColor,
                Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold),
                Dock = DockStyle.Right,
                AutoSize = false,
                Width = 230,
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnlHeader.Controls.Add(lblNaturaleza);
            pnlHeader.Controls.Add(lblTitulo);

            var dgv = new DataGridView
            {
                Dock = DockStyle.Top,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(180, 198, 215),
                CellBorderStyle = DataGridViewCellBorderStyle.Single,
                RowTemplate = { Height = 26 },
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false
            };

            dgv.DoubleBuffered(true);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(189, 215, 238);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(189, 215, 238);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.ColumnHeadersHeight = 32;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            var colF = new DataGridViewTextBoxColumn { Name = "colFecha", HeaderText = "Fecha", FillWeight = 75, SortMode = DataGridViewColumnSortMode.NotSortable };
            colF.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colA = new DataGridViewTextBoxColumn { Name = "colAsiento", HeaderText = "Partida", FillWeight = 50, SortMode = DataGridViewColumnSortMode.NotSortable };
            colA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colC = new DataGridViewTextBoxColumn { Name = "colConcepto", HeaderText = "Concepto / Descripción", FillWeight = 220, SortMode = DataGridViewColumnSortMode.NotSortable };

            var colD = new DataGridViewTextBoxColumn { Name = "colDebe", HeaderText = "Debe", FillWeight = 95, SortMode = DataGridViewColumnSortMode.NotSortable };
            colD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colD.DefaultCellStyle.Format = "N2";

            var colH = new DataGridViewTextBoxColumn { Name = "colHaber", HeaderText = "Haber", FillWeight = 95, SortMode = DataGridViewColumnSortMode.NotSortable };
            colH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colH.DefaultCellStyle.Format = "N2";

            var colS = new DataGridViewTextBoxColumn { Name = "colSaldo", HeaderText = "Saldo", FillWeight = 95, SortMode = DataGridViewColumnSortMode.NotSortable };
            colS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colS.DefaultCellStyle.Format = "N2";
            colS.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);

            var colN = new DataGridViewTextBoxColumn { Name = "colNat", HeaderText = "Nat.", FillWeight = 35, SortMode = DataGridViewColumnSortMode.NotSortable };
            colN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colN.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold);

            dgv.Columns.AddRange(colF, colA, colC, colD, colH, colS, colN);

            foreach (var fila in cuenta.Movimientos)
            {
                int idx = dgv.Rows.Add(
                    fila.Fecha,
                    $"A-{fila.NumeroAsiento}",
                    fila.Concepto,
                    fila.Debe.HasValue ? fila.Debe.Value.ToString("N2") : string.Empty,
                    fila.Haber.HasValue ? fila.Haber.Value.ToString("N2") : string.Empty,
                    fila.Saldo.ToString("N2"),
                    fila.NaturalezaSaldo
                );

                var row = dgv.Rows[idx];
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                row.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

                row.Cells["colNat"].Style.ForeColor = fila.NaturalezaSaldo == "D"
                    ? Color.FromArgb(37, 99, 235)
                    : Color.FromArgb(220, 38, 38);
            }

            int idxTot = dgv.Rows.Add(
                string.Empty,
                string.Empty,
                "SUMAS IGUALES",
                cuenta.TotalDebe.ToString("N2"),
                cuenta.TotalHaber.ToString("N2"),
                cuenta.SaldoFinal.ToString("N2"),
                cuenta.NaturalezaSaldo == "Deudor" ? "D" : "A"
            );

            var rowTot = dgv.Rows[idxTot];
            rowTot.DefaultCellStyle.BackColor = Color.FromArgb(226, 232, 240);
            rowTot.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            rowTot.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);

            int altDgv = dgv.ColumnHeadersHeight + (dgv.Rows.Count * dgv.RowTemplate.Height) + 2;
            dgv.Height = altDgv;

            card.Height = pnlHeader.Height + dgv.Height;
            card.Controls.Add(dgv);
            card.Controls.Add(pnlHeader);

            return card;
        }

        private void ActualizarResumen(List<CuentaMayor> cuentas)
        {
            int total = cuentas.Count;
            decimal totalD = cuentas.Sum(c => c.TotalDebe);
            decimal totalH = cuentas.Sum(c => c.TotalHaber);

            lblTotalCuentas.Text = $"Total Cuentas: {total}";
            lblTotalDebe.Text = $"Total Debe: {totalD:C2}";
            lblTotalHaber.Text = $"Total Haber: {totalH:C2}";

            bool cuadrado = total > 0 && Math.Round(totalD, 2) == Math.Round(totalH, 2);
            if (cuadrado)
            {
                lblEstado.Text = "✓ Mayorización Cuadrada";
                lblEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else if (total == 0)
            {
                lblEstado.Text = "Sin movimientos registrados";
                lblEstado.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else
            {
                lblEstado.Text = "⚠ Advertencia: Mayorización descuadrada";
                lblEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        private void btnCambiarVista_Click(object sender, EventArgs e)
        {
            if (pnlGrillaContenedor.Visible)
            {
                pnlGrillaContenedor.Visible = false;
                pnlScroll.Visible = true;
                btnCambiarVista.Text = "📄 Vista Grilla";
            }
            else
            {
                pnlScroll.Visible = false;
                pnlGrillaContenedor.Visible = true;
                btnCambiarVista.Text = "🗂️ Vista Tarjetas";
            }
        }

        private void cmbCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoCombo) return;
            CargarDatos(dtpDesde.Value.Date, dtpHasta.Value.Date);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatos(dtpDesde.Value.Date, dtpHasta.Value.Date);
        }
    }
}
