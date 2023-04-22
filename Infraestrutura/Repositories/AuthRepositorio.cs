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
    public class AuthRepositorio : IAuthRepositorio
    {
        private readonly ConexaoSQL _connection;

        public AuthRepositorio(ConexaoSQL connection)
        {
            _connection = connection;
        }

        public async Task<bool> ObterUsuarioAutenticado(string usuario, string senha)
        {
            using DbConnection connection = _connection.Sql;
            var variables = new DynamicParameters();

            variables.Add("USUARIO", usuario, System.Data.DbType.String, size: 30);
            variables.Add("SENHA", senha, System.Data.DbType.String, size: 30);

            const string sqlCommand = @"
                SELECT 1 FROM usuarios
                WHERE usuario = @USUARIO AND senha = @SENHA
            ";
            var sqlConsult = await connection.QueryFirstOrDefaultAsync<string>(sqlCommand, variables);
            return sqlConsult != null;
        }
    }
}
