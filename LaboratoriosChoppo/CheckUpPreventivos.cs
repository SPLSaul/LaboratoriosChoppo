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

    public partial class check_up_label : Form
    {
        private readonly string connectionString = "Server=tcp:laboratorios-chopo.database.windows.net,1433;Initial Catalog=chopoLabs;Persist Security Info=False;User ID=chopo;Password=admin123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public check_up_label()
        {
            InitializeComponent();

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }      
        private void LimpiarControles()
        {
            onlyPreventivo.Value = 0;
            prevPlusMRI.Value = 0;
            prevPlusRad.Value = 0;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            int cantidadPreventivo = (int)onlyPreventivo.Value;
            int cantidadPreventivoMRI = (int)prevPlusMRI.Value;
            int cantidadPreventivoRadiografia = (int)prevPlusRad.Value;

            if (cantidadPreventivo + cantidadPreventivoMRI + cantidadPreventivoRadiografia == 0)
            {
                MessageBox.Show("Por favor seleccione al menos un servicio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Obtain id_cliente from user input (e.g., a ComboBox or login session)
            int idCliente = 1; // Placeholder; replace with actual client selection logic
            string metodoPago = "TARJETA"; // Placeholder; replace with actual payment method selection

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    var estudios = await ObtenerEstudiosAsync(connection);

                    // Map study names to IDs (case-insensitive)
                    int? idPreventivo = estudios.FirstOrDefault(x => x.Value.Nombre.ToLower().Contains("check up preventivo") && !x.Value.Nombre.ToLower().Contains("mri") && !x.Value.Nombre.ToLower().Contains("radiografia")).Key;
                    int? idPreventivoMRI = estudios.FirstOrDefault(x => x.Value.Nombre.ToLower().Contains("check up preventivo") && x.Value.Nombre.ToLower().Contains("mri")).Key;
                    int? idPreventivoRad = estudios.FirstOrDefault(x => x.Value.Nombre.ToLower().Contains("check up preventivo") && x.Value.Nombre.ToLower().Contains("radiografia")).Key;

                    if ((cantidadPreventivo > 0 && idPreventivo == null) ||
                        (cantidadPreventivoMRI > 0 && idPreventivoMRI == null) ||
                        (cantidadPreventivoRadiografia > 0 && idPreventivoRad == null))
                    {
                        MessageBox.Show("Uno o más estudios no están disponibles en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    decimal total = 0;
                    var resultados = new List<(string Status, int? IdFactura, decimal? Total, string ErrorMessage)>();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            if (cantidadPreventivo > 0)
                            {
                                var resultado = await EjecutarCompraAsync(connection, idCliente, idPreventivo.Value, cantidadPreventivo, metodoPago);
                                resultados.Add(resultado);
                                if (resultado.Status == "SUCCESS") total += resultado.Total.Value;
                            }

                            if (cantidadPreventivoMRI > 0)
                            {
                                var resultado = await EjecutarCompraAsync(connection, idCliente, idPreventivoMRI.Value, cantidadPreventivoMRI, metodoPago);
                                resultados.Add(resultado);
                                if (resultado.Status == "SUCCESS") total += resultado.Total.Value;
                            }

                            if (cantidadPreventivoRadiografia > 0)
                            {
                                var resultado = await EjecutarCompraAsync(connection, idCliente, idPreventivoRad.Value, cantidadPreventivoRadiografia, metodoPago);
                                resultados.Add(resultado);
                                if (resultado.Status == "SUCCESS") total += resultado.Total.Value;
                            }

                            if (resultados.Any(r => r.Status != "SUCCESS"))
                            {
                                throw new Exception(string.Join("\n", resultados.Where(r => r.Status != "SUCCESS").Select(r => r.ErrorMessage)));
                            }

                            transaction.Commit();
                            MessageBox.Show($"Compra registrada exitosamente\nTotal: ${total:N2}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
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
        private async Task<(string Status, int? IdFactura, decimal? Total, string ErrorMessage)> EjecutarCompraAsync(
            SqlConnection connection, int idCliente, int idEstudio, int cantidad, string metodoPago)
        {
            using (var command = new SqlCommand("sp_AgregarCompraYFactura", connection))
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
    }
}

