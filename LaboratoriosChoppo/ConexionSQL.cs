using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoriosChoppo
{
    internal class ConexionSQL
    {
        string cadena = "Data Source=SAULLAPTOP;Initial Catalog=Choppo;Integrated Security=True;Trust Server Certificate=True";
        public SqlConnection conectarbd = new SqlConnection();

        public ConexionSQL()
        {
            conectarbd.ConnectionString = cadena;
        }
        public SqlConnection Conectar()
        {
            try
            {
                conectarbd.Open();
                return conectarbd;
            }
            catch { return null; }
        }
        public bool Desconectar()
        {
            try
            {
                conectarbd.Close();
                return true;
            }
            catch { return false; }
        }
    }
}
