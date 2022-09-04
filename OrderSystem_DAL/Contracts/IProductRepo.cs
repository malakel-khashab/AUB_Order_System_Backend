using Order_System.Generic_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Repository
{
    public interface IProductRepo : IGenericRepository<Product>
    { 
        /*
        public List<Product> GetAll();
        public Product GetById(int Product_ID);
        public void Insert(Product product);
        public void Update(int Product_ID, Product product);
        public void Delete(int Product_ID);
        */

    }
}
