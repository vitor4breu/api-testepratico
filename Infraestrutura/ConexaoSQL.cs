using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class ConexaoSQL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ConexaoSQL(IConfiguration configuracao)
        {
            _configuration = configuracao;
            _connectionString = _configuration.GetConnectionString("SqlServer");
        }

        public DbConnection Sql => new SqlConnection(_connectionString);
    }
}
