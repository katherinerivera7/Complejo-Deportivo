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

             Server = @"LAPTOP-J5U2QS20\SQLEXPRESS01"; //LAPTOP-J5U2QS20\SQLEXPRESS01         DESKTOP-OSJ26G2\SQLEXPRESS01
              Database = "ComplejoDeportivo";
              Usuario = "Basados777"; // Basados
              Clave = "Basados888";  //Basados888
            /* Server = @"HP\SQLEXPRESS";
              Database = "ComplejoDeportivo";
              Usuario = "";
              Clave = ""; */
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
        public int insertarReserva(int clienteID, int canchaID, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, string estado)
        {
            try
            {
                if (!abrirConexion())
                    return 0;

                string consulta = @"
        IF EXISTS
        (
            SELECT 1
            FROM Canchas
            WHERE CanchaID = @CanchaID
            AND UPPER(LTRIM(RTRIM(Estado))) LIKE 'MANTENIMIENTO%'
        )
        BEGIN
            SELECT -1;
            RETURN;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM Reservas
            WHERE CanchaID = @CanchaID
            AND Fecha = @Fecha
            AND UPPER(LTRIM(RTRIM(ISNULL(Estado, '')))) <> 'CANCELADA'
            AND HoraInicio < @HoraFin
            AND HoraFin > @HoraInicio
        )
        BEGIN
            SELECT -2;
            RETURN;
        END;

        INSERT INTO Reservas
        (
            ClienteID,
            CanchaID,
            Fecha,
            HoraInicio,
            HoraFin,
            Estado
        )
        VALUES
        (
            @ClienteID,
            @CanchaID,
            @Fecha,
            @HoraInicio,
            @HoraFin,
            @Estado
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(consulta, oCon))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                    cmd.Parameters.AddWithValue("@CanchaID", canchaID);
                    cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha.Date;
                    cmd.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = horaInicio;
                    cmd.Parameters.Add("@HoraFin", SqlDbType.Time).Value = horaFin;
                    cmd.Parameters.AddWithValue("@Estado", estado);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cerrarConexion();
            }
        }

        public int insertarFactura(int reservaID, string numeroFactura, DateTime fechaEmision, string metodoPago, decimal subtotal, decimal descuento, decimal iva, decimal total)
        {
            try
            {
                if (!abrirConexion())
                    return 0;

                string consulta = @"
        IF EXISTS
        (
            SELECT 1
            FROM Facturas
            WHERE NumeroFactura = @NumeroFactura
        )
        BEGIN
            SELECT 0;
            RETURN;
        END;

        INSERT INTO Facturas
        (
            ReservaID,
            NumeroFactura,
            FechaEmision,
            MetodoPago,
            Subtotal,
            Descuento,
            IVA,
            Total
        )
        VALUES
        (
            @ReservaID,
            @NumeroFactura,
            @FechaEmision,
            @MetodoPago,
            @Subtotal,
            @Descuento,
            @IVA,
            @Total
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(consulta, oCon))
                {
                    cmd.Parameters.AddWithValue("@ReservaID", reservaID);
                    cmd.Parameters.AddWithValue("@NumeroFactura", numeroFactura);
                    cmd.Parameters.AddWithValue("@FechaEmision", fechaEmision);
                    cmd.Parameters.AddWithValue("@MetodoPago", metodoPago);
                    cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                    cmd.Parameters.AddWithValue("@Descuento", descuento);
                    cmd.Parameters.AddWithValue("@IVA", iva);
                    cmd.Parameters.AddWithValue("@Total", total);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cerrarConexion();
            }
        }

        public bool insertarDetalleFactura(int facturaID, string descripcion, string horario, int cantidadHoras, decimal precioHora, decimal descuento, decimal subtotal)
        {
            try
            {
                if (!abrirConexion())
                    return false;

                string consulta = @"
        INSERT INTO DetalleFactura
        (
            FacturaID,
            Descripcion,
            Horario,
            CantidadHoras,
            PrecioHora,
            Descuento,
            Subtotal
        )
        VALUES
        (
            @FacturaID,
            @Descripcion,
            @Horario,
            @CantidadHoras,
            @PrecioHora,
            @Descuento,
            @Subtotal
        )";

                using (SqlCommand cmd = new SqlCommand(consulta, oCon))
                {
                    cmd.Parameters.AddWithValue("@FacturaID", facturaID);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Horario", horario);
                    cmd.Parameters.AddWithValue("@CantidadHoras", cantidadHoras);
                    cmd.Parameters.AddWithValue("@PrecioHora", precioHora);
                    cmd.Parameters.AddWithValue("@Descuento", descuento);
                    cmd.Parameters.AddWithValue("@Subtotal", subtotal);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                cerrarConexion();
            }
        }
        public int guardarReservaFactura(
    int clienteID,
    int canchaID,
    DateTime fechaReserva,
    TimeSpan horaInicio,
    TimeSpan horaFin,
    string numeroFactura,
    DateTime fechaEmision,
    string metodoPago,
    int? promocionID,
    decimal subtotal,
    decimal descuento,
    decimal iva,
    decimal total,
    string cancha,
    string horario,
    int cantidadHoras,
    decimal precioHora,
    bool incluyeArbitro,
    decimal precioArbitro)
        {
            SqlTransaction transaccion = null;

            try
            {
                if (!abrirConexion())
                    return 0;

                decimal subtotalCancha =
                    precioHora * cantidadHoras;

                decimal subtotalArbitro =
                    incluyeArbitro ? precioArbitro : 0m;

                subtotal =
                    subtotalCancha + subtotalArbitro;

                if (descuento < 0)
                    descuento = 0;

                if (descuento > subtotalCancha)
                    descuento = subtotalCancha;

                iva =
                    (subtotal - descuento) * 0.15m;

                total =
                    subtotal - descuento + iva;

                transaccion = oCon.BeginTransaction();

                using (SqlCommand cmdEstado = new SqlCommand(
                    "SELECT UPPER(LTRIM(RTRIM(ISNULL(Estado, '')))) " +
                    "FROM Canchas " +
                    "WHERE CanchaID = @CanchaID",
                    oCon,
                    transaccion))
                {
                    cmdEstado.Parameters.AddWithValue(
                        "@CanchaID",
                        canchaID);

                    string estado =
                        Convert.ToString(
                            cmdEstado.ExecuteScalar());

                    if (estado == "MANTENIMIENTO" ||
                        estado == "INACTIVA" ||
                        estado == "CERRADA")
                    {
                        transaccion.Rollback();
                        return -1;
                    }
                }

                using (SqlCommand cmdHorario = new SqlCommand(
                    "SELECT COUNT(*) FROM Reservas " +
                    "WHERE CanchaID = @CanchaID " +
                    "AND Fecha = @Fecha " +
                    "AND UPPER(LTRIM(RTRIM(ISNULL(Estado, '')))) <> 'CANCELADA' " +
                    "AND HoraInicio < @HoraFin " +
                    "AND HoraFin > @HoraInicio",
                    oCon,
                    transaccion))
                {
                    cmdHorario.Parameters.AddWithValue(
                        "@CanchaID",
                        canchaID);

                    cmdHorario.Parameters.AddWithValue(
                        "@Fecha",
                        fechaReserva.Date);

                    cmdHorario.Parameters.Add(
                        "@HoraInicio",
                        SqlDbType.Time).Value = horaInicio;

                    cmdHorario.Parameters.Add(
                        "@HoraFin",
                        SqlDbType.Time).Value = horaFin;

                    if (Convert.ToInt32(
                        cmdHorario.ExecuteScalar()) > 0)
                    {
                        transaccion.Rollback();
                        return -2;
                    }
                }

                using (SqlCommand cmdFacturaExiste = new SqlCommand(
                    "SELECT COUNT(*) FROM Facturas " +
                    "WHERE NumeroFactura = @NumeroFactura",
                    oCon,
                    transaccion))
                {
                    cmdFacturaExiste.Parameters.AddWithValue(
                        "@NumeroFactura",
                        numeroFactura);

                    if (Convert.ToInt32(
                        cmdFacturaExiste.ExecuteScalar()) > 0)
                    {
                        transaccion.Rollback();
                        return -3;
                    }
                }

                int reservaID;

                using (SqlCommand cmdReserva = new SqlCommand(
                    "INSERT INTO Reservas " +
                    "(ClienteID, CanchaID, Fecha, HoraInicio, HoraFin, Estado) " +
                    "VALUES " +
                    "(@ClienteID, @CanchaID, @Fecha, @HoraInicio, @HoraFin, 'Confirmada'); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);",
                    oCon,
                    transaccion))
                {
                    cmdReserva.Parameters.AddWithValue(
                        "@ClienteID",
                        clienteID);

                    cmdReserva.Parameters.AddWithValue(
                        "@CanchaID",
                        canchaID);

                    cmdReserva.Parameters.AddWithValue(
                        "@Fecha",
                        fechaReserva.Date);

                    cmdReserva.Parameters.Add(
                        "@HoraInicio",
                        SqlDbType.Time).Value = horaInicio;

                    cmdReserva.Parameters.Add(
                        "@HoraFin",
                        SqlDbType.Time).Value = horaFin;

                    reservaID =
                        Convert.ToInt32(
                            cmdReserva.ExecuteScalar());
                }

                int facturaID;

                using (SqlCommand cmdFactura = new SqlCommand(
                    "INSERT INTO Facturas " +
                    "(ReservaID, PromocionID, NumeroFactura, FechaEmision, " +
                    "MetodoPago, Subtotal, Descuento, IVA, Total) " +
                    "VALUES " +
                    "(@ReservaID, @PromocionID, @NumeroFactura, @FechaEmision, " +
                    "@MetodoPago, @Subtotal, @Descuento, @IVA, @Total); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);",
                    oCon,
                    transaccion))
                {
                    cmdFactura.Parameters.AddWithValue(
                        "@ReservaID",
                        reservaID);

                    cmdFactura.Parameters.Add(
                        "@PromocionID",
                        SqlDbType.Int).Value =
                        promocionID.HasValue
                            ? (object)promocionID.Value
                            : DBNull.Value;

                    cmdFactura.Parameters.AddWithValue(
                        "@NumeroFactura",
                        numeroFactura);

                    cmdFactura.Parameters.AddWithValue(
                        "@FechaEmision",
                        fechaEmision);

                    cmdFactura.Parameters.AddWithValue(
                        "@MetodoPago",
                        metodoPago);

                    cmdFactura.Parameters.AddWithValue(
                        "@Subtotal",
                        subtotal);

                    cmdFactura.Parameters.AddWithValue(
                        "@Descuento",
                        descuento);

                    cmdFactura.Parameters.AddWithValue(
                        "@IVA",
                        iva);

                    cmdFactura.Parameters.AddWithValue(
                        "@Total",
                        total);

                    facturaID =
                        Convert.ToInt32(
                            cmdFactura.ExecuteScalar());
                }

                using (SqlCommand cmdDetalleCancha = new SqlCommand(
                    "INSERT INTO DetalleFactura " +
                    "(FacturaID, Descripcion, Horario, CantidadHoras, " +
                    "PrecioHora, Descuento, Subtotal) " +
                    "VALUES " +
                    "(@FacturaID, @Descripcion, @Horario, @CantidadHoras, " +
                    "@PrecioHora, @Descuento, @Subtotal)",
                    oCon,
                    transaccion))
                {
                    cmdDetalleCancha.Parameters.AddWithValue(
                        "@FacturaID",
                        facturaID);

                    cmdDetalleCancha.Parameters.AddWithValue(
                        "@Descripcion",
                        cancha);

                    cmdDetalleCancha.Parameters.AddWithValue(
                        "@Horario",
                        horario);

                    cmdDetalleCancha.Parameters.AddWithValue(
                        "@CantidadHoras",
                        cantidadHoras);

                    cmdDetalleCancha.Parameters.AddWithValue(
                        "@PrecioHora",
                        precioHora);

                    cmdDetalleCancha.Parameters.AddWithValue(
                        "@Descuento",
                        descuento);

                    cmdDetalleCancha.Parameters.AddWithValue(
                        "@Subtotal",
                        subtotalCancha);

                    cmdDetalleCancha.ExecuteNonQuery();
                }

                if (incluyeArbitro)
                {
                    using (SqlCommand cmdDetalleArbitro = new SqlCommand(
                        "INSERT INTO DetalleFactura " +
                        "(FacturaID, Descripcion, Horario, CantidadHoras, " +
                        "PrecioHora, Descuento, Subtotal) " +
                        "VALUES " +
                        "(@FacturaID, @Descripcion, @Horario, @CantidadHoras, " +
                        "@PrecioHora, @Descuento, @Subtotal)",
                        oCon,
                        transaccion))
                    {
                        cmdDetalleArbitro.Parameters.AddWithValue(
                            "@FacturaID",
                            facturaID);

                        cmdDetalleArbitro.Parameters.AddWithValue(
                            "@Descripcion",
                            "Servicio de árbitro");

                        cmdDetalleArbitro.Parameters.AddWithValue(
                            "@Horario",
                            horario);

                        cmdDetalleArbitro.Parameters.AddWithValue(
                            "@CantidadHoras",
                            1);

                        cmdDetalleArbitro.Parameters.AddWithValue(
                            "@PrecioHora",
                            precioArbitro);

                        cmdDetalleArbitro.Parameters.AddWithValue(
                            "@Descuento",
                            0m);

                        cmdDetalleArbitro.Parameters.AddWithValue(
                            "@Subtotal",
                            precioArbitro);

                        cmdDetalleArbitro.ExecuteNonQuery();
                    }
                }

                transaccion.Commit();
                return facturaID;
            }
            catch (Exception ex)
            {
                try
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                }
                catch
                {
                }

                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return 0;
            }
            finally
            {
                cerrarConexion();
            }
        }
        public bool eliminarReserva(int reservaID)
        {
            SqlTransaction transaccion = null;

            try
            {
                if (!abrirConexion())
                    return false;

                transaccion = oCon.BeginTransaction();

                string consulta = @"
            DELETE FROM DetalleFactura
            WHERE FacturaID IN
            (
                SELECT FacturaID
                FROM Facturas
                WHERE ReservaID = @ReservaID
            );

            DELETE FROM Facturas
            WHERE ReservaID = @ReservaID;

            DELETE FROM Reservas
            WHERE ReservaID = @ReservaID;";

                using (SqlCommand cmd = new SqlCommand(consulta, oCon, transaccion))
                {
                    cmd.Parameters.Add("@ReservaID", SqlDbType.Int).Value = reservaID;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas <= 0)
                    {
                        transaccion.Rollback();
                        return false;
                    }
                }

                transaccion.Commit();
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                }
                catch
                {
                }

                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public int actualizarReservaFactura(
    int reservaID,
    int clienteID,
    int canchaID,
    DateTime fecha,
    TimeSpan horaInicio,
    TimeSpan horaFin,
    string cancha,
    string horario,
    int cantidadHoras,
    decimal precioHora,
    decimal descuento)
        {
            SqlTransaction transaccion = null;

            try
            {
                if (!abrirConexion())
                    return 0;

                transaccion = oCon.BeginTransaction();

                string validacion =
                    "IF EXISTS " +
                    "(SELECT 1 FROM Canchas " +
                    "WHERE CanchaID = @CanchaID " +
                    "AND UPPER(LTRIM(RTRIM(ISNULL(Estado, '')))) " +
                    "LIKE 'MANTENIMIENTO%') " +
                    "SELECT -1 " +
                    "ELSE IF EXISTS " +
                    "(SELECT 1 FROM Reservas " +
                    "WHERE ReservaID <> @ReservaID " +
                    "AND CanchaID = @CanchaID " +
                    "AND CONVERT(DATE, Fecha) = @Fecha " +
                    "AND UPPER(LTRIM(RTRIM(ISNULL(Estado, '')))) " +
                    "<> 'CANCELADA' " +
                    "AND HoraInicio < @HoraFin " +
                    "AND HoraFin > @HoraInicio) " +
                    "SELECT -2 " +
                    "ELSE SELECT 1";

                using (SqlCommand cmdValidacion =
                    new SqlCommand(
                        validacion,
                        oCon,
                        transaccion))
                {
                    cmdValidacion.Parameters.Add(
                        "@ReservaID",
                        SqlDbType.Int).Value = reservaID;

                    cmdValidacion.Parameters.Add(
                        "@CanchaID",
                        SqlDbType.Int).Value = canchaID;

                    cmdValidacion.Parameters.Add(
                        "@Fecha",
                        SqlDbType.Date).Value = fecha.Date;

                    cmdValidacion.Parameters.Add(
                        "@HoraInicio",
                        SqlDbType.Time).Value = horaInicio;

                    cmdValidacion.Parameters.Add(
                        "@HoraFin",
                        SqlDbType.Time).Value = horaFin;

                    int resultado =
                        Convert.ToInt32(
                            cmdValidacion.ExecuteScalar());

                    if (resultado != 1)
                    {
                        transaccion.Rollback();
                        return resultado;
                    }
                }

                decimal subtotal =
                    precioHora * cantidadHoras;

                decimal iva =
                    subtotal * 0.15m;

                decimal total =
                    subtotal - descuento + iva;

                string consulta =
                    "UPDATE Reservas SET " +
                    "ClienteID = @ClienteID, " +
                    "CanchaID = @CanchaID, " +
                    "Fecha = @Fecha, " +
                    "HoraInicio = @HoraInicio, " +
                    "HoraFin = @HoraFin " +
                    "WHERE ReservaID = @ReservaID; " +

                    "UPDATE Facturas SET " +
                    "Subtotal = @Subtotal, " +
                    "Descuento = @Descuento, " +
                    "IVA = @IVA, " +
                    "Total = @Total " +
                    "WHERE ReservaID = @ReservaID; " +

                    "UPDATE DetalleFactura SET " +
                    "Descripcion = @Descripcion, " +
                    "Horario = @Horario, " +
                    "CantidadHoras = @CantidadHoras, " +
                    "PrecioHora = @PrecioHora, " +
                    "Descuento = @Descuento, " +
                    "Subtotal = @Subtotal " +
                    "WHERE FacturaID IN " +
                    "(SELECT FacturaID FROM Facturas " +
                    "WHERE ReservaID = @ReservaID)";

                using (SqlCommand cmd =
                    new SqlCommand(
                        consulta,
                        oCon,
                        transaccion))
                {
                    cmd.Parameters.Add(
                        "@ReservaID",
                        SqlDbType.Int).Value = reservaID;

                    cmd.Parameters.Add(
                        "@ClienteID",
                        SqlDbType.Int).Value = clienteID;

                    cmd.Parameters.Add(
                        "@CanchaID",
                        SqlDbType.Int).Value = canchaID;

                    cmd.Parameters.Add(
                        "@Fecha",
                        SqlDbType.Date).Value = fecha.Date;

                    cmd.Parameters.Add(
                        "@HoraInicio",
                        SqlDbType.Time).Value = horaInicio;

                    cmd.Parameters.Add(
                        "@HoraFin",
                        SqlDbType.Time).Value = horaFin;

                    cmd.Parameters.Add(
                        "@Descripcion",
                        SqlDbType.VarChar,
                        200).Value = cancha;

                    cmd.Parameters.Add(
                        "@Horario",
                        SqlDbType.VarChar,
                        20).Value = horario;

                    cmd.Parameters.Add(
                        "@CantidadHoras",
                        SqlDbType.Int).Value = cantidadHoras;

                    cmd.Parameters.Add(
                        "@PrecioHora",
                        SqlDbType.Decimal).Value = precioHora;

                    cmd.Parameters.Add(
                        "@Descuento",
                        SqlDbType.Decimal).Value = descuento;

                    cmd.Parameters.Add(
                        "@Subtotal",
                        SqlDbType.Decimal).Value = subtotal;

                    cmd.Parameters.Add(
                        "@IVA",
                        SqlDbType.Decimal).Value = iva;

                    cmd.Parameters.Add(
                        "@Total",
                        SqlDbType.Decimal).Value = total;

                    cmd.ExecuteNonQuery();
                }

                transaccion.Commit();
                return 1;
            }
            catch (Exception ex)
            {
                try
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                }
                catch
                {
                }

                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cerrarConexion();
            }
        }

    }
}