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

            // VALIDAR CAMPOS VACÍOS
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarClave.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                cmbCargo.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Por favor, llene todos los campos del formulario.",
                    "Campos Vacíos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // VALIDAR CÉDULA
            if (!txtCedula.Text.All(char.IsDigit))
            {
                MessageBox.Show(
                    "La cédula debe contener únicamente números.",
                    "Cédula inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCedula.Focus();
                return;
            }

            if (txtCedula.Text.Length != 10)
            {
                MessageBox.Show(
                    "La cédula debe contener exactamente 10 dígitos.",
                    "Cédula inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCedula.Focus();
                return;
            }


            // VALIDAR USUARIO
            if (txtUsuario.Text.Length < 4)
            {
                MessageBox.Show(
                    "El nombre de usuario debe tener al menos 4 caracteres.",
                    "Usuario inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsuario.Focus();
                return;
            }


            // VALIDAR DIRECCIÓN
            if (txtDireccion.Text.Length < 5)
            {
                MessageBox.Show(
                    "Ingrese una dirección válida de al menos 5 caracteres.",
                    "Dirección inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDireccion.Focus();
                return;
            }


            // VALIDAR CARGO
            if (cmbCargo.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un cargo.",
                    "Cargo no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCargo.Focus();
                return;
            }


            // VALIDAR CONTRASEÑA
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

            if (!txtClave.Text.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show(
                    "La contraseña debe contener al menos un carácter especial, por ejemplo: @, #, $, %, &.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtClave.Focus();
                return;
            }


            // CONFIRMAR CONTRASEÑA
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



            // CONEXIÓN CON SQL SERVER


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

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCedula.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2ComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCorreo.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCargo.Focus();
                cmbCargo.DroppedDown = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmarClave.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtConfirmarClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCrear.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
