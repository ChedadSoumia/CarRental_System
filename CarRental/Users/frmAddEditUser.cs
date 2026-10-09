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

namespace CarRental.Users
{
    public partial class frmAddEditUser : Form
    {
        enum enMode { AddNew = 0, Update = 1 }
        enum enIsActive { NotActive = 0, Active = 1 }

        enMode _Mode = enMode.AddNew;

        private int _UserID = -1;
        private clsUser _User;

        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditUser(int UserId)
        {
            InitializeComponent();
            _UserID = UserId;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValue()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMainTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();

                tpLoginInfo.Enabled = false;
                ctrlPersonInfoWithFilter1.FilterFocus();
            }
            else
            {
                lblMainTitle.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }


            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPasssword.Text = "";
            chkbIsActive.Checked = false;

        }


        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.Update)
                _LoadData();
        }
    }
}
