using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOrderDetailList() => OrderDetailDAO.Instance.GetOrderDetailList();
        public OrderDetail GetOrderDetailByID(int orderDetailID) => OrderDetailDAO.Instance.GetOrderDetailByID(orderDetailID);
        public List<OrderDetail> GetOrderDetailByOrderID(int OrderID) => OrderDetailDAO.Instance.GetOrderDetailByOrderID(OrderID);
        public void AddOrderDetail(OrderDetail OrderDetail) => OrderDetailDAO.Instance.AddOrderDetail(OrderDetail);
        public void UpdateOrderDetail(OrderDetail OrderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(OrderDetail);
        public void RemoveOrderDetail(int orderDetailID) => OrderDetailDAO.Instance.RemoveOrderDetail(orderDetailID);

    }
}
