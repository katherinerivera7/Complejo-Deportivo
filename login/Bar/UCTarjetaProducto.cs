using System;
using System.Drawing;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class UCTarjetaProducto : UserControl
    {
        public int ProductoID { get; private set; }
        public string NombreProducto { get; private set; }
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }
        public string Categoria { get; private set; }

        public event EventHandler ProductoAgregado;

        public UCTarjetaProducto()
        {
            InitializeComponent();

            Dock = DockStyle.None;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Size = new Size(180, 290);
            MinimumSize = new Size(180, 276);
            AutoSize = false;
            Margin = new Padding(4);

            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;

            btnAnadir.Click -= btnAnadir_Click;
            btnAnadir.Click += btnAnadir_Click;
        }

        public void CargarDatos(int productoID, string nombre, decimal precio, int stock, string categoria, Image imagen)
        {
            ProductoID = productoID;
            NombreProducto = nombre;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;

            lblNombre.Text = nombre;
            lblPrecio.Text = "$ " + precio.ToString("0.00");

            pbImagen.Image?.Dispose();
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