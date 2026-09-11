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
            string nombre = txtNombre.Text.Trim();
            string tipoCancha = cmbDeporte.Text.Trim();
            string estado = cmbEstado.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese el nombre de la cancha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (nombre.Length < 3 || nombre.Length > 50)
            {
                MessageBox.Show("El nombre debe tener entre 3 y 50 caracteres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cmbDeporte.SelectedIndex == -1 || string.IsNullOrWhiteSpace(tipoCancha))
            {
                MessageBox.Show("Seleccione el tipo de cancha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDeporte.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrecioHora.Text.Trim(), out decimal precioHora))
            {
                MessageBox.Show("Ingrese un precio válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioHora.Focus();
                return;
            }

            if (precioHora <= 0)
            {
                MessageBox.Show("El precio por hora debe ser mayor que cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioHora.Focus();
                return;
            }

            if (cmbEstado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(estado))
            {
                MessageBox.Show("Seleccione el estado de la cancha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEstado.Focus();
                return;
            }

            if (estado != "Disponible" && estado != "Mantenimiento")
            {
                MessageBox.Show("El estado seleccionado no es válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEstado.Focus();
                return;
            }

            if (NombreCanchaExiste(nombre))
            {
                MessageBox.Show("Ya existe una cancha con ese nombre.", "Nombre duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (tipo == 1)
            {
                if (oCon.insertarCancha(nombre, tipoCancha, precioHora, estado))
                {
                    MessageBox.Show("Cancha registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la cancha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (oCon.actualizarCancha(canchaID, nombre, tipoCancha, precioHora, estado))
                {
                    MessageBox.Show("Cancha actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la cancha.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool NombreCanchaExiste(string nombre)
        {
            string nombreConsulta = nombre.Replace("'", "''");

            string consulta = "SELECT COUNT(*) AS Cantidad FROM Canchas " +
                              "WHERE LOWER(LTRIM(RTRIM(Nombre))) = LOWER('" + nombreConsulta + "')";

            if (tipo == 2)
                consulta += " AND CanchaID <> " + canchaID;

            DataTable tabla = oCon.retornaRegistros(consulta);

            return tabla != null &&
                   tabla.Rows.Count > 0 &&
                   Convert.ToInt32(tabla.Rows[0]["Cantidad"]) > 0;
        }

        private void CargarCancha()
        {
            DataTable tabla = oCon.retornaRegistros(
                "SELECT Nombre, Tipo, PrecioHora, Estado FROM Canchas WHERE CanchaID = " + canchaID);

            if (tabla == null || tabla.Rows.Count == 0)
                return;

            DataRow fila = tabla.Rows[0];

            txtNombre.Text = fila["Nombre"].ToString();
            cmbDeporte.SelectedValue = fila["Tipo"].ToString();
            txtPrecioHora.Text = fila["PrecioHora"].ToString();

            string estado = fila["Estado"].ToString();

            if (estado == "Disponible" || estado == "Mantenimiento")
                cmbEstado.Text = estado;
            else
                cmbEstado.SelectedIndex = -1;
        }

        private void CargarEstados()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Disponible");
            cmbEstado.Items.Add("Mantenimiento");
            cmbEstado.SelectedIndex = -1;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmCrearCancha_Load_1(object sender, EventArgs e)
        {
            CargarEstados();

            DataTable dt = oCon.retornaRegistros(
                "SELECT DISTINCT Tipo FROM Canchas ORDER BY Tipo");

            cmbDeporte.DataSource = dt;
            cmbDeporte.DisplayMember = "Tipo";
            cmbDeporte.ValueMember = "Tipo";
            cmbDeporte.SelectedIndex = -1;

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