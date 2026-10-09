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
    public partial class ctrlUserInfo : UserControl
    {

        private int _UserID = -1;
        private clsUser _User;

        public int UserID
        {
            get => _UserID;
        }

        public clsUser SelectedUserInfo
        {
            get => _User;
        }


        public ctrlUserInfo()
        {
            InitializeComponent();
        }
        public void ResetUserInfo()
        {
            _UserID = -1;
            lblUserID.Text = "[???]";
            lblUsername.Text = "[???]";
            lblIsActive.Text = "[???]";
        }

        private void _FillUserInfo()
        {
            ctrlPersonInfo1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.UserName;



            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUser.Find(UserID);
            if (_User == null)
            {
                ResetUserInfo();
                MessageBox.Show("No Person with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }


    }
}
