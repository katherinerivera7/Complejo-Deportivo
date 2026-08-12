using login.GestionDeUsuarios;
using login.Promciones;
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


        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmGestionarReservas frm = new frmGestionarReservas();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void guna2CircleButton7_Click(object sender, EventArgs e)
        {

            pnlContenido.Controls.Clear();
            frmDisponibilidad frm = new frmDisponibilidad();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
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

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmCanchas frm = new frmCanchas();

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
