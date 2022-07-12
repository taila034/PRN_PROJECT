using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            var orders = new List<OrderDetail>();
            try
            {
                using var context = new SportCourtManagementDBContext();
                orders = context.OrderDetails.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;

        }

        public OrderDetail GetOrderDetailByID(int OrderDetailID)
        {
            OrderDetail or = null;
            try
            {
                using var context = new SportCourtManagementDBContext();
                or = context.OrderDetails.SingleOrDefault(c => c.OrderDetailId == OrderDetailID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return or;
        }



        //public List<double> getTotal(List<OrderDetail> ors)
        //{
        //    List<double> total = new List<double>();
        //    try
        //    {
        //        foreach (var i in ors.OrderByDescending(c => c.))
        //        {

        //            total.Add((double.Parse(i.Quantity.ToString()) * double.Parse(i.UnitPrice.ToString()) * i.Discount) / 100);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return total;
        //}

        public List<OrderDetail> GetOrderDetailByOrderID(int OrderID)
        {
            var orders = new List<OrderDetail>();
            var order = new List<OrderDetail>();
            try
            {
                using var context = new SportCourtManagementDBContext();
                orders = context.OrderDetails.ToList();

                foreach (var item in orders)
                {
                    if (item.OrderId == OrderID)
                    {
                        order.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }

        
        public void AddOrderDetail(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail or = GetOrderDetailByID(OrderDetail.OrderDetailId);
                if (or == null)
                {
                    using var context = new SportCourtManagementDBContext();
                    context.OrderDetails.Add(OrderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
       
        public void UpdateOrderDetail(OrderDetail OrderDetail)
        {
            try
            {
                OrderDetail or = GetOrderDetailByID(OrderDetail.CourtDetailsId);
                if (or != null)
                {
                    using var context = new SportCourtManagementDBContext();
                    context.OrderDetails.Update(OrderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The OrderDetail does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
        public void RemoveOrderDetail(int OrderDetailID)
        {
            try
            {
                OrderDetail or = GetOrderDetailByID(OrderDetailID);
                if (or != null)
                {
                    using var context = new SportCourtManagementDBContext();
                    context.OrderDetails.Remove(or);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The  OrderDetail does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
