using FontAwesome.Sharp;
using login;
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
using System.Windows.Media.Media3D;

namespace login.Reservas
{
    public partial class frmDisponibilidad : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        string cadena;

        public frmDisponibilidad()
        {
            InitializeComponent();

            dgvHorarios.RowHeadersVisible = false;
            dgvHorarios.ReadOnly = true;
            dgvHorarios.AllowUserToAddRows = false;
            dgvHorarios.AllowUserToDeleteRows = false;
            dgvHorarios.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvHorarios.ScrollBars = ScrollBars.Both;
            dgvHorarios.RowTemplate.Height = 35;
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
        }

        private void frmDisponibilidad_Load(object sender, EventArgs e)
        {
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            cmbFiltroCancha.Items.Clear();
            cmbFiltroCancha.Items.Add("Todas");

            DataTable dtCanchas = conSQL.retornaRegistros(
                "SELECT Nombre FROM Canchas ORDER BY Nombre");

            if (dtCanchas != null)
            {
                foreach (DataRow fila in dtCanchas.Rows)
                    cmbFiltroCancha.Items.Add(fila["Nombre"].ToString());
            }

            cmbFiltroCancha.SelectedIndex = 0;
            CargarDisponibilidad();
        }

        private void CargarDisponibilidad()
        {
            string fecha = dtpFecha.Value.ToString("yyyyMMdd");
            string filtro = cmbFiltroCancha.Text.Trim().Replace("'", "''");

            cadena =
                "SELECT " +
                "CONVERT(VARCHAR(5), H.HoraInicio, 108) AS HoraInicio, " +
                "CONVERT(VARCHAR(5), H.HoraFin, 108) AS HoraFin, " +
                "C.CanchaID, " +
                "C.Nombre, " +
                "CASE " +
                "WHEN UPPER(LTRIM(RTRIM(ISNULL(C.Estado, '')))) LIKE 'MANTENIMIENTO%' " +
                "OR UPPER(LTRIM(RTRIM(ISNULL(C.Estado, '')))) IN ('INACTIVA', 'CERRADA') " +
                "THEN 'Mantenimiento' " +
                "WHEN EXISTS " +
                "( " +
                "SELECT 1 " +
                "FROM Reservas R " +
                "WHERE R.CanchaID = C.CanchaID " +
                "AND CONVERT(DATE, R.Fecha) = CONVERT(DATE, '" + fecha + "', 112) " +
                "AND UPPER(LTRIM(RTRIM(ISNULL(R.Estado, '')))) <> 'CANCELADA' " +
                "AND R.HoraInicio < H.HoraFin " +
                "AND R.HoraFin > H.HoraInicio " +
                ") " +
                "THEN 'Reservada' " +
                "ELSE 'Disponible' " +
                "END AS EstadoHorario " +
                "FROM Horarios H " +
                "CROSS JOIN Canchas C ";

            if (filtro != "Todas" && !string.IsNullOrWhiteSpace(filtro))
                cadena += "WHERE C.Nombre = '" + filtro + "' ";

            cadena += "ORDER BY H.HoraInicio, C.CanchaID";

            DataTable dt = conSQL.retornaRegistros(cadena);

            dgvHorarios.Columns.Clear();
            dgvHorarios.Rows.Clear();

            if (dt == null || dt.Rows.Count == 0)
                return;

            DataTable canchas = dt.DefaultView.ToTable(
                true,
                "CanchaID",
                "Nombre");

            DataGridViewTextBoxColumn columnaHorario =
                new DataGridViewTextBoxColumn();

            columnaHorario.Name = "colHorario";
            columnaHorario.HeaderText = "Horario";
            columnaHorario.Width = 120;
            columnaHorario.Frozen = true;

            dgvHorarios.Columns.Add(columnaHorario);

            foreach (DataRow cancha in canchas.Rows)
            {
                DataGridViewTextBoxColumn columna =
                    new DataGridViewTextBoxColumn();

                int canchaID = Convert.ToInt32(cancha["CanchaID"]);

                columna.Name = "Cancha_" + canchaID;
                columna.HeaderText = cancha["Nombre"].ToString();
                columna.Width = 130;
                columna.Tag = canchaID;

                dgvHorarios.Columns.Add(columna);
            }

            DataTable horarios = dt.DefaultView.ToTable(
                true,
                "HoraInicio",
                "HoraFin");

            Dictionary<string, int> filas =
                new Dictionary<string, int>();

            foreach (DataRow horario in horarios.Rows)
            {
                string inicio = horario["HoraInicio"].ToString();
                string fin = horario["HoraFin"].ToString();
                string clave = inicio + "|" + fin;
                string textoHorario = inicio + " - " + fin;

                int fila = dgvHorarios.Rows.Add();

                dgvHorarios.Rows[fila].Cells[0].Value = textoHorario;
                dgvHorarios.Rows[fila].Tag = clave;

                filas[clave] = fila;
            }

            foreach (DataRow registro in dt.Rows)
            {
                string inicio = registro["HoraInicio"].ToString();
                string fin = registro["HoraFin"].ToString();
                string claveHorario = inicio + "|" + fin;

                int canchaID = Convert.ToInt32(registro["CanchaID"]);

                if (!filas.ContainsKey(claveHorario))
                    continue;

                string nombreColumna = "Cancha_" + canchaID;

                if (!dgvHorarios.Columns.Contains(nombreColumna))
                    continue;

                int fila = filas[claveHorario];
                int columna = dgvHorarios.Columns[nombreColumna].Index;

                string estado = registro["EstadoHorario"].ToString();

                DataGridViewCell celda =
                    dgvHorarios.Rows[fila].Cells[columna];

                celda.Value = estado;
                celda.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                if (estado == "Disponible")
                {
                    celda.Style.BackColor =
                        Color.FromArgb(190, 239, 190);
                }
                else if (estado == "Reservada")
                {
                    celda.Style.BackColor =
                        Color.FromArgb(245, 166, 130);
                }
                else
                {
                    celda.Style.BackColor = Color.LightGray;
                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarDisponibilidad();
        }

        private void cmbFiltroCancha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroCancha.SelectedIndex >= 0)
                CargarDisponibilidad();
        }
    }
}