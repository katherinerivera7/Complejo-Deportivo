using login.Bar;
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

namespace login
{
    public partial class frmCambiarClave : Form
    {
        public frmCambiarClave()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string claveActual = txtClaveActual.Text.Trim();
            string claveNueva = txtClaveNueva.Text.Trim();
            string confirmarClave = txtConfirmarClaveNueva.Text.Trim();

            if (string.IsNullOrWhiteSpace(claveActual))
            {
                MessageBox.Show("Ingrese su contraseña actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveActual.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(claveNueva))
            {
                MessageBox.Show("Ingrese una nueva contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva.Focus();
                return;
            }

            if (claveNueva.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva.Focus();
                return;
            }

            if (!claveNueva.Any(char.IsUpper))
            {
                MessageBox.Show("La contraseña debe contener al menos una letra mayúscula.", "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva.Focus();
                return;
            }

            if (!claveNueva.Any(char.IsLower))
            {
                MessageBox.Show("La contraseña debe contener al menos una letra minúscula.", "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva.Focus();
                return;
            }

            if (!claveNueva.Any(char.IsDigit))
            {
                MessageBox.Show("La contraseña debe contener al menos un número.", "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva.Focus();
                return;
            }

            if (!claveNueva.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("La contraseña debe contener al menos un carácter especial, por ejemplo: @, #, $, %, &.", "Contraseña inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClaveNueva.Focus();
                return;
            }

            if (claveNueva != confirmarClave)
            {
                MessageBox.Show("Las contraseñas nuevas no coinciden.", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmarClaveNueva.Focus();
                return;
            }

            if (csSesionUsuario.UsuarioID <= 0)
            {
                MessageBox.Show("No se encontró el usuario actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = "update Usuarios set Clave = @ClaveNueva where UsuarioID = @UsuarioID and Clave = @ClaveActual";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ClaveNueva", claveNueva);
                        cmd.Parameters.AddWithValue("@ClaveActual", claveActual);
                        cmd.Parameters.AddWithValue("@UsuarioID", csSesionUsuario.UsuarioID);

                        conexion.Open();

                        int filasModificadas = cmd.ExecuteNonQuery();

                        if (filasModificadas == 0)
                        {
                            MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtClaveActual.Focus();
                            return;
                        }
                    }
                }

                MessageBox.Show("Contraseña cambiada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtClaveActual.Clear();
                txtClaveNueva.Clear();
                txtConfirmarClaveNueva.Clear();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar la contraseña:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
            {
                txtClaveActual.PasswordChar = '\0';
                txtClaveNueva.PasswordChar = '\0';
                txtConfirmarClaveNueva.PasswordChar = '\0';
            }
            else
            {
                txtClaveActual.PasswordChar = '●';
                txtClaveNueva.PasswordChar = '●';
                txtConfirmarClaveNueva.PasswordChar = '●';

            }
        }

        private void frmCambiarClave_Load(object sender, EventArgs e)
        {
            txtClaveActual.PasswordChar = '●';
            txtClaveNueva.PasswordChar = '●';
            txtConfirmarClaveNueva.PasswordChar = '●';
        }
    }
}
