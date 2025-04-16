using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LaboratoriosChoppo
{
    public class DatabaseHelper
    {
        public Dictionary<int, decimal> ObtenerPrecios(MySqlConnection connection)
        {
            var precios = new Dictionary<int, decimal>();
            string query = "SELECT id_Estudio, precio FROM ESTUDIOS";

            using (var command = new MySqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int idEstudio = reader.GetInt32("id_Estudio");
                    decimal precio = reader.GetDecimal("precio");
                    precios.Add(idEstudio, precio);
                }
            }
            return precios;
        }
    }
}
