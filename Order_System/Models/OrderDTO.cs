using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Models
{
    public class OrderDTO
    {
        public int? OrderId { get; set; }
        public DateTime? Order_Order_Date { get; set; }
        public string Order_Comments { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Phone { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_Country { get; set; }
        public string Total { get; set; }

        public List<OrderProductDTO> OrderProducts { get; set; }
    }
}
