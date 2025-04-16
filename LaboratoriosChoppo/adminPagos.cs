using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratoriosChoppo
{
    public partial class adminPagos : Form
    {
        public adminPagos()
        {
            InitializeComponent();
        }

        private void adminPagos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'choppoDataSet2.VistaAdministradorPagos' Puede moverla o quitarla según sea necesario.
            this.vistaAdministradorPagosTableAdapter2.Fill(this.choppoDataSet2.VistaAdministradorPagos);
            // TODO: esta línea de código carga datos en la tabla 'choppoDataSet1.VistaAdministradorPagos' Puede moverla o quitarla según sea necesario.
            this.vistaAdministradorPagosTableAdapter1.Fill(this.choppoDataSet1.VistaAdministradorPagos);
            // TODO: esta línea de código carga datos en la tabla 'choppoDataSet.VistaAdministradorPagos' Puede moverla o quitarla según sea necesario.
                this.vistaAdministradorPagosTableAdapter.Fill(this.choppoDataSet.VistaAdministradorPagos);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {

        }
    }
}
