using Guna.UI2.WinForms;
using login.Promciones;
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
       
        public FrmMenu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            this.UpdateStyles();

        }
        public class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                DoubleBuffered = true;

                SetStyle(
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint |
                    ControlStyles.OptimizedDoubleBuffer,
                    true);

                UpdateStyles();
            }
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tmSidebar_Tick(object sender, EventArgs e)
        {


            
    }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCafeteria_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            Bar.frmBar frm = new Bar.frmBar();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
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
            pnlContenido.Controls.Clear();
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

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmMenuPromociones frm = new frmMenuPromociones();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            FrmMenu menu= new FrmMenu();
            menu.Show();

        }


        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {

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

        private void cmbBienvenida_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            CrearCuenta x = new CrearCuenta();
            x.TopLevel = false;
            x.FormBorderStyle = FormBorderStyle.None;
            x.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(x);
            pnlContenido.Tag = x;

            x.Show();
        }
    }

}
