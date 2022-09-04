using Microsoft.EntityFrameworkCore;
using OrderSystem_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.DAL
{
    public class Order_System_Context : DbContext
    {
        public Order_System_Context(DbContextOptions<Order_System_Context> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderProduct>().ToTable("OrderProduct");
            modelBuilder.Entity<Cart>().ToTable("Cart");
        }
    }
}
