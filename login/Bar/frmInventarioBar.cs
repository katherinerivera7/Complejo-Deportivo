using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace login.Bar
{
    public partial class frmInventarioBar : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmInventarioBar()
        {
            InitializeComponent();
        }

        private void frmInventarioBar_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
        private void CargarProductos()
        {
            string consulta = @"
                SELECT
                    p.ProductoID,
                    c.Nombre AS Categoria,
                    p.Nombre,
                    p.Precio,
                    p.Stock
                FROM Productos p
                INNER JOIN Categorias c
                    ON p.CategoriaID = c.CategoriaID
                ORDER BY p.ProductoID DESC";

            dgvProductos.DataSource =
                conSQL.retornaRegistros(consulta);

            dgvProductos.ClearSelection();
            dgvProductos.CurrentCell = null;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmInventarioBar frm = new frmInventarioBar();

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarProductos();
        }
    }
}
