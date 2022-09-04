using Microsoft.AspNetCore.Mvc;
using Order_System.Interfaces;
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
    public class OrderProduct_Controller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderProduct_Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<OrderProduct_Controller>
        [HttpGet]
        public List<OrderProduct> Get()
        {
            return _unitOfWork.OrderProduct.GetAll().ToList();
        }

        // GET api/<OrderProduct_Controller>/5
        [HttpGet("{id}")]
        public OrderProduct Get(int id)
        {
            return _unitOfWork.OrderProduct.GetById(id);
        }

        // POST api/<OrderProduct_Controller>
        [HttpPost]
        public void Post([FromBody] OrderProduct orderProduct)
        {
            _unitOfWork.OrderProduct.Insert(orderProduct);
            _unitOfWork.Complete();
        }

        // PUT api/<OrderProduct_Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderProduct orderProduct)
        {
            OrderProduct required = _unitOfWork.OrderProduct.GetById(id);
            required.Product_Description = orderProduct.Product_Description;
            required.Product_Name = orderProduct.Product_Name;
            required.Product_Price = orderProduct.Product_Price;
            required.Product_Quantity = orderProduct.Product_Quantity;
            required.Total_Product_Price = orderProduct.Total_Product_Price;
            required.Product_Image = orderProduct.Product_Image;
            _unitOfWork.OrderProduct.Update(required);
            _unitOfWork.Complete();
        }

        // DELETE api/<OrderProduct_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.OrderProduct.Delete(id);
            _unitOfWork.Complete();
        }
    }
}
