using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class UCNuevaReserva : UserControl
    {
        csConectaSQL conSQL = new csConectaSQL();

        private int clienteID = 0;

        public UCNuevaReserva()
        {
            InitializeComponent();
        }

        private void UCNuevaReserva_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }


        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmFacturaReserva frm = new frmFacturaReserva();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
     "¿Está seguro de que desea cancelar la reserva?",
     "Cancelar reserva",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Question
 );
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == "" ||
        txtNombres.Text == "" ||
        txtApellidos.Text == "" ||
        txtCorreo.Text == "" ||
        txtTelefono.Text == "" ||
        txtDireccion.Text == "" ||
        cmbCancha.SelectedIndex == -1 ||
        cmbHorario.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Por favor, complete todos los datos de la reserva.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea realizar esta reserva?",
                "Confirmar reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                // Aquí vamos a guardar el cliente y la reserva
                MessageBox.Show(
        "Reserva registrada correctamente.",
        "Reserva",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);

                btnFacturar.Enabled = true;
            }
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCliente();
                e.SuppressKeyPress = true;
            }
        }



        private void BuscarCliente()
        {
            string cedula = txtCedula.Text.Trim();

            if (cedula == "")
            {
                MessageBox.Show("Ingrese la cédula del cliente.");
                return;
            }

            string consulta = $@"
        SELECT ClienteID, Nombre, Apellido, Correo, Telefono, Direccion
        FROM Clientes
        WHERE Cedula = '{cedula}'";

            DataTable datos = conSQL.retornaRegistros(consulta);

            if (datos.Rows.Count > 0)
            {
                DataRow cliente = datos.Rows[0];

                clienteID = Convert.ToInt32(cliente["ClienteID"]);

                txtNombres.Text = cliente["Nombre"].ToString();
                txtApellidos.Text = cliente["Apellido"].ToString();
                txtCorreo.Text = cliente["Correo"].ToString();
                txtTelefono.Text = cliente["Telefono"].ToString();
                txtDireccion.Text = cliente["Direccion"].ToString();

                MessageBox.Show("Cliente encontrado.");
            }
            else
            {
                clienteID = 0;

                MessageBox.Show(
                    "El cliente no está registrado. Puede ingresar sus datos para registrarlo.",
                    "Cliente no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
