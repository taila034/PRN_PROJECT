using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void DeleteAccount(Account acc) => AccountDAO.DeleteAccount(acc);
        public void AddAccount(Account acc) => AccountDAO.AddAccount(acc);
        public void UpdateAccount(Account acc) => AccountDAO.UpdateAccount(acc);
        public List<Account> GetAccounts() => AccountDAO.GetAccounts();
        public Account GetAccountById(int id) => AccountDAO.GetAccountById(id);
    }
}
