using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

                    string verificar = @"SELECT COUNT(*) FROM Clientes
                                         WHERE Cedula = @Cedula
                                         AND TipoDocumento = @TipoDocumento
                                         AND ClienteID <> @ClienteID";

                    using (SqlCommand cmdVerificar = new SqlCommand(verificar, conexion))
                    {
                        cmdVerificar.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Value = txtCedula.Text.Trim();
                        cmdVerificar.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 15).Value = cmbTipoDocumento.Text.Trim();
                        cmdVerificar.Parameters.Add("@ClienteID", SqlDbType.Int).Value = clienteID;

                        int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show("El número de documento ya pertenece a otro cliente.", "Documento duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string consulta = @"UPDATE Clientes SET
                                        TipoDocumento = @TipoDocumento,
                                        Cedula = @Cedula,
                                        Nombre = @Nombre,
                                        Apellido = @Apellido,
                                        Correo = @Correo,
                                        Telefono = @Telefono,
                                        Ciudad = @Ciudad,
                                        Direccion = @Direccion,
                                        FechaNacimiento = @FechaNacimiento
                                        WHERE ClienteID = @ClienteID";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        AgregarParametros(cmd);
                        cmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = clienteID;
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FindForm().DialogResult = DialogResult.OK;
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarParametros(SqlCommand cmd)
        {
            cmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 15).Value = cmbTipoDocumento.Text.Trim();
            cmd.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Value = txtCedula.Text.Trim();
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = txtNombres.Text.Trim();
            cmd.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = txtApellidos.Text.Trim();
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 100).Value = txtCorreo.Text.Trim();
            cmd.Parameters.Add("@Telefono", SqlDbType.VarChar, 15).Value = txtTelefono.Text.Trim();
            cmd.Parameters.Add("@Ciudad", SqlDbType.VarChar, 50).Value = txtCiudad.Text.Trim();
            cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 150).Value = txtDireccion.Text.Trim();
            cmd.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = dtpFechaNacimiento.Value.Date;
        }

        private void CargarCliente()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = @"SELECT TipoDocumento, Cedula, Nombre, Apellido, Correo, Telefono, Ciudad, Direccion, FechaNacimiento
                                         FROM Clientes
                                         WHERE ClienteID = @ClienteID";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.Add("@ClienteID", SqlDbType.Int).Value = clienteID;
                        conexion.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmbTipoDocumento.Text = reader["TipoDocumento"].ToString();
                                txtCedula.Text = reader["Cedula"].ToString();
                                txtNombres.Text = reader["Nombre"].ToString();
                                txtApellidos.Text = reader["Apellido"].ToString();
                                txtCorreo.Text = reader["Correo"].ToString();
                                txtTelefono.Text = reader["Telefono"].ToString();
                                txtCiudad.Text = reader["Ciudad"].ToString();
                                txtDireccion.Text = reader["Direccion"].ToString();
                                dtpFechaNacimiento.Value = Convert.ToDateTime(reader["FechaNacimiento"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string tipoDocumento = cmbTipoDocumento.Text.Trim();

            if (string.IsNullOrWhiteSpace(tipoDocumento) ||
                !new[] { "Cédula", "RUC", "Pasaporte" }.Contains(tipoDocumento))
            {
                MessageBox.Show("Seleccione un tipo de documento válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Complete los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (clienteID == 0)
                CrearCliente();
            else
                EditarCliente();
        }

        private void CrearCliente()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string verificar = @"SELECT COUNT(*) FROM Clientes
                                         WHERE Cedula = @Cedula
                                         AND TipoDocumento = @TipoDocumento";

                    conexion.Open();

                    using (SqlCommand cmdVerificar = new SqlCommand(verificar, conexion))
                    {
                        cmdVerificar.Parameters.Add("@Cedula", SqlDbType.VarChar, 20).Value = txtCedula.Text.Trim();
                        cmdVerificar.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 15).Value = cmbTipoDocumento.Text.Trim();

                        int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show("El número de documento ya está registrado.", "Documento duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string consulta = @"INSERT INTO Clientes
                                        (TipoDocumento, Cedula, Nombre, Apellido, Correo, Telefono, Ciudad, Direccion, FechaNacimiento)
                                        VALUES
                                        (@TipoDocumento, @Cedula, @Nombre, @Apellido, @Correo, @Telefono, @Ciudad, @Direccion, @FechaNacimiento)";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        AgregarParametros(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.FindForm().DialogResult = DialogResult.OK;
                this.FindForm().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cliente:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}