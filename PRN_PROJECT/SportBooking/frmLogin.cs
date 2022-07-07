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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        IAccountRepository accountRepository = new AccountRepository();
        ICourtRepository courtRepository = new CourtRepository();
        public Account AccountInfo { get; set; }
        



        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            //check user account
            var accounts = accountRepository.GetAccounts();
            bool isAdmin = false;
            bool flag = false;
            Account acc = null;

            foreach (var account in accounts)
            {
                if (account.Email == txtEmail.Text && account.Password == txtPassword.Text && account.Role == "Customer")
                {
                    
                    acc = account;
                    flag = true;
                    break;
                }
                if (account.Email == txtEmail.Text && account.Password == txtPassword.Text && account.Role == "Admin")
                {

                    acc = account;
                    isAdmin = true;
                    flag = true;
                    break;
                }
  

            }


            if (isAdmin && flag)
            {

                frmMain frmMain = new frmMain()
                {
                    AccountInfo = acc,
                    AccountRepository = accountRepository,
                    isCustomer = false,
                    CourtRepository = courtRepository
                };
                frmMain.ShowDialog();

            }
            else if (!isAdmin && flag)
            {
                frmMain frmMain = new frmMain()
                {
                    AccountInfo = acc,
                    AccountRepository = accountRepository,
                    isCustomer = true,
                    CourtRepository = courtRepository
                };
                frmMain.ShowDialog();

            }

            else
            {
                MessageBox.Show("Incorrect email or password please enter again");

            }
        }
    }
}
