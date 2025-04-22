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
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Server=tcp:laboratorios-chopo.database.windows.net,1433;Initial Catalog=chopoLabs;Persist Security Info=False;User ID=chopo;Password=admin123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Form1()
        {
            InitializeComponent();
            
        }
        public Cliente ClienteActual { get; set; }


        private void btnRevGeneral_Click(object sender, EventArgs e)
        {
            this.Hide();
            check_up_label checkUpPreventivos = new check_up_label();
            checkUpPreventivos.Show();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminPagos adminPagos = new adminPagos();
            adminPagos.Show();
        }

        private void btnEstudHombe_Click(object sender, EventArgs e)
        {        
            vistaEstudiosHombre estudiosHombre = new vistaEstudiosHombre();
            estudiosHombre.Show();
            this.Hide();
        }

        private void btnSeleccionUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryUser.Text))
            {
                MessageBox.Show("Por favor ingrese un ID de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(entryUser.Text, out int idCliente))
            {
                MessageBox.Show("El ID de usuario debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verify client exists in database
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT nombre, email FROM CLIENTES WHERE id_cliente = @idCliente AND activo = 1";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idCliente", idCliente);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombreCliente = reader["nombre"].ToString();
                                string emailCliente = reader["email"].ToString();

                                // Store client ID for later use (in a class variable or property)
                                this.ClienteActual = new Cliente
                                {
                                    Id = idCliente,
                                    Nombre = nombreCliente,
                                    Email = emailCliente
                                };

                                MessageBox.Show($"Cliente seleccionado: {nombreCliente}", "Éxito",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Cliente no encontrado o inactivo", "Error",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar cliente: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
