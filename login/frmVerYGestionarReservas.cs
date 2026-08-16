using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class frmVerYGestionarReservas : Form
    {
        public frmVerYGestionarReservas()
        {
            InitializeComponent();
        }

        private void frmVerYGestionarReservas_Load(object sender, EventArgs e)
        {
            VerReservas frm = new VerReservas();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(frm);

            frm.Show();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NuevaReservaUsuario frm = new NuevaReservaUsuario();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(frm);

            frm.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            VerReservas frm = new VerReservas();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(frm);

            frm.Show();
        }
    }
}
