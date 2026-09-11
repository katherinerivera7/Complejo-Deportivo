using login.Bar;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            DoubleBuffered = true;

            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);

            UpdateStyles();
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
                Application.Exit();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show(
                    "Ingrese su usuario.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show(
                    "Ingrese su contraseña.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClave.Focus();
                return;
            }

            string conexionString =
                @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection conexion =
                    new SqlConnection(conexionString))
                {
                    string consulta =
                        "SELECT UsuarioID, NombreUsuario, Rol " +
                        "FROM Usuarios " +
                        "WHERE NombreUsuario = @Usuario " +
                        "AND Clave = @Clave";

                    using (SqlCommand cmd =
                        new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Usuario",
                            txtUsuario.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Clave",
                            txtClave.Text);

                        conexion.Open();

                        using (SqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int usuarioID =
                                    Convert.ToInt32(
                                        reader["UsuarioID"]);

                                string nombreUsuario =
                                    reader["NombreUsuario"].ToString();

                                string rol =
                                    reader["Rol"].ToString();

                                csSesionUsuario.UsuarioID =
                                    usuarioID;

                                csSesionUsuario.NombreUsuario =
                                    nombreUsuario;

                                csSesionUsuario.Rol =
                                    rol;

                                MessageBox.Show(
                                    "Bienvenido, " + nombreUsuario,
                                    "Inicio de sesión",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                FrmMenu menu =
                                    new FrmMenu();

                                menu.Show();
                                Hide();
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
                    "Error al iniciar sesión:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chkMostrar_CheckedChanged_1(
            object sender,
            EventArgs e)
        {
            if (chkMostrar.Checked)
                txtClave.PasswordChar = '\0';
            else
                txtClave.PasswordChar = '●';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csSesionUsuario.UsuarioID = 2;
            csSesionUsuario.NombreUsuario = "usuario";
            csSesionUsuario.Rol = "Usuario";

            FrmMenu menuUsuario =
                new FrmMenu();

            menuUsuario.Show();
            Hide();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            CrearCuenta x =
                new CrearCuenta();

            x.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            csSesionUsuario.UsuarioID = 1;
            csSesionUsuario.NombreUsuario = "admin";
            csSesionUsuario.Rol = "Admin";

            FrmMenu menuAdmin =
                new FrmMenu();

            menuAdmin.Show();
            Hide();
        }

        private void txtUsuario_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtClave_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            csSesionUsuario.UsuarioID = 1;
            csSesionUsuario.NombreUsuario = "admin";
            csSesionUsuario.Rol = "Admin";

            FrmMenu menuAdmin =
                new FrmMenu();

            menuAdmin.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            csSesionUsuario.UsuarioID = 2;
            csSesionUsuario.NombreUsuario = "usuario";
            csSesionUsuario.Rol = "Usuario";

            FrmMenu menuUsuario =
                new FrmMenu();

            menuUsuario.Show();
            Hide();
        }

        private void pnlLogin_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void txtUsuario_TextChanged(
            object sender,
            EventArgs e)
        {
        }
    }
}