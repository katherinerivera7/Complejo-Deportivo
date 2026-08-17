using System;
using System.Data;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmInventarioBar : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private bool configurandoFiltro = false;
        private bool busquedaAutomaticaAplicada = false;

        public frmInventarioBar()
        {
            InitializeComponent();

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns["colProductoID"].DataPropertyName = "ProductoID";
            dgvProductos.Columns["colCategoria"].DataPropertyName = "Categoria";
            dgvProductos.Columns["colNombre"].DataPropertyName = "Nombre";
            dgvProductos.Columns["colPrecio"].DataPropertyName = "Precio";
            dgvProductos.Columns["colStock"].DataPropertyName = "Stock";
        }

        private void frmInventarioBar_Load(object sender, EventArgs e)
        {
            ConfigurarFiltro();
            CargarProductos();
        }

        private void ConfigurarFiltro()
        {
            configurandoFiltro = true;

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("ID Producto");
            cmbFiltro.Items.Add("Categoría");
            cmbFiltro.Items.Add("Nombre");
            cmbFiltro.Items.Add("Precio");
            cmbFiltro.Items.Add("Stock");
            cmbFiltro.SelectedIndex = 0;

            configurandoFiltro = false;
        }

        private void CargarProductos()
        {
            try
            {
                string texto = txtBuscar.Text.Trim().Replace("'", "''");
                string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

                string consulta = @"SELECT p.ProductoID, c.Nombre AS Categoria, p.Nombre, p.Precio, p.Stock
                                    FROM Productos p
                                    INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    switch (filtro)
                    {
                        case "ID Producto":
                            consulta += " WHERE CONVERT(VARCHAR(20), p.ProductoID) LIKE '%" + texto + "%'";
                            break;

                        case "Categoría":
                            consulta += " WHERE c.Nombre LIKE '%" + texto + "%'";
                            break;

                        case "Nombre":
                            consulta += " WHERE p.Nombre LIKE '%" + texto + "%'";
                            break;

                        case "Precio":
                            consulta += " WHERE CONVERT(VARCHAR(30), p.Precio) LIKE '%" + texto + "%'";
                            break;

                        case "Stock":
                            consulta += " WHERE CONVERT(VARCHAR(20), p.Stock) LIKE '%" + texto + "%'";
                            break;

                        default:
                            consulta += @" WHERE CONCAT(
                                          CONVERT(VARCHAR(20), p.ProductoID), ' ',
                                          c.Nombre, ' ',
                                          p.Nombre, ' ',
                                          CONVERT(VARCHAR(30), p.Precio), ' ',
                                          CONVERT(VARCHAR(20), p.Stock)
                                          ) LIKE '%" + texto + "%'";
                            break;
                    }
                }

                consulta += " ORDER BY p.ProductoID DESC";

                DataTable tabla = conSQL.retornaRegistros(consulta);

                if (tabla == null)
                {
                    MessageBox.Show("No se pudieron cargar los productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvProductos.DataSource = tabla;
                dgvProductos.ClearSelection();
                dgvProductos.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarProductos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productoID = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["colProductoID"].Value);

            frmProductos frm = new frmProductos(productoID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productoID = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["colProductoID"].Value);
            string nombre = dgvProductos.SelectedRows[0].Cells["colNombre"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar el producto " + nombre + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            if (conSQL.borrarDatos("Productos", "ProductoID = " + productoID))
            {
                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
            }
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            frmRegistrarMovimiento frm = new frmRegistrarMovimiento();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarProductos();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pnlContenidoo.Controls.Clear();

            frmHistorialMovimientos frm = new frmHistorialMovimientos();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;
            frm.Show();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtBuscar.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarProductos();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarProductos();
            }
        }

        private void cmbFiltro_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!configurandoFiltro && cmbFiltro.SelectedIndex >= 0)
            {
                CargarProductos();
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarProductos();
                e.SuppressKeyPress = true;
            }
        }
    }
}