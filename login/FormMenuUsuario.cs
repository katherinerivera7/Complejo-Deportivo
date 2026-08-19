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
    public partial class FormMenuUsuario : Form
    {
        public FormMenuUsuario()
        {
            InitializeComponent();
        }

        
        private void AbrirFormulario(Form formulario, Control contenedor)
        {
            
            foreach (Control control in contenedor.Controls.Cast<Control>().ToList())
            {
                if (control is Form frm)
                {
                    frm.Close();
                    frm.Dispose();
                    contenedor.Controls.Remove(control);
                }
                else
                {
                    control.Visible = false;
                }
            }

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            contenedor.Controls.Add(formulario);
            contenedor.Tag = formulario;

            formulario.BringToFront();
            formulario.Show();
        }


        private void RestaurarPanel(Control contenedor)
        {
            foreach (Control control in contenedor.Controls.Cast<Control>().ToList())
            {
                if (control is Form frm)
                {
                    frm.Close();
                    frm.Dispose();
                    contenedor.Controls.Remove(control);
                }
                else
                {
                    control.Visible = true;
                }
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarInicio();
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MostrarInicio();
        }


        private void MostrarInicio()
        {
         
            RestaurarPanel(pnlContenido);
            RestaurarPanel(guna2Panel8);
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(
                new frmReservasUsuario(),
                pnlContenido
            );
        }

        private void guna2CircleButton8_Click(object sender, EventArgs e)
        {
            AbrirFormulario(
                new VerPromocionesUsuario(),
                guna2Panel8
            );
        }


    
        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
            AbrirFormulario(
                new frmVerYGestionarReservas(),
                guna2Panel8
            );
        }


      
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(
                new frmDisponiblidadDeCnchaUsuario(),
                guna2Panel8
            );
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }


        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }


        private void CerrarSesion()
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea cerrar sesión?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();

                this.Close();
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea salir del programa?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
       "¿Está seguro de que desea salir del programa?",
       "Confirmar salida",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlSuperior_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
