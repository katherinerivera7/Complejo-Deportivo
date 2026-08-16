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
            this.DoubleBuffered = true;
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);

            this.UpdateStyles();

        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
        "¿Está seguro de que desea salir del programa?",
        "Confirmar salida",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Ingrese su usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Ingrese su contraseña.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClave.Focus();
                return;
            }

            string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = @"
                SELECT UsuarioID, NombreUsuario, Rol
                FROM Usuarios
                WHERE NombreUsuario = @Usuario
                AND Clave = @Clave";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@Clave", txtClave.Text);

                        conexion.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int usuarioID = Convert.ToInt32(reader["UsuarioID"]);
                                string nombreUsuario = reader["NombreUsuario"].ToString();
                                string rol = reader["Rol"].ToString();

                                MessageBox.Show(
                                    "Bienvenido, " + nombreUsuario,
                                    "Inicio de sesión",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                if (rol == "Admin")
                                {
                                    FrmMenu menuAdmin = new FrmMenu();
                                    menuAdmin.Show();
                                }
                                else if (rol == "Usuario")
                                {
                                    FormMenuUsuario menuUsuario = new FormMenuUsuario();
                                    menuUsuario.Show();
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Usuario o contraseña incorrectos.",
                                    "Error de inicio de sesión",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al iniciar sesión:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chkMostrar_CheckedChanged_1(object sender, EventArgs e)
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
            FormMenuUsuario menuPrincipal = new FormMenuUsuario();
            menuPrincipal.Show();
            this.Hide();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {

            CrearCuenta x = new CrearCuenta();
            x.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMenu menuPrincipal = new FrmMenu();
            menuPrincipal.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
