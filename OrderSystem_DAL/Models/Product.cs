using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Product_Name { get; set; }
        public string Product_Category { get; set; }
        public string Product_Description { get; set; }
        public string Product_Price { get; set; }
        public string Product_Image  { get; set; }


    }
}
