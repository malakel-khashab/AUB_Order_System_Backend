using Order_System.DAL;
using Order_System.Generic_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Repository
{
    public class ProductService : GenericRepository_Class<Product>, IProductRepo
    {

        public ProductService(Order_System_Context context) : base(context)
        {

        }
        /*
        private readonly Order_System_Context DB_Context;
        public Product_Class(Order_System_Context DB_Context_Constructor) 
        {
            DB_Context = DB_Context_Constructor;
        }
        public void Delete(int Product_ID)
        {
            Product required = DB_Context.Products.FirstOrDefault(a => a.ProductId == Product_ID);
            DB_Context.Remove(required);
            DB_Context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return DB_Context.Products.ToList();
        }

        public Product GetById(int Product_ID)
        {
            return  DB_Context.Products.FirstOrDefault(a => a.ProductId == Product_ID);
        }

        public void Insert(Product product)
        {
            DB_Context.Add(product);
            DB_Context.SaveChanges();
        }

        public void Update(int Product_ID, Product product)
        {
            Product required = DB_Context.Products.FirstOrDefault(a => a.ProductId == Product_ID);
            required.Product_Category = product.Product_Category;
            required.Product_Description = product.Product_Description;
            required.Product_Name = product.Product_Name;
            required.Product_Price = product.Product_Price;
            DB_Context.SaveChanges();
        }
        */
    }
}
