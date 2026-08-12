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
            Server = @"LAPTOP-J5U2QS20\SQLEXPRESS01";
            Database = "ComplejoDeportivo";
            Usuario = "Basados777";
            Clave = "Basados888";
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

        public bool insertarProducto(
            int categoriaID,
            string nombre,
            decimal precio,
            int stock,
            byte[] imagen)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta = @"
                        INSERT INTO Productos
                        (
                            CategoriaID,
                            Nombre,
                            Precio,
                            Stock,
                            Imagen
                        )
                        VALUES
                        (
                            @CategoriaID,
                            @Nombre,
                            @Precio,
                            @Stock,
                            @Imagen
                        )";

                    oCom = new SqlCommand(consulta, oCon);

                    oCom.Parameters.AddWithValue(
                        "@CategoriaID", categoriaID);

                    oCom.Parameters.AddWithValue(
                        "@Nombre", nombre);

                    oCom.Parameters.AddWithValue(
                        "@Precio", precio);

                    oCom.Parameters.AddWithValue(
                        "@Stock", stock);

                    if (imagen != null)
                    {
                        oCom.Parameters.Add(
                            "@Imagen",
                            SqlDbType.VarBinary,
                            -1).Value = imagen;
                    }
                    else
                    {
                        oCom.Parameters.Add(
                            "@Imagen",
                            SqlDbType.VarBinary,
                            -1).Value = DBNull.Value;
                    }

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

        public bool actualizarProducto(
            int productoID,
            int categoriaID,
            string nombre,
            decimal precio,
            int stock,
            byte[] imagen)
        {
            try
            {
                if (abrirConexion())
                {
                    string consulta = @"
                        UPDATE Productos
                        SET
                            CategoriaID = @CategoriaID,
                            Nombre = @Nombre,
                            Precio = @Precio,
                            Stock = @Stock,
                            Imagen = @Imagen
                        WHERE ProductoID = @ProductoID";

                    oCom = new SqlCommand(consulta, oCon);

                    oCom.Parameters.AddWithValue(
                        "@ProductoID", productoID);

                    oCom.Parameters.AddWithValue(
                        "@CategoriaID", categoriaID);

                    oCom.Parameters.AddWithValue(
                        "@Nombre", nombre);

                    oCom.Parameters.AddWithValue(
                        "@Precio", precio);

                    oCom.Parameters.AddWithValue(
                        "@Stock", stock);

                    if (imagen != null)
                    {
                        oCom.Parameters.Add(
                            "@Imagen",
                            SqlDbType.VarBinary,
                            -1).Value = imagen;
                    }
                    else
                    {
                        oCom.Parameters.Add(
                            "@Imagen",
                            SqlDbType.VarBinary,
                            -1).Value = DBNull.Value;
                    }

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
    }
}