using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratoriosChoppo
{
    public partial class vistaEstudiosHombre : Form
    {
        public vistaEstudiosHombre()
        {
            InitializeComponent();

        }
        private void ConfigurarDataGridView()
        {
            // Configuración básica del DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // Limpiar columnas existentes
            dataGridView1.Columns.Clear();

            // Agregar columnas manualmente
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ClienteId",
                HeaderText = "ID",
                Name = "colId",
                Width = 50
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "colNombre",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Name = "colTelefono",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Email",
                HeaderText = "Correo Electrónico",
                Name = "colEmail",
                Width = 200
            });
        }

        private void CargarClientes()
        {
            try
            {
                using (var db = new ChopoLabsDbContext())
                {
                    // Cargar datos y enlazar al DataGridView
                    db.Clientes.Load();
                    dataGridView1.DataSource = db.Clientes.Local.ToBindingList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void vistaEstudiosHombre_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chopoLabsDataSet.CLIENTES' table. You can move, or remove it, as needed.
            this.cLIENTESTableAdapter.Fill(this.chopoLabsDataSet.CLIENTES);

        }
    }
}
