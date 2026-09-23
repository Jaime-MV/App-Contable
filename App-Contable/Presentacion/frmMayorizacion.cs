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

        public frmMayorizacion()
        {
            InitializeComponent();
            this.Load += (s, e) => CargarDatos();
            this.Shown += (s, e) => AjustarAnchoTarjetas();
            pnlCuentas.SizeChanged += (s, e) => AjustarAnchoTarjetas();
        }

        private void CargarDatos(DateTime? desde = null, DateTime? hasta = null)
        {
            var cuentas = _servicio.GenerarMayor(desde, hasta);

            // Limpiar panel
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
                    Location = new Point(20, 30)
                };
                pnlCuentas.Controls.Add(lbl);
                pnlCuentas.ResumeLayout();
                ActualizarResumen(cuentas);
                return;
            }

            int y = 20;
            foreach (var cuenta in cuentas)
            {
                var card = CrearTarjetaCuenta(cuenta, y);
                pnlCuentas.Controls.Add(card);
                y += card.Height + 20;
            }

            pnlCuentas.ResumeLayout();
            ActualizarResumen(cuentas);
            AjustarAnchoTarjetas();
        }

        private void AjustarAnchoTarjetas()
        {
            if (pnlCuentas == null || pnlCuentas.Controls.Count == 0) return;

            int cardWidth = Math.Max(300, pnlCuentas.ClientSize.Width - 36);

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
                                    lblTitulo.Width = Math.Max(100, cardWidth - 230);
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
            int cardWidth = Math.Max(300, pnlCuentas.ClientSize.Width - 36);

            // Panel exterior (sombra / borde)
            var card = new Panel
            {
                BackColor = Color.White,
                Location = new Point(16, top),
                Width = cardWidth,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(0)
            };

            // ── ENCABEZADO de la tarjeta ──────────────────────────────────
            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.FromArgb(30, 41, 59)
            };

            string tituloTexto = string.IsNullOrWhiteSpace(cuenta.NombreSubcuenta)
                ? cuenta.NombreCuenta
                : $"{cuenta.NombreCuenta}  ›  {cuenta.NombreSubcuenta}";

            var lblTitulo = new Label
            {
                Text = $"  📊  {tituloTexto}",
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold),
                Dock = DockStyle.Left,
                AutoSize = false,
                Width = cardWidth - 230,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            // Badge naturaleza saldo
            string naturalezaTexto = cuenta.NaturalezaSaldo == "Deudor" ? "Saldo Deudor" : "Saldo Acreedor";
            Color naturalezaColor = cuenta.NaturalezaSaldo == "Deudor"
                ? Color.FromArgb(37, 99, 235)
                : Color.FromArgb(220, 38, 38);

            var lblNaturaleza = new Label
            {
                Text = $"{naturalezaTexto}: {cuenta.SaldoFinal:N2}",
                ForeColor = Color.White,
                BackColor = naturalezaColor,
                Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold),
                Dock = DockStyle.Right,
                AutoSize = false,
                Width = 220,
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnlHeader.Controls.Add(lblNaturaleza);
            pnlHeader.Controls.Add(lblTitulo);

            // ── TABLA de movimientos (DataGridView) ───────────────────────
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
                GridColor = Color.FromArgb(226, 232, 240),
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                RowTemplate = { Height = 26 },
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Estilo encabezado columnas
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(189, 215, 238);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(189, 215, 238);
            dgv.ColumnHeadersHeight = 30;
            dgv.EnableHeadersVisualStyles = false;

            // Columnas
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFecha", HeaderText = "Fecha", FillWeight = 70, SortMode = DataGridViewColumnSortMode.NotSortable });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAsiento", HeaderText = "Asiento", FillWeight = 45, SortMode = DataGridViewColumnSortMode.NotSortable });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colConcepto", HeaderText = "Concepto / Glosa", FillWeight = 230, SortMode = DataGridViewColumnSortMode.NotSortable });

            var colDebe = new DataGridViewTextBoxColumn { Name = "colDebe", HeaderText = "Debe", FillWeight = 90, SortMode = DataGridViewColumnSortMode.NotSortable };
            colDebe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDebe.DefaultCellStyle.Format = "N2";

            var colHaber = new DataGridViewTextBoxColumn { Name = "colHaber", HeaderText = "Haber", FillWeight = 90, SortMode = DataGridViewColumnSortMode.NotSortable };
            colHaber.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHaber.DefaultCellStyle.Format = "N2";

            var colSaldo = new DataGridViewTextBoxColumn { Name = "colSaldo", HeaderText = "Saldo", FillWeight = 90, SortMode = DataGridViewColumnSortMode.NotSortable };
            colSaldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSaldo.DefaultCellStyle.Format = "N2";
            colSaldo.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);

            var colNat = new DataGridViewTextBoxColumn { Name = "colNat", HeaderText = "N", FillWeight = 25, SortMode = DataGridViewColumnSortMode.NotSortable };
            colNat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNat.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold);

            dgv.Columns.AddRange(colDebe, colHaber, colSaldo, colNat);

            // Poblar filas
            foreach (var fila in cuenta.Movimientos)
            {
                int idx = dgv.Rows.Add(
                    fila.Fecha,
                    $"A-{fila.NumeroAsiento:D2}",
                    fila.Concepto,
                    fila.Debe,
                    fila.Haber,
                    fila.Saldo,
                    fila.NaturalezaSaldo
                );

                var row = dgv.Rows[idx];
                // Color leve según debe/haber
                if (fila.Debe.HasValue && fila.Debe > 0)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 249, 255);
                else
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 245);

                // Color naturaleza saldo
                row.Cells["colNat"].Style.ForeColor = fila.NaturalezaSaldo == "D"
                    ? Color.FromArgb(37, 99, 235)
                    : Color.FromArgb(220, 38, 38);
            }

            // Fila de TOTALES CIERRE
            int idxTot = dgv.Rows.Add(
                string.Empty,
                string.Empty,
                "SUMAS IGUALES",
                cuenta.TotalDebe,
                cuenta.TotalHaber,
                cuenta.SaldoFinal,
                cuenta.NaturalezaSaldo == "Deudor" ? "D" : "A"
            );
            var rowTot = dgv.Rows[idxTot];
            rowTot.DefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            rowTot.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            rowTot.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);

            // Altura total del DGV
            int altDgv = dgv.ColumnHeadersHeight + (dgv.Rows.Count * dgv.RowTemplate.Height) + 4;
            dgv.Height = altDgv;

            // ── Ajustar altura total de la tarjeta ────────────────────────
            card.Height = pnlHeader.Height + dgv.Height + 2;

            card.Controls.Add(dgv);
            card.Controls.Add(pnlHeader);

            return card;
        }

        private void ActualizarResumen(List<CuentaMayor> cuentas)
        {
            int total = cuentas.Count;
            decimal totalD = cuentas.Sum(c => c.TotalDebe);
            decimal totalH = cuentas.Sum(c => c.TotalHaber);

            lblTotalCuentas.Text = $"Cuentas: {total}";
            lblTotalDebe.Text = $"Total Debe: {totalD:N2}";
            lblTotalHaber.Text = $"Total Haber: {totalH:N2}";

            bool cuadrado = total > 0 && Math.Round(totalD, 2) == Math.Round(totalH, 2);
            if (cuadrado)
            {
                lblEstado.Text = "✓ Mayorización Cuadrada";
                lblEstado.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else if (total == 0)
            {
                lblEstado.Text = "Sin movimientos";
                lblEstado.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else
            {
                lblEstado.Text = "⚠ Totales descuadrados";
                lblEstado.ForeColor = Color.FromArgb(220, 38, 38);
            }
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
