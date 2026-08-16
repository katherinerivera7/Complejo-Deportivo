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
    public partial class UCTarjetaProducto : UserControl
    {
        public int ProductoID { get; private set; }
        public int Stock { get; private set; }
        public decimal Precio { get; private set; }

        public event EventHandler ProductoAgregado;
        public UCTarjetaProducto()
        {
            InitializeComponent();
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            btnAnadir.Click += btnAnadir_Click;

        }
        public void CargarDatos(int productoID, string nombre, decimal precio, int stock, Image imagen)
        {
            ProductoID = productoID;
            Precio = precio;
            Stock = stock;

            lblNombre.Text = nombre;
            lblPrecio.Text = "$ " + precio.ToString("0.00");
            pbImagen.Image = imagen;

            btnAnadir.Enabled = stock > 0;
            btnAnadir.Text = stock > 0 ? "Añadir" : "Sin stock";
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            ProductoAgregado?.Invoke(this, EventArgs.Empty);
        }
    }
}
