using CarRental_business;
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
    
    public partial class frmCustomerInfo : Form
    {
        private int _CustomerID = -1;
        public frmCustomerInfo(int CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
        }

        private void frmCustomerInfo_Load(object sender, EventArgs e)
        {
            ctrlCustomerInfo1.LoadCustomerInfo(_CustomerID);
        }
    }
}
