using System;
using System.Windows.Forms;
using login.Promciones;
using login.Reservas;

namespace login
{
    public partial class frmMenucs : System.Windows.Forms.Form
    {
        public frmMenucs()
        {
            InitializeComponent();
        }

        private void AbrirFormulario(Form formulario)
        {
            if (formulario == null)
                return;

            pnlContenido.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(formulario);
            pnlContenido.Tag = formulario;

            formulario.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            bool abierto = pnlSidebar.Width == 150;

            pnlSidebar.Width = abierto ? 40 : 150;

            btnInicio.Text = abierto ? "" : "Inicio";
            btnUsuarios.Text = abierto ? "" : "Usuarios";
            btnReservas.Text = abierto ? "" : "Reservas";
            btnCafeteria.Text = abierto ? "" : "Bar";
            btnPromociones.Text = abierto ? "" : "Promociones";
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReservas());
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmMenuPromociones());
        }

        private void btnCafeteria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Bar.frmBar());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void picLogin_Click(object sender, EventArgs e)
        {

        }

        private void frmMenucs_Load(object sender, EventArgs e)
        {

        }
    }
}