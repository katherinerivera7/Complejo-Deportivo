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

namespace login.Reservas
{
    public partial class frmEditarUsuario : Form
    {
        private int idUsuario;
        public frmEditarUsuario()
        {
            InitializeComponent();
        }
        public frmEditarUsuario(int id)
        {
            InitializeComponent();
            idUsuario = id;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            string conexion = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string sql = @"UPDATE Usuarios
                       SET Nombre=@Nombre,
                           Apellido=@Apellido,
                           Correo=@Correo,
                           Telefono=@Telefono,
                           Ciudad=@Ciudad,
                           Direccion=@Direccion,
                           FechaNacimiento=@Fecha,
                           Clave=@Clave
                       WHERE UsuarioID=@Id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@Id", idUsuario);
                cmd.Parameters.AddWithValue("@Nombre", txtNombres.Text.Trim());
                cmd.Parameters.AddWithValue("@Apellido", txtApellidos.Text.Trim());
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@Ciudad", txtCiudad.Text.Trim());
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("@Fecha", guna2DateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@Clave", txtClave.Text.Trim());

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Usuario actualizado correctamente.");

            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmEditarUsuario_Load(object sender, EventArgs e)
        {
            string conexion = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                string sql = "SELECT * FROM Usuarios WHERE UsuarioID=@id";

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@id", idUsuario);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtNombres.Text = dr["Nombre"].ToString();
                    txtApellidos.Text = dr["Apellido"].ToString();
                    txtCorreo.Text = dr["Correo"].ToString();
                    txtTelefono.Text = dr["Telefono"].ToString();
                    txtCiudad.Text = dr["Ciudad"].ToString();
                    txtDireccion.Text = dr["Direccion"].ToString();
                    guna2DateTimePicker1.Value = Convert.ToDateTime(dr["FechaNacimiento"]);
                    txtClave.Text = dr["Clave"].ToString();
                    txtConfirmarClave.Text = dr["Clave"].ToString();
                }
            }
        }

        private void txtNombres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtApellidos.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtApellidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCorreo.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCiudad.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtCiudad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
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
    }
}
