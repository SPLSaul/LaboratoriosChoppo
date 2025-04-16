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
        public Form1()
        {
            InitializeComponent();
            var dbCon = DBConexion.Instance();
            dbCon.Server = "localhost";
            dbCon.DatabaseName = "CHOPO";
            dbCon.User = "root";
            dbCon.Password = "Arr!ba3lCruzAzul";
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
    }
}
