using System.Data.SqlClient;

namespace Project.Infra.Context
{
    public interface IUnitOfWork
    {
        IDbContext DataContext { get; }
        SqlTransaction BeginTransaction();

        void Commit();
    }
}
