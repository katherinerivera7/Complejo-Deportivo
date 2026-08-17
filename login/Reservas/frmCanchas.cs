using System;
using System.Data;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmCanchas : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private bool configurandoFiltro = false;
        private bool busquedaAutomaticaAplicada = false;

        public frmCanchas()
        {
            InitializeComponent();

            dgvCanchas.AutoGenerateColumns = false;

            dgvCanchas.Columns[0].Name = "colCanchaID";
            dgvCanchas.Columns[0].DataPropertyName = "CanchaID";

            dgvCanchas.Columns[1].Name = "colNombre";
            dgvCanchas.Columns[1].DataPropertyName = "Nombre";

            dgvCanchas.Columns[2].Name = "colTipo";
            dgvCanchas.Columns[2].DataPropertyName = "Tipo";

            dgvCanchas.Columns[3].Name = "colPrecioHora";
            dgvCanchas.Columns[3].DataPropertyName = "PrecioHora";

            dgvCanchas.Columns[4].Name = "colEstado";
            dgvCanchas.Columns[4].DataPropertyName = "Estado";
        }

        private void frmCanchas_Load(object sender, EventArgs e)
        {
            ConfigurarFiltro();
            CargarCanchas();
        }

        private void ConfigurarFiltro()
        {
            configurandoFiltro = true;

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("ID Cancha");
            cmbFiltro.Items.Add("Nombre");
            cmbFiltro.Items.Add("Tipo");
            cmbFiltro.Items.Add("Precio por hora");
            cmbFiltro.Items.Add("Estado");
            cmbFiltro.SelectedIndex = 0;

            configurandoFiltro = false;
        }

        private void CargarCanchas()
        {
            try
            {
                string texto = txtFiltro.Text.Trim().Replace("'", "''");
                string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

                string consulta = @"SELECT CanchaID, Nombre, Tipo, PrecioHora, Estado
                                    FROM Canchas";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    switch (filtro)
                    {
                        case "ID Cancha":
                            consulta += " WHERE CONVERT(VARCHAR(20), CanchaID) LIKE '%" + texto + "%'";
                            break;

                        case "Nombre":
                            consulta += " WHERE Nombre LIKE '%" + texto + "%'";
                            break;

                        case "Tipo":
                            consulta += " WHERE Tipo LIKE '%" + texto + "%'";
                            break;

                        case "Precio por hora":
                            consulta += " WHERE CONVERT(VARCHAR(30), PrecioHora) LIKE '%" + texto + "%'";
                            break;

                        case "Estado":
                            consulta += " WHERE CONVERT(VARCHAR(30), Estado) LIKE '%" + texto + "%'";
                            break;

                        default:
                            consulta += @" WHERE CONCAT(
                                          CONVERT(VARCHAR(20), CanchaID), ' ',
                                          Nombre, ' ',
                                          Tipo, ' ',
                                          CONVERT(VARCHAR(30), PrecioHora), ' ',
                                          CONVERT(VARCHAR(30), Estado)
                                          ) LIKE '%" + texto + "%'";
                            break;
                    }
                }

                consulta += " ORDER BY CanchaID DESC";

                DataTable tabla = conSQL.retornaRegistros(consulta);

                if (tabla == null)
                {
                    MessageBox.Show("No se pudieron cargar las canchas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvCanchas.DataSource = tabla;
                dgvCanchas.ClearSelection();
                dgvCanchas.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las canchas:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCanchas();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtFiltro.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarCanchas();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarCanchas();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarCanchas();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!configurandoFiltro && cmbFiltro.SelectedIndex >= 0)
            {
                CargarCanchas();
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmCrearCancha frm = new frmCrearCancha();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarCanchas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCanchas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cancha para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int canchaID = Convert.ToInt32(dgvCanchas.SelectedRows[0].Cells["colCanchaID"].Value);

            frmCrearCancha frm = new frmCrearCancha(canchaID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            CargarCanchas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCanchas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cancha para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int canchaID = Convert.ToInt32(dgvCanchas.SelectedRows[0].Cells["colCanchaID"].Value);
            string nombre = dgvCanchas.SelectedRows[0].Cells["colNombre"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar la cancha " + nombre + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            if (conSQL.borrarDatos("Canchas", "CanchaID = " + canchaID))
            {
                MessageBox.Show("Cancha eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCanchas();
            }
        }
    }
}