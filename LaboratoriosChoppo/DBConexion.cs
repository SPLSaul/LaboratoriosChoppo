using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LaboratoriosChoppo
{
    public class DBConexion : IDisposable
    {
        private DBConexion() { }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; private set; }

        private static DBConexion instance = null;
        public static DBConexion Instance()
        {
            if (instance == null)
                instance = new DBConexion();
            return instance;
        }

        public bool IsConnected()
        {
            if (Connection != null)
            {
                return Connection.State == System.Data.ConnectionState.Open;
            }

            if (String.IsNullOrEmpty(DatabaseName))
                return false;

            string connectionString = $"Server={Server};Database={DatabaseName};Uid={User};Pwd={Password};";
            Connection = new MySqlConnection(connectionString);

            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
                Connection?.Dispose();
                Connection = null;
                return false;
            }
        }

        public void Close()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection = null;
            }
        }

        // Implementación de IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Liberar recursos administrados
                    Close(); // Reutilizamos el método Close que ya teníamos
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Destructor (solo por si acaso)
        ~DBConexion()
        {
            Dispose(false);
        }
    }
}
