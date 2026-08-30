using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmProductos : Form
    {
        csConectaSQL oCon = new csConectaSQL();

        int tipo = 1;
        int productoID = 0;
        private byte[] imagenProducto = null;

        public static event Action ProductoGuardado;

        public frmProductos()
        {
            InitializeComponent();
        }

        public frmProductos(int id)
        {
            InitializeComponent();
            productoID = id;
            tipo = 2;
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            pbImagen.SizeMode = PictureBoxSizeMode.Zoom;

            if (tipo == 2)
            {
                CargarProducto();
                lblCrearProducto.Text = "Editar producto";
                btnCrear.Text = "Guardar cambios";
            }
        }

        private void CargarCategorias()
        {
            DataTable tabla = oCon.retornaRegistros(
                "SELECT CategoriaID, Nombre FROM Categorias ORDER BY Nombre");

            cmbCategoria.DataSource = tabla;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "CategoriaID";
            cmbCategoria.SelectedIndex = -1;
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrir = new OpenFileDialog())
            {
                abrir.Title = "Seleccionar imagen del producto";
                abrir.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (abrir.ShowDialog() == DialogResult.OK)
                {
                    imagenProducto = File.ReadAllBytes(abrir.FileName);

                    using (MemoryStream ms = new MemoryStream(imagenProducto))
                    using (Image imagenTemporal = Image.FromStream(ms))
                    {
                        pbImagen.Image?.Dispose();
                        pbImagen.Image = new Bitmap(imagenTemporal);
                    }

                    pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                return;
            }

            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.");
                return;
            }

            int categoriaID = Convert.ToInt32(cmbCategoria.SelectedValue);
            string nombre = txtNombre.Text.Trim();

            if (tipo == 1)
            {
                if (oCon.insertarProducto(categoriaID, nombre, precio, imagenProducto))
                {
                    MessageBox.Show(
                        "Producto registrado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ProductoGuardado?.Invoke();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                if (oCon.actualizarProducto(
                    productoID,
                    categoriaID,
                    nombre,
                    precio,
                    imagenProducto))
                {
                    MessageBox.Show(
                        "Producto actualizado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ProductoGuardado?.Invoke();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void CargarProducto()
        {
            DataTable tabla = oCon.retornaRegistros(
                "SELECT CategoriaID, Nombre, Precio, Imagen " +
                "FROM Productos WHERE ProductoID = " + productoID);

            if (tabla.Rows.Count == 0)
                return;

            DataRow fila = tabla.Rows[0];

            cmbCategoria.SelectedValue = Convert.ToInt32(fila["CategoriaID"]);
            txtNombre.Text = fila["Nombre"].ToString();
            txtPrecio.Text = Convert.ToDecimal(fila["Precio"]).ToString("0.##");

            if (fila["Imagen"] != DBNull.Value)
            {
                imagenProducto = (byte[])fila["Imagen"];

                using (MemoryStream ms = new MemoryStream(imagenProducto))
                using (Image imagenTemporal = Image.FromStream(ms))
                {
                    pbImagen.Image?.Dispose();
                    pbImagen.Image = new Bitmap(imagenTemporal);
                }
            }
            else
            {
                imagenProducto = null;
                pbImagen.Image = null;
            }
        }
    }
}