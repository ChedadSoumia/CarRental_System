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
    public partial class ctrlCustomerInfo : UserControl
    {
        private int _CustomerID = -1;
        private clsCustomers _Customer;

        public int CustomerID
        {
            get => _CustomerID;
        }
        public clsCustomers SelectedCustomerInfo
        {
            get => _Customer;
        }
        public ctrlCustomerInfo()
        {
            InitializeComponent();
        }

        public void ResetCustomerInfo()
        {
            _CustomerID = -1;
            lblCustomerID.Text = "";
            lblNationalNo.Text = "";
            lblDriverLicenseNumber.Text = "";
        }

        private void _FillCustomerInfo()
        {
            ctrlPersonInfo1.LoadPersonInfo(_Customer.PersonID);


            lblCustomerID.Text = _Customer.CustomerID.ToString();
            lblDriverLicenseNumber.Text = _Customer.DriverLicenseNumber;
            lblNationalNo.Text = _Customer.NationalNo;

        }

        public void LoadCustomerInfo(int CustomerID)
        {
            _CustomerID = CustomerID;
            _Customer = clsCustomers.Find(CustomerID);
            if (_Customer == null)
            {
                ResetCustomerInfo();
                MessageBox.Show("No Person with CustomerID = " + CustomerID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillCustomerInfo();

        }


    }
}
