using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();
        T GetById(int id);
        List<T> GetListAllByFilter(Expression<Func<T, bool>> filter);

    }
}
