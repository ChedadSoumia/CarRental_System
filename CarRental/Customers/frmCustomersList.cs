using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Customers
{
    public partial class frmCustomersList : Form
    {
        public frmCustomersList()
        {
            InitializeComponent();
        }

        private void showPeopleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerInfo customerInfo = new frmCustomerInfo();
            customerInfo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer addEditCustomer = new frmAddEditCustomer();
            addEditCustomer.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer addEditCustomer = new frmAddEditCustomer();
            addEditCustomer.ShowDialog();
        }
    }
}
