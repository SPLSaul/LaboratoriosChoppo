using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratoriosChoppo
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=tcp:design-patterns.database.windows.net,1433;Initial Catalog=ChopoLabsDB;Authentication=Active Directory Default;Encrypt=True;"; 
        public Form1()
        {
            InitializeComponent();
            
        }

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


    }
}
