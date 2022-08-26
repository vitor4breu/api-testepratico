using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Infrastructure
{
    public class SqlConnection
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SqlConnection(IConfiguration configuracao)
        {
            _configuration = configuracao;
            _connectionString = _configuration.GetConnectionString("PostgreSql");
        }

        public DbConnection Sql => new NpgsqlConnection(_connectionString);
    }
}
