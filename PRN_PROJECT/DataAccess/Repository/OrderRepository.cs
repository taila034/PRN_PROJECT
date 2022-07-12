using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrderList() => OrderDAO.Instance.GetOrderList();
        public Order GetOrderByID(int OrderID) => OrderDAO.Instance.GetOrderByID(OrderID);
        public void AddNew(Order Order) => OrderDAO.Instance.AddNew(Order);
        public void Update(Order Order) => OrderDAO.Instance.Update(Order);
        public void Remove(int OrderId) => OrderDAO.Instance.Remove(OrderId);
        public List<Order> getOrderByAccountID(int id) => OrderDAO.Instance.getOrderByAccountID(id);

    }
}
