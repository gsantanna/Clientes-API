using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Project.Infra.Context
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public DbContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
        }

        public SqlCommand Command
        {
            get
            {
                return new SqlCommand();
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
