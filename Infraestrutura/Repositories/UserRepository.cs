using Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<User>> SelectUsers()
        {
            using DbConnection connection = _connection.Sql;

            const string sqlCommand = "SELECT Username, Id FROM tb_usuarios";

            return await connection.QueryAsync<User>(sqlCommand);
        }
    }
}
