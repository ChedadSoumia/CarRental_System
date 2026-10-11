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
    public partial class frmAddEditCustomer : Form
    {
        enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode = enMode.AddNew;

        private int _CustomerID = -1;
        private clsCustomers _Customer;

        public frmAddEditCustomer()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditCustomer(int CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValue()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMainTitle.Text = "Add New Customer";
                this.Text = "Add New Customer";
                lblCustomerID.Text = "[???]";
                ctrlPersonInfoWithFilter1.FilterFocus();
                _Customer = new clsCustomers();

            }
            else
            {
                lblMainTitle.Text = "Update Customer";
                this.Text = "Update Customer";

            }

            txtNationalID.Text = "";
            txtDriverLicenseNumber.Text = "";
        }

        private void _LoadDate()
        {
            _Customer = clsCustomers.Find(_CustomerID);
            _CustomerID = _Customer.CustomerID;
            ctrlPersonInfoWithFilter1.FilterEnable = false;

            if (_Customer == null)
            {
                MessageBox.Show("No Customer with ID = " + _CustomerID, "Customer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonInfoWithFilter1.LoadPersonInfo(_Customer.PersonID);
            lblCustomerID.Text = _CustomerID.ToString();
            txtNationalID.Text = _Customer.NationalNo;
            txtDriverLicenseNumber.Text = _Customer.DriverLicenseNumber;

        }

        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.Update)
                _LoadDate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlPersonInfoWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Selected a person", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlPersonInfoWithFilter1.FilterFocus();
            }


            if (_Mode == enMode.AddNew)
            {
                if (clsCustomers.PersonIsCustomer(ctrlPersonInfoWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected person has already a Customer Account, Choose another one", "Select another person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ctrlPersonInfoWithFilter1.FilterFocus();
                    return;
                }
            }
                
            else
            {
                if(_Customer.PersonID != ctrlPersonInfoWithFilter1.PersonID)
                {
                    if (clsCustomers.PersonIsCustomer(ctrlPersonInfoWithFilter1.PersonID))
                    {
                        MessageBox.Show("Selected person has already a Customer Account, Choose another one", "Select another person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ctrlPersonInfoWithFilter1.FilterFocus();
                        return;
                    }
                }
            }

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _Customer.NationalNo = txtNationalID.Text;
            _Customer.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            _Customer.DriverLicenseNumber = txtDriverLicenseNumber.Text;

            if (_Customer.Save())
            {
                lblCustomerID.Text = _Customer.CustomerID.ToString();
                _Mode = enMode.Update;
                ctrlPersonInfoWithFilter1.FilterEnable = false;
                lblMainTitle.Text = "Update Customer";
                this.Text = "Update Customer";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _Mode = enMode.AddNew;
            _ResetDefaultValue();
            ctrlPersonInfoWithFilter1.ResetPersonInfo();
        }

        private void txtNationalID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalID, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalID, null);
            }
        }

        private void txtDriverLicenseNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDriverLicenseNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDriverLicenseNumber, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtDriverLicenseNumber, null);
            }
        }
    }
}
