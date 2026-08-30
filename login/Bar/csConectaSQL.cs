using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace login
{
    class csConectaSQL
    {
        public SqlConnection oCon;
        SqlCommand oCom;
        SqlDataAdapter oDA;
        DataTable oDT;

        string Server;
        string Database;
        string Usuario;
        string Clave;
        string Cadena;

        public csConectaSQL()
        {
            Server = @"  DESKTOP-OSJ26G2\SQLEXPRESS01"; //LAPTOP-J5U2QS20\SQLEXPRESS01         DESKTOP-OSJ26G2\SQLEXPRESS01
            Database = "ComplejoDeportivo";
            Usuario = "sa"; // Basados
            Clave = "1234567";  //Basados888
        }

        public bool abrirConexion()
        {
            oCon = new SqlConnection();

            try
            {
                Cadena =
                    "Server=" + Server +
                    ";Database=" + Database +
                    ";Integrated Security=True;" +
                    "TrustServerCertificate=True;";

                oCon.ConnectionString = Cadena;
                oCon.Open();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool cerrarConexion()
        {
            try
            {
                if (oCon != null &&
                    oCon.State == ConnectionState.Open)
                {
                    oCon.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable retornaRegistros(string sentencia)
        {
            oDT = new DataTable();

            try
            {
                if (sentencia.Length > 0 && abrirConexion())
                {
                    oCom = new SqlCommand(sentencia, oCon);
                    oDA = new SqlDataAdapter(oCom);

                    oDA.Fill(oDT);

                    cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();
            }

            return oDT;
        }

        public bool borrarDatos(string tabla, string condicion)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta =
                        "DELETE FROM " + tabla +
                        " WHERE " + condicion;

                    oCom = new SqlCommand(consulta, oCon);

                    oCom.ExecuteNonQuery();

                    cerrarConexion();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();

                return false;
            }
        }
        public bool insertarProducto(int categoriaID, string nombre, decimal precio, byte[] imagen)
        {
            try
            {
                if (!abrirConexion())
                    return false;

                string consulta = "INSERT INTO Productos " +
                                  "(CategoriaID, Nombre, Precio, Imagen) " +
                                  "VALUES (@CategoriaID, @Nombre, @Precio, @Imagen)";

                using (SqlCommand cmd = new SqlCommand(consulta, oCon))
                {
                    cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value =
                        (object)imagen ?? DBNull.Value;

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool actualizarProducto(int productoID, int categoriaID, string nombre, decimal precio, byte[] imagen)
        {
            try
            {
                if (!abrirConexion())
                    return false;

                string consulta = "UPDATE Productos SET " +
                                  "CategoriaID = @CategoriaID, " +
                                  "Nombre = @Nombre, " +
                                  "Precio = @Precio, " +
                                  "Imagen = @Imagen " +
                                  "WHERE ProductoID = @ProductoID";

                using (SqlCommand cmd = new SqlCommand(consulta, oCon))
                {
                    cmd.Parameters.AddWithValue("@ProductoID", productoID);
                    cmd.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.Add("@Imagen", SqlDbType.VarBinary).Value =
                        (object)imagen ?? DBNull.Value;

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                cerrarConexion();
            }
        }
        public bool insertarCategoria(string nombre)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta = "INSERT INTO Categorias (Nombre) VALUES (@Nombre)";
                    oCom = new SqlCommand(consulta, oCon);
                    oCom.Parameters.AddWithValue("@Nombre", nombre);
                    oCom.ExecuteNonQuery();
                    cerrarConexion();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();
                return false;
            }
        }

        public bool actualizarCategoria(int categoriaID, string nombre)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta = "UPDATE Categorias SET Nombre = @Nombre WHERE CategoriaID = @CategoriaID";
                    oCom = new SqlCommand(consulta, oCon);
                    oCom.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    oCom.Parameters.AddWithValue("@Nombre", nombre);
                    oCom.ExecuteNonQuery();
                    cerrarConexion();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();
                return false;
            }
        }
        public bool insertarCancha(string nombre, string tipo, decimal precioHora, string estado)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta = "INSERT INTO Canchas (Nombre, Tipo, PrecioHora, Estado) VALUES (@Nombre, @Tipo, @PrecioHora, @Estado)";
                    oCom = new SqlCommand(consulta, oCon);
                    oCom.Parameters.AddWithValue("@Nombre", nombre);
                    oCom.Parameters.AddWithValue("@Tipo", tipo);
                    oCom.Parameters.AddWithValue("@PrecioHora", precioHora);
                    oCom.Parameters.AddWithValue("@Estado", estado);
                    oCom.ExecuteNonQuery();
                    cerrarConexion();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();
                return false;
            }
        }

        public bool actualizarCancha(int canchaID, string nombre, string tipo, decimal precioHora, string estado)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta = "UPDATE Canchas SET Nombre = @Nombre, Tipo = @Tipo, PrecioHora = @PrecioHora, Estado = @Estado WHERE CanchaID = @CanchaID";
                    oCom = new SqlCommand(consulta, oCon);
                    oCom.Parameters.AddWithValue("@CanchaID", canchaID);
                    oCom.Parameters.AddWithValue("@Nombre", nombre);
                    oCom.Parameters.AddWithValue("@Tipo", tipo);
                    oCom.Parameters.AddWithValue("@PrecioHora", precioHora);
                    oCom.Parameters.AddWithValue("@Estado", estado);
                    oCom.ExecuteNonQuery();
                    cerrarConexion();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();
                return false;
            }
        }
        public bool registrarMovimientoInventario(int productoID, int usuarioID, string tipoMovimiento, int cantidad, string motivo)
        {
            SqlTransaction transaccion = null;

            try
            {
                if (!abrirConexion())
                    return false;

                transaccion = oCon.BeginTransaction();

                string consultaStock = "SELECT Stock FROM Productos WHERE ProductoID = @ProductoID";
                SqlCommand cmdStock = new SqlCommand(consultaStock, oCon, transaccion);
                cmdStock.Parameters.AddWithValue("@ProductoID", productoID);

                object resultado = cmdStock.ExecuteScalar();

                if (resultado == null)
                {
                    transaccion.Rollback();
                    cerrarConexion();
                    MessageBox.Show("El producto no existe.");
                    return false;
                }

                int stockActual = Convert.ToInt32(resultado);
                int nuevoStock = stockActual;

                if (tipoMovimiento == "Entrada")
                    nuevoStock = stockActual + cantidad;
                else if (tipoMovimiento == "Salida")
                {
                    if (cantidad > stockActual)
                    {
                        transaccion.Rollback();
                        cerrarConexion();
                        MessageBox.Show("No hay suficiente stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    nuevoStock = stockActual - cantidad;
                }

                string consultaMovimiento = "INSERT INTO MovimientosInventario (ProductoID, UsuarioID, TipoMovimiento, Cantidad, FechaMovimiento, Motivo) VALUES (@ProductoID, @UsuarioID, @TipoMovimiento, @Cantidad, GETDATE(), @Motivo)";
                SqlCommand cmdMovimiento = new SqlCommand(consultaMovimiento, oCon, transaccion);
                cmdMovimiento.Parameters.AddWithValue("@ProductoID", productoID);
                cmdMovimiento.Parameters.AddWithValue("@UsuarioID", usuarioID);
                cmdMovimiento.Parameters.AddWithValue("@TipoMovimiento", tipoMovimiento);
                cmdMovimiento.Parameters.AddWithValue("@Cantidad", cantidad);
                cmdMovimiento.Parameters.AddWithValue("@Motivo", motivo);
                cmdMovimiento.ExecuteNonQuery();

                string consultaActualizar = "UPDATE Productos SET Stock = @Stock WHERE ProductoID = @ProductoID";
                SqlCommand cmdActualizar = new SqlCommand(consultaActualizar, oCon, transaccion);
                cmdActualizar.Parameters.AddWithValue("@Stock", nuevoStock);
                cmdActualizar.Parameters.AddWithValue("@ProductoID", productoID);
                cmdActualizar.ExecuteNonQuery();

                transaccion.Commit();
                cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                    transaccion.Rollback();

                cerrarConexion();
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        // modulo de disponibilidad
        public bool insertarHorario(int canchaID, string horaInicio, string horaFin)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta = @"
                INSERT INTO Horarios
                (CanchaID, HoraInicio, HoraFin)
                VALUES
                (@CanchaID, @HoraInicio, @HoraFin)";

                    oCom = new SqlCommand(consulta, oCon);

                    oCom.Parameters.AddWithValue("@CanchaID", canchaID);
                    oCom.Parameters.AddWithValue("@HoraInicio", horaInicio);
                    oCom.Parameters.AddWithValue("@HoraFin", horaFin);

                    oCom.ExecuteNonQuery();

                    cerrarConexion();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();

                return false;
            }
        }

        public bool actualizarHorario(
    int horarioID,
    int canchaID,
    string horaInicio,
    string horaFin)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta = @"
                UPDATE Horarios
                SET
                    CanchaID = @CanchaID,
                    HoraInicio = @HoraInicio,
                    HoraFin = @HoraFin
                WHERE HorarioID = @HorarioID";

                    oCom = new SqlCommand(consulta, oCon);

                    oCom.Parameters.AddWithValue("@HorarioID", horarioID);
                    oCom.Parameters.AddWithValue("@CanchaID", canchaID);
                    oCom.Parameters.AddWithValue("@HoraInicio", horaInicio);
                    oCom.Parameters.AddWithValue("@HoraFin", horaFin);

                    oCom.ExecuteNonQuery();

                    cerrarConexion();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cerrarConexion();

                return false;
            }
        }







    }
}