using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_Contable.Modelos;

namespace App_Contable.Presentacion
{
    // ══════════════════════════════════════════════════════════════════
    //  Diálogo modal para agregar o editar una cuenta del catálogo
    // ══════════════════════════════════════════════════════════════════
    public class frmEditarCuenta : Form
    {
        // ─── controles ────────────────────────────────────────────────
        private Label      lblTitulo        = null!;
        private Label      lblCodigo        = null!;
        private TextBox    txtCodigo        = null!;
        private Label      lblNombre        = null!;
        private TextBox    txtNombre        = null!;
        private Label      lblNaturaleza    = null!;
        private ComboBox   cmbNaturaleza    = null!;
        private Label      lblSubcuentas    = null!;
        private Label      lblAyudaSub      = null!;
        private CheckedListBox clbSubcuentas = null!;
        private TextBox    txtNuevaSubcuenta = null!;
        private Button     btnAgregarSub    = null!;
        private Button     btnQuitarSub     = null!;
        private Button     btnGuardar       = null!;
        private Button     btnCancelar      = null!;

        public CuentaDefinicion? Resultado { get; private set; }

        private readonly CuentaDefinicion? _cuentaExistente;

        public frmEditarCuenta(CuentaDefinicion? cuentaExistente = null)
        {
            _cuentaExistente = cuentaExistente;
            BuildUI();
            CargarDatos();
        }

        // ─── construcción de UI ───────────────────────────────────────
        private void BuildUI()
        {
            this.Text            = _cuentaExistente == null ? "Nueva Cuenta" : "Editar Cuenta";
            this.Size            = new Size(480, 560);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.BackColor       = Color.White;
            this.Font            = new Font("Segoe UI", 9.5f);

            // título
            lblTitulo = new Label
            {
                Text      = _cuentaExistente == null ? "➕ Nueva Cuenta" : "✏ Editar Cuenta",
                Font      = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location  = new Point(20, 18),
                AutoSize  = true
            };

            // Código
            lblCodigo = new Label { Text = "Código contable:", Location = new Point(20, 68), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtCodigo = new TextBox { Location = new Point(20, 88), Width = 160, MaxLength = 10 };
            EstilizarTextBox(txtCodigo);

            // Nombre
            lblNombre = new Label { Text = "Nombre de la cuenta:", Location = new Point(20, 124), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            txtNombre = new TextBox { Location = new Point(20, 144), Width = 420, MaxLength = 80 };
            EstilizarTextBox(txtNombre);

            // Naturaleza
            lblNaturaleza = new Label { Text = "Naturaleza del saldo:", Location = new Point(20, 182), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            cmbNaturaleza = new ComboBox
            {
                Location      = new Point(20, 202),
                Width         = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle     = FlatStyle.Flat
            };
            cmbNaturaleza.Items.AddRange(new object[] { "Deudora  (Debe +)", "Acreedora  (Haber +)" });
            cmbNaturaleza.SelectedIndex = 0;

            // Subcuentas
            lblSubcuentas = new Label { Text = "Subcuentas (opcional):", Location = new Point(20, 246), AutoSize = true, ForeColor = Color.FromArgb(71, 85, 105) };
            lblAyudaSub   = new Label
            {
                Text      = "Si agregas subcuentas, el sistema las mostrará al registrar asientos.",
                Location  = new Point(20, 264),
                Size      = new Size(420, 18),
                ForeColor = Color.FromArgb(100, 116, 139),
                Font      = new Font("Segoe UI", 8.5f)
            };

            clbSubcuentas = new CheckedListBox
            {
                Location      = new Point(20, 286),
                Size          = new Size(420, 110),
                BorderStyle   = BorderStyle.FixedSingle,
                CheckOnClick  = true,
                Font          = new Font("Segoe UI", 9.5f)
            };

            txtNuevaSubcuenta = new TextBox
            {
                Location    = new Point(20, 404),
                Width       = 270,
                PlaceholderText = "Escribir nombre de subcuenta..."
            };
            EstilizarTextBox(txtNuevaSubcuenta);
            txtNuevaSubcuenta.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; AgregarSubcuenta(); } };

            btnAgregarSub = CrearBoton("➕ Agregar", new Point(300, 402), 70, Color.FromArgb(37, 99, 235), Color.White, 26);
            btnAgregarSub.Click += (s, e) => AgregarSubcuenta();

            btnQuitarSub = CrearBoton("🗑 Quitar", new Point(376, 402), 66, Color.FromArgb(254, 242, 242), Color.FromArgb(185, 28, 28), 26);
            btnQuitarSub.Click += (s, e) => QuitarSubcuenta();

            // Botones inferiores
            btnGuardar  = CrearBoton("✓ Guardar", new Point(20, 444), 110, Color.FromArgb(22, 163, 74), Color.White);
            btnGuardar.Click  += BtnGuardar_Click;
            btnCancelar = CrearBoton("✕ Cancelar", new Point(140, 444), 110, Color.FromArgb(241, 245, 249), Color.FromArgb(71, 85, 105));
            btnCancelar.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            // Agregar todos los controles
            this.Controls.AddRange(new Control[] {
                lblTitulo,
                lblCodigo, txtCodigo,
                lblNombre, txtNombre,
                lblNaturaleza, cmbNaturaleza,
                lblSubcuentas, lblAyudaSub, clbSubcuentas,
                txtNuevaSubcuenta, btnAgregarSub, btnQuitarSub,
                btnGuardar, btnCancelar
            });
        }

        private static void EstilizarTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font        = new Font("Segoe UI", 9.5f);
        }

