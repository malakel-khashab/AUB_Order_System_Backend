using Microsoft.AspNetCore.Mvc;
using Order_System.Interfaces;
using Order_System.Models;
using OrderSystem_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order_System.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_Controller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public Order_Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*
        private IOrderRepo Order_Interface;
        
        public Order_Controller(IOrderRepo Order_Interface_Constructor)
        {
            Order_Interface = Order_Interface_Constructor;
        }
        */
        // GET: api/<Order_Controller>
        [HttpGet]
        public List<OrderDTO> Get()
        {
            var list = _unitOfWork.Order.GetAll().ToList();
            List<OrderDTO> result = new List<OrderDTO>();
            foreach (var item in list)
            {
                result.Add(new OrderDTO
                {
                    OrderId = item.OrderId,
                    Order_Comments = item.Order_Comments,
                    Order_Order_Date = item.Order_Order_Date,
                    Customer_Address = item.Customer_Address,
                    Customer_Country = item.Customer_Country,
                    Customer_Email = item.Customer_Email,
                    Customer_Name = item.Customer_Name,
                    Customer_Phone = item.Customer_Phone,
                    Total = item.Total,

                    //Product_Description=item.orderproduct.Product_Description,
                    //Product_Name=item.orderproduct.Product_Name,
                    //Product_Price=item.orderproduct.Product_Price,
                    //Product_Quantity=item.orderproduct.Product_Quantity,
                    //Total_Product_Price=item.orderproduct.Total_Product_Price
                }) ;
            }
            return result;
        }

        // GET api/<Order_Controller>/5
        [HttpGet("{id}")]
        public OrderDTO Get(int id)
        {
            var order = _unitOfWork.Order.GetAllLazyLoad(null, x => x.orderproducts).FirstOrDefault(x => x.OrderId == id);

            OrderDTO result = new OrderDTO();
            result.OrderId = order.OrderId;
            result.Order_Comments = order.Order_Comments;
            result.Order_Order_Date = order.Order_Order_Date;
            result.Customer_Address = order.Customer_Address;
            result.Customer_Country = order.Customer_Country;
            result.Customer_Email = order.Customer_Email;
            result.Customer_Name = order.Customer_Name;
            result.Customer_Phone = order.Customer_Phone;
            result.Total = order.Total;
            List<OrderProductDTO> list = new List<OrderProductDTO>();

            foreach (var item in order.orderproducts)
            {
                 list.Add(new OrderProductDTO
                {
                    Product_Description = item.Product_Description,
                    Product_Name = item.Product_Name,
                    Product_Price = item.Product_Price,
                    Product_Quantity = item.Product_Quantity,
                    Total_Product_Price = item.Total_Product_Price,
                    ProductId = item.ProductId,
                    OrderId = item.OrderId,
                    Product_Image=item.Product_Image,
                });
            }
            result.OrderProducts = list;
            return result;
        }

        // POST api/<Order_Controller>
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            _unitOfWork.Order.Insert(order);
            _unitOfWork.Complete();

            var entity = _unitOfWork.Order.GetAll().LastOrDefault();
            var cartList = _unitOfWork.Cart.GetAllLazyLoad(null, x => x.product).ToList();
            foreach (var item in cartList)
            {
                OrderProduct orderProduct = new OrderProduct();
                orderProduct.OrderId = entity.OrderId;
                orderProduct.ProductId = item.ProductId;
                orderProduct.Product_Quantity = item.Product_Quantity;
                orderProduct.Total_Product_Price = item.Total_Product_Price;
                orderProduct.Product_Price = item.product.Product_Price;
                orderProduct.Product_Name = item.product.Product_Name;
                orderProduct.Product_Description = item.product.Product_Description;
                orderProduct.Order = order;
                orderProduct.Product_Image = item.product.Product_Image;
                _unitOfWork.OrderProduct.Insert(orderProduct);
                _unitOfWork.Complete();

                _unitOfWork.Cart.Delete(item.CartId);
                _unitOfWork.Complete();

            }
        }

        // PUT api/<Order_Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        {
            Order required = _unitOfWork.Order.GetById(id);
            required.Order_Order_Date = order.Order_Order_Date;
            required.Order_Comments = order.Order_Comments;
            required.Customer_Address = order.Customer_Address;
            required.Customer_Country = order.Customer_Country;
            required.Customer_Email = order.Customer_Email;
            required.Customer_Name = order.Customer_Name;
            required.Customer_Phone = order.Customer_Phone;
            _unitOfWork.Order.Update(required);
            _unitOfWork.Complete();
        }

        // DELETE api/<Order_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Order.Delete(id);
            _unitOfWork.Complete();
        }
    }
}
