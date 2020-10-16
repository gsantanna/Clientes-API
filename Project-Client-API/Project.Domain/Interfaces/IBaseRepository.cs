using System;
using System.Linq;

namespace Project.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
