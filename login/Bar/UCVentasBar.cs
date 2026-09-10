using System;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class UCVentasBar : UserControl
    {
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        private int cantidad = 1;

        public int Cantidad
        {
            get { return cantidad; }
        }

        public event EventHandler ProductoEliminado;

        public UCVentasBar()
        {
            InitializeComponent();
        }

        public void CargarProducto(int id, string nombre, decimal precio)
        {
            ProductoID = id;
            NombreProducto = nombre;
            Precio = precio;
            cantidad = 1;

            lblNombre.Text = nombre;
            lblPrecio.Text = "$ " + precio.ToString("0.00");

            ActualizarSubtotal();
        }

        public void AumentarCantidad()
        {
            cantidad++;
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

        private void lblPrecio_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar este producto de la venta?",
                "Eliminar producto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                ProductoEliminado?.Invoke(this, EventArgs.Empty);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            cantidad++;
            ActualizarSubtotal();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (cantidad > 1)
            {
                cantidad--;
                ActualizarSubtotal();
            }
        }
    }
}