using System;
using System.Data;
using System.Windows.Forms;

namespace login.Reservas
{
    public partial class frmCrearCancha : Form
    {
        csConectaSQL oCon = new csConectaSQL();

        int tipo = 1;
        int canchaID = 0;

        public frmCrearCancha()
        {
            InitializeComponent();
        }

        public frmCrearCancha(int id)
        {
            InitializeComponent();
            canchaID = id;
            tipo = 2;
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la cancha.");
                return;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de cancha.");
                return;
            }

            if (!decimal.TryParse(txtPrecioHora.Text, out decimal precioHora))
            {
                MessageBox.Show("Ingrese un precio por hora válido.");
                return;
            }

            if (precioHora < 0)
            {
                MessageBox.Show("El precio por hora no puede ser negativo.");
                return;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado de la cancha.");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string tipoCancha = cmbTipo.Text;
            string estado = cmbEstado.Text;

            if (tipo == 1)
            {
                if (oCon.insertarCancha(nombre, tipoCancha, precioHora, estado))
                {
                    MessageBox.Show("Cancha registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else if (tipo == 2)
            {
                if (oCon.actualizarCancha(canchaID, nombre, tipoCancha, precioHora, estado))
                {
                    MessageBox.Show("Cancha actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void CargarCancha()
        {
            DataTable tabla = oCon.retornaRegistros("SELECT Nombre, Tipo, PrecioHora, Estado FROM Canchas WHERE CanchaID = " + canchaID);

            if (tabla.Rows.Count == 0)
                return;

            DataRow fila = tabla.Rows[0];

            txtNombre.Text = fila["Nombre"].ToString();
            cmbTipo.Text = fila["Tipo"].ToString();
            txtPrecioHora.Text = fila["PrecioHora"].ToString();
            cmbEstado.Text = fila["Estado"].ToString();
        }

        private void frmCrearCancha_Load_1(object sender, EventArgs e)
        {
            if (tipo == 2)
            {
                CargarCancha();
                btnCrear.Text = "Guardar cambios";
                lblCrearCancha.Text = "Editar cancha";
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              txtPrecioHora.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbTipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEstado.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCrear.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}