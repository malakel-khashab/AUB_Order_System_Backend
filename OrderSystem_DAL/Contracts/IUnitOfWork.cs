using Order_System.Repository;
using OrderSystem_DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_System.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         ICustomerRepo Customer { get; }
         IProductRepo Product { get; }
         IOrderRepo Order { get; }
        IOrderProductRepo OrderProduct { get; }
        ICartRepo Cart { get; }

        int Complete();
    }
}
