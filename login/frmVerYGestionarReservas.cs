using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.Reservas;

namespace login
{
    public partial class frmVerYGestionarReservas : Form
    {
        public frmVerYGestionarReservas()
        {

            InitializeComponent();
           
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBox5.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBox3.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTipoPromocion.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
 "¿Está seguro de que desea cancelar la reserva?",
 "Cancelar reserva",
 MessageBoxButtons.YesNo,
 MessageBoxIcon.Question
);

            if (resultado == DialogResult.Yes)
            {

            }
        }

        private void frmVerYGestionarReservas_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
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

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnFacturar_Click_1(object sender, EventArgs e)
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
    }
}
