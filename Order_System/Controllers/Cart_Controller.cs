using Microsoft.AspNetCore.Mvc;
using Order_System.Interfaces;
using Order_System.Models;
using OrderSystem_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cart_Controller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public Cart_Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<Cart_Controller>
        [HttpGet]
        public List<CartDTO> Get()
        {
            var list = _unitOfWork.Cart.GetAllLazyLoad(null,x=>x.product).ToList();
            List<CartDTO> result = new List<CartDTO>();
            foreach (var item in list)
            {
                result.Add(new CartDTO
                {
                    CartId = item.CartId,
                    ProductId = item.ProductId,
                    Product_Description = item.product.Product_Description,
                    Product_Name = item.product.Product_Name,
                    Product_Price=item.product.Product_Price,
                    Product_Quantity=item.Product_Quantity,
                    Total_Product_Price=item.Total_Product_Price
                }) ;
            }
            return result;
        }

        // GET api/<Cart_Controller>/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            return _unitOfWork.Cart.GetById(id);
        }

        // POST api/<Cart_Controller>
        [HttpPost]
        public void Post([FromBody] Cart cart)
        {
            _unitOfWork.Cart.Insert(cart);
            _unitOfWork.Complete();
        }

        // PUT api/<Cart_Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cart cart)
        {
            Cart required = _unitOfWork.Cart.GetById(id);
           // required.Product_Description = cart.Product_Description;
           // required.Product_Name = cart.Product_Name;
           // required.Product_Price = cart.Product_Price;
            required.Product_Quantity = cart.Product_Quantity;
            required.Total_Product_Price = cart.Total_Product_Price;
            _unitOfWork.Cart.Update(required);
            _unitOfWork.Complete();
        }

        // DELETE api/<Cart_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Cart.Delete(id);
            _unitOfWork.Complete();
        }
    }
}
