using CarRental.Global_Classes;
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

namespace CarRental.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.Find(txtUsername.Text.Trim());
            if (User != null)
            {
                if (User.VerifyPassword(txtPassword.Text))
                {
                    if (ckbRememberMe.Checked)
                    {
                        clsGlobal.WriteRegistryValue(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                        User.LoginHistoryID = clsSettings.AddLoginHistory(User.UserID, true);
                    }
                    else
                    {
                        clsGlobal.DeleteRegistryValue();
                    }

                    if (!User.IsActive)
                    {
                        txtUsername.Focus();
                        MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    clsGlobal.CurrentUser = User;
                    clsSettings.AddLoginHistory(clsGlobal.CurrentUser.UserID, false);
                    this.Hide();
                    frmMain frm = new frmMain(this);
                    frm.ShowDialog();

                }
                else
                {
                    txtPassword.Focus();
                    MessageBox.Show("Invalid Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";
            if (clsGlobal.ReadRegistryValue(ref Username, ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;
                ckbRememberMe.Checked = true;
            }
            else
            {
                ckbRememberMe.Checked = false;
            }
        }
    }
}
