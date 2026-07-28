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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtClave.Text))
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico y contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string conexionString = "Server=LAPTOP-J5U2QS20\\SQLEXPRESS01; Database=ComplejoDeportivo; Integrated Security=True;";

            string query = "SELECT Rol FROM Usuarios WHERE Correo = @correo AND Clave = @clave";

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        comando.Parameters.AddWithValue("@clave", txtClave.Text);

                        conexion.Open();

                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            string rolUsuario = resultado.ToString();

                            MessageBox.Show($"¡Bienvenido al sistema! Ingresando como: {rolUsuario}", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FrmMenu menuPrincipal = new FrmMenu();
                            menuPrincipal.CargarInterfazPorRol(rolUsuario);
                            menuPrincipal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("El correo electrónico o la contraseña son incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRegistrarse_Click(object sender, EventArgs e)
        {
            CrearCuenta x = new CrearCuenta();
            x.Show();
            Hide();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
            {
                txtClave.PasswordChar = '\0';
            }
            else
            {
                txtClave.PasswordChar = '●';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu menuPrincipal = new FrmMenu();
            menuPrincipal.Show();
            this.Hide();
        }
    }
}
