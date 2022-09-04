using Order_System.Generic_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Repository
{
    public interface IOrderRepo: IGenericRepository<Order>
    {
        /*
        public List<Order> GetAll();
        public Order GetById(int Order_ID);
        public void Insert(Order order);
        public void Update(int Order_ID, Order order);
        public void Delete(int Order_ID);
        */
    }
}
