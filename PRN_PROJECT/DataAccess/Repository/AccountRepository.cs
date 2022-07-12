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
        public void AddAccount(Account acc) => AccountDAO.Instance.AddAccount(acc);
        public void UpdateAccount(Account acc) => AccountDAO.Instance.UpdateAccount(acc);
        public void DeleteAccount(Account acc) => AccountDAO.Instance.DeleteAccount(acc);
        public List<Account> GetAccounts() => AccountDAO.Instance.GetAccounts();
        public Account GetAccountById(int id) => AccountDAO.Instance.GetAccountById(id);


    }
}
