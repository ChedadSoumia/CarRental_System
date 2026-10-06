using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Maintenance
{
    public partial class frmMaintenanceList : Form
    {
        public frmMaintenanceList()
        {
            InitializeComponent();
        }

        private void btnAddNewMaintenance_Click(object sender, EventArgs e)
        {
            frmAddEditMaintenance NewMaintenance = new frmAddEditMaintenance();
            NewMaintenance.ShowDialog();
        }
    }
}
