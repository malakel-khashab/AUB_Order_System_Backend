using Microsoft.EntityFrameworkCore;
using Order_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order_System.Generic_repository
{
    public class GenericRepository_Class<T> : IGenericRepository<T> where T : class
    {
        private readonly Order_System_Context DB_Context;
        public GenericRepository_Class(Order_System_Context DB_Context_Constructor)
        {
            DB_Context = DB_Context_Constructor;
        }
        public void Delete(object id)
        {
            T required = DB_Context.Set<T>().Find(id);
            DB_Context.Set<T>().Remove(required);
        }

        public IEnumerable<T> GetAll()
        {
            return DB_Context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return DB_Context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            DB_Context.Set<T>().Add(obj);
        }

        public void Update(T obj)
        {
            DB_Context.Set<T>().Attach(obj);
            DB_Context.Entry(obj).State = EntityState.Modified;
        }
        public virtual IQueryable<T> GetAllLazyLoad(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children)
        {

            children.ToList().ForEach(x => DB_Context.Set<T>().Include(x).Load());
            return DB_Context.Set<T>();
        }

    }
}
