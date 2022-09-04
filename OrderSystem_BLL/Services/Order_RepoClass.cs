using Order_System.DAL;
using Order_System.Generic_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Repository
{
    public class Order_RepoClass : GenericRepository_Class<Order>, IOrderRepo
    {

        public Order_RepoClass(Order_System_Context context) : base(context)
        {

        }
        /*
        private readonly Order_System_Context DB_Context;
        public I_Order_Class(Order_System_Context DB_Context_Constructor)
        {
            DB_Context = DB_Context_Constructor;
        }
        public void Delete(int Order_ID)
        {
            Order required = DB_Context.Orders.FirstOrDefault(a => a.OrderId == Order_ID);
            DB_Context.Remove(required);
            DB_Context.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return DB_Context.Orders.ToList();
        }

        public Order GetById(int Order_ID)
        {
            return DB_Context.Orders.FirstOrDefault(a => a.OrderId == Order_ID);
        }

        public void Insert(Order order)
        {
            DB_Context.Add(order);
            DB_Context.SaveChanges();
        }

        public void Update(int Order_ID, Order order)
        {
            Order required = DB_Context.Orders.FirstOrDefault(a => a.OrderId == Order_ID);
            required.CustomerId = order.CustomerId;
            required.ProductId = order.ProductId;
            required.Order_Status = order.Order_Status;
            required.Order_Order_Date = order.Order_Order_Date;
            required.Order_Quantity = order.Order_Quantity;
            required.Order_Comments = order.Order_Comments;
            required.Order_Shipping_Date = order.Order_Shipping_Date;
            DB_Context.SaveChanges();

        }
        */
    }
}
