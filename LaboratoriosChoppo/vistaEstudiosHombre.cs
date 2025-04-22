using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace LaboratoriosChoppo
{
    public partial class vistaEstudiosHombre : Form
    {
        private readonly string connectionString = "Server=tcp:laboratorios-chopo.database.windows.net,1433;Initial Catalog=chopoLabs;Persist Security Info=False;User ID=chopo;Password=admin123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public vistaEstudiosHombre()
        {
            InitializeComponent();

        }
        public Cliente ClienteActual { get; set; }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void LimpiarControles()
        {
            antigeno.Value = 0;
            cultivo.Value = 0;
            CompleteCheckup.Value = 0;
            basicCheckUp.Value = 0;
            Espermatobioscopia.Value = 0;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            int cantidadAntigeno = (int)antigeno.Value;
            int cantidadCultivo = (int)cultivo.Value;
            int cantidadCompleteCheckup = (int)CompleteCheckup.Value;
            int cantidadBasicCheckUp = (int)basicCheckUp.Value;
            int cantidadEspermatobioscopia = (int)Espermatobioscopia.Value;

            if (cantidadAntigeno + cantidadCultivo + cantidadCompleteCheckup + cantidadBasicCheckUp + cantidadEspermatobioscopia == 0)
            {
                MessageBox.Show("Por favor seleccione al menos un servicio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.ClienteActual == null)
            {
                MessageBox.Show("Por favor seleccione un cliente primero", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use the selected client ID
            int idCliente = this.ClienteActual.Id; string metodoPago = "TARJETA";

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    var estudios = await ObtenerEstudiosAsync(connection);

                    int? idAntigeno = estudios.FirstOrDefault(x => x.Value.Nombre.ToLower().Contains("antígeno")).Key;
                    int? idCultivo = estudios.FirstOrDefault(x => x.Value.Nombre.ToLower().Contains("cultivo")).Key;
                    int? idCompleteCheckup = estudios.FirstOrDefault(x => x.Value.Nombre.ToLower().Contains("completo") && x.Value.Nombre.ToLower().Contains("masculino")).Key;
                    int? idBasicCheckUp = estudios.FirstOrDefault(x => x.Value.Nombre.ToLower().Contains("basico") && x.Value.Nombre.ToLower().Contains("masculino")).Key;
                    int? idEspermatobioscopia = estudios.FirstOrDefault(x => x.Value.Nombre.ToLower().Contains("espermatobioscopia")).Key;

                    if ((cantidadAntigeno > 0 && idAntigeno == null) ||
                       (cantidadCultivo > 0 && idCultivo == null) ||
                       (cantidadCompleteCheckup > 0 && idCompleteCheckup == null) ||
                       (cantidadBasicCheckUp > 0 && idBasicCheckUp == null) ||
                       (cantidadEspermatobioscopia > 0 && idEspermatobioscopia == null))
                    {
                        MessageBox.Show("No se encontraron todos los estudios seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    decimal total = 0;
                    var resultados = new List<(string Status, int? IdFactura, decimal? Total, string ErrorMessage)>();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            if (cantidadAntigeno > 0)
                            {
                                var resultado = await EjecutarCompraAsync(connection, transaction, idCliente, idAntigeno.Value, cantidadAntigeno, metodoPago);
                                resultados.Add(resultado);
                                if (resultado.Status == "SUCCESS")
                                {
                                    total += resultado.Total ?? 0;
                                }
                            }
                            if (cantidadCultivo > 0)
                            {
                                var resultado = await EjecutarCompraAsync(connection, transaction, idCliente, idCultivo.Value, cantidadCultivo, metodoPago);
                                resultados.Add(resultado);
                                if (resultado.Status == "SUCCESS")
                                {
                                    total += resultado.Total ?? 0;
                                }
                            }
                            if (cantidadCompleteCheckup > 0)
                            {
                                var resultado = await EjecutarCompraAsync(connection, transaction, idCliente, idCompleteCheckup.Value, cantidadCompleteCheckup, metodoPago);
                                resultados.Add(resultado);
                                if (resultado.Status == "SUCCESS")
                                {
                                    total += resultado.Total ?? 0;
                                }
                            }
                            if (cantidadBasicCheckUp > 0)
                            {
                                var resultado = await EjecutarCompraAsync(connection, transaction, idCliente, idBasicCheckUp.Value, cantidadBasicCheckUp, metodoPago);
                                resultados.Add(resultado);
                                if (resultado.Status == "SUCCESS")
                                {
                                    total += resultado.Total ?? 0;
                                }
                            }
                            if (cantidadEspermatobioscopia > 0)
                            {
                                var resultado = await EjecutarCompraAsync(connection, transaction, idCliente, idEspermatobioscopia.Value, cantidadEspermatobioscopia, metodoPago);
                                resultados.Add(resultado);
                                if (resultado.Status == "SUCCESS")
                                {
                                    total += resultado.Total ?? 0;
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show("Servicios agregados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarControles();
                        }
                        catch (Exception ex)
                        {
                            try { transaction.Rollback(); }
                            catch (Exception rollbackEx)
                            {
                                // Log rollback error (e.g., to a file or monitoring system)
                                Console.WriteLine($"Error during rollback: {rollbackEx.Message}");
                            }
                            MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async Task<(string Status, int? IdFactura, decimal? Total, string ErrorMessage)> EjecutarCompraAsync(
    SqlConnection connection, SqlTransaction transaction, int idCliente, int idEstudio, int cantidad, string metodoPago)
        {
            using (var command = new SqlCommand("sp_AgregarCompraYFactura", connection, transaction)) // Added transaction here
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_cliente", idCliente);
                command.Parameters.AddWithValue("@id_estudio", idEstudio);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                command.Parameters.AddWithValue("@metodo_pago", (object)metodoPago ?? DBNull.Value);
                command.Parameters.AddWithValue("@descuento", 0);
                command.Parameters.AddWithValue("@notas", DBNull.Value);
                command.Parameters.AddWithValue("@id_factura_existente", DBNull.Value);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        string status = reader.GetString(0);
                        if (status == "SUCCESS")
                        {
                            return (status, reader.GetInt32(1), reader.GetDecimal(2), null);
                        }
                        else
                        {
                            return (status, null, null, reader.GetString(2));
                        }
                    }
                }
            }
            return ("ERROR", null, null, "No se recibió respuesta del procedimiento almacenado");
        }

        private async Task<Dictionary<int, (string Nombre, decimal Precio)>> ObtenerEstudiosAsync(SqlConnection connection)
        {
            var estudios = new Dictionary<int, (string Nombre, decimal Precio)>();
            string query = "SELECT id_estudio, nombre, precio FROM ESTUDIOS WHERE activo = 1";

            using (var command = new SqlCommand(query, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    estudios.Add(reader.GetInt32(0), (reader.GetString(1), reader.GetDecimal(2)));
                }
            }
            return estudios;
        }

    }
}
