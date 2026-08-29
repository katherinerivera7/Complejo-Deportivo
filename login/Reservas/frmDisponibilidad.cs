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
            // Cancha 1
            dgvHorarios.Rows[2].Cells["Cancha1"].Value = "Carlos Ramírez";
            dgvHorarios.Rows[3].Cells["Cancha1"].Value = "Ana López";
            dgvHorarios.Rows[8].Cells["Cancha1"].Value = "Grupo Sport";

            // Cancha 2
            dgvHorarios.Rows[2].Cells["Cancha2"].Value = "Liga Amigos";
            dgvHorarios.Rows[5].Cells["Cancha2"].Value = "Empresa XYZ";
            dgvHorarios.Rows[6].Cells["Cancha2"].Value = "Empresa XYZ";
            dgvHorarios.Rows[8].Cells["Cancha2"].Value = "Torneo Juvenil";
            dgvHorarios.Rows[9].Cells["Cancha2"].Value = "Torneo Juvenil";

            // Cancha 3
            dgvHorarios.Rows[3].Cells["Cancha3"].Value = "Entrenamiento";
            dgvHorarios.Rows[9].Cells["Cancha3"].Value = "Clase Funcional";
            dgvHorarios.Rows[10].Cells["Cancha3"].Value = "Clase Funcional";
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
