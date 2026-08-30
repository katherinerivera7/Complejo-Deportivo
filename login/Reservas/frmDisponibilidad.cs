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
            h.HoraFin,
            c.Estado AS EstadoCancha,
            r.Estado AS EstadoReserva
        FROM CanchaHorario ch
        INNER JOIN Horarios2 h
            ON ch.idHorario = h.idHorario
        INNER JOIN Canchas c
            ON ch.idCancha = c.CanchaID
        LEFT JOIN Reservas r
            ON r.CanchaID = ch.idCancha
            AND r.Fecha = CAST(GETDATE() AS DATE)
            AND r.HoraInicio = h.HoraInicio
            AND r.HoraFin = h.HoraFin
            AND r.Estado IN ('Pendiente', 'Confirmada')
        ORDER BY h.HoraInicio, ch.idCancha";

            DataTable datos = conSQL.retornaRegistros(consulta);

            dgvHorarios.Rows.Clear();

            var horarios = datos.AsEnumerable()
                .GroupBy(x => new
                {
                    IdHorario = x.Field<int>("idHorario"),
                    HoraInicio = x.Field<TimeSpan>("HoraInicio"),
                    HoraFin = x.Field<TimeSpan>("HoraFin")
                });

            foreach (var grupo in horarios)
            {
                string horaInicio = grupo.Key.HoraInicio.ToString(@"hh\:mm");
                string horaFin = grupo.Key.HoraFin.ToString(@"hh\:mm");

                string horario = horaInicio + " - " + horaFin;

                int fila = dgvHorarios.Rows.Add();

                // Columna de la hora
                dgvHorarios.Rows[fila].Cells[0].Value = horario;

                foreach (DataRow dato in grupo)
                {
                    int idCancha = Convert.ToInt32(dato["idCancha"]);

                    // AQUÍ VA EL CÓDIGO DEL ESTADO
                    string estado;

                    if (dato["EstadoReserva"] != DBNull.Value)
                    {
                        estado = "Ocupada";
                    }
                    else
                    {
                        estado = dato["EstadoCancha"].ToString();
                    }

                    int columna = -1;

                    if (idCancha == 3)
                        columna = 1;
                    else if (idCancha == 4)
                        columna = 2;
                    else if (idCancha == 5)
                        columna = 3;
                    else if (idCancha == 8)
                        columna = 4;

                    if (columna != -1)
                    {
                        dgvHorarios.Rows[fila].Cells[columna].Value = estado;
                    }
                }
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
