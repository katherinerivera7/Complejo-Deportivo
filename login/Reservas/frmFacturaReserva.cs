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
    public partial class frmFacturaReserva : Form
    {
        public frmFacturaReserva()
        {
            InitializeComponent();
        }

        private void dgvDetalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalleFactura.ReadOnly = true;
            dgvDetalleFactura.AllowUserToAddRows = false;
            dgvDetalleFactura.AllowUserToDeleteRows = false;
            dgvDetalleFactura.AllowUserToResizeRows = false;
            dgvDetalleFactura.RowHeadersVisible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            UCNuevaReserva frm = new UCNuevaReserva();

            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            UCNuevaReserva frm = new UCNuevaReserva();

            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpFechaFin.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaFin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2ComboBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void guna2ComboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2TextBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }
    }
}
