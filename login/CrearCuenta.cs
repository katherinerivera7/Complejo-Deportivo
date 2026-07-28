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

namespace login
{
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        private void txtRegistrarse_Click(object sender, EventArgs e)
        {
           frmLogin x = new frmLogin();
            x.Show();
            Hide();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtClave.Text) ||
                string.IsNullOrEmpty(txtConfirmarClave.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos del formulario.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden. Inténtelo de nuevo.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string conexionString = "Server=LAPTOP-J5U2QS20\\SQLEXPRESS01; Database=ComplejoDeportivo; Integrated Security=True;";
            string query = "INSERT INTO Usuarios (NombreCompleto, Correo, Telefono, Clave) VALUES (@nombre, @correo, @telefono, @clave)";

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                        comando.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        comando.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                        comando.Parameters.AddWithValue("@clave", txtClave.Text);

                        conexion.Open();
                        comando.ExecuteNonQuery();

                        MessageBox.Show("¡Cuenta creada con éxito! Ya puedes iniciar sesión.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarCampos();
                        
                        frmLogin a = new frmLogin();
                        a.Show();
                        this.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Este correo electrónico ya se encuentra registrado.", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
