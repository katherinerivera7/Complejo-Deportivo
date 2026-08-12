using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.Promciones;
using login.Reservas;

namespace login
{
    public partial class frmMenucs : Form
    {
        public frmMenucs()
        {
            InitializeComponent();
        }


        public void AbrirFormulario(Form formulario)
        {
            pnlContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(formulario);
            formulario.Show();
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {

            if (pnlSidebar.Width == 150)
            {
                pnlSidebar.Width = 40;

                btnInicio.Text = "";
                btnUsuarios.Text = "";
                btnReservas.Text = "";
               
                btnCafeteria.Text = "";
                btnPromociones.Text = "";

            }
            else
            {
                pnlSidebar.Width = 150;

                btnInicio.Text = "Inicio";
                btnUsuarios.Text = "Usuarios";
                btnReservas.Text = "Reservas";
               
                btnCafeteria.Text = "Bar";
                btnPromociones.Text = "Promociones";

            }
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReservas());
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmMenuPromociones());
        }

        private void picLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnCafeteria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Bar.frmBar());

        }

        private void frmMenucs_Load(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
          


        }
    }
}
