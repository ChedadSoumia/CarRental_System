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

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            _UserID = _User.UserID;
            ctrlPersonInfoWithFilter1.FilterEnable = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonInfoWithFilter1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            txtUsername.Text = _User.UserName;
            chkbIsActive.Checked = _User.IsActive;

        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnNext.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

            if (ctrlPersonInfoWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Selected a person", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlPersonInfoWithFilter1.FilterFocus();
            }
            else
            {
                if (clsUser.PersonIsUser(ctrlPersonInfoWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected person has already a user, Choose another one", "Select another person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ctrlPersonInfoWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _Mode = enMode.AddNew;
            _ResetDefaultValue();
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpPersonInfo"];
            ctrlPersonInfoWithFilter1.ResetPersonInfo();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpPersonInfo"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            _User.UserName = txtUsername.Text;
            _User.IsActive = chkbIsActive.Checked;

            if (_User.Save(txtPassword.Text))
            {
                lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update;
                lblMainTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
