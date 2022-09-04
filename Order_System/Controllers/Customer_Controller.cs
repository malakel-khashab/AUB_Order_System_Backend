using Microsoft.AspNetCore.Mvc;
using Order_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order_System.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_Controller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public Customer_Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /*
        private I_Customer Customer_Interface;

        public Customer_Controller(I_Customer Customer_Interface_Constructor)
        {
            Customer_Interface = Customer_Interface_Constructor;
        }
        */
        // GET: api/<Customer_Controller>
        [HttpGet]
        public List<Customer> Get()
        {
            return _unitOfWork.Customer.GetAll().ToList();
        }

        // GET api/<Customer_Controller>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _unitOfWork.Customer.GetById(id);
        }

        // POST api/<Customer_Controller>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _unitOfWork.Customer.Insert(customer);
            _unitOfWork.Complete();
        }

        // PUT api/<Customer_Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            Customer required = _unitOfWork.Customer.GetById(id);
            required.Customer_Address_Line_1 = customer.Customer_Address_Line_1;
            required.Customer_City = customer.Customer_City;
            required.Customer_Country = customer.Customer_Country;
            required.Customer_Email = customer.Customer_Email;
            required.Customer_First_Name = customer.Customer_First_Name;
            required.Customer_Last_Name = customer.Customer_Last_Name;
            required.Customer_Password = customer.Customer_Password;
            required.Customer_Phone_Number = customer.Customer_Phone_Number;
            _unitOfWork.Customer.Update(required);
            _unitOfWork.Complete();
        }

        // DELETE api/<Customer_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Customer.Delete(id);
            _unitOfWork.Complete();
        }
    }
}
