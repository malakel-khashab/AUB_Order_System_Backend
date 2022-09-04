using OrderSystem_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Order_Order_Date { get; set; }
        public string Order_Comments { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Phone { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_Country { get; set; }
        public string Total { get; set; }
        public virtual List<OrderProduct> orderproducts { get; set; }
    }
}
