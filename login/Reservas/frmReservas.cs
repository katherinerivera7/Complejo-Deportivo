using login.GestionDeUsuarios;
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
    public partial class frmReservas : Form
    {
        public frmReservas()
        {
            InitializeComponent();
        }
        private FrmMenu menu;
        public frmReservas(FrmMenu menu)
        {
            InitializeComponent();
            this.menu = menu;
        }
        private void frmReservas_Load(object sender, EventArgs e)
        {

        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton6_Click_1(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            UCNuevaReserva uc = new UCNuevaReserva();
            uc.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnNueva_Click_1(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            UCNuevaReserva uc = new UCNuevaReserva();
            uc.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
