using System.Data.SqlClient;

namespace Project.Infra.Context
{
    public interface IDbContext
    {
        SqlConnection Connection { get; }
        SqlCommand Command { get; }
        void Dispose();
    }
}
