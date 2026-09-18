using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmHistorialMovimientos : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        public frmHistorialMovimientos()
        {
            InitializeComponent();

            dgvMovimientos.AutoGenerateColumns = false;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvMovimientos.Columns.Contains("colCargo"))
                dgvMovimientos.Columns.Remove("colCargo");

            dgvMovimientos.Columns["colMovimientoID"].DataPropertyName = "MovimientoID";
            dgvMovimientos.Columns["colProducto"].DataPropertyName = "Producto";
            dgvMovimientos.Columns["colUsuario"].DataPropertyName = "Usuario";
            dgvMovimientos.Columns["colTipoMovimiento"].DataPropertyName = "TipoMovimiento";
            dgvMovimientos.Columns["colCantidad"].DataPropertyName = "Cantidad";
            dgvMovimientos.Columns["colFechaMovimiento"].DataPropertyName = "FechaMovimiento";
            dgvMovimientos.Columns["colMotivo"].DataPropertyName = "Motivo";

            dgvMovimientos.Columns["colMovimientoID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMovimientos.Columns["colMovimientoID"].Width = 60;

            ConfigurarFiltro();
        }

        private void ConfigurarFiltro()
        {
            cmbFiltro.Items.Clear();

            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("ID Producto");
            cmbFiltro.Items.Add("Producto");
            cmbFiltro.Items.Add("Usuario");
            cmbFiltro.Items.Add("Tipo");
            cmbFiltro.Items.Add("Cantidad");
            cmbFiltro.Items.Add("Fecha");
            cmbFiltro.Items.Add("Motivo");

            cmbFiltro.SelectedIndex = 0;
        }

        private void frmHistorialMovimientos_Load(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void CargarMovimientos()
        {
            string texto = txtFiltro.Text.Trim();
            string filtro = cmbFiltro.Text.Trim();

            string consulta = @"
                SELECT
                    m.MovimientoID,
                    p.ProductoID,
                    p.Nombre AS Producto,
                    u.NombreUsuario AS Usuario,
                    m.TipoMovimiento,
                    m.Cantidad,
                    m.FechaMovimiento,
                    m.Motivo
                FROM MovimientosInventario m
                INNER JOIN Productos p
                    ON m.ProductoID = p.ProductoID
                INNER JOIN Usuarios u
                    ON m.UsuarioID = u.UsuarioID";

            if (!string.IsNullOrWhiteSpace(texto))
            {
                string textoSeguro = texto.Replace("'", "''");

                switch (filtro)
                {
                    case "ID Producto":
                        consulta +=
                            " WHERE CONVERT(VARCHAR(20), p.ProductoID) LIKE '%" +
                            textoSeguro + "%'";
                        break;

                    case "Producto":
                        consulta +=
                            " WHERE p.Nombre LIKE '%" +
                            textoSeguro + "%'";
                        break;

                    case "Usuario":
                        consulta +=
                            " WHERE u.NombreUsuario LIKE '%" +
                            textoSeguro + "%'";
                        break;

                    case "Tipo":
                        consulta +=
                            " WHERE m.TipoMovimiento LIKE '%" +
                            textoSeguro + "%'";
                        break;

                    case "Cantidad":
                        consulta +=
                            " WHERE CONVERT(VARCHAR(20), m.Cantidad) LIKE '%" +
                            textoSeguro + "%'";
                        break;

                    case "Fecha":
                        consulta +=
                            " WHERE CONVERT(VARCHAR(10), m.FechaMovimiento, 103) LIKE '%" +
                            textoSeguro + "%'";
                        break;

                    case "Motivo":
                        consulta +=
                            " WHERE m.Motivo LIKE '%" +
                            textoSeguro + "%'";
                        break;

                    default:
                        consulta += @"
                            WHERE
                                CONVERT(VARCHAR(20), p.ProductoID) LIKE '%" + textoSeguro + @"%'
                                OR p.Nombre LIKE '%" + textoSeguro + @"%'
                                OR u.NombreUsuario LIKE '%" + textoSeguro + @"%'
                                OR m.TipoMovimiento LIKE '%" + textoSeguro + @"%'
                                OR CONVERT(VARCHAR(20), m.Cantidad) LIKE '%" + textoSeguro + @"%'
                                OR CONVERT(VARCHAR(10), m.FechaMovimiento, 103) LIKE '%" + textoSeguro + @"%'
                                OR m.Motivo LIKE '%" + textoSeguro + @"%'";
                        break;
                }
            }

            consulta += " ORDER BY m.MovimientoID DESC";

            try
            {
                DataTable tabla = conSQL.retornaRegistros(consulta);

                dgvMovimientos.DataSource = tabla;
                dgvMovimientos.ClearSelection();
                dgvMovimientos.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los movimientos:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarMovimientos();
                e.SuppressKeyPress = true;
            }
        }

        private void pnlContenidoo_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlContenidoo.Controls.Clear();

            frmInventarioBar frm = new frmInventarioBar();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;

            frm.Show();
        }
    }
}