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
    public partial class frmCustomersList : Form
    {
        private static DataTable _AllCustomersList;

        public frmCustomersList()
        {
            InitializeComponent();
        }

        private void _RefreshCustomersList()
        {
            _AllCustomersList = clsCustomers.GetAllCustomers();

            dgvAllCustomers.DataSource = _AllCustomersList;
            lblCountRecord.Text = _AllCustomersList.Rows.Count.ToString();
        }

        private void showPeopleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerInfo customerInfo = new frmCustomerInfo((int)dgvAllCustomers.CurrentRow.Cells[0].Value);
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

        private void frmCustomersList_Load(object sender, EventArgs e)
        {
            _RefreshCustomersList();

            txtFilter.Visible = false;

            if (dgvAllCustomers.Rows.Count > 0)
            {
                dgvAllCustomers.Columns[0].HeaderText = "Customer ID";
                dgvAllCustomers.Columns[0].Width = 50;

                dgvAllCustomers.Columns[1].HeaderText = "Person ID";
                dgvAllCustomers.Columns[1].Width = 50;

                dgvAllCustomers.Columns[2].HeaderText = "Full Name";
                dgvAllCustomers.Columns[2].Width = 80;

                dgvAllCustomers.Columns[3].HeaderText = "Phone";
                dgvAllCustomers.Columns[3].Width = 80;

                dgvAllCustomers.Columns[4].HeaderText = "National No";
                dgvAllCustomers.Columns[4].Width = 80;

                dgvAllCustomers.Columns[5].HeaderText = "Driver License Number";
                dgvAllCustomers.Columns[5].Width = 180;
            }
        
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID" || cbFilter.Text == "Customer ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilter.Text != "None");

            txtFilter.Text = "";
            txtFilter.Focus();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Customer ID":
                    FilterColumn = "CustomerID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full name":
                    FilterColumn = "FullName";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Driver License Number":
                    FilterColumn = "DriverLicenseNumber";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                _AllCustomersList.DefaultView.RowFilter = "";
                lblCountRecord.Text = dgvAllCustomers.Rows.Count.ToString();
                return;

            }

            if (FilterColumn == "PersonID" || FilterColumn == "CustomerID")
            {
                _AllCustomersList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _AllCustomersList.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilter.Text.Trim());
            }

            lblCountRecord.Text = dgvAllCustomers.Rows.Count.ToString();

        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvAllCustomers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsCustomers.DeleteCustomer((int)dgvAllCustomers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Customer Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshCustomersList();
                }

                else
                    MessageBox.Show("Customer was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
