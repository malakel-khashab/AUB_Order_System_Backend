namespace Order_System.Models
{
    public class OrderProductDTO
    {
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public string Product_Image{ get; set; }
        public string Product_Price { get; set; }
        public string Product_Quantity { get; set; }
        public string Total_Product_Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}