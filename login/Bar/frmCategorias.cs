using System;
using System.Data;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmCategorias : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private bool configurandoFiltro = false;
        private bool busquedaAutomaticaAplicada = false;

        public frmCategorias()
        {
            InitializeComponent();

            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.Columns["colCategoriaID"].DataPropertyName = "CategoriaID";
            dgvCategorias.Columns["colNombre"].DataPropertyName = "Nombre";
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            ConfigurarFiltro();
            CargarCategorias();
        }

        private void ConfigurarFiltro()
        {
            configurandoFiltro = true;

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("ID Categoría");
            cmbFiltro.Items.Add("Nombre");
            cmbFiltro.SelectedIndex = 0;

            configurandoFiltro = false;
        }

        private void CargarCategorias()
        {
            try
            {
                string texto = txtFiltro.Text.Trim().Replace("'", "''");
                string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

                string consulta = "SELECT CategoriaID, Nombre FROM Categorias";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    switch (filtro)
                    {
                        case "ID Categoría":
                            consulta += " WHERE CONVERT(VARCHAR(20), CategoriaID) LIKE '%" + texto + "%'";
                            break;

                        case "Nombre":
                            consulta += " WHERE Nombre LIKE '%" + texto + "%'";
                            break;

                        default:
                            consulta += @" WHERE CONCAT(
                                          CONVERT(VARCHAR(20), CategoriaID), ' ',
                                          Nombre
                                          ) LIKE '%" + texto + "%'";
                            break;
                    }
                }

                consulta += " ORDER BY CategoriaID DESC";

                DataTable tabla = conSQL.retornaRegistros(consulta);

                if (tabla == null)
                {
                    MessageBox.Show("No se pudieron cargar las categorías.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvCategorias.DataSource = tabla;
                dgvCategorias.ClearSelection();
                dgvCategorias.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!configurandoFiltro && cmbFiltro.SelectedIndex >= 0)
            {
                CargarCategorias();
            }
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

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar la categoría " + nombre + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            if (conSQL.borrarDatos("Categorias", "CategoriaID = " + categoriaID))
            {
                MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCategorias();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtFiltro.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarCategorias();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarCategorias();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarCategorias();
                e.SuppressKeyPress = true;
            }
        }
    }
}