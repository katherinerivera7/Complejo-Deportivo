using login.Bar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Promciones
{
    public partial class frmMenuPromociones : Form
    {
        public frmMenuPromociones()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMenuPromociones_Load(object sender, EventArgs e)
        {

        }


        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmCrearPromocion frm = new frmCrearPromocion();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void guna2CircleButton9_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmVerPromociones frm = new frmVerPromociones();

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
