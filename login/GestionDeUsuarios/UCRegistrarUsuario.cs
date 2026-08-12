using login.Reservas;
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

namespace login.GestionDeUsuarios
{
    public partial class UCRegistrarUsuario : UserControl
    {
        private int clienteID = 0;
        private string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";
        public UCRegistrarUsuario()
        {
            InitializeComponent();
        }
        public UCRegistrarUsuario(int id)
        {
            InitializeComponent();

            clienteID = id;

            btnCrear.Text = "Guardar cambios";
            lblCrearCliente.Text = "Editar cliente";

            CargarCliente();
        }
        private void EditarCliente()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    conexion.Open();

                    string verificar = @"
                SELECT COUNT(*)
                FROM Clientes
                WHERE Cedula = @Cedula
                AND ClienteID <> @ClienteID";

                    using (SqlCommand cmdVerificar =
                           new SqlCommand(verificar, conexion))
                    {
                        cmdVerificar.Parameters.AddWithValue(
                            "@Cedula", txtCedula.Text.Trim());

                        cmdVerificar.Parameters.AddWithValue(
                            "@ClienteID", clienteID);

                        int existe = Convert.ToInt32(
                            cmdVerificar.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show(
                                "La cédula ingresada ya pertenece a otro cliente.",
                                "Cédula duplicada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    // Actualizar cliente
                    string consulta = @"
                UPDATE Clientes
                SET
                    Cedula = @Cedula,
                    Nombre = @Nombre,
                    Apellido = @Apellido,
                    Correo = @Correo,
                    Telefono = @Telefono,
                    Ciudad = @Ciudad,
                    Direccion = @Direccion,
                    FechaNacimiento = @FechaNacimiento
                WHERE ClienteID = @ClienteID";

                    using (SqlCommand cmd =
                           new SqlCommand(consulta, conexion))
                    {
                        AgregarParametros(cmd);

                        cmd.Parameters.AddWithValue(
                            "@ClienteID", clienteID);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Cliente actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.FindForm().DialogResult = DialogResult.OK;
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar el cliente:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void AgregarParametros(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text.Trim());
            cmd.Parameters.AddWithValue("@Nombre", txtNombres.Text.Trim());
            cmd.Parameters.AddWithValue("@Apellido", txtApellidos.Text.Trim());
            cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
            cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
            cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text.Trim());
            cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
            cmd.Parameters.AddWithValue(
                "@FechaNacimiento",
                dtpFechaNacimiento.Value.Date
            );
        }
        private void CargarCliente()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = @"
                SELECT
                    Cedula,
                    Nombre,
                    Apellido,
                    Correo,
                    Telefono,
                    Ciudad,
                    Direccion,
                    FechaNacimiento
                FROM Clientes
                WHERE ClienteID = @ClienteID";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ClienteID", clienteID);

                        conexion.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCedula.Text = reader["Cedula"].ToString();
                                txtNombres.Text = reader["Nombre"].ToString();
                                txtApellidos.Text = reader["Apellido"].ToString();
                                txtCorreo.Text = reader["Correo"].ToString();
                                txtTelefono.Text = reader["Telefono"].ToString();
                                txtCiudad.Text = reader["Ciudad"].ToString();
                                txtDireccion.Text = reader["Direccion"].ToString();

                                dtpFechaNacimiento.Value =
                                    Convert.ToDateTime(reader["FechaNacimiento"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los datos del cliente:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UCRegistrarUsuario_Load(object sender, EventArgs e)
        {
            dtpFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtpFechaNacimiento.CustomFormat = "'Fecha de nacimiento'";
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
       string.IsNullOrWhiteSpace(txtNombres.Text) ||
       string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show(
                    "Complete los campos obligatorios.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // SI clienteID = 0 → CREAR
            if (clienteID == 0)
            {
                CrearCliente();
            }
            // SI clienteID tiene un valor → EDITAR
            else
            {
                EditarCliente();
            }
        }
        private void CrearCliente()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = @"
                INSERT INTO Clientes
                (
                    Cedula,
                    Nombre,
                    Apellido,
                    Correo,
                    Telefono,
                    Ciudad,
                    Direccion,
                    FechaNacimiento
                )
                VALUES
                (
                    @Cedula,
                    @Nombre,
                    @Apellido,
                    @Correo,
                    @Telefono,
                    @Ciudad,
                    @Direccion,
                    @FechaNacimiento
                )";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 10)
                            .Value = txtCedula.Text.Trim();

                        cmd.Parameters.AddWithValue("@Nombre", txtNombres.Text.Trim());
                        cmd.Parameters.AddWithValue("@Apellido", txtApellidos.Text.Trim());
                        cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text.Trim());
                        cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue(
                            "@FechaNacimiento",
                            dtpFechaNacimiento.Value.Date);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Cliente registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.FindForm().DialogResult = DialogResult.OK;
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar el cliente:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}



