using Order_System.DAL;
using Order_System.Generic_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Repository
{
    public class Customer_RepoClass : GenericRepository_Class<Customer>, ICustomerRepo
    {
        public Customer_RepoClass(Order_System_Context context) : base(context)
            {

            }
            /*
            private readonly Order_System_Context DB_Context;
            public Customer_Class(Order_System_Context DB_Context_Constructor)
            {
                DB_Context = DB_Context_Constructor;
            }

            public void Delete(int Customer_ID)
            {
                Customer required = DB_Context.Customers.FirstOrDefault(a => a.CustomerId == Customer_ID);
                DB_Context.Remove(required);
                DB_Context.SaveChanges();
            }

            public List<Customer> GetAll()
            {
                return DB_Context.Customers.ToList();
            }

            public Customer GetById(int Customer_ID)
            {
                return DB_Context.Customers.FirstOrDefault(a => a.CustomerId == Customer_ID);
            }

            public void Insert(Customer customer)
            {
                DB_Context.Remove(customer);
                DB_Context.SaveChanges();
            }

            public void Update(int Customer_ID, Customer customer)
            {
                Customer required = DB_Context.Customers.FirstOrDefault(a => a.CustomerId == Customer_ID);
                required.Customer_Address_Line_1 = customer.Customer_Address_Line_1;
                required.Customer_City = customer.Customer_City;
                required.Customer_Country = customer.Customer_Country;
                required.Customer_Email = customer.Customer_Email;
                required.Customer_First_Name = customer.Customer_First_Name;
                required.Customer_Last_Name = customer.Customer_Last_Name;
                required.Customer_Password = customer.Customer_Password;
                required.Customer_Phone_Number = customer.Customer_Phone_Number;
                DB_Context.SaveChanges();
            }
            */
        }

}
