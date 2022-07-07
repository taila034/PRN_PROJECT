using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAccountRepository
    {
        void AddAccount(Account acc);
        void DeleteAccount(Account acc);
        void UpdateAccount(Account acc);
        List<Account> GetAccounts();
        Account GetAccountById(int id);
    }
}
