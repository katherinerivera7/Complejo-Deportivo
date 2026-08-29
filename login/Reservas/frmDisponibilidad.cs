using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmDisponibilidad : Form
    {
        public frmDisponibilidad()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //              ControlStyles.AllPaintingInWmPaint |
            //              ControlStyles.UserPaint, true);
            //this.UpdateStyles();
            CargarReservasPrueba();
        }


        private void CargarReservasPrueba()
        {
            dgvHorarios.Rows[0].Cells["Cancha1"].Value = "Carlos Ramírez";
            dgvHorarios.Rows[1].Cells["Cancha1"].Value = "Ana López";
            dgvHorarios.Rows[3].Cells["Cancha2"].Value = "Pedro Gómez";
            dgvHorarios.Rows[5].Cells["Cancha3"].Value = "María Torres";
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvHorarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
