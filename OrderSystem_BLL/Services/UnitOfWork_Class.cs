using Order_System.DAL;
using Order_System.Interfaces;
using Order_System.Repository;
using OrderSystem_BLL.Services;
using OrderSystem_DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System
{
    public class UnitOfWork_Class : IUnitOfWork
    {
        private readonly Order_System_Context DBcontext;
        public UnitOfWork_Class(Order_System_Context DBcontext)
        {
            this.DBcontext = DBcontext;
            Customer = new Customer_RepoClass(DBcontext);
            Product = new ProductService(DBcontext);
            Order = new Order_RepoClass(DBcontext);
            Cart = new Cart_RepoClass(DBcontext);
            OrderProduct = new OrderProduct_RepoClass(DBcontext);
        }
        public ICustomerRepo Customer { get; private set; }

        public IProductRepo Product { get; private set; }

        public IOrderRepo Order { get; private set; }
        public IOrderProductRepo OrderProduct { get; private set; }
        public ICartRepo Cart { get; private set; }

        public int Complete()
        {
            return DBcontext.SaveChanges();
        }

        public void Dispose()
        {
            DBcontext.Dispose();
        }
    }
}
