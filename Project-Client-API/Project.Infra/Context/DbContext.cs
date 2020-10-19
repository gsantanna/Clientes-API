using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Project.Infra.Context
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;
        private readonly IConfiguration _configuration;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClientesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public SqlCommand Command
        {
            get
            {
                return Connection.CreateCommand();
            }
        }

        public SqlConnection Connection
        {
            get
            {
                if (_sqlConnection == null)
                    _sqlConnection = new SqlConnection(_connectionString);

                if (_sqlConnection.State != ConnectionState.Open)
                    _sqlConnection.Open();

                return _sqlConnection;
            }
        }

        public void Dispose()
        {
            if (_sqlConnection != null && _sqlConnection.State == ConnectionState.Open)
                _sqlConnection.Close();
        }
    }
}
