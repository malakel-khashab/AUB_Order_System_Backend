using Order_System;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem_DAL.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        //public string Product_Name { get; set; }
          //public string Product_Description { get; set; }
         //public string Product_Price { get; set; }
        public string Product_Quantity { get; set; }
        public string Total_Product_Price { get; set; }

        public int ProductId { get; set; }

        public virtual Product product { get; set; }

    }
}
