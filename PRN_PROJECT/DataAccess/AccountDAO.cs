using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        private static SportCourtManagementDBContext instance = null;
        private static readonly object instanceLock = new object();
        public static SportCourtManagementDBContext InstanceAccountDAO
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SportCourtManagementDBContext();
                    }
                    return instance;
                }
            }
        }
        public static List<Account> GetAccounts()
        {
            var listAccounts = new List<Account>();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    listAccounts = db.Accounts.ToList();
                }
            }
            catch (Exception e) { }
            return listAccounts;
        }
        public static Account GetAccountById(int id)
        {
            var account = new Account();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    account = db.Accounts.Find(id);
                }
            }
            catch (Exception e) { }
            return account;
        }

        public static void AddAccount(Account acc)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    context.Accounts.Add(acc);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateAccount(Account acc)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    context.Entry<Account>(acc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteAccount(Account acc)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    var p1 = context.Accounts.SingleOrDefault(mem => mem.AccountId == acc.AccountId);
                    context.Accounts.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
