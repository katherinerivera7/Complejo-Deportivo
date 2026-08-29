using login.Reservas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmBar : Form
    {
        public frmBar()
        {
            InitializeComponent();
        }

        private void frmBar_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2CircleButton6_Click_1(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmRegistroVenta frm = new frmRegistroVenta();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void guna2CircleButton8_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmRegistroVenta frm = new frmRegistroVenta();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void guna2CircleButton8_Click_1(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmInventarioBar frm = new frmInventarioBar();

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
            frmCategorias frm = new frmCategorias();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
