using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Promciones
{
    public partial class frmCrearPromocion : Form
    {
        string conexionString = @"Server=LAPTOP-J5U2QS20\SQLEXPRESS01;Database=ComplejoDeportivo;Integrated Security=True;TrustServerCertificate=True;";

        public frmCrearPromocion()
        {
            InitializeComponent();
        }


        private void frmCrearPromocion_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.MinDate = DateTime.Today;
            dtpFechaFin.MinDate = DateTime.Today;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            if (cmbUnidadDescuento.Items.Count == 0)
            {
                cmbUnidadDescuento.Items.Add("%");
                cmbUnidadDescuento.Items.Add("$");
            }

            cmbUnidadDescuento.SelectedIndex = -1;
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private bool ValidarCampos(out decimal descuento)
        {
            descuento = 0;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarAviso("Ingrese el nombre de la promoción.", txtNombre);
                return false;
            }

            if (txtNombre.Text.Trim().Length < 4)
            {
                MostrarAviso("El nombre debe tener al menos 4 caracteres.", txtNombre);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MostrarAviso("Ingrese una descripción.", txtDescripcion);
                return false;
            }

            if (txtDescripcion.Text.Trim().Length < 10)
            {
                MostrarAviso("La descripción debe tener al menos 10 caracteres.", txtDescripcion);
                return false;
            }

            if (cmbTipoPromocion.SelectedIndex == -1)
            {
                MostrarAviso("Seleccione el tipo de promoción.", cmbTipoPromocion);
                return false;
            }

            if (cmbUnidadDescuento.SelectedIndex == -1)
            {
                MostrarAviso("Seleccione si el descuento será en $ o %.", cmbUnidadDescuento);
                return false;
            }

            if (!IntentarConvertirDescuento(txtDescuento.Text, out descuento))
            {
                MostrarAviso("Ingrese un descuento numérico válido.", txtDescuento);
                txtDescuento.SelectAll();
                return false;
            }

            if (descuento <= 0)
            {
                MostrarAviso("El descuento debe ser mayor que cero.", txtDescuento);
                txtDescuento.SelectAll();
                return false;
            }

            if (cmbUnidadDescuento.Text == "%" && descuento > 100)
            {
                MostrarAviso("El descuento porcentual no puede superar el 100%.", txtDescuento);
                txtDescuento.SelectAll();
                return false;
            }

            if (cmbTipoCliente.SelectedIndex == -1)
            {
                MostrarAviso("Seleccione el tipo de cliente.", cmbTipoCliente);
                return false;
            }

            if (cmbAplicarA.SelectedIndex == -1)
            {
                MostrarAviso("Seleccione a qué se aplicará la promoción.", cmbAplicarA);
                return false;
            }

            if (dtpFechaInicio.Value.Date < DateTime.Today)
            {
                MostrarAviso("La fecha de inicio no puede ser anterior a hoy.", dtpFechaInicio);
                return false;
            }

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                MostrarAviso("La fecha final no puede ser anterior a la fecha de inicio.", dtpFechaFin);
                return false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MostrarAviso("Seleccione el estado de la promoción.", cmbEstado);
                return false;
            }

            return true;
        }

        private void MostrarAviso(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private bool IntentarConvertirDescuento(string texto, out decimal descuento)
        {
            texto = texto.Trim();

            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out descuento))
                return true;

            texto = texto.Replace(',', '.');
            return decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out descuento);
        }

        private void btnGuardarPromocion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out decimal descuento))
                return;

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = @"INSERT INTO Promociones
                    (Nombre, Descripcion, TipoPromocion, Descuento, UnidadDescuento,
                    TipoCliente, AplicarA, ServicioIncluido, FechaInicio, FechaFin,
                    Condiciones, Estado)
                    VALUES
                    (@Nombre, @Descripcion, @TipoPromocion, @Descuento, @UnidadDescuento,
                    @TipoCliente, @AplicarA, @ServicioIncluido, @FechaInicio, @FechaFin,
                    @Condiciones, @Estado)";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = txtNombre.Text.Trim();
                        cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 500).Value = txtDescripcion.Text.Trim();
                        cmd.Parameters.Add("@TipoPromocion", SqlDbType.NVarChar, 50).Value = cmbTipoPromocion.Text;
                        cmd.Parameters.Add("@UnidadDescuento", SqlDbType.VarChar, 1).Value = cmbUnidadDescuento.Text;
                        cmd.Parameters.Add("@TipoCliente", SqlDbType.NVarChar, 50).Value = cmbTipoCliente.Text;
                        cmd.Parameters.Add("@AplicarA", SqlDbType.NVarChar, 100).Value = cmbAplicarA.Text;
                        cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = dtpFechaInicio.Value.Date;
                        cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = dtpFechaFin.Value.Date;
                        cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = cmbEstado.Text.Equals("Activa", StringComparison.OrdinalIgnoreCase);

                        SqlParameter parametroDescuento = cmd.Parameters.Add("@Descuento", SqlDbType.Decimal);
                        parametroDescuento.Precision = 10;
                        parametroDescuento.Scale = 2;
                        parametroDescuento.Value = descuento;

                        cmd.Parameters.Add("@ServicioIncluido", SqlDbType.NVarChar, 100).Value =
                            cmbServicio.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbServicio.Text)
                            ? (object)DBNull.Value
                            : cmbServicio.Text.Trim();

                        cmd.Parameters.Add("@Condiciones", SqlDbType.NVarChar, 500).Value =
                            string.IsNullOrWhiteSpace(txtCondiciones.Text)
                            ? (object)DBNull.Value
                            : txtCondiciones.Text.Trim();

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Promoción registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al guardar la promoción:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();

            if (btnCancelar.FocusedColor == Color.FromArgb(9, 128, 0))
            {
                frmVerPromociones frm = new frmVerPromociones();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlContenido.Controls.Add(frm);
                pnlContenido.Tag = frm;
                frm.Show();
            }
            else
            {
                frmMenuPromociones frm = new frmMenuPromociones();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlContenido.Controls.Add(frm);
                pnlContenido.Tag = frm;
                frm.Show();
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                return;

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                !txtDescuento.Text.Contains(",") &&
                !txtDescuento.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value.Date;

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
                dtpFechaFin.Value = dtpFechaInicio.Value.Date;
        }

        private void cmbUnidadDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUnidadDescuento.Text == "%" &&
                IntentarConvertirDescuento(txtDescuento.Text, out decimal descuento) &&
                descuento > 100)
            {
                txtDescuento.Clear();
                MessageBox.Show("El porcentaje debe estar entre 0 y 100.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescuento.Focus();
            }
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcion.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTipoPromocion.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipoPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUnidadDescuento.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipoPromocion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescuento.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbUnidadDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTipoCliente.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
