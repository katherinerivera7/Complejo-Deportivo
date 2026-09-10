using System;

namespace login.Bar
{
    public class DetalleVenta
    {
        public int ProductoID { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}