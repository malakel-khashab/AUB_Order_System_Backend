using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Order_System.Generic_repository
{
    public interface IGenericRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(object id);
        public void Insert(T obj);
        public void Update(T obj1);
        public void Delete(object id);
        IQueryable<T> GetAllLazyLoad(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children);
    }
}
