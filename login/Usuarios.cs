using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.GestionDeUsuarios;
using System.Data.SqlClient;

namespace login
{
    public partial class Usuarios : Form
    {
        string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";
        public Usuarios()
        {
            InitializeComponent();
        }
  
     
        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void CargarClientes()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = @"
                SELECT
                    ClienteID,
                    Cedula,
                    Nombre,
                    Apellido,
                    Correo,
                    Telefono,
                    Ciudad,
                    Direccion,
                    FechaNacimiento
                FROM Clientes
                ORDER BY ClienteID DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);

                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dgvClientes.DataSource = tabla;

                    dgvClientes.ClearSelection();
                    dgvClientes.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los clientes:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                MessageBox.Show(
                    "Seleccione un cliente para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int clienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["colClienteID"].Value
            );

            frmRegistrarCliente ventana =
                new frmRegistrarCliente(clienteID);

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
                MessageBox.Show(
                    "Seleccione un cliente para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int clienteID = Convert.ToInt32(
                dgvClientes.SelectedRows[0]
                .Cells["colClienteID"].Value
            );

            string nombre = dgvClientes.SelectedRows[0]
                .Cells["colNombres"].Value.ToString();

            string apellido = dgvClientes.SelectedRows[0]
                .Cells["colApellidos"].Value.ToString();

            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar al cliente {nombre} {apellido}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conexion =
                       new SqlConnection(conexionString))
                {
                    string consulta = @"
                DELETE FROM Clientes
                WHERE ClienteID = @ClienteID";

                    using (SqlCommand cmd =
                           new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue(
                            "@ClienteID", clienteID);

                        conexion.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Cliente eliminado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar el cliente:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

