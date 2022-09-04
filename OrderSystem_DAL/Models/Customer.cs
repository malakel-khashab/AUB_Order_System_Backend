using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Password { get; set; }
        public string Customer_First_Name { get; set; }
        public string Customer_Last_Name { get; set; }
        public string Customer_Phone_Number { get; set; }
        public string Customer_Address_Line_1 { get; set; }
        public string Customer_City { get; set; }
        public string Customer_Country { get; set; }


    }
}
