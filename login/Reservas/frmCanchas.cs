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
    public partial class frmCanchas : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmCanchas()
        {
            InitializeComponent();
        }

        private void frmCanchas_Load(object sender, EventArgs e)
        {
            CargarCanchas();
        }
        private void CargarCanchas()
        {
            dgvCanchas.DataSource = conSQL.retornaRegistros("SELECT CanchaID, Nombre, Tipo, PrecioHora, Estado FROM Canchas ORDER BY CanchaID DESC");
            dgvCanchas.ClearSelection();
            dgvCanchas.CurrentCell = null;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmCrearCancha frm = new frmCrearCancha();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            CargarCanchas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCanchas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cancha para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int canchaID = Convert.ToInt32(dgvCanchas.SelectedRows[0].Cells["colCanchaID"].Value);

            frmCrearCancha frm = new frmCrearCancha(canchaID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            CargarCanchas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCanchas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una cancha para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int canchaID = Convert.ToInt32(dgvCanchas.SelectedRows[0].Cells["colCanchaID"].Value);
            string nombre = dgvCanchas.SelectedRows[0].Cells["colNombre"].Value.ToString();

            DialogResult respuesta = MessageBox.Show("¿Desea eliminar la cancha " + nombre + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            if (conSQL.borrarDatos("Canchas", "CanchaID = " + canchaID))
            {
                MessageBox.Show("Cancha eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCanchas();
            }
        }
    }
}
