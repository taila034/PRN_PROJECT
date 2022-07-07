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
    public partial class frmUserDetail : Form
    {
        public frmUserDetail()
        {
            InitializeComponent();
        }
        public Account AccountEditInfo { get; set; }
        public IAccountRepository AccountRepository { get; set; }
        public bool isUpdate { get; set; }

        private void frmUserDetail_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                txtEmail.Text = AccountEditInfo.Email;
                txtName.Text = AccountEditInfo.AccountName;
                txtPassword.Text = AccountEditInfo.Password;
                txtPhone.Text = AccountEditInfo.Phone;
                

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var acc = new Account
                {
                    
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    AccountName = txtName.Text,
                    Phone = txtPhone.Text,
                    
                };
                if (!isUpdate)
                {
                    acc.Role = "Customer";
                    AccountRepository.AddAccount(acc);
                    MessageBox.Show("Added successfully!", "Account Management - Add an account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    acc.AccountId = AccountEditInfo.AccountId;
                    acc.Role = AccountEditInfo.Role;
                    AccountRepository.UpdateAccount(acc);
                    MessageBox.Show("Updated successfully!", "Account Management - Update an account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
