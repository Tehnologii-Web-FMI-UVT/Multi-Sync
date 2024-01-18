using AspNetCore.Identity.Dapper;

using Microsoft.Extensions.Configuration;

using Npgsql;

using System.Data;

namespace DataLayer
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public string ConnectionString { get; set; }

        public DbConnectionFactory(IConfiguration configuration)
        {
            ConnectionString = configuration["Database:ConnectionString"];
        }

        public IDbConnection Create()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
