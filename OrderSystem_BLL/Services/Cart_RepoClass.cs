using Order_System.DAL;
using Order_System.Generic_repository;
using OrderSystem_DAL.Contracts;
using OrderSystem_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem_BLL.Services
{
    public class Cart_RepoClass : GenericRepository_Class<Cart>, ICartRepo
    {
            public Cart_RepoClass(Order_System_Context context) : base(context)
            {

            }
        }
}
