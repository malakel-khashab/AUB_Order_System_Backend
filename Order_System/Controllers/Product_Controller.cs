using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Order_System.Helper;
using Order_System.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order_System.Repository
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class Product_Controller : ControllerBase
    {
        private IWebHostEnvironment _hostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public Product_Controller(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = environment;

        }
       
        /*
        private IProductRepo Product_Interface;

        public Product_Controller(IProductRepo Product_Interface_Constructor)
        {
            Product_Interface = Product_Interface_Constructor;
        }
        */

        // GET: api/<Product_Controller>
        [HttpGet]
        public List<Product> Get()
        {
            return _unitOfWork.Product.GetAll().ToList();
        }

        // GET api/<Product_Controller>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _unitOfWork.Product.GetById(id);
        }

        // POST api/<Product_Controller>
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            byte[] image =Convert.FromBase64String(product.Product_Image.Split(',')[1]);
            string path = Path.Combine(Path.Combine(_hostEnvironment.WebRootPath, "images"), product.Product_Name+".png");
            UploaderImagesHelper.SaveByteArrayToFileWithStaticMethod(image, path);
            product.Product_Image = "images/"+product.Product_Name + ".png";
            _unitOfWork.Product.Insert(product);
            _unitOfWork.Complete();
        }

        // PUT api/<Product_Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var entity= _unitOfWork.Product.GetById(id);
            entity.Product_Category = product.Product_Category;
            entity.Product_Description = product.Product_Description;
            entity.Product_Name = product.Product_Name;
            entity.Product_Price = product.Product_Price;
            entity.Product_Image = product.Product_Image;
            _unitOfWork.Product.Update(entity);
            _unitOfWork.Complete();
        }

        // DELETE api/<Product_Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.Product.Delete(id);
            _unitOfWork.Complete();
        }
    }
}
