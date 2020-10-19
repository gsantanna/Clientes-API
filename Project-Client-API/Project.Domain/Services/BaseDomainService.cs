using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Project.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public TEntity GetById(long id)
        {
            return repository.Get(id);
        }


        public List<TEntity> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
