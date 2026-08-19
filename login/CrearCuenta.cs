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
            this.DoubleBuffered = true;
            this.SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);

            this.UpdateStyles();
        }

        private void txtRegistrarse_Click(object sender, EventArgs e)
        {
           frmLogin x = new frmLogin();
            x.Show();
            Hide();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // ==========================================
            // 1. VALIDAR CAMPOS VACÍOS
            // ==========================================

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarClave.Text))
            {
                MessageBox.Show(
                    "Por favor, llene todos los campos del formulario.",
                    "Campos Vacíos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (txtClave.Text.Length < 8)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 8 caracteres.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClave.Focus();
                return;
            }

            if (!txtClave.Text.Any(char.IsUpper))
            {
                MessageBox.Show(
                    "La contraseña debe contener al menos una letra mayúscula.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClave.Focus();
                return;
            }

            if (!txtClave.Text.Any(char.IsLower))
            {
                MessageBox.Show(
                    "La contraseña debe contener al menos una letra minúscula.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClave.Focus();
                return;
            }

            if (!txtClave.Text.Any(char.IsDigit))
            {
                MessageBox.Show(
                    "La contraseña debe contener al menos un número.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClave.Focus();
                return;
            }


            // ==========================================
            // 9. CONFIRMAR CONTRASEÑA
            // ==========================================

            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show(
                    "Las contraseñas ingresadas no coinciden.",
                    "Error de Contraseña",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtConfirmarClave.Focus();
                return;
            }


            // ==========================================
            // 10. CONEXIÓN CON SQL SERVER
            // ==========================================

            try
            {
                string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    // Primero comprobamos si ya existe el usuario
                    string verificar = @"
                SELECT COUNT(*)
                FROM Usuarios
                WHERE NombreUsuario = @NombreUsuario";

                    using (SqlCommand cmdVerificar = new SqlCommand(verificar, conexion))
                    {
                        cmdVerificar.Parameters.AddWithValue(
                            "@NombreUsuario",
                            txtUsuario.Text.Trim());

                        conexion.Open();

                        int existe = (int)cmdVerificar.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Ese nombre de usuario ya está registrado.",
                                "Usuario existente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            txtUsuario.Focus();
                            return;
                        }
                    }

                    // Insertar usuario
                    string consulta = @"
                INSERT INTO Usuarios
                (
                    NombreUsuario,
                    Clave,
                    Rol
                )
                VALUES
                (
                    @NombreUsuario,
                    @Clave,
                    @Rol
                )";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue(
                            "@NombreUsuario",
                            txtUsuario.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Clave",
                            txtClave.Text);

                        cmd.Parameters.AddWithValue(
                            "@Rol",
                            "Usuario");

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario creado correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Limpiar campos
                txtUsuario.Clear();
                txtClave.Clear();
                txtConfirmarClave.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al crear el usuario:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
            
        
        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmarClave_TextChanged(object sender, EventArgs e)
        {

        }
    

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
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

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkMostrar.Checked;
            txtConfirmarClave.UseSystemPasswordChar = !chkMostrar.Checked;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
