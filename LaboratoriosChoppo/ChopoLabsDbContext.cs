using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using LaboratoriosChoppo;

public class ChopoLabsDbContext : DbContext
{
    public ChopoLabsDbContext() : base("name=ChopoLabsDbContext")
    {
        try
        {
            // Configuración adicional para mejor diagnóstico
            Database.Log = sql => Debug.WriteLine(sql);

            // Prueba explícita de conexión
            if (!Database.Exists())
            {
                var connection = Database.Connection;
                try
                {
                    connection.Open();
                    Debug.WriteLine("Conexión exitosa!");
                    connection.Close();
                }
                catch (SqlException sqlEx)
                {
                    Debug.WriteLine($"Error SQL #{sqlEx.Number}: {sqlEx.Message}");
                    throw new Exception($"Error al conectar a la base de datos: {sqlEx.Message}", sqlEx);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error general: {ex.ToString()}");
            throw;
        }
    }

    public DbSet<Cliente> Clientes { get; set; }
}