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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarRental.People
{
    public partial class frmPeopleList : Form
    {

        

        private DataTable _dtAllPeople = clsPerson.GetAllPeople();
        public frmPeopleList()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
           

            dgvAllPeople.DataSource = _dtAllPeople;
            lblCountRecord.Text = _dtAllPeople.Rows.Count.ToString();
        }

        private void frmPeopleList_Load(object sender, EventArgs e)
        {
            txtFilter.Visible = false;
            PnlGendor.Visible = false;

            _RefreshPeopleList();
            if (dgvAllPeople.Rows.Count > 0)
            {

                dgvAllPeople.Columns[0].HeaderText = "Person ID";
                dgvAllPeople.Columns[0].Width = 50;

                dgvAllPeople.Columns[1].HeaderText = "Full name";
                dgvAllPeople.Columns[1].Width = 110;

                dgvAllPeople.Columns[2].HeaderText = "Gendor";
                dgvAllPeople.Columns[2].Width = 40;

                dgvAllPeople.Columns[3].HeaderText = "Phone";
                dgvAllPeople.Columns[3].Width = 80;

                dgvAllPeople.Columns[4].HeaderText = "Email";
                dgvAllPeople.Columns[4].Width = 200;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddPerson = new frmAddEditPerson();
            AddPerson.ShowDialog();

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbFilter.Text == "Gendor")
            {
                PnlGendor.Visible = true;
                txtFilter.Visible = false;
                rbAll.Checked = true;
            }
            else
            {
                PnlGendor.Visible = false;
                txtFilter.Visible = true;
                txtFilter.Text = "";
                txtFilter.Visible = (cbFilter.Text != "None");
                txtFilter.Focus();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "Person_id";
                    break;
                case "Full name":
                    FilterColumn = "FullName";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text == "" || FilterColumn == "None")
            {
                _dtAllPeople.DefaultView.RowFilter = "";
                lblCountRecord.Text = dgvAllPeople.Rows.Count.ToString();
                return;

            }


            if (FilterColumn == "Person_id")
            {
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            }
            else
            {
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilter.Text.Trim());
            }


            lblCountRecord.Text = dgvAllPeople.Rows.Count.ToString();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", "Gendor", "Male");
            lblCountRecord.Text = dgvAllPeople.Rows.Count.ToString();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", "Gendor", "Female");
            lblCountRecord.Text = dgvAllPeople.Rows.Count.ToString();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            _dtAllPeople.DefaultView.RowFilter = "";
            lblCountRecord.Text = dgvAllPeople.Rows.Count.ToString();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvAllPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }

                else
                    MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddPerson = new frmAddEditPerson();
            AddPerson.ShowDialog();
            _RefreshPeopleList();
        }

        private void showPeopleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo personInfo =new frmPersonInfo((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            personInfo.ShowDialog();
            _RefreshPeopleList();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson EditPerson = new frmAddEditPerson((int)dgvAllPeople.CurrentRow.Cells[0].Value);
            EditPerson.ShowDialog();
            _RefreshPeopleList();
        }
    }
}
