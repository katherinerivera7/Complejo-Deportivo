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
    public partial class UCVentasBar : UserControl
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        private int cantidad = 1;
        public UCVentasBar()
        {
            InitializeComponent();
        }

        public void CargarProducto(int id, string nombre, decimal precio)
        {
            ProductoID = id;
            NombreProducto = nombre;
            Precio = precio;

            lblNombre.Text = nombre;
            lblPrecio.Text = "$ " + precio.ToString("0.00");

            ActualizarSubtotal();
        }


        private void ActualizarSubtotal()
        {
            lblCantidad.Text = cantidad.ToString();

            decimal subtotal = Precio * cantidad;

            lblSubtotal.Text = "$ " + subtotal.ToString("0.00");
        }
        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void UCVentasBar_Load(object sender, EventArgs e)
        {

        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            cantidad++;
            ActualizarSubtotal();
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (cantidad > 1)
            {
                cantidad--;
                ActualizarSubtotal();
            }
        }
    }
}
