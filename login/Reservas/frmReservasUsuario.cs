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
    public partial class frmReservasUsuario : Form
    {
        public frmReservasUsuario()
        {
            InitializeComponent();
        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            UCNuevaReserva frm = new UCNuevaReserva();

            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }
    }
}
