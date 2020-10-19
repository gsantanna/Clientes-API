using Project.Domain.Interfaces;
using Project.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project.Infra.Repositories
{
    public abstract class Repository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly SqlConnection SqlConnection;
        protected readonly SqlCommand SqlCommand;
        protected SqlDataReader SqlDataReader = null;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");

            SqlConnection = unitOfWork.DataContext.Connection;
            SqlCommand = unitOfWork.DataContext.Command;
        }

        public void Add(TEntity obj)
        {
            try
            {
                SqlCommand.Transaction = _unitOfWork.BeginTransaction();

                MapAddCommandParameters(obj);
                SqlCommand.ExecuteNonQuery();

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return MapGetAllCommandParameters();
        }

        public TEntity Get(long id)
        {
            return MapGetByIdCommandParameters(id);
        }

        public void Update(TEntity entity)
        {
            SqlCommand.Transaction = _unitOfWork.BeginTransaction();

            MapUpdateCommandParameters(entity);
            SqlCommand.ExecuteNonQuery();

            _unitOfWork.Commit();
        }

        public void Remove(TEntity entity)
        {
            SqlCommand.Transaction = _unitOfWork.BeginTransaction();

            MapRemoveCommandParameters(entity);
            SqlCommand.ExecuteNonQuery();

            _unitOfWork.Commit();
        }

        public virtual void MapAddCommandParameters(TEntity entity) { }
        public virtual void MapUpdateCommandParameters(TEntity entity) { }
        public virtual void MapRemoveCommandParameters(TEntity entity) { }
        public virtual TEntity MapGetByIdCommandParameters(long id) { return null; }
        public virtual IEnumerable<TEntity> MapGetAllCommandParameters() { return null; }

        public void Dispose()
        {
            _unitOfWork.DataContext.Dispose();
            SqlCommand.Dispose();
            SqlConnection.Close();
        }
    }
}
