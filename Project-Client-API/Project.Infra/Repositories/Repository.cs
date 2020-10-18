using Project.Domain.Interfaces;
using Project.Infra.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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
                _unitOfWork.BeginTransaction();

                MapAddCommandParameters(obj, SqlCommand);
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
            return MapGetAllCommandParameters(SqlCommand);
        }

        public TEntity Get(long id)
        {
            return MapGetByIdCommandParameters(SqlCommand, id);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.BeginTransaction();

            MapUpdateCommandParameters(entity, SqlCommand);
            SqlCommand.ExecuteNonQuery();

            _unitOfWork.Commit();
        }

        public void Remove(TEntity entity)
        {
            _unitOfWork.BeginTransaction();

            MapRemoveCommandParameters(entity, SqlCommand);
            SqlCommand.ExecuteNonQuery();

            _unitOfWork.Commit();
        }

        public virtual void MapAddCommandParameters(TEntity entity, SqlCommand sqlCommand) { }
        public virtual void MapUpdateCommandParameters(TEntity entity, SqlCommand sqlCommand) { }
        public virtual void MapRemoveCommandParameters(TEntity entity, SqlCommand sqlCommand) { }
        public virtual TEntity MapGetByIdCommandParameters(SqlCommand sqlCommand, long id) { return null; }
        public virtual IEnumerable<TEntity> MapGetAllCommandParameters(SqlCommand sqlCommand) { return null; }
    }
}
