using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.GestionDeUsuarios;

namespace login
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void RegistarUsuario_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            UCRegistrarUsuario uc = new UCRegistrarUsuario();
            uc.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(uc);
            uc.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            UCEditarInformacion uc = new UCEditarInformacion();
            uc.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(uc);
            uc.BringToFront();
        }

        private void ListaDeUsuarios_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            UCListaDeUsuarios uc = new UCListaDeUsuarios();
            uc.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(uc);
            uc.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

           UCHistorialDeReservas uc = new UCHistorialDeReservas();
            uc.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}