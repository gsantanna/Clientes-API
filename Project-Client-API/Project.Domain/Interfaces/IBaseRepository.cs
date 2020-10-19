using System;
using System.Collections.Generic;

namespace Project.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
    }
}
