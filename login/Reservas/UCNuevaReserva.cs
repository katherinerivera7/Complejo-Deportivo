using FontAwesome.Sharp;
using login.GestionDeUsuarios;
using System;
using System.Data;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class UCNuevaReserva : UserControl
    {
        csConectaSQL conSQL = new csConectaSQL();
        private int clienteID = 0;

        public UCNuevaReserva()
        {
            InitializeComponent();
            dtpFecha.MinDate = DateTime.Today;
            dtpFecha.Value = DateTime.Today;
        }

        private void UCNuevaReserva_Load(object sender, EventArgs e)
        {
            DataTable dt = conSQL.retornaRegistros("SELECT DISTINCT Tipo FROM Canchas ORDER BY Tipo");

            cmbDeporte.DataSource = dt;
            cmbDeporte.DisplayMember = "Tipo";
            cmbDeporte.ValueMember = "Tipo";
            cmbDeporte.SelectedIndex = -1;

            lblFecha.Text = dtpFecha.Value.ToString("dd/MM/yyyy");
            lblCancha.Text = "---";
            lblHorario.Text = "---";
        }

        private void cmbDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCancha.DataSource = null;
            cmbCancha.Items.Clear();
            cmbCancha.Enabled = true;

            cmbHorario.DataSource = null;
            cmbHorario.Items.Clear();
            cmbHorario.Enabled = true;

            lblCancha.Text = "---";
            lblHorario.Text = "---";

            if (cmbDeporte.SelectedIndex == -1)
                return;

            string deporte = cmbDeporte.Text.Trim().Replace("'", "''");

            string consulta = "SELECT CanchaID, Tipo + ' - ' + Nombre AS Cancha " +
                              "FROM Canchas " +
                              "WHERE Tipo = '" + deporte + "' " +
                              "AND UPPER(LTRIM(RTRIM(Estado))) NOT LIKE 'MANTENIMIENTO%' " +
                              "AND UPPER(LTRIM(RTRIM(Estado))) NOT IN ('INACTIVA', 'CERRADA') " +
                              "ORDER BY Nombre";

            DataTable dt = conSQL.retornaRegistros(consulta);

            if (dt == null || dt.Rows.Count == 0)
            {
                cmbCancha.Items.Add("No hay canchas disponibles");
                cmbCancha.Enabled = false;
                cmbCancha.SelectedIndex = 0;

                cmbHorario.Items.Add("No hay horarios disponibles");
                cmbHorario.Enabled = false;
                cmbHorario.SelectedIndex = 0;

                lblCancha.Text = "No disponible";
                lblHorario.Text = "No hay horarios disponibles";
                return;
            }

            cmbCancha.DataSource = dt;
            cmbCancha.DisplayMember = "Cancha";
            cmbCancha.ValueMember = "CanchaID";
            cmbCancha.SelectedIndex = 0;
        }

        private void cmbCancha_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView filaCancha = cmbCancha.SelectedItem as DataRowView;

            if (filaCancha == null || !cmbCancha.Enabled)
                return;

            lblCancha.Text = filaCancha["Cancha"].ToString();
            CargarHorariosDisponibles();
        }

        private void CargarHorariosDisponibles()
        {
            lblHorario.Text = "---";

            cmbHorario.DataSource = null;
            cmbHorario.Items.Clear();
            cmbHorario.Enabled = true;

            DataRowView filaCancha = cmbCancha.SelectedItem as DataRowView;

            if (filaCancha == null || !cmbCancha.Enabled)
                return;

            int canchaID = Convert.ToInt32(filaCancha["CanchaID"]);
            string fecha = dtpFecha.Value.ToString("yyyyMMdd");

            string consulta = "SELECT H.HorarioID, " +
                              "CONVERT(VARCHAR(5), H.HoraInicio, 108) + ' - ' + CONVERT(VARCHAR(5), H.HoraFin, 108) AS Horario, " +
                              "H.HoraInicio, H.HoraFin " +
                              "FROM Horarios H " +
                              "WHERE EXISTS " +
                              "(SELECT 1 FROM Canchas C " +
                              "WHERE C.CanchaID = " + canchaID + " " +
                              "AND UPPER(LTRIM(RTRIM(C.Estado))) NOT LIKE 'MANTENIMIENTO%' " +
                              "AND UPPER(LTRIM(RTRIM(C.Estado))) NOT IN ('INACTIVA', 'CERRADA')) " +
                              "AND NOT EXISTS " +
                              "(SELECT 1 FROM Reservas R " +
                              "WHERE R.CanchaID = " + canchaID + " " +
                              "AND R.Fecha = '" + fecha + "' " +
                              "AND UPPER(LTRIM(RTRIM(ISNULL(R.Estado, '')))) <> 'CANCELADA' " +
                              "AND R.HoraInicio < H.HoraFin " +
                              "AND R.HoraFin > H.HoraInicio) " +
                              "ORDER BY H.HoraInicio";

            DataTable tabla = conSQL.retornaRegistros(consulta);

            if (tabla == null || tabla.Rows.Count == 0)
            {
                cmbHorario.Items.Add("No hay horarios disponibles");
                cmbHorario.Enabled = false;
                cmbHorario.SelectedIndex = 0;
                lblHorario.Text = "No hay horarios disponibles";
                return;
            }

            cmbHorario.DataSource = tabla;
            cmbHorario.DisplayMember = "Horario";
            cmbHorario.ValueMember = "HorarioID";
            cmbHorario.SelectedIndex = -1;
            lblHorario.Text = "---";
        }

        private void cmbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView filaHorario = cmbHorario.SelectedItem as DataRowView;

            if (filaHorario != null && cmbHorario.Enabled)
                lblHorario.Text = filaHorario["Horario"].ToString();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            lblFecha.Text = dtpFecha.Value.ToString("dd/MM/yyyy");
            CargarHorariosDisponibles();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            frmFacturaReserva frm = new frmFacturaReserva();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(frm);
            pnlContenido.Tag = frm;

            frm.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de que desea cancelar la reserva?",
                "Cancelar reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnEncontrarCliente_Click(object sender, EventArgs e)
        {
            frmEncontrarCliente frmC = new frmEncontrarCliente();
            frmC.StartPosition = FormStartPosition.CenterScreen;
            frmC.ShowDialog();

            if (frmC.DialogResult == DialogResult.OK)
            {
                txtTipoDocumento.Text = frmC.TipoDocumento;
                txtTelefono.Text = frmC.Telefono;
                txtNombres.Text = frmC.Nombre;
                txtDireccion.Text = frmC.Direccion;
                txtCorreo.Text = frmC.Correo;
                txtCodigo.Text = frmC.ClienteID;
                txtCedula.Text = frmC.Cedula;
                txtApellidos.Text = frmC.Apellido;
                lblCliente.Text = frmC.Nombre + " " + frmC.Apellido;
            }
        }

        private void chkArbitro_CheckedChanged(object sender, EventArgs e)
        {
            lblServiciosAdicionales.Text = "Árbitro";
            if(!chkArbitro.Checked)
                lblServiciosAdicionales.Text = "Ninguno";
        }
    }
}