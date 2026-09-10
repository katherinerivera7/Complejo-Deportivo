using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login.Bar
{
    public partial class frmFacturaVenta : Form
    {
        private List<DetalleVenta> detallesVenta;
        private frmRegistroVenta formularioVenta;
        private csConectaSQL oCon = new csConectaSQL();

        private decimal porcentajeIVA = 15;
        private int clienteID = 0;
        private bool compraFinalizada = false;

        public frmFacturaVenta()
        {
            InitializeComponent();

            detallesVenta = new List<DetalleVenta>();

            ConfigurarEventos();

            txtNumerodeFactura.ReadOnly = true;
            txtNumerodeFactura.Text = "Pendiente";
        }

        public frmFacturaVenta(List<DetalleVenta> detalles, frmRegistroVenta venta)
        {
            InitializeComponent();

            detallesVenta = detalles;
            formularioVenta = venta;

            ConfigurarEventos();

            txtNumerodeFactura.ReadOnly = true;
            txtNumerodeFactura.Text = "Pendiente";

            CargarDetalleFactura();
        }

        private void ConfigurarEventos()
        {
            txtCedula.TextChanged -= txtCedula_TextChanged;
            txtCedula.TextChanged += txtCedula_TextChanged;

            txtDescuento.TextChanged -= txtDescuento_TextChanged;
            txtDescuento.TextChanged += txtDescuento_TextChanged;
        }

        private void frmFacturaVenta_Load(object sender, EventArgs e)
        {
            CargarDetalleFactura();
        }

        private void CargarDetalleFactura()
        {
            dgvDetalleFactura.Rows.Clear();

            decimal porcentajeDescuento = 0;

            if (!string.IsNullOrWhiteSpace(txtDescuento.Text))
            {
                decimal.TryParse(txtDescuento.Text, out porcentajeDescuento);
            }

            decimal subtotalFactura = 0;
            decimal descuentoFactura = 0;
            decimal ivaFactura = 0;
            decimal totalFactura = 0;

            if (detallesVenta != null)
            {
                foreach (DetalleVenta detalle in detallesVenta)
                {
                    decimal subtotal = detalle.Cantidad * detalle.PrecioUnitario;

                    decimal descuento =
                        subtotal * porcentajeDescuento / 100;

                    decimal subtotalConDescuento =
                        subtotal - descuento;

                    decimal iva =
                        subtotalConDescuento * porcentajeIVA / 100;

                    decimal total =
                        subtotalConDescuento + iva;

                    dgvDetalleFactura.Rows.Add(
                        detalle.Producto,
                        detalle.Cantidad,
                        "$ " + detalle.PrecioUnitario.ToString("0.00"),
                        "$ " + descuento.ToString("0.00"),
                        "$ " + iva.ToString("0.00"),
                        "$ " + subtotal.ToString("0.00"),
                        "$ " + total.ToString("0.00")
                    );

                    subtotalFactura += subtotal;
                    descuentoFactura += descuento;
                    ivaFactura += iva;
                    totalFactura += total;
                }
            }

            lblSubtotal.Text = "$" + subtotalFactura.ToString("0.00");
            lblDescuento.Text = "$" + descuentoFactura.ToString("0.00");
            lblIva.Text = "$" + ivaFactura.ToString("0.00");
            lblTotal.Text = "$" + totalFactura.ToString("0.00");
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (compraFinalizada)
                return;

            if (string.IsNullOrWhiteSpace(txtDescuento.Text))
            {
                CargarDetalleFactura();
                return;
            }

            decimal descuento;

            if (!decimal.TryParse(txtDescuento.Text, out descuento))
                return;

            if (descuento < 0 || descuento > 100)
            {
                MessageBox.Show(
                    "El descuento debe estar entre 0 y 100.",
                    "Descuento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDescuento.Text = "0";
                txtDescuento.SelectionStart = txtDescuento.Text.Length;
                return;
            }

            CargarDetalleFactura();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            if (compraFinalizada)
                return;

            BuscarCliente();
        }

        private void BuscarCliente()
        {
            string cedula = txtCedula.Text.Trim();

            clienteID = 0;

            if (string.IsNullOrWhiteSpace(cedula))
            {
                LimpiarCliente();
                return;
            }

            if (cedula.Length < 10)
            {
                LimpiarCliente();
                return;
            }

            try
            {
                string cedulaSegura = cedula.Replace("'", "''");

                string consulta =
                    "SELECT TOP 1 ClienteID, Cedula, Nombre, Apellido, Correo, Telefono, Ciudad, Direccion " +
                    "FROM Clientes " +
                    "WHERE CAST(Cedula AS VARCHAR(20)) = '" + cedulaSegura + "'";

                DataTable dtCliente = oCon.retornaRegistros(consulta);

                if (dtCliente.Rows.Count > 0)
                {
                    DataRow fila = dtCliente.Rows[0];

                    clienteID = Convert.ToInt32(fila["ClienteID"]);

                    txtCliente.Text =
                        fila["Nombre"].ToString() + " " +
                        fila["Apellido"].ToString();

                    txtCorreo.Text = fila["Correo"].ToString();
                    txtTelefono.Text = fila["Telefono"].ToString();
                    txtCiudad.Text = fila["Ciudad"].ToString();
                    txtDireccion.Text = fila["Direccion"].ToString();
                }
                else
                {
                    LimpiarCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar el cliente:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LimpiarCliente()
        {
            clienteID = 0;

            txtCliente.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Control pnlContenido = this.Parent;

            if (pnlContenido == null)
                return;

            pnlContenido.Controls.Clear();

            if (!compraFinalizada &&
                formularioVenta != null &&
                !formularioVenta.IsDisposed)
            {
                formularioVenta.TopLevel = false;
                formularioVenta.FormBorderStyle = FormBorderStyle.None;
                formularioVenta.Dock = DockStyle.Fill;

                pnlContenido.Controls.Add(formularioVenta);
                pnlContenido.Tag = formularioVenta;

                formularioVenta.Show();
            }
            else
            {
                frmRegistroVenta nuevaVenta = new frmRegistroVenta();

                nuevaVenta.TopLevel = false;
                nuevaVenta.FormBorderStyle = FormBorderStyle.None;
                nuevaVenta.Dock = DockStyle.Fill;

                pnlContenido.Controls.Add(nuevaVenta);
                pnlContenido.Tag = nuevaVenta;

                nuevaVenta.Show();
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (compraFinalizada)
            {
                MessageBox.Show(
                    "Esta compra ya fue finalizada.",
                    "Factura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            if (clienteID == 0)
            {
                MessageBox.Show(
                    "Debe ingresar la cédula de un cliente registrado.",
                    "Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtCedula.Focus();
                return;
            }

            if (detallesVenta == null || detallesVenta.Count == 0)
            {
                MessageBox.Show(
                    "No hay productos agregados a la factura.",
                    "Factura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            decimal porcentajeDescuento = 0;

            if (!string.IsNullOrWhiteSpace(txtDescuento.Text))
            {
                if (!decimal.TryParse(
                    txtDescuento.Text,
                    out porcentajeDescuento))
                {
                    MessageBox.Show(
                        "Ingrese un descuento válido.",
                        "Descuento",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            if (porcentajeDescuento < 0 ||
                porcentajeDescuento > 100)
            {
                MessageBox.Show(
                    "El descuento debe estar entre 0 y 100.",
                    "Descuento",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de finalizar la compra?",
                "Finalizar compra",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                GuardarFactura();
            }
        }

        private void GuardarFactura()
        {
            decimal porcentajeDescuento = 0;

            decimal.TryParse(
                txtDescuento.Text,
                out porcentajeDescuento
            );

            decimal subtotalFactura = 0;
            decimal descuentoFactura = 0;
            decimal ivaFactura = 0;
            decimal totalFactura = 0;

            foreach (DetalleVenta detalle in detallesVenta)
            {
                decimal subtotal =
                    detalle.Cantidad *
                    detalle.PrecioUnitario;

                decimal descuento =
                    subtotal *
                    porcentajeDescuento / 100;

                decimal subtotalConDescuento =
                    subtotal - descuento;

                decimal iva =
                    subtotalConDescuento *
                    porcentajeIVA / 100;

                decimal total =
                    subtotalConDescuento + iva;

                subtotalFactura += subtotal;
                descuentoFactura += descuento;
                ivaFactura += iva;
                totalFactura += total;
            }

            SqlTransaction transaccion = null;

            try
            {
                oCon.abrirConexion();

                transaccion =
                    oCon.oCon.BeginTransaction();

                string consultaFactura = @"
                    INSERT INTO FacturasVenta
                    (
                        ClienteID,
                        Fecha,
                        Subtotal,
                        PorcentajeDescuento,
                        Descuento,
                        IVA,
                        Total,
                        Estado
                    )
                    OUTPUT INSERTED.FacturaID
                    VALUES
                    (
                        @ClienteID,
                        GETDATE(),
                        @Subtotal,
                        @PorcentajeDescuento,
                        @Descuento,
                        @IVA,
                        @Total,
                        'Finalizada'
                    )";

                int facturaID;

                using (SqlCommand cmdFactura =
                    new SqlCommand(
                        consultaFactura,
                        oCon.oCon,
                        transaccion))
                {
                    cmdFactura.Parameters.AddWithValue(
                        "@ClienteID",
                        clienteID
                    );

                    cmdFactura.Parameters.AddWithValue(
                        "@Subtotal",
                        subtotalFactura
                    );

                    cmdFactura.Parameters.AddWithValue(
                        "@PorcentajeDescuento",
                        porcentajeDescuento
                    );

                    cmdFactura.Parameters.AddWithValue(
                        "@Descuento",
                        descuentoFactura
                    );

                    cmdFactura.Parameters.AddWithValue(
                        "@IVA",
                        ivaFactura
                    );

                    cmdFactura.Parameters.AddWithValue(
                        "@Total",
                        totalFactura
                    );

                    facturaID =
                        Convert.ToInt32(
                            cmdFactura.ExecuteScalar()
                        );
                }

                string numeroFactura =
                    "FAC-V" +
                    facturaID.ToString("D4");

                string consultaNumero = @"
                    UPDATE FacturasVenta
                    SET NumeroFactura = @NumeroFactura
                    WHERE FacturaID = @FacturaID";

                using (SqlCommand cmdNumero =
                    new SqlCommand(
                        consultaNumero,
                        oCon.oCon,
                        transaccion))
                {
                    cmdNumero.Parameters.AddWithValue(
                        "@NumeroFactura",
                        numeroFactura
                    );

                    cmdNumero.Parameters.AddWithValue(
                        "@FacturaID",
                        facturaID
                    );

                    cmdNumero.ExecuteNonQuery();
                }

                foreach (DetalleVenta detalle in detallesVenta)
                {
                    decimal subtotal =
                        detalle.Cantidad *
                        detalle.PrecioUnitario;

                    decimal descuento =
                        subtotal *
                        porcentajeDescuento / 100;

                    decimal subtotalConDescuento =
                        subtotal - descuento;

                    decimal iva =
                        subtotalConDescuento *
                        porcentajeIVA / 100;

                    decimal total =
                        subtotalConDescuento + iva;

                    string consultaStock = @"
                        UPDATE Productos
                        SET Stock = Stock - @Cantidad
                        WHERE ProductoID = @ProductoID
                        AND Stock >= @Cantidad";

                    using (SqlCommand cmdStock =
                        new SqlCommand(
                            consultaStock,
                            oCon.oCon,
                            transaccion))
                    {
                        cmdStock.Parameters.AddWithValue(
                            "@Cantidad",
                            detalle.Cantidad
                        );

                        cmdStock.Parameters.AddWithValue(
                            "@ProductoID",
                            detalle.ProductoID
                        );

                        int resultadoStock =
                            cmdStock.ExecuteNonQuery();

                        if (resultadoStock == 0)
                        {
                            throw new Exception(
                                "No hay stock suficiente para el producto " +
                                detalle.Producto + "."
                            );
                        }
                    }

                    string consultaDetalle = @"
                        INSERT INTO DetalleFacturaVenta
                        (
                            FacturaID,
                            ProductoID,
                            Cantidad,
                            PrecioUnitario,
                            Descuento,
                            IVA,
                            Subtotal,
                            Total
                        )
                        VALUES
                        (
                            @FacturaID,
                            @ProductoID,
                            @Cantidad,
                            @PrecioUnitario,
                            @Descuento,
                            @IVA,
                            @Subtotal,
                            @Total
                        )";

                    using (SqlCommand cmdDetalle =
                        new SqlCommand(
                            consultaDetalle,
                            oCon.oCon,
                            transaccion))
                    {
                        cmdDetalle.Parameters.AddWithValue(
                            "@FacturaID",
                            facturaID
                        );

                        cmdDetalle.Parameters.AddWithValue(
                            "@ProductoID",
                            detalle.ProductoID
                        );

                        cmdDetalle.Parameters.AddWithValue(
                            "@Cantidad",
                            detalle.Cantidad
                        );

                        cmdDetalle.Parameters.AddWithValue(
                            "@PrecioUnitario",
                            detalle.PrecioUnitario
                        );

                        cmdDetalle.Parameters.AddWithValue(
                            "@Descuento",
                            descuento
                        );

                        cmdDetalle.Parameters.AddWithValue(
                            "@IVA",
                            iva
                        );

                        cmdDetalle.Parameters.AddWithValue(
                            "@Subtotal",
                            subtotal
                        );

                        cmdDetalle.Parameters.AddWithValue(
                            "@Total",
                            total
                        );

                        cmdDetalle.ExecuteNonQuery();
                    }
                }

                transaccion.Commit();

                compraFinalizada = true;

                txtNumerodeFactura.Text =
                    numeroFactura;

                txtCedula.ReadOnly = true;
                txtDescuento.ReadOnly = true;
                txtCliente.ReadOnly = true;
                txtCorreo.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtCiudad.ReadOnly = true;

                if (formularioVenta != null &&
                    !formularioVenta.IsDisposed)
                {
                    formularioVenta.LiberarVenta();
                    formularioVenta = null;
                }

                MessageBox.Show(
                    "Compra finalizada correctamente.\n\n" +
                    "Factura: " +
                    numeroFactura +
                    "\nTotal: $" +
                    totalFactura.ToString("0.00"),
                    "Venta realizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                {
                    try
                    {
                        transaccion.Rollback();
                    }
                    catch
                    {
                    }
                }

                MessageBox.Show(
                    "Error al finalizar la compra:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                try
                {
                    oCon.cerrarConexion();
                }
                catch
                {
                }
            }
        }
    }
}