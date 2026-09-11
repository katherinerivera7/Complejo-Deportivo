using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmDisponibilidad : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        string cadena;
        private bool cargandoFormulario = false;

        public frmDisponibilidad()
        {
            InitializeComponent();

            dgvHorarios.RowHeadersVisible = false;
            dgvHorarios.ReadOnly = true;
            dgvHorarios.AllowUserToAddRows = false;
            dgvHorarios.AllowUserToDeleteRows = false;
            dgvHorarios.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvHorarios.MultiSelect = false;
            dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvHorarios.ScrollBars = ScrollBars.Both;
            dgvHorarios.RowTemplate.Height = 35;
        }

        private void frmDisponibilidad_Load(object sender, EventArgs e)
        {
            cargandoFormulario = true;

            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;

            CargarFiltroCanchas();

            cargandoFormulario = false;
            ActualizarPantalla();
        }

        private void CargarFiltroCanchas()
        {
            cmbFiltroCancha.Items.Clear();
            cmbFiltroCancha.Items.Add("Todas");

            DataTable dtCanchas = conSQL.retornaRegistros(
                "SELECT Nombre FROM Canchas ORDER BY Nombre");

            foreach (DataRow fila in dtCanchas.Rows)
                cmbFiltroCancha.Items.Add(fila["Nombre"].ToString());

            cmbFiltroCancha.SelectedIndex = 0;
        }

        private void ActualizarPantalla()
        {
            ActualizarFecha();
            CargarResumenCanchas();
            CargarDisponibilidad();
        }

        private void ActualizarFecha()
        {
            DateTime fecha = dtpFecha.Value.Date;
            CultureInfo cultura = new CultureInfo("es-ES");

            lblMes.Text = fecha.ToString("d 'de' MMMM 'de' yyyy", cultura);
            lblFechaSeleccionada.Text = fecha.ToString("d MMMM yyyy", cultura);
            lblDia.Text = fecha.ToString("dddd", cultura);

            btnRetroceder.Enabled = fecha > DateTime.Today;
            btnSiguiente.Enabled = fecha < dtpFecha.MaxDate.Date;
        }

        private void CargarResumenCanchas()
        {
            string fecha = dtpFecha.Value.ToString("yyyyMMdd");

            string consultaTotal = @"
SELECT COUNT(*) AS TotalActivas
FROM Canchas
WHERE UPPER(LTRIM(RTRIM(ISNULL(Estado, '')))) NOT LIKE 'MANTENIMIENTO%'
AND UPPER(LTRIM(RTRIM(ISNULL(Estado, '')))) NOT IN ('INACTIVA', 'CERRADA')";

            DataTable dtTotal = conSQL.retornaRegistros(consultaTotal);

            int totalActivas = 0;

            if (dtTotal.Rows.Count > 0)
                totalActivas = Convert.ToInt32(dtTotal.Rows[0]["TotalActivas"]);

            string condicionHora = "";

            if (dtpFecha.Value.Date == DateTime.Today)
                condicionHora = "AND H.HoraFin > CAST(GETDATE() AS TIME)";

            string consultaDisponibles = @"
SELECT COUNT(*) AS Disponibles
FROM Canchas C
WHERE UPPER(LTRIM(RTRIM(ISNULL(C.Estado, '')))) NOT LIKE 'MANTENIMIENTO%'
AND UPPER(LTRIM(RTRIM(ISNULL(C.Estado, '')))) NOT IN ('INACTIVA', 'CERRADA')
AND EXISTS
(
    SELECT 1
    FROM Horarios H
    WHERE 1 = 1
    " + condicionHora + @"
    AND NOT EXISTS
    (
        SELECT 1
        FROM Reservas R
        WHERE R.CanchaID = C.CanchaID
        AND CONVERT(DATE, R.Fecha) = CONVERT(DATE, '" + fecha + @"', 112)
        AND UPPER(LTRIM(RTRIM(ISNULL(R.Estado, '')))) <> 'CANCELADA'
        AND R.HoraInicio < H.HoraFin
        AND R.HoraFin > H.HoraInicio
    )
)";

            DataTable dtDisponibles = conSQL.retornaRegistros(consultaDisponibles);

            int disponibles = 0;

            if (dtDisponibles.Rows.Count > 0)
                disponibles = Convert.ToInt32(dtDisponibles.Rows[0]["Disponibles"]);

            lblCanchasTotales.Text = totalActivas.ToString();
            lblCanchasDisponibles.Text = disponibles.ToString();
        }

        private void CargarDisponibilidad()
        {
            string fecha = dtpFecha.Value.ToString("yyyyMMdd");
            string filtro = cmbFiltroCancha.Text.Trim().Replace("'", "''");

            cadena = "SELECT " +
                     "CONVERT(VARCHAR(5), H.HoraInicio, 108) AS HoraInicio, " +
                     "CONVERT(VARCHAR(5), H.HoraFin, 108) AS HoraFin, " +
                     "C.CanchaID, C.Nombre, " +
                     "CASE " +
                     "WHEN UPPER(LTRIM(RTRIM(ISNULL(C.Estado, '')))) LIKE 'MANTENIMIENTO%' " +
                     "OR UPPER(LTRIM(RTRIM(ISNULL(C.Estado, '')))) IN ('INACTIVA', 'CERRADA') " +
                     "THEN 'Mantenimiento' " +
                     "WHEN EXISTS " +
                     "(SELECT 1 FROM Reservas R " +
                     "WHERE R.CanchaID = C.CanchaID " +
                     "AND CONVERT(DATE, R.Fecha) = CONVERT(DATE, '" + fecha + "', 112) " +
                     "AND UPPER(LTRIM(RTRIM(ISNULL(R.Estado, '')))) <> 'CANCELADA' " +
                     "AND R.HoraInicio < H.HoraFin " +
                     "AND R.HoraFin > H.HoraInicio) " +
                     "THEN 'Reservada' " +
                     "ELSE 'Disponible' END AS EstadoHorario " +
                     "FROM Horarios H CROSS JOIN Canchas C ";

            if (filtro != "Todas" && !string.IsNullOrWhiteSpace(filtro))
                cadena += "WHERE C.Nombre = '" + filtro + "' ";

            cadena += "ORDER BY H.HoraInicio, C.CanchaID";

            DataTable dt = conSQL.retornaRegistros(cadena);

            dgvHorarios.Columns.Clear();
            dgvHorarios.Rows.Clear();

            if (dt == null || dt.Rows.Count == 0)
                return;

            DataTable canchas = dt.DefaultView.ToTable(true, "CanchaID", "Nombre");

            DataGridViewTextBoxColumn columnaHorario = new DataGridViewTextBoxColumn();
            columnaHorario.Name = "colHorario";
            columnaHorario.HeaderText = "Horario";
            columnaHorario.Width = 120;
            columnaHorario.Frozen = true;
            columnaHorario.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHorarios.Columns.Add(columnaHorario);

            foreach (DataRow cancha in canchas.Rows)
            {
                int canchaID = Convert.ToInt32(cancha["CanchaID"]);

                DataGridViewTextBoxColumn columna =
                    new DataGridViewTextBoxColumn();

                columna.Name = "Cancha_" + canchaID;
                columna.HeaderText = cancha["Nombre"].ToString();
                columna.Width = 130;
                columna.Tag = canchaID;
                columna.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvHorarios.Columns.Add(columna);
            }

            DataTable horarios =
                dt.DefaultView.ToTable(true, "HoraInicio", "HoraFin");

            Dictionary<string, int> filas =
                new Dictionary<string, int>();

            foreach (DataRow horario in horarios.Rows)
            {
                string inicio = horario["HoraInicio"].ToString();
                string fin = horario["HoraFin"].ToString();
                string clave = inicio + "|" + fin;

                int fila = dgvHorarios.Rows.Add();

                dgvHorarios.Rows[fila].Cells[0].Value =
                    inicio + " - " + fin;

                dgvHorarios.Rows[fila].Tag = clave;
                filas[clave] = fila;
            }

            foreach (DataRow registro in dt.Rows)
            {
                string inicio = registro["HoraInicio"].ToString();
                string fin = registro["HoraFin"].ToString();
                string claveHorario = inicio + "|" + fin;

                int canchaID = Convert.ToInt32(registro["CanchaID"]);
                string nombreColumna = "Cancha_" + canchaID;

                if (!filas.ContainsKey(claveHorario))
                    continue;

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

                    celda.Style.ForeColor =
                        Color.FromArgb(45, 110, 45);
                }
                else if (estado == "Reservada")
                {
                    celda.Style.BackColor =
                        Color.FromArgb(245, 166, 130);

                    celda.Style.ForeColor =
                        Color.FromArgb(130, 55, 25);
                }
                else
                {
                    celda.Style.BackColor = Color.LightGray;
                    celda.Style.ForeColor = Color.DimGray;
                }
            }

            dgvHorarios.ClearSelection();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!cargandoFormulario)
                ActualizarPantalla();
        }

        private void cmbFiltroCancha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargandoFormulario && cmbFiltroCancha.SelectedIndex >= 0)
                CargarDisponibilidad();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            DateTime nuevaFecha = dtpFecha.Value.Date.AddDays(1);

            if (nuevaFecha <= dtpFecha.MaxDate.Date)
                dtpFecha.Value = nuevaFecha;
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            DateTime nuevaFecha = dtpFecha.Value.Date.AddDays(-1);

            if (nuevaFecha >= DateTime.Today)
                dtpFecha.Value = nuevaFecha;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dgvHorarios_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
        }

        private void dgvHorarios_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
        }
    }
}