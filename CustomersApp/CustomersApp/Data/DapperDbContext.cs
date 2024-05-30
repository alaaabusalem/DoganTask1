using Microsoft.Data.SqlClient;
using System.Data;

namespace CustomersApp.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public DapperDbContext(IConfiguration config)
        {
            this._configuration = config;
            this.connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
