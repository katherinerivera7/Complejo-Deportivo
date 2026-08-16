using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace login.Bar
{
    public partial class frmRegistroVenta : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        public frmRegistroVenta()
        {
            InitializeComponent();
            frmProductos.ProductoGuardado += CargarProductos;
            FormClosed += frmRegistroVenta_FormClosed;
        }
        private void CargarProductos()
        {
            flpProductos.Controls.Clear();

            DataTable tabla = oCon.retornaRegistros(
                "SELECT ProductoID, Nombre, Precio, Stock, Imagen FROM Productos ORDER BY ProductoID DESC"
            );

            foreach (DataRow fila in tabla.Rows)
            {
                int productoID = Convert.ToInt32(fila["ProductoID"]);
                string nombre = fila["Nombre"].ToString();
                decimal precio = Convert.ToDecimal(fila["Precio"]);
                int stock = Convert.ToInt32(fila["Stock"]);
                Image imagen = ConvertirBytesAImagen(fila["Imagen"]);

                UCTarjetaProducto tarjeta = new UCTarjetaProducto();
                tarjeta.CargarDatos(productoID, nombre, precio, stock, imagen);
                tarjeta.ProductoAgregado += tarjeta_ProductoAgregado;

                flpProductos.Controls.Add(tarjeta);
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
        private void tarjeta_ProductoAgregado(object sender, EventArgs e)
        {
            UCTarjetaProducto tarjeta = sender as UCTarjetaProducto;

            if (tarjeta == null)
                return;

            MessageBox.Show("Producto seleccionado. ID: " + tarjeta.ProductoID);
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

        private void frmRegistroVenta_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void frmRegistroVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProductos.ProductoGuardado -= CargarProductos;
        }
    }
}
