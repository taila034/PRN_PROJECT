using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetailList();
        OrderDetail GetOrderDetailByID(int orderDetailID);
        List<OrderDetail> GetOrderDetailByOrderID(int OrderID);
        void AddOrderDetail(OrderDetail OrderDetail);
        void UpdateOrderDetail(OrderDetail OrderDetail);
        void RemoveOrderDetail(int orderDetailID);

    }
}
