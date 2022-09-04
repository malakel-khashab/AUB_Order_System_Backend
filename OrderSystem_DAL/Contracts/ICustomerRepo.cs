using Order_System.Generic_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Repository
{
    public interface ICustomerRepo : IGenericRepository<Customer>
    {
        /*
        public List<Customer> GetAll();
        public Customer GetById(int Customer_ID);
        public void Insert(Customer customer);
        public void Update(int Customer_ID, Customer customer);
        public void Delete(int Customer_ID);
        */
    }
}
