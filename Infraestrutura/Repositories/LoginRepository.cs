using Dapper;
using Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SqlConnection _connection;

        public LoginRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> SelectLogin(string username, string password)
        {
            using DbConnection connection = _connection.Sql;
            var variables = new DynamicParameters();

            variables.Add("username", username, System.Data.DbType.String, size: 30);
            variables.Add("password", password, System.Data.DbType.String, size: 30);

            const string sqlCommand = @"
                SELECT 1 FROM tb_usuarios 
                WHERE username = @username AND password = @password
            ";
            var sqlConsult = await connection.QueryFirstOrDefaultAsync<string>(sqlCommand, variables);
            return sqlConsult != null;
        }
    }
}
