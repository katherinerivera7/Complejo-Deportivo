using Guna.UI2.WinForms;
using login.Reservas;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace login
{
    public partial class frmGestionarReservas : Form
    {
        csConectaSQL con = new csConectaSQL();
        string cadena;

        public frmGestionarReservas()
        {
            InitializeComponent();
        }

        private void frmGestionarReservas_Load(object sender, EventArgs e)
        {
            CargarReservas();

            dgvReservas.ReadOnly = true;
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.MultiSelect = false;
        }

        private void CargarReservas()
        {
            cadena = @"SELECT
                        R.ReservaID,
                        R.ClienteID,
                        R.CanchaID,
                        C.Cedula,
                        C.Nombre,
                        C.Apellido,
                        C.Telefono,
                        CA.Tipo + ' - ' + CA.Nombre AS Cancha,
                        R.Fecha,
                        R.HoraInicio,
                        R.HoraFin,
                        R.Estado
                       FROM Reservas R
                       INNER JOIN Clientes C ON R.ClienteID = C.ClienteID
                       INNER JOIN Canchas CA ON R.CanchaID = CA.CanchaID
                       ORDER BY R.Fecha DESC, R.HoraInicio";

            dgvReservas.DataSource = con.retornaRegistros(cadena);

            if (dgvReservas.Columns["ClienteID"] != null)
                dgvReservas.Columns["ClienteID"].Visible = false;

            if (dgvReservas.Columns["CanchaID"] != null)
                dgvReservas.Columns["CanchaID"].Visible = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtNombre.Text.Trim();
            string filtro = cmbFiltro.Text;

            if (string.IsNullOrWhiteSpace(texto))
            {
                CargarReservas();
                return;
            }

            string consulta = @"SELECT
                                R.ReservaID,
                                R.ClienteID,
                                R.CanchaID,
                                C.Cedula,
                                C.Nombre,
                                C.Apellido,
                                C.Telefono,
                                CA.Tipo + ' - ' + CA.Nombre AS Cancha,
                                R.Fecha,
                                R.HoraInicio,
                                R.HoraFin,
                                R.Estado
                                FROM Reservas R
                                INNER JOIN Clientes C ON R.ClienteID = C.ClienteID
                                INNER JOIN Canchas CA ON R.CanchaID = CA.CanchaID
                                WHERE 1 = 1";

            texto = texto.Replace("'", "''");

            switch (filtro)
            {
                case "Nombres":
                    consulta += " AND C.Nombre LIKE '%" + texto + "%'";
                    break;

                case "Apellidos":
                    consulta += " AND C.Apellido LIKE '%" + texto + "%'";
                    break;

                case "Teléfono":
                    consulta += " AND C.Telefono LIKE '%" + texto + "%'";
                    break;

                case "ID":
                    int reservaID;

                    if (!int.TryParse(texto, out reservaID))
                    {
                        MessageBox.Show(
                            "Ingrese un ID de reserva válido.",
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    consulta += " AND R.ReservaID = " + reservaID;
                    break;

                default:
                    MessageBox.Show(
                        "Seleccione un filtro de búsqueda.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
            }

            consulta += " ORDER BY R.Fecha DESC, R.HoraInicio";

            dgvReservas.DataSource = con.retornaRegistros(consulta);

            if (dgvReservas.Columns["ClienteID"] != null)
                dgvReservas.Columns["ClienteID"].Visible = false;

            if (dgvReservas.Columns["CanchaID"] != null)
                dgvReservas.Columns["CanchaID"].Visible = false;
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una reserva.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dgvReservas.CurrentRow;

            int reservaID = Convert.ToInt32(
                ObtenerValorFila(fila, "ReservaID", 0));

            string cancha = Convert.ToString(
                ObtenerValorFila(fila, "Cancha", 7));

            string fecha = Convert.ToDateTime(
                ObtenerValorFila(fila, "Fecha", 8)).ToString("dd/MM/yyyy");

            string horaInicio = Convert.ToString(
                ObtenerValorFila(fila, "HoraInicio", 9));

            string horaFin = Convert.ToString(
                ObtenerValorFila(fila, "HoraFin", 10));

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar esta reserva?\n\n" +
                "ID Reserva: " + reservaID + "\n" +
                "Cancha: " + cancha + "\n" +
                "Fecha: " + fecha + "\n" +
                "Horario: " + horaInicio + " - " + horaFin,
                "Eliminar reserva",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado != DialogResult.Yes)
                return;

            if (con.eliminarReserva(reservaID))
            {
                MessageBox.Show(
                    "Reserva eliminada correctamente. El horario quedó disponible.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarReservas();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo eliminar la reserva.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una reserva.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dgvReservas.CurrentRow;

            int reservaID = Convert.ToInt32(
                ObtenerValorFila(fila, "ReservaID", 0));

            UCNuevaReserva frm = new UCNuevaReserva(reservaID);

            pnlContenidoo.Controls.Clear();

            frm.Dock = DockStyle.Fill;

            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;

            frm.Show();
        }

        private object ObtenerValorFila(
            DataGridViewRow fila,
            string campo,
            int indice)
        {
            foreach (DataGridViewColumn columna in dgvReservas.Columns)
            {
                if (columna.DataPropertyName == campo ||
                    columna.Name == campo)
                {
                    return fila.Cells[columna.Index].Value;
                }
            }

            return fila.Cells[indice].Value;
        }

        private void pnlContenidoo_Paint(object sender, PaintEventArgs e)
        {

        }
    
private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

        }
    }
}