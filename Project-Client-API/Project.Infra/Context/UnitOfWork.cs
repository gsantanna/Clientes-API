using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace Project.Infra.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbContext _context;
        private readonly IConfiguration _configuration;
        public SqlTransaction Transaction { get; private set; }

        public void Commit()
        {
            if (Transaction != null)
            {
                try
                {
                    Transaction.Commit();
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                }
                Transaction.Dispose();
                Transaction = null;
            }
            else
            {
                throw new NullReferenceException("Não encontrou transação aberta.");
            }
        }

        public IDbContext DataContext => _context ??= new DbContext(_configuration);

        public SqlTransaction BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new NullReferenceException("Transação não finalizada");
            }

            Transaction = _context.Connection.BeginTransaction();
            return Transaction;
        }


        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
