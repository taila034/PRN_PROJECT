using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportBooking
{
    
    public partial class frmUserManagement : Form
    {
        public frmUserManagement()
        {
            InitializeComponent();
        }
        public IAccountRepository AccountRepository { get; set; }
        BindingSource source = new BindingSource();
        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            LoadAccountList();
        }
        public void LoadAccountList()
        {
            var accounts = AccountRepository.GetAccounts().Where(p => p.Role == "Customer");

            try
            {
                source = new BindingSource();
                source.DataSource = accounts;

                txtPassword.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtPhone.DataBindings.Clear();
                txtID.DataBindings.Clear();

                txtName.DataBindings.Add("Text", source, "AccountName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtPhone.DataBindings.Add("Text", source, "Phone");
                txtID.DataBindings.Add("Text", source, "AccountId");

                dgvAccount.DataSource = null;
                dgvAccount.DataSource = source;
                dgvAccount.Columns[6].Visible = false;
                dgvAccount.Columns[7].Visible = false;

                if (accounts.Count() == 0)
                {
                    ClearText();
                    btnSearch.Enabled = false;

                }
                else
                {

                    btnSearch.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load account list");
            }
        }
        private void ClearText()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtID.Text = string.Empty;

        }
        public void FindAccountList()
        {
            var accounts = AccountRepository.GetAccounts().Where(c => c.AccountName.ToUpper().Contains(txtSearch.Text.ToUpper()) || c.Email.ToUpper().Contains(txtSearch.Text.ToUpper()));
            try
            {
                source = new BindingSource();
                source.DataSource = accounts;

                txtPassword.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtPhone.DataBindings.Clear();
                txtID.DataBindings.Clear();
                txtName.DataBindings.Add("Text", source, "AccountName");
                txtEmail.DataBindings.Add("Text", source, "Email");
                txtPassword.DataBindings.Add("Text", source, "Password");
                txtPhone.DataBindings.Add("Text", source, "Phone");
                txtID.DataBindings.Add("Text", source, "AccountId");

                dgvAccount.DataSource = null;
                dgvAccount.DataSource = source;
                dgvAccount.Columns[6].Visible = false;
                dgvAccount.Columns[7].Visible = false;

                if (accounts.Count() == 0)
                {
                    ClearText();
                    btnSearch.Enabled = false;
                    MessageBox.Show("No account found!!", "Account Management - Search account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    btnSearch.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load account list");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindAccountList(); 
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmUserDetail frm = new frmUserDetail
            {
                Text = "Add member",
                isUpdate = false,
                AccountRepository = AccountRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {

                LoadAccountList();
                source.Position = source.Count - 1;

            }
        
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Do you want to delete this account ?", "Account Management - Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var account = GetAccount();
                    AccountRepository.DeleteAccount(account);
                    LoadAccountList();
                    MessageBox.Show("Deleted successfully!", "Account Management - Delete an account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot delete this user because of some related data", "Account Management - Delete an account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private Account GetAccount()
        {
            Account acc = null;
            try
            {
                acc = new Account
                {
                    AccountId = int.Parse(txtID.Text),
                    AccountName = txtName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Phone = txtPhone.Text,
                    Role = "Customer"
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return acc;
        }

        private void dgvAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserDetail frm = new frmUserDetail()
            {
                Text = "Update account",
                isUpdate = true,
                AccountEditInfo = GetAccount(),
                AccountRepository = AccountRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAccountList();
                source.Position = source.Count - 1;
            }
        }
    }
}
