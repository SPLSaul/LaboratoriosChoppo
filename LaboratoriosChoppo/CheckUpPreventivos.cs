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
        private readonly string connectionString = "Server=localhost;Database=Choppo;User Id=SPL;Password=Arr!ba3lCruzAzul;TrustServerCertificate=True;";
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
        private async Task<Dictionary<int, decimal>> ObtenerPreciosAsync(SqlConnection connection)
        {
            var precios = new Dictionary<int, decimal>();
            string query = "SELECT id_Estudio, precio FROM ESTUDIOS";

            using (var command = new SqlCommand(query, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    if (int.TryParse(reader[0].ToString(), out int idEstudio) &&
                        decimal.TryParse(reader[1].ToString(), out decimal precio))
                    {
                        precios.Add(idEstudio, precio);
                    }
                }
            }
            return precios;
        }

        private async Task AgregarCompraAsync(SqlConnection connection, SqlTransaction transaction, int idEstudio, int cantidad)
        {
            string query = "INSERT INTO COMPRA (id_Estudio, cantidad) VALUES (@idEstudio, @cantidad)";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@idEstudio", idEstudio);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                await command.ExecuteNonQueryAsync();
            }
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

            if (cantidadPreventivo == 0 && cantidadPreventivoMRI == 0 && cantidadPreventivoRadiografia == 0)
            {
                MessageBox.Show("Por favor seleccione al menos un servicio para agregar.");
                return;
            }

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    // Obtener precios desde la base de datos
                    var precios = await ObtenerPreciosAsync(connection);
                    decimal total = 0;

                    // Validar que existan los estudios necesarios
                    if (!precios.ContainsKey(1) || !precios.ContainsKey(2) || !precios.ContainsKey(3))
                    {
                        MessageBox.Show("Error: Configuración de estudios incompleta en la base de datos");
                        return;
                    }

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            if (cantidadPreventivo > 0)
                            {
                                total += cantidadPreventivo * precios[1];
                                await AgregarCompraAsync(connection, transaction, 1, cantidadPreventivo);
                            }

                            if (cantidadPreventivoMRI > 0)
                            {
                                total += cantidadPreventivoMRI * precios[2];
                                await AgregarCompraAsync(connection, transaction, 2, cantidadPreventivoMRI);
                            }

                            if (cantidadPreventivoRadiografia > 0)
                            {
                                total += cantidadPreventivoRadiografia * precios[3];
                                await AgregarCompraAsync(connection, transaction, 3, cantidadPreventivoRadiografia);
                            }

                            transaction.Commit();
                            MessageBox.Show($"Se agregaron los estudios. Total: ${total:N2}");
                            LimpiarControles();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error al guardar los datos: {ex.Message}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de base de datos: {ex.Message}");
                }
            }        
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
