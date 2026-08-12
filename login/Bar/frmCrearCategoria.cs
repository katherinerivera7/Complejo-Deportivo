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
    public partial class frmCrearCategoria : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        int tipo = 1;
        int categoriaID = 0;
        public frmCrearCategoria()
        {
            InitializeComponent();
        }
        public frmCrearCategoria(int id)
        {
            InitializeComponent();
            categoriaID = id;
            tipo = 2;
        }

        private void frmCrearCategoria_Load(object sender, EventArgs e)
        {
            if (tipo == 2)
            {
                CargarCategoria();
                lblCrearCategoría.Text = "Editar categoría";
                btnCrear.Text = "Guardar cambios";
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombre.Text.Trim();

            if (tipo == 1)
            {
                if (oCon.insertarCategoria(nombre))
                {
                    MessageBox.Show("Categoría registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else if (tipo == 2)
            {
                if (oCon.actualizarCategoria(categoriaID, nombre))
                {
                    MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        private void CargarCategoria()
        {
            DataTable tabla = oCon.retornaRegistros("SELECT Nombre FROM Categorias WHERE CategoriaID = " + categoriaID);

            if (tabla.Rows.Count == 0)
                return;

            txtNombre.Text = tabla.Rows[0]["Nombre"].ToString();
        }

    }
}
