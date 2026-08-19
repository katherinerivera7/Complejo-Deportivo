using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmRegistroVenta : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        private string categoriaSeleccionada = "Todos";

        public frmRegistroVenta()
        {
            InitializeComponent();
            frmProductos.ProductoGuardado += CargarProductos;
            
        }

        private void frmRegistroVenta_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            flpProductos.SuspendLayout();

            while (flpProductos.Controls.Count > 0)
            {
                Control control = flpProductos.Controls[0];
                flpProductos.Controls.Remove(control);
                control.Dispose();
            }

            try
            {
                string consulta = @"SELECT P.ProductoID, P.Nombre, P.Precio, P.Stock, P.Imagen, C.Nombre AS Categoria
                                    FROM Productos P
                                    INNER JOIN Categorias C ON P.CategoriaID = C.CategoriaID
                                    ORDER BY P.Nombre";

                DataTable productos = oCon.retornaRegistros(consulta);

                foreach (DataRow fila in productos.Rows)
                {
                    int productoID = Convert.ToInt32(fila["ProductoID"]);
                    string nombre = fila["Nombre"].ToString();
                    decimal precio = Convert.ToDecimal(fila["Precio"]);
                    int stock = Convert.ToInt32(fila["Stock"]);
                    string categoria = fila["Categoria"].ToString();
                    Image imagen = ConvertirBytesAImagen(fila["Imagen"]);

                    UCTarjetaProducto tarjeta = new UCTarjetaProducto();
                    tarjeta.CargarDatos(productoID, nombre, precio, stock, categoria, imagen);
                    tarjeta.ProductoAgregado += tarjeta_ProductoAgregado;

                   flpProductos.Controls.Add(tarjeta);
                }

                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                flpProductos.ResumeLayout();
            }
        }

        private Image ConvertirBytesAImagen(object valorImagen)
        {
            if (valorImagen == null || valorImagen == DBNull.Value)
                return null;

            byte[] bytesImagen = (byte[])valorImagen;

            using (MemoryStream memoria = new MemoryStream(bytesImagen))
            using (Image imagenTemporal = Image.FromStream(memoria))
            {
                return new Bitmap(imagenTemporal);
            }
        }

        private void AplicarFiltros()
        {
            string texto = Filtro.Text.Trim();

            foreach (Control control in flpProductos.Controls)
            {
                if (control is UCTarjetaProducto tarjeta)
                {
                    bool coincideNombre = string.IsNullOrEmpty(texto) ||
                                          tarjeta.NombreProducto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0;

                    bool coincideCategoria = categoriaSeleccionada == "Todos" ||
                                             string.Equals(tarjeta.Categoria, categoriaSeleccionada, StringComparison.OrdinalIgnoreCase);

                    tarjeta.Visible = coincideNombre && coincideCategoria;
                }
            }
        }

        private void Filtro_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Todos";
            AplicarFiltros();
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Bebidas";
            AplicarFiltros();
        }

        private void btnComidas_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Comidas";
            AplicarFiltros();
        }

        private void btnSnacks_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Snacks";
            AplicarFiltros();
        }

        private void btnDulces_Click(object sender, EventArgs e)
        {
            categoriaSeleccionada = "Dulces";
            AplicarFiltros();
        }

        private void tarjeta_ProductoAgregado(object sender, EventArgs e)
        {

            if (sender is UCTarjetaProducto tarjeta)
            {
                AgregarProductoAVenta(tarjeta);
            }
        }


        private void AgregarProductoAVenta(UCTarjetaProducto producto)
        {

            // BUSCAR SI EL PRODUCTO YA ESTÁ EN LA VENTA
            foreach (Control control in flpProduct.Controls)
            {
                if (control is Panel tarjetaExistente &&
                    Convert.ToInt32(tarjetaExistente.Tag) == producto.ProductoID)
                {
                    Label lblCantidadExistente =
                        tarjetaExistente.Controls["lblCantidad"] as Label;

                    if (lblCantidadExistente != null)
                    {
                        int cantidad = Convert.ToInt32(lblCantidadExistente.Text);

                        if (cantidad < producto.Stock)
                        {
                            cantidad++;
                            lblCantidadExistente.Text = cantidad.ToString();

                            ActualizarSubtotal(tarjetaExistente);
                        }
                    }

                    return;
                }
            }

            // SI NO EXISTE, CREAR UNA NUEVA TARJETA
            Panel tarjetaVenta = new Panel();

            tarjetaVenta.Width = -25;
            tarjetaVenta.Height = 110;
            tarjetaVenta.Margin = new Padding(5);
            tarjetaVenta.BorderStyle = BorderStyle.FixedSingle;

            tarjetaVenta.Tag = producto.ProductoID;

            // NOMBRE
            Label lblNombre = new Label();
            lblNombre.Text = producto.NombreProducto;
            lblNombre.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(10, 10);

            // PRECIO
            Label lblPrecio = new Label();
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Text = producto.Precio.ToString("0.00");
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(10, 40);

            // SUBTOTAL
            Label lblSubtotal = new Label();
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Text = "$ " + producto.Precio.ToString("0.00");
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(40, 65);

            // BOTÓN MENOS
            Button btnMenos = new Button();
            btnMenos.Text = "-";
            btnMenos.Size = new Size(30, 30);
            btnMenos.Location = new Point(150, 35);

            // CANTIDAD
            Label lblCantidad = new Label();
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Text = "1";
            lblCantidad.AutoSize = false;
            lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
            lblCantidad.Size = new Size(30, 30);
            lblCantidad.Location = new Point(185, 35);


            // BOTÓN MÁS
            Button btnMas = new Button();
            btnMas.Text = "+";
            btnMas.Size = new Size(30, 30);
            btnMas.Location = new Point(220, 35);

            // EVENTO +
            btnMas.Click += (sender, e) =>
            {
                int cantidad = Convert.ToInt32(lblCantidad.Text);

                if (cantidad < producto.Stock)
                {
                    cantidad++;
                    lblCantidad.Text = cantidad.ToString();

                    ActualizarSubtotal(tarjetaVenta);
                }
            };

            // EVENTO -
            btnMenos.Click += (sender, e) =>
            {
                int cantidad = Convert.ToInt32(lblCantidad.Text);

                if (cantidad > 1)
                {
                    cantidad--;
                    lblCantidad.Text = cantidad.ToString();

                    ActualizarSubtotal(tarjetaVenta);
                }
            };

            tarjetaVenta.Controls.Add(lblNombre);
            tarjetaVenta.Controls.Add(lblPrecio);
            tarjetaVenta.Controls.Add(lblSubtotal);
            tarjetaVenta.Controls.Add(btnMenos);
            tarjetaVenta.Controls.Add(lblCantidad);
            tarjetaVenta.Controls.Add(btnMas);

            // AGREGAR LA TARJETA AL PANEL
            flpProduct.Controls.Add(tarjetaVenta);
        

        }
        private void ActualizarSubtotal(Panel tarjeta)
        {
            Label lblPrecio = tarjeta.Controls["lblPrecio"] as Label;
            Label lblCantidad = tarjeta.Controls["lblCantidad"] as Label;
            Label lblSubtotal = tarjeta.Controls["lblSubtotal"] as Label;

            if (lblPrecio == null || lblCantidad == null || lblSubtotal == null)
                return;

            decimal precio = Convert.ToDecimal(lblPrecio.Text);
            int cantidad = Convert.ToInt32(lblCantidad.Text);

            decimal subtotal = precio * cantidad;

            lblSubtotal.Text = "$ " + subtotal.ToString("0.00");
        
        }

        private void frmRegistroVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProductos.ProductoGuardado -= CargarProductos;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlProductos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}