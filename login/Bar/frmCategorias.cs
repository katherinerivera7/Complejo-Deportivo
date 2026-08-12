using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmCategorias : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmCategorias()
        {
            InitializeComponent();
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.Columns["colCategoriaID"].DataPropertyName = "CategoriaID";
            dgvCategorias.Columns["colNombre"].DataPropertyName = "Nombre";
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }
        private void CargarCategorias()
        {
            dgvCategorias.DataSource = conSQL.retornaRegistros("SELECT CategoriaID, Nombre FROM Categorias ORDER BY CategoriaID DESC");
            dgvCategorias.ClearSelection();
            dgvCategorias.CurrentCell = null;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmCrearCategoria frm = new frmCrearCategoria();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarCategorias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoriaID = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["colCategoriaID"].Value);

            frmCrearCategoria frm = new frmCrearCategoria(categoriaID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            CargarCategorias();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoriaID = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["colCategoriaID"].Value);
            string nombre = dgvCategorias.SelectedRows[0].Cells["colNombre"].Value.ToString();

            DialogResult respuesta = MessageBox.Show("¿Desea eliminar la categoría " + nombre + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            if (conSQL.borrarDatos("Categorias", "CategoriaID = " + categoriaID))
            {
                MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
