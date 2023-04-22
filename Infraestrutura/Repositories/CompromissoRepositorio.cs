using Domain.Interfaces.Repositorios;
using System.Data.Common;
using Dapper;
using Domain.Models;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CompromissoRepositorio : ICompromissoRepositorio
    {
        private readonly ConexaoSQL _connection;

        public CompromissoRepositorio(ConexaoSQL connection)
        {
            _connection = connection;
        }


        public async Task<IEnumerable<CompromissoDominio>> BuscarCompromissosPorUsuario(int idUsuario)
        {
            using DbConnection connection = _connection.Sql;

            var variaveis = new DynamicParameters();

            variaveis.Add("ID_USUARIO", idUsuario, System.Data.DbType.Int32);

            const string sqlCommand = @"
                SELECT 
                    ID              AS Id,
                    DATA            AS Data,
                    DATA_INCLUSAO   AS DataInclusao,
                    TEXTO           AS Texto,
                    ID_USUARIO      AS IdUsuario
                FROM COMPROMISSOS
                    WHERE ID_USUARIO = @ID_USUARIO";

            return await connection.QueryAsync<CompromissoDominio>(sqlCommand, variaveis);
        }

        public async Task<IEnumerable<CompromissoDominio>> BuscarCompromissos()
        {
            using DbConnection connection = _connection.Sql;

            const string sqlCommand = @"
                 SELECT 
                    ID              AS Id,
                    DATA            AS Data,
                    DATA_INCLUSAO   AS DataInclusao,
                    TEXTO           AS Texto,
                    ID_USUARIO      AS IdUsuario
                FROM COMPROMISSOS";

            return await connection.QueryAsync<CompromissoDominio>(sqlCommand);
        }

        public async Task<IEnumerable<CompromissoDominio>> BuscarCompromisso(int idCompromisso)
        {
            using DbConnection connection = _connection.Sql;

            var variaveis = new DynamicParameters();

            variaveis.Add("ID", idCompromisso, System.Data.DbType.Int32);

            const string sqlCommand = @"
                SELECT 
                    ID              AS Id,
                    DATA            AS Data,
                    DATA_INCLUSAO   AS DataInclusao,
                    TEXTO           AS Texto,
                    ID_USUARIO      AS IdUsuario
                FROM COMPROMISSOS
                    WHERE ID = @ID";

            return await connection.QueryAsync<CompromissoDominio>(sqlCommand, variaveis);

        }

        public async Task<bool> AlterarCompromisso(CompromissoDominio compromisso)
        {
            using DbConnection connection = _connection.Sql;

            var variaveis = new DynamicParameters();

            variaveis.Add("ID", compromisso.Id, System.Data.DbType.Int32);
            variaveis.Add("DATA", compromisso.Data, System.Data.DbType.DateTime);
            variaveis.Add("TEXTO", compromisso.Texto, System.Data.DbType.String, size: 150);
            variaveis.Add("ID_USUARIO", compromisso.IdUsuario, System.Data.DbType.Int32);

            const string sqlCommand = @"
                 UPDATE COMPROMISSOS SET
                    DATA = @DATA,
                    TEXTO = @TEXTO
                    ID_USUARIO = @ID_USUARIO
                WHERE ID = @ID";

            return await connection.ExecuteAsync(sqlCommand, variaveis) > 0;
        }

        public async Task<bool> ExcluirCompromisso(int idCompromisso)
        {
            using DbConnection connection = _connection.Sql;

            var variaveis = new DynamicParameters();

            variaveis.Add("ID_COMPROMISSO", idCompromisso, System.Data.DbType.Int32);

            const string sqlCommand = @"
                DELETE FROM COMPROMISSOS 
                    WHERE ID = @ID_COMPROMISSO";

            return await connection.ExecuteAsync(sqlCommand, variaveis) > 0;
        }

        public async Task<bool> InserirCompromisso(CompromissoDominio compromisso)
        {
            using DbConnection connection = _connection.Sql;

            var variaveis = new DynamicParameters();

            variaveis.Add("DATA", compromisso.Data, System.Data.DbType.DateTime);
            variaveis.Add("DATA_INCLUSAO", DateTime.Now, System.Data.DbType.DateTime);
            variaveis.Add("TEXTO", compromisso.Texto, System.Data.DbType.String, size: 150);
            variaveis.Add("ID_USUARIO", compromisso.IdUsuario, System.Data.DbType.Int32);

            const string sqlCommand = @"
                INSERT INTO 
                    COMPROMISSOS(DATA, DATA_INCLUSAO, TEXTO, ID_USUARIO)
                    VALUES(@DATA, @DATA_INCLUSAO, @TEXTO, @ID_USUARIO)";

            return await connection.ExecuteAsync(sqlCommand, variaveis) > 0;
        }
    }
}
