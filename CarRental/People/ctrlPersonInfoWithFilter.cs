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

namespace CarRental.People
{
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int personId)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(personId);
            }
        }
        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get { return _FilterEnable; }
            set
            {
                _FilterEnable = value;
                gbFilters.Enabled = _FilterEnable;
            }
        }
        public int PersonID => ctrlPersonInfo1.PersonID;
        public clsPerson SelectedPersonInfo => ctrlPersonInfo1.SelectedPersonInfo;
        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddPerson = new frmAddEditPerson();
            AddPerson.ShowDialog();
        }
        private void _FindNow()
        {
            if (int.TryParse(txtFilter.Text, out int ToPersonID))
            {
                ctrlPersonInfo1.LoadPersonInfo(ToPersonID);
            }
            else
            {
                MessageBox.Show("Please enter a valid Person ID");
            }
            if (OnPersonSelected != null && FilterEnable)
            {
                OnPersonSelected(ctrlPersonInfo1.PersonID);
            }

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text  == "")
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(txtFilter.Text == "")
            {
                btnFilter.Enabled = false;
            }
            else
            {
                btnFilter.Enabled = true;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFilter.PerformClick();
            }
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtFilter.Focus();
        }

        public void FilterFocus()
        {
            txtFilter.Focus();
        }

        private void btnAddNewPerson_Click_1(object sender, EventArgs e)
        {
            frmAddEditPerson addNewPerson = new frmAddEditPerson();
            // Subsecribe to delegeate on AddEdirPerson From to get the new person id after adding a new person
            //addNewPerson.DataBack += DataBackEvent;
            addNewPerson.ShowDialog();
        }
    }
}
