using BusinessObject.Models;
using BusinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CartDAO
    {
        private static SportCourtManagementDBContext instance = null;
        private static readonly object instanceLock = new object();
        public static SportCourtManagementDBContext Instance
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
        

    }
}
