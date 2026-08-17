using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using login.GestionDeUsuarios;

namespace login
{
    public partial class Usuarios : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        private bool busquedaAutomaticaAplicada = false;

        string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos");
            cmbFiltro.Items.Add("Cédula");
            cmbFiltro.Items.Add("Nombres");
            cmbFiltro.Items.Add("Apellidos");
            cmbFiltro.Items.Add("Correo");
            cmbFiltro.Items.Add("Teléfono");
            cmbFiltro.Items.Add("Ciudad");
            cmbFiltro.SelectedIndex = 0;

            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                string texto = txtBuscar.Text.Trim().Replace("'", "''");
                string filtro = cmbFiltro.SelectedItem?.ToString() ?? "Todos";

                string consulta = @"SELECT ClienteID, Cedula, Nombre, Apellido, Correo, Telefono, Ciudad, Direccion, FechaNacimiento
                                    FROM Clientes";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    switch (filtro)
                    {
                        case "Cédula":
                            consulta += " WHERE Cedula LIKE '%" + texto + "%'";
                            break;

                        case "Nombres":
                            consulta += " WHERE Nombre LIKE '%" + texto + "%'";
                            break;

                        case "Apellidos":
                            consulta += " WHERE Apellido LIKE '%" + texto + "%'";
                            break;

                        case "Correo":
                            consulta += " WHERE Correo LIKE '%" + texto + "%'";
                            break;

                        case "Teléfono":
                            consulta += " WHERE Telefono LIKE '%" + texto + "%'";
                            break;

                        case "Ciudad":
                            consulta += " WHERE Ciudad LIKE '%" + texto + "%'";
                            break;

                        default:
                            consulta += @" WHERE CONCAT(Cedula, ' ', Nombre, ' ', Apellido, ' ', Correo, ' ', Telefono, ' ', Ciudad, ' ', Direccion)
                                          LIKE '%" + texto + "%'";
                            break;
                    }
                }

                consulta += " ORDER BY ClienteID DESC";

                DataTable tabla = oCon.retornaRegistros(consulta);

                if (tabla == null)
                {
                    MessageBox.Show("No se pudieron cargar los clientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvClientes.DataSource = tabla;
                dgvClientes.ClearSelection();
                dgvClientes.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarClientes();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            int cantidadCaracteres = txtBuscar.Text.Trim().Length;

            if (cantidadCaracteres > 4)
            {
                busquedaAutomaticaAplicada = true;
                CargarClientes();
            }
            else if (cantidadCaracteres == 0 || busquedaAutomaticaAplicada)
            {
                busquedaAutomaticaAplicada = false;
                CargarClientes();
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmRegistrarCliente ventana = new frmRegistrarCliente();
            ventana.StartPosition = FormStartPosition.CenterParent;

            if (ventana.ShowDialog(this) == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colClienteID"].Value);

            frmRegistrarCliente ventana = new frmRegistrarCliente(clienteID);
            ventana.StartPosition = FormStartPosition.CenterParent;

            if (ventana.ShowDialog(this) == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colClienteID"].Value);
            string nombre = dgvClientes.SelectedRows[0].Cells["colNombres"].Value.ToString();
            string apellido = dgvClientes.SelectedRows[0].Cells["colApellidos"].Value.ToString();

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar al cliente {nombre} {apellido}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = "DELETE FROM Clientes WHERE ClienteID = @ClienteID";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = clienteID;
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                CargarClientes();
            }
        }
    }
}