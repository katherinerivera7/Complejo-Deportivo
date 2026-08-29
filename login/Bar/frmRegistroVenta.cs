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
            UCVentasBar tarjetaVenta = new UCVentasBar();

            tarjetaVenta.CargarProducto(
                producto.ProductoID,
                producto.NombreProducto,
                producto.Precio
            );

            tarjetaVenta.ProductoEliminado += TarjetaVenta_ProductoEliminado;
            flpProduct.Controls.Add(tarjetaVenta);
            flpProduct.AutoScroll = true;
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
        private void TarjetaVenta_ProductoEliminado(object sender, EventArgs e)
        {
            if (sender is UCVentasBar tarjeta)
            {
                flpProduct.Controls.Remove(tarjeta);
                tarjeta.Dispose();
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void flpProduct_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
              DialogResult respuesta = MessageBox.Show(
             "¿Está seguro de cancelar la venta?",
              "Cancelar venta",
                MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
           );

            if (respuesta == DialogResult.Yes)
            {
                flpProduct.Controls.Clear();
            }
        }
    }
}