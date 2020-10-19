using System;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity> : IDisposable
        where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        List<TEntity> GetAll();
        TEntity GetById(long id);
    }
}
