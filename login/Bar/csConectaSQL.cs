using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Bar
{
    internal class csConectaSQL
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
            Server = "LAPTOP-J5U2QS20\\SQLEXPRESS01";
            Database = "ComplejoDeportivo";
            Usuario = "Basados777";
            Clave = "Basados888";
        }

        public bool abrirConexion()
        {
            oCon = new SqlConnection();

            try
            {
                Cadena = @"Server=" + Server +";Database=" + Database +";Integrated Security=True;" +"TrustServerCertificate=True;";

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
                oCon.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable retornaRegistros(string Sentencia)
        {
            oDT = new DataTable();

            if (Sentencia.Length > 0)
            {
                if (abrirConexion())
                {
                    oCom = new SqlCommand(Sentencia, oCon);
                    oDA = new SqlDataAdapter(oCom);

                    oDA.Fill(oDT);

                    cerrarConexion();
                }
            }

            return oDT;
        }

        public bool insertDatos(string tabla, string campos, string datos)
        {
            try
            {
                if (abrirConexion())
                {
                    Cadena = "INSERT INTO " + tabla +"(" + campos + ")" +" VALUES (" + datos + ")";

                    oCom = new SqlCommand(Cadena, oCon);
                    oCom.ExecuteNonQuery();

                    cerrarConexion();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool editarDatos(string tabla, string datos, string condicion)
        {
            try
            {
                if (abrirConexion())
                {
                    Cadena = "UPDATE " + tabla +
                             " SET " + datos +
                             " WHERE " + condicion;

                    oCom = new SqlCommand(Cadena, oCon);
                    oCom.ExecuteNonQuery();

                    cerrarConexion();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool eliminarDatos(string tabla, string condicion)
        {
            try
            {
                if (abrirConexion())
                {
                    Cadena = "DELETE FROM " + tabla +
                             " WHERE " + condicion;

                    oCom = new SqlCommand(Cadena, oCon);
                    oCom.ExecuteNonQuery();

                    cerrarConexion();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}