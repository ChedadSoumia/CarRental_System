using CarRental.Customers;
using CarRental.Dashboard;
using CarRental.Global_Classes;
using CarRental.Maintenance;
using CarRental.People;
using CarRental.Users;
using CarRental.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            _LoadForm(new frmDashboard());
        }
        private void _LoadForm(object frm)
        {
            if (this.panel4.Controls.Count > 0)
                this.panel4.Controls.Clear();

            Form f = frm as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(f);
            this.panel4.Tag = f;
            f.Show();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            _LoadForm(new frmPeopleList());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            _LoadForm(new frmUsersList());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            _LoadForm(new frmDashboard());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            _LoadForm(new frmCustomersList());
        }

        private void btnVehicle_Click(object sender, EventArgs e)
        {
            _LoadForm(new frmVehicleList());
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            _LoadForm(new frmMaintenanceList());
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            changePassword.ShowDialog();
        }
    }
}
