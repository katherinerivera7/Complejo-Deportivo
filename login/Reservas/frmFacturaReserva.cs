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

        private void btnGuardarPDF_Click(object sender, EventArgs e)
        {

        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
