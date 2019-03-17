using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Leagueen.Persistence.Connections
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
        IDbConnection CreateConnection(string connectionString);
    }

    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = configuration.GetConnectionString(PersistenceConstants.AppConnectionString);
            return CreateConnection(connectionString);
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
