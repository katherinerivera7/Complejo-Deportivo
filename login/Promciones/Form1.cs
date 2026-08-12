using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarPromocion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre de la promoción.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescripcion.Focus();
                return;
            }

            if (cmbTipoPromocion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de promoción.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbTipoPromocion.Focus();
                return;
            }

            decimal descuento;

            if (!decimal.TryParse(txtDescuento.Text, out descuento))
            {
                MessageBox.Show("Ingrese un descuento válido.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescuento.Focus();
                return;
            }

            if (descuento < 0)
            {
                MessageBox.Show("El descuento no puede ser negativo.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescuento.Focus();
                return;
            }

            if (cmbTipoCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de cliente.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbTipoCliente.Focus();
                return;
            }

            if (cmbAplicarA.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione a qué se aplicará la promoción.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbAplicarA.Focus();
                return;
            }

            if (cmbServicio.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el servicio incluido.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbServicio.Focus();
                return;
            }

            if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de finalización no puede ser anterior a la fecha de inicio.",
                    "Fecha incorrecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el estado de la promoción.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEstado.Focus();
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionString))
                {
                    string consulta = @"
                        INSERT INTO Promociones
                        (
                            Nombre,
                            Descripcion,
                            TipoPromocion,
                            Descuento,
                            TipoCliente,
                            AplicarA,
                            ServicioIncluido,
                            FechaInicio,
                            FechaFin,
                            Condiciones,
                            Estado
                        )
                        VALUES
                        (
                            @Nombre,
                            @Descripcion,
                            @TipoPromocion,
                            @Descuento,
                            @TipoCliente,
                            @AplicarA,
                            @ServicioIncluido,
                            @FechaInicio,
                            @FechaFin,
                            @Condiciones,
                            @Estado
                        )";

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                        cmd.Parameters.AddWithValue("@TipoPromocion", cmbTipoPromocion.Text);
                        cmd.Parameters.AddWithValue("@Descuento", descuento);
                        cmd.Parameters.AddWithValue("@TipoCliente", cmbTipoCliente.Text);
                        cmd.Parameters.AddWithValue("@AplicarA", cmbAplicarA.Text);
                        cmd.Parameters.AddWithValue("@ServicioIncluido", cmbServicio.Text);
                        cmd.Parameters.AddWithValue("@FechaInicio", dtpFechaInicio.Value.Date);
                        cmd.Parameters.AddWithValue("@FechaFin", dtpFechaFin.Value.Date);

                        cmd.Parameters.AddWithValue("@Condiciones",
                            string.IsNullOrWhiteSpace(txtCondiciones.Text)
                            ? (object)DBNull.Value
                            : txtCondiciones.Text.Trim());

                        bool estado = cmbEstado.Text == "Activa";
                        cmd.Parameters.AddWithValue("@Estado", estado);

                        conexion.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Promoción registrada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar la promoción:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnCancelar.FocusedColor == Color.FromArgb(9, 128, 0))
            {
                pnlContenido.Controls.Clear();
                frmVerPromociones frm = new frmVerPromociones();

                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                pnlContenido.Controls.Clear();
                pnlContenido.Controls.Add(frm);
                pnlContenido.Tag = frm;

                frm.Show();
            }
            else
            {
                pnlContenido.Controls.Clear();
                frmMenuPromociones frm = new frmMenuPromociones();

                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                pnlContenido.Controls.Clear();
                pnlContenido.Controls.Add(frm);
                pnlContenido.Tag = frm;

                frm.Show();
            }
        }
    }
}
