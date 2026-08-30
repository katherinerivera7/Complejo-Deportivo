using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmRegistrarMovimiento : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        public frmRegistrarMovimiento()
        {
            InitializeComponent();
        }

        private void txtOtro_TextChanged(object sender, EventArgs e)
        {
            txtOtro.Visible = cmbMotivo.Text == "Otro";

            if (!txtOtro.Visible)
                txtOtro.Clear();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            if (cmbTipoMovimiento.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de movimiento.");
                return;
            }

            if (cmbMotivo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el motivo.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            string motivo = cmbMotivo.Text;

            if (cmbMotivo.Text == "Otro")
            {
                if (string.IsNullOrWhiteSpace(txtOtro.Text))
                {
                    MessageBox.Show("Ingrese el motivo del movimiento.");
                    return;
                }

                motivo = txtOtro.Text.Trim();
            }

            int productoID = Convert.ToInt32(cmbProducto.SelectedValue);
            string tipoMovimiento = cmbTipoMovimiento.Text;
            int usuarioID = csSesionUsuario.UsuarioID;

            if (oCon.registrarMovimientoInventario(productoID, usuarioID, tipoMovimiento, cantidad, motivo))
            {
                MessageBox.Show("Movimiento registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        

        private void cmbMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOtro.Visible = cmbMotivo.Text == "Otro";

            if (!txtOtro.Visible)
                txtOtro.Clear();
        }

        private void cmbTipoMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMotivo.Items.Clear();

            if (cmbTipoMovimiento.Text == "Entrada")
            {
                cmbMotivo.Items.Add("Compra de productos");
                cmbMotivo.Items.Add("Devolución");
                cmbMotivo.Items.Add("Ajuste de inventario");
                cmbMotivo.Items.Add("Otro");
            }
            else if (cmbTipoMovimiento.Text == "Salida")
            {
                cmbMotivo.Items.Add("Producto dañado");
                cmbMotivo.Items.Add("Producto vencido");
                cmbMotivo.Items.Add("Pérdida");
                cmbMotivo.Items.Add("Consumo interno");
                cmbMotivo.Items.Add("Ajuste de inventario");
                cmbMotivo.Items.Add("Otro");
            }

            cmbMotivo.SelectedIndex = -1;
        }

        private void frmRegistrarMovimiento_Load(object sender, EventArgs e)
        {
            CargarProductos();

            cmbTipoMovimiento.Items.Clear();
            cmbTipoMovimiento.Items.Add("Entrada");
            cmbTipoMovimiento.Items.Add("Salida");
            cmbTipoMovimiento.SelectedIndex = -1;

            txtOtro.Visible = false;
        }
        private void CargarProductos()
        {
            DataTable tabla = oCon.retornaRegistros("SELECT ProductoID, Nombre FROM Productos ORDER BY Nombre");

            cmbProducto.DataSource = tabla;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "ProductoID";
            cmbProducto.SelectedIndex = -1;
        }

        private void cmbProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTipoMovimiento.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbTipoMovimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbMotivo.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOtro.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtOtro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCantidad.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
