using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosChoppo
{
    internal class ChopoCAD
    {
        public static bool Agregar(Estudios e)
        {
            try
            {
                ConexionSQL con = new ConexionSQL();
                string sql = "AGREGAR_COMPRA";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id_Estudio", e.id_estudio1);
                comando.Parameters.AddWithValue("@cantidad", e.cantidad1);

                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1) { return true; }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }
        public static DataTable Listar()
        {
            try
            {
                ConexionSQL con = new ConexionSQL();
                string sql = "SELECT * FROM ORDEN;";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                SqlDataReader datalector = comando.ExecuteReader(CommandBehavior.CloseConnection);  //Esta no es una consulta, este nos permite la cantidad de filas afectadas
                DataTable dt = new DataTable();
                dt.Load(datalector);
                con.Desconectar();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public static bool Eliminar(string ID)
        {
            try
            {
                ConexionSQL con = new ConexionSQL();
                string sql = "EXECUTE BORRAR " + ID + "";
                SqlCommand comando = new SqlCommand(sql, con.Conectar());
                int cantidad = comando.ExecuteNonQuery();  //Esta no es una consulta, este nos permite la cantidad de filas afectadas
                if (cantidad == 1) { con.Desconectar(); return true; }
                else
                {
                    con.Desconectar();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static float Pago()
        {
            try
            {
                ConexionSQL sql = new ConexionSQL();
                string pago = "SELECT SUM(Monto) FROM ORDEN ";
                float cantidad = float.Parse(pago);
                return cantidad;
            }
            catch
            {
                return 0.0f;
            }
        }
    }
}
