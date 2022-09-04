﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Models
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public string Product_Price { get; set; }
        public string Product_Quantity { get; set; }
        public string Total_Product_Price { get; set; }

        public int ProductId { get; set; }
    }
}