        private static Button CrearBoton(string texto, Point pos, int ancho, Color fondo, Color texto2, int alto = 32)
        {
            var btn = new Button
            {
                Text             = texto,
                Location         = pos,
                Size             = new Size(ancho, alto),
                BackColor        = fondo,
                ForeColor        = texto2,
                FlatStyle        = FlatStyle.Flat,
                Cursor           = Cursors.Hand,
                Font             = new Font("Segoe UI", 9f, FontStyle.Bold),
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        // ─── lógica ───────────────────────────────────────────────────
        private void CargarDatos()
        {
            if (_cuentaExistente == null) return;

            txtCodigo.Text = _cuentaExistente.Codigo;
            txtNombre.Text = _cuentaExistente.Nombre;
            cmbNaturaleza.SelectedIndex = _cuentaExistente.NaturalezaPredeterminada == CuentaDefinicion.TipoNaturaleza.Deudora ? 0 : 1;

            foreach (var sub in _cuentaExistente.Subcuentas)
                clbSubcuentas.Items.Add(sub, false);
        }

        private void AgregarSubcuenta()
        {
            string sub = txtNuevaSubcuenta.Text.Trim();
            if (string.IsNullOrWhiteSpace(sub)) return;

            // evitar duplicados
            bool existe = clbSubcuentas.Items.Cast<string>().Any(s => s.Equals(sub, StringComparison.OrdinalIgnoreCase));
            if (existe)
            {
                MessageBox.Show("Esa subcuenta ya existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clbSubcuentas.Items.Add(sub, false);
            txtNuevaSubcuenta.Clear();
            txtNuevaSubcuenta.Focus();
        }

        private void QuitarSubcuenta()
        {
            // Quitar las que están marcadas con check
            var marcadas = clbSubcuentas.CheckedItems.Cast<string>().ToList();
            foreach (var item in marcadas)
                clbSubcuentas.Items.Remove(item);
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El código contable es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la cuenta es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus(); return;
            }

            var subcuentas = clbSubcuentas.Items.Cast<string>().ToList();

            Resultado = new CuentaDefinicion
            {
                Codigo   = txtCodigo.Text.Trim().ToUpper(),
                Nombre   = txtNombre.Text.Trim(),
                TieneSubcuentas  = subcuentas.Any(),
                Subcuentas       = subcuentas,
                NaturalezaPredeterminada = cmbNaturaleza.SelectedIndex == 0
                    ? CuentaDefinicion.TipoNaturaleza.Deudora
                    : CuentaDefinicion.TipoNaturaleza.Acreedora
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }

    // ══════════════════════════════════════════════════════════════════
    //  Formulario principal: Catálogo de Cuentas
    // ══════════════════════════════════════════════════════════════════
    public partial class frmCatalogoCuentas : Form
    {
        public frmCatalogoCuentas()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarCatalogo();
        }

        // ─── configuración ────────────────────────────────────────────
        private void ConfigurarFormulario()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            dgvCatalogo.AutoGenerateColumns = false;
            dgvCatalogo.DoubleBuffered(true);

            foreach (DataGridViewColumn col in dgvCatalogo.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            AplicarEstiloGrilla();

            // Doble clic abre edición
            dgvCatalogo.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) EditarCuenta();
            };

            // Botones
            btnNueva.Click   += (s, e) => AgregarCuenta();
            btnEditar.Click  += (s, e) => EditarCuenta();
            btnEliminar.Click += (s, e) => EliminarCuenta();

            txtBuscar.TextChanged += (s, e) => FiltrarCatalogo();

            pnlToolbar.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, pnlToolbar.Height - 1, pnlToolbar.Width, pnlToolbar.Height - 1);
            };

            pnlFooter.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240));
                e.Graphics.DrawLine(pen, 0, 0, pnlFooter.Width, 0);
            };
        }

        private void AplicarEstiloGrilla()
        {
            dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor      = Color.FromArgb(189, 215, 238);
            dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor      = Color.FromArgb(15, 23, 42);
            dgvCatalogo.ColumnHeadersDefaultCellStyle.Font           = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgvCatalogo.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(189, 215, 238);
            dgvCatalogo.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvCatalogo.EnableHeadersVisualStyles = false;

            dgvCatalogo.DefaultCellStyle.BackColor      = Color.White;
            dgvCatalogo.DefaultCellStyle.ForeColor      = Color.FromArgb(30, 41, 59);
            dgvCatalogo.DefaultCellStyle.Font           = new Font("Segoe UI", 9.5f);
            dgvCatalogo.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 234, 245);
            dgvCatalogo.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            dgvCatalogo.GridColor       = Color.FromArgb(203, 213, 225);
            dgvCatalogo.BackgroundColor = Color.White;
            dgvCatalogo.ColumnHeadersHeight = 36;
            dgvCatalogo.RowTemplate.Height  = 30;

            dgvCatalogo.RowPrePaint += Dgv_RowPrePaint;
        }

        // ─── carga y filtro ───────────────────────────────────────────
        private void CargarCatalogo(string? filtro = null)
        {
            dgvCatalogo.Rows.Clear();
            lblTotalCuentas.Text = $"Total Cuentas: {CatalogoCuentasConfig.CuentasPermitidas.Count}";

            var cuentas = CatalogoCuentasConfig.CuentasPermitidas.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                cuentas = cuentas.Where(c =>
                    c.Codigo.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    c.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase));
            }

            foreach (var cuenta in cuentas.OrderBy(c => c.Codigo))
            {
                string naturaleza = cuenta.NaturalezaPredeterminada == CuentaDefinicion.TipoNaturaleza.Deudora
                    ? "Deudora" : "Acreedora";
                string subcuentas = cuenta.TieneSubcuentas && cuenta.Subcuentas.Any()
                    ? string.Join(" · ", cuenta.Subcuentas)
                    : "—";

                int idx = dgvCatalogo.Rows.Add(cuenta.Codigo, cuenta.Nombre, subcuentas, naturaleza);
                dgvCatalogo.Rows[idx].Tag = cuenta;
            }
        }

        private void FiltrarCatalogo() => CargarCatalogo(txtBuscar.Text.Trim());

        // ─── operaciones CRUD ─────────────────────────────────────────
        private void AgregarCuenta()
        {
            using var dlg = new frmEditarCuenta();
            if (dlg.ShowDialog(this) != DialogResult.OK || dlg.Resultado == null) return;

            // Verificar duplicado de código o nombre
            var nueva = dlg.Resultado;
            if (CatalogoCuentasConfig.CuentasPermitidas.Any(c =>
                c.Codigo.Equals(nueva.Codigo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Ya existe una cuenta con el código '{nueva.Codigo}'.", "Código duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CatalogoCuentasConfig.CuentasPermitidas.Any(c =>
                c.Nombre.Equals(nueva.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Ya existe una cuenta con el nombre '{nueva.Nombre}'.", "Nombre duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CatalogoCuentasConfig.CuentasPermitidas.Add(nueva);
            CargarCatalogo(txtBuscar.Text.Trim());
            SeleccionarPorNombre(nueva.Nombre);
        }

        private void EditarCuenta()
        {
            if (dgvCatalogo.CurrentRow?.Tag is not CuentaDefinicion cuentaOriginal) return;

            using var dlg = new frmEditarCuenta(cuentaOriginal);
            if (dlg.ShowDialog(this) != DialogResult.OK || dlg.Resultado == null) return;

            var editada = dlg.Resultado;

            // Verificar colisión de código/nombre con OTRAS cuentas
            if (CatalogoCuentasConfig.CuentasPermitidas.Any(c =>
                c != cuentaOriginal &&
                c.Codigo.Equals(editada.Codigo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Otra cuenta ya usa el código '{editada.Codigo}'.", "Código duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Reemplazar en la lista estática
            int pos = CatalogoCuentasConfig.CuentasPermitidas.IndexOf(cuentaOriginal);
            if (pos >= 0)
                CatalogoCuentasConfig.CuentasPermitidas[pos] = editada;

            CargarCatalogo(txtBuscar.Text.Trim());
            SeleccionarPorNombre(editada.Nombre);
        }

        private void EliminarCuenta()
        {
            if (dgvCatalogo.CurrentRow?.Tag is not CuentaDefinicion cuenta) return;

            var respuesta = MessageBox.Show(
                $"¿Deseas eliminar la cuenta '{cuenta.Nombre}' ({cuenta.Codigo})?\n\nEsta acción no afecta los asientos ya registrados.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes) return;

            CatalogoCuentasConfig.CuentasPermitidas.Remove(cuenta);
            CargarCatalogo(txtBuscar.Text.Trim());
        }

        private void SeleccionarPorNombre(string nombre)
        {
            foreach (DataGridViewRow row in dgvCatalogo.Rows)
            {
                if (row.Tag is CuentaDefinicion c && c.Nombre == nombre)
                {
                    dgvCatalogo.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        // ─── pintado visual por fila ──────────────────────────────────
        private void Dgv_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCatalogo.Rows.Count) return;

            if (dgvCatalogo.Rows[e.RowIndex].Tag is not CuentaDefinicion cuenta) return;

            bool esDeudora = cuenta.NaturalezaPredeterminada == CuentaDefinicion.TipoNaturaleza.Deudora;

            // Deudoras = fondo azul muy suave; Acreedoras = fondo salmón muy suave
            dgvCatalogo.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                esDeudora ? Color.FromArgb(239, 246, 255) : Color.FromArgb(255, 244, 243);
            dgvCatalogo.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
        }
    }
}
