using login.Promciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmInventarioBar : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

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
            CargarProductos();
        }

        private void CargarProductos()
        {
            string consulta = @"SELECT p.ProductoID, c.Nombre AS Categoria, p.Nombre, p.Precio, p.Stock FROM Productos p INNER JOIN Categorias c ON p.CategoriaID = c.CategoriaID ORDER BY p.ProductoID DESC";

            dgvProductos.DataSource = conSQL.retornaRegistros(consulta);
            dgvProductos.ClearSelection();
            dgvProductos.CurrentCell = null;
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

            DialogResult respuesta = MessageBox.Show("¿Desea eliminar el producto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

            pnlContenidoo.Controls.Clear();
            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;

            frm.Show();
        }
    }
}