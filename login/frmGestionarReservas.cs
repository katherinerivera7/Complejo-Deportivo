using Guna.UI2.WinForms;
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
    public partial class frmGestionarReservas : Form
    {
        csConectaSQL con=new csConectaSQL();
        string cadena;
        public frmGestionarReservas()
        {
            InitializeComponent();
        }

        private void pnlContenidoo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void frmGestionarReservas_Load(object sender, EventArgs e)
        {
            cadena = "SELECT\r\n    R.ReservaID,\r\n    C.Cedula,\r\n    C.Nombre,\r\n    C.Apellido,\r\n    CA.Tipo + ' - ' + CA.Nombre AS Cancha,\r\n    R.Fecha,\r\n    R.HoraInicio,\r\n    R.HoraFin,\r\n    R.Estado\r\nFROM Reservas R\r\nINNER JOIN Clientes C ON R.ClienteID = C.ClienteID\r\nINNER JOIN Canchas CA ON R.CanchaID = CA.CanchaID\r\nORDER BY R.Fecha DESC, R.HoraInicio;";
            dgvReservas.DataSource = con.retornaRegistros(cadena);
            dgvReservas.ReadOnly = true;
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.AllowUserToDeleteRows = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.MultiSelect = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            DataGridViewRow fila = dgvReservas.CurrentRow;

            int reservaID = Convert.ToInt32(
                ObtenerValorFila(fila, "ReservaID", 0));

            string cancha = Convert.ToString(
                ObtenerValorFila(fila, "Cancha", 4));

            string fecha = Convert.ToDateTime(
                ObtenerValorFila(fila, "Fecha", 5)).ToString("dd/MM/yyyy");

            string horaInicio = Convert.ToString(
                ObtenerValorFila(fila, "HoraInicio", 6));

            string horaFin = Convert.ToString(
                ObtenerValorFila(fila, "HoraFin", 7));

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar esta reserva?\n\n" +
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

                dgvReservas.DataSource = con.retornaRegistros(cadena);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la reserva.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva.");
                return;
            }

            int reservaID = Convert.ToInt32(
                dgvReservas.CurrentRow.Cells[0].Value);

            UCNuevaReserva frm =
                new UCNuevaReserva(reservaID);

            pnlContenidoo.Controls.Clear();
            frm.Dock = DockStyle.Fill;

            pnlContenidoo.Controls.Add(frm);
            pnlContenidoo.Tag = frm;

            frm.Show();
        }
        private object ObtenerValorFila(DataGridViewRow fila, string campo, int indice)
        {
            foreach (DataGridViewColumn columna in dgvReservas.Columns)
            {
                if (columna.DataPropertyName == campo || columna.Name == campo)
                    return fila.Cells[columna.Index].Value;
            }

            return fila.Cells[indice].Value;
        }
    }
}
