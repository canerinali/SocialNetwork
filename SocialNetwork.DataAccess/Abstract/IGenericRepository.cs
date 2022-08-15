using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface IGenericRepository<T>
    {
        T GetById(Guid id);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
