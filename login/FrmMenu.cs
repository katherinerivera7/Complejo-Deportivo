using Guna.UI2.WinForms;
using login.Bar;
using login.GestionDeUsuarios;
using login.Promciones;
using login.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace login
{
    public partial class FrmMenu : Form
    {
        private List<Control> controlesInicio = new List<Control>();

        public FrmMenu()
        {
            InitializeComponent();

            foreach (Control control in pnlContenido.Controls)
            {
                controlesInicio.Add(control);
            }

            DoubleBuffered = true;

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            UpdateStyles();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            CargarEstadoCanchas();
            CargarTotalClientes();
            CargarEstadoProductos();
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            if (string.Equals(csSesionUsuario.Rol, "Usuario", StringComparison.OrdinalIgnoreCase))
            {
                btnCrearUsuario.Enabled = false;
            }
            else
            {
                btnCrearUsuario.Enabled = true;
            }
        }

        private void AbrirFormulario(Form frm)
        {
            pnlContenido.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void MostrarInicio()
        {
            pnlContenido.Controls.Clear();

            foreach (Control control in controlesInicio)
            {
                pnlContenido.Controls.Add(control);
            }

            CargarEstadoCanchas();
            CargarTotalClientes();
            CargarEstadoProductos();
        }

        private void tmSidebar_Tick(object sender, EventArgs e)
        {

        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCafeteria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Bar.frmBar());
        }

        private void pnlIngresosDiarios_MouseEnter(object sender, EventArgs e)
        {
            pnlIngresosDiarios.Margin = new Padding(4);
        }

        private void pnlIngresosDiarios_MouseLeave(object sender, EventArgs e)
        {
            pnlIngresosDiarios.Margin = new Padding(10);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pnlEstadoCanchas_MouseEnter(object sender, EventArgs e)
        {
            pnlEstadoCanchas.Margin = new Padding(4);
        }

        private void pnlEstadoCanchas_MouseLeave(object sender, EventArgs e)
        {
            pnlEstadoCanchas.Margin = new Padding(10);
        }

        private void pnlUsuariosRegistrados_MouseEnter(object sender, EventArgs e)
        {
            pnlUsuariosRegistrados.Margin = new Padding(4);
        }

        private void pnlUsuariosRegistrados_MouseLeave(object sender, EventArgs e)
        {
            pnlUsuariosRegistrados.Margin = new Padding(10);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new UCClientes());
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReservas());
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmMenuPromociones());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarInicio();
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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea cerrar sesión?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();

                Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CrearCuenta());
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new frmVerFacturas());
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CargarEstadoProductos()
        {
            csConectaSQL oCon = new csConectaSQL();

            string consulta = @"SELECT
                                COUNT(CASE WHEN ISNULL(Stock, 0) > 0 THEN 1 END) AS ConStock,
                                COUNT(CASE WHEN ISNULL(Stock, 0) = 0 THEN 1 END) AS Agotados
                                FROM Productos";

            DataTable dt = oCon.retornaRegistros(consulta);

            if (dt.Rows.Count > 0)
            {
                int conStock = Convert.ToInt32(dt.Rows[0]["ConStock"]);
                int agotados = Convert.ToInt32(dt.Rows[0]["Agotados"]);

                int maximo = Math.Max(conStock, agotados);

                if (maximo == 0)
                {
                    maximo = 1;
                }

                stockbar.Minimum = 0;
                stockbar.Maximum = maximo;
                stockbar.Value = conStock;

                agotadobar.Minimum = 0;
                agotadobar.Maximum = maximo;
                agotadobar.Value = agotados;

                lblCantidadStock.Text = "Con stock: " + conStock;
                lblCantidadAgotados.Text = "Agotados: " + agotados;
            }
        }

        private void CargarEstadoCanchas()
        {
            csConectaSQL oCon = new csConectaSQL();

            string consulta = @"SELECT COUNT(*) AS Total,
                                COUNT(CASE WHEN Estado = 'Disponible' THEN 1 END) AS Disponibles,
                                COUNT(CASE WHEN Estado = 'Mantenimiento' THEN 1 END) AS Mantenimiento
                                FROM Canchas";

            DataTable dt = oCon.retornaRegistros(consulta);

            if (dt.Rows.Count > 0)
            {
                int total = Convert.ToInt32(dt.Rows[0]["Total"]);
                int disponibles = Convert.ToInt32(dt.Rows[0]["Disponibles"]);
                int mantenimiento = Convert.ToInt32(dt.Rows[0]["Mantenimiento"]);

                int porcentaje = total == 0
                    ? 0
                    : (int)Math.Round((double)disponibles / total * 100);

                EstadoCancha.Minimum = 0;
                EstadoCancha.Maximum = 100;
                EstadoCancha.Value = porcentaje;

                lblDisponibles.Text = "Disponibles: " + disponibles;
                lblMantenimiento.Text = "En mantenimiento: " + mantenimiento;
            }
        }

        private void CargarTotalClientes()
        {
            csConectaSQL oCon = new csConectaSQL();

            string consulta = "SELECT COUNT(*) AS TotalClientes FROM Clientes";

            DataTable dt = oCon.retornaRegistros(consulta);

            if (dt.Rows.Count > 0)
            {
                int totalClientes = Convert.ToInt32(dt.Rows[0]["TotalClientes"]);

                lblTotalClientes.Text = totalClientes.ToString();
            }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTotalClientes_Click(object sender, EventArgs e)
        {

        }

        private void lblCantidadStock_Click(object sender, EventArgs e)
        {

        }
        private void agotadobar_ValueChanged(object sender, EventArgs e)
        {

        }
        private void lblCantidadAgotados_Click(object sender, EventArgs e)
        {

        }
    }
}