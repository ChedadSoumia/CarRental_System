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
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser();
            addEditUser.ShowDialog();
        }

        private void showPeopleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userInfo = new frmUserInfo();
            userInfo.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword();
            changePassword.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser();
            addEditUser.ShowDialog();
        }
    }
}
