using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrderList();
        Order GetOrderByID(int OrderID);
        void AddNew(Order Order);
        void Update(Order Order);
        void Remove(int OrderId);
        List<Order> getOrderByAccountID(int id);


    }
}
