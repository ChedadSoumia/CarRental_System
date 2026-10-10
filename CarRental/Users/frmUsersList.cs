using CarRental_business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CarRental.Users
{
    public partial class frmUsersList : Form
    {
        private static DataTable _AllUsersList;

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
            frmUserInfo userInfo = new frmUserInfo((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            userInfo.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            changePassword.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser();
            addEditUser.ShowDialog();
        }

        private void _RefreshUserList()
        {
            _AllUsersList = clsUser.GetAllUsers();

            dgvAllUsers.DataSource = _AllUsersList;
            lblCountRecord.Text = _AllUsersList.Rows.Count.ToString();
        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            _RefreshUserList();

            if (dgvAllUsers.Rows.Count > 0)
            {
                dgvAllUsers.Columns[0].HeaderText = "User ID";
                dgvAllUsers.Columns[0].Width = 110;

                dgvAllUsers.Columns[1].HeaderText = "Person ID";
                dgvAllUsers.Columns[1].Width = 120;

                dgvAllUsers.Columns[2].HeaderText = "Full Name";
                dgvAllUsers.Columns[2].Width = 350;

                dgvAllUsers.Columns[3].HeaderText = "UserName";
                dgvAllUsers.Columns[3].Width = 120;

                dgvAllUsers.Columns[4].HeaderText = "Is Active";
                dgvAllUsers.Columns[4].Width = 120;
            }


        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID" || cbFilter.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            _RefreshUserList();
            if (cbFilter.Text == "Active")
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;

                cbIsActive.SelectedIndex = 0;
                cbIsActive.Focus();
            }
            else
            {
                txtFilter.Visible = (cbFilter.Text != "None");
                cbIsActive.Visible = false;

                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "User ID":
                    FilterColumn = "user_id";
                    break;
                case "Person ID":
                    FilterColumn = "person_id";
                    break;
                case "Full name":
                    FilterColumn = "FullName";
                    break;
                case "Username":
                    FilterColumn = "username";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                _AllUsersList.DefaultView.RowFilter = "";
                lblCountRecord.Text = dgvAllUsers.Rows.Count.ToString();
                return;

            }

            if (FilterColumn == "person_id" || FilterColumn == "user_id")
            {
                _AllUsersList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _AllUsersList.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilter.Text.Trim());
            }

            lblCountRecord.Text = dgvAllUsers.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "is_active";
            string FilterValue = cbIsActive.Text;
            switch (FilterValue)
            {
                case "All":
                    break;
                case "Active":
                    FilterValue = "1";
                    break;
                case "Not active":
                    FilterValue = "0";
                    break;
            }
            if (FilterValue == "All")
            {
                _AllUsersList.DefaultView.RowFilter = "";
            }
            else
            {
                _AllUsersList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            lblCountRecord.Text = dgvAllUsers.Rows.Count.ToString();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvAllUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsUser.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUserList();
                }

                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void makeItAsUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Deactive User [" + dgvAllUsers.CurrentRow.Cells[0].Value + "]", "Confirm Deactivate", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsUser.Deactivate((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deactivate Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUserList();
                }

                else
                    MessageBox.Show("User was not Deactivate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            DeactiveUserToolStripMenuItem.Enabled = (bool)dgvAllUsers.CurrentRow.Cells[4].Value;
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            addEditUser.ShowDialog();
            _RefreshUserList();
        }
    }
}
