using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Order> GetOrderList()
        {
            var orders = new List<Order>();
            try
            {
                using var context = new SportCourtManagementDBContext();
                orders = context.Orders.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;

        }

        public Order GetOrderByID(int OrderID)
        {
            Order or = null;
            try
            {
                using var context = new SportCourtManagementDBContext();
                or = context.Orders.SingleOrDefault(c => c.OrderId == OrderID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return or;
        }

       
        public void AddNew(Order Order)
        {
            try
            {
                Order or = GetOrderByID(Order.OrderId);
                if (or == null)
                {
                    using var context = new SportCourtManagementDBContext();
                    context.Orders.Add(Order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
       
        public void Update(Order Order)
        {
            try
            {
                Order or = GetOrderByID(Order.OrderId);
                if (or != null)
                {
                    using var context = new SportCourtManagementDBContext();
                    context.Orders.Update(Order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void Remove(int OrderId)
        {
            try
            {
                Order or = GetOrderByID(OrderId);
                if (or != null)
                {
                    using var context = new SportCourtManagementDBContext();
                    context.Orders.Remove(or);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Order> getOrderByAccountID(int id)
        {
            var or = GetOrderList();
            List<Order> orders = new List<Order>();
            try
            {
                foreach (var i in or)
                {
                    if (i.AccountId == id)
                    {
                        orders.Add(i);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }
    }
}
