using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
                    if(txtPhone.Text == "" || txtEmail.Text =="" || txtName.Text ==""|| txtPassword.Text == "")
                    {
                        MessageBox.Show("All fields are required!!", "Account Management - Add account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (checkDup())
                    {
                        acc.Role = "Customer";
                        AccountRepository.AddAccount(acc);
                        MessageBox.Show("Added successfully!", "Account Management - Add an account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Email or phone number existed!!", "Account Management - Add account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
        private bool checkDup()
        {
            var accountList = AccountRepository.GetAccounts();
            foreach(var item in accountList)
            {
                if(item.Email == txtEmail.Text || item.Phone == txtPhone.Text)
                {
                    return false;
                }
            }
            return true;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!IsValid(txtEmail.Text))
            {
                MessageBox.Show("You entered the wrong email format ! Please enter again", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            if (!regex.IsMatch(txtPhone.Text))
            {
                MessageBox.Show("Phone must be numbers ! Please enter again", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
