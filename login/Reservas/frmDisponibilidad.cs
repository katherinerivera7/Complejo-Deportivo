using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login;

namespace login.Reservas
{
    public partial class frmDisponibilidad : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmDisponibilidad()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //              ControlStyles.AllPaintingInWmPaint |
            //              ControlStyles.UserPaint, true);
            //this.UpdateStyles();
         
            cargarHorarios();
        }


        private void cargarHorarios()
        {
            string consulta = @"
    SELECT 
        ch.idCancha,
        h.idHorario,
        h.HoraInicio,
        h.HoraFin
    FROM CanchaHorario ch
    INNER JOIN Horarios2 h
        ON ch.idHorario = h.idHorario
    ORDER BY ch.idCancha, h.HoraInicio";


            DataTable datos = conSQL.retornaRegistros(consulta);


            dgvHorarios.Rows.Clear();

            foreach (DataRow fila in datos.Rows)
            {
                string horaInicio = ((TimeSpan)fila["HoraInicio"]).ToString(@"hh\:mm");
                string horaFin = ((TimeSpan)fila["HoraFin"]).ToString(@"hh\:mm");

                string horario = horaInicio + " - " + horaFin;

                dgvHorarios.Rows.Add(horario);
            }



          

            











        }
       
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvHorarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {

        }

        private void dgvHorarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            string estado = e.Value.ToString();

            if (estado == "Disponible")
            {
                e.CellStyle.BackColor = Color.Green;
                e.CellStyle.ForeColor = Color.White;
            }
            else if (estado == "Ocupada")
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.White;
            }
            else if (estado == "Mantenimiento")
            {
                e.CellStyle.BackColor = Color.Orange;
                e.CellStyle.ForeColor = Color.White;
            }
        }
    }
}
