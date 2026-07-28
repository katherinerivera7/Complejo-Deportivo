using Guna.UI2.WinForms;
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

namespace login
{
    public partial class FrmMenu : Form
    {
        public void CargarInterfazPorRol(string rol)
        {
            if (rol == "Usuario")
            {
                btnUsuarios.Visible = false;
                btnCafeteria.Visible = false;

                pnlAdmin.Visible = false;
                pnlUsuario.Visible = true;

                pnlUsuario.BringToFront();
            }
            else if (rol == "Admin")
            {
                btnUsuarios.Visible = true;
                btnPromociones.Visible = true;
                btnCafeteria.Visible = true;

                pnlUsuario.Visible = false;
                pnlAdmin.Visible = true;

                pnlAdmin.BringToFront();
            }
        }
        public FrmMenu()
        {
            InitializeComponent();
        }
       
        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
           

            if (pnlSidebar.Width == 200)
            {
                pnlSidebar.Width = 50;

                btnInicio.Text = "";
                btnUsuarios.Text = "";
                btnReservas.Text = "";
                btnFacturacion.Text = "";
                btnCafeteria.Text = "";
                btnPromociones.Text = "";
              
            }
            else
            {
                pnlSidebar.Width = 200;

                btnInicio.Text = "Inicio";
                btnUsuarios.Text = "Usuarios";
                btnReservas.Text = "Reservas";
                btnFacturacion.Text = "Facturación";
                btnCafeteria.Text = "Cafetería";
                btnPromociones.Text = "Promociones";
               
            }
        
        }

        private void tmSidebar_Tick(object sender, EventArgs e)
        {


            
    }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnCafeteria_Click(object sender, EventArgs e)
        {

        }

        private void pnlIngresosDiarios_MouseEnter(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlIngresosDiarios.Margin = new Padding(4, 4, 4, 4);
            this.ResumeLayout();
        }

        private void pnlIngresosDiarios_MouseLeave(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlIngresosDiarios.Margin = new Padding(10, 10, 10, 10);
            this.ResumeLayout();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pnlEstadoCanchas_MouseEnter(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlEstadoCanchas.Margin = new Padding(4, 4, 4, 4);
            this.ResumeLayout();
        }

        private void pnlEstadoCanchas_MouseLeave(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlEstadoCanchas.Margin = new Padding(10, 10, 10, 10);
            this.ResumeLayout();
        }

        private void pnlUsuariosRegistrados_MouseEnter(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlUsuariosRegistrados.Margin = new Padding(4, 4, 4, 4);
            this.ResumeLayout();
        }

        private void pnlUsuariosRegistrados_MouseLeave(object sender, EventArgs e)
        {
            this.SuspendLayout();
            pnlUsuariosRegistrados.Margin = new Padding(10, 10, 10, 10);
            this.ResumeLayout();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            Usuarios frm = new Usuarios();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            frmReservas frm = new frmReservas();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
