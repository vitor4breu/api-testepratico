using Dapper;
using Dominio.Interfaces.Repositorios;
using Dominio.Models;
using System.Data.Common;

namespace Infrastructure.Repositories
{
    public class CompromissoRepositorio : ICompromissoRepositorio
    {
        private readonly ConexaoSQL _connection;

        public CompromissoRepositorio(ConexaoSQL connection)
        {
            _connection = connection;
        }


        public async Task<CompromissoDominio> BuscarCompromisso(int idCompromisso)
        {
            using DbConnection connection = _connection.Sql;

            var variaveis = new DynamicParameters();

            variaveis.Add("ID_COMPROMISSO", idCompromisso, System.Data.DbType.Int32);

            const string sqlCommand = @"
                SELECT 
                    ID              AS Id,
                    DATA            AS Data,
                    DATA_INCLUSAO   AS DataInclusao,
                    TEXTO           AS Texto
                FROM COMPROMISSOS
                    WHERE ID = @ID_COMPROMISSO";

            return await connection.QueryFirstOrDefaultAsync<CompromissoDominio>(sqlCommand, variaveis);
        }

        public async Task<IEnumerable<CompromissoDominio>> BuscarCompromissos()
        {
            using DbConnection connection = _connection.Sql;

            const string sqlCommand = @"
                 SELECT 
                    ID              AS Id,
                    DATA            AS Data,
                    DATA_INCLUSAO   AS DataInclusao,
                    TEXTO           AS Texto
                FROM COMPROMISSOS";

            return await connection.QueryAsync<CompromissoDominio>(sqlCommand);
        }

        public async Task<bool> AlterarCompromisso(CompromissoDominio compromisso)
        {
            using DbConnection connection = _connection.Sql;

            var variaveis = new DynamicParameters();

            variaveis.Add("ID", compromisso.Id, System.Data.DbType.Int32);
            variaveis.Add("DATA", compromisso.Data, System.Data.DbType.DateTime);
            variaveis.Add("TEXTO", compromisso.Texto, System.Data.DbType.String, size: 150);

            const string sqlCommand = @"
                 UPDATE COMPROMISSOS SET
                    DATA = @DATA,
                    TEXTO = @TEXTO
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

        public async Task<int> InserirCompromisso(CompromissoDominio compromisso)
        {
            using DbConnection connection = _connection.Sql;

            var variaveis = new DynamicParameters();

            variaveis.Add("DATA", compromisso.Data, System.Data.DbType.DateTime);
            variaveis.Add("DATA_INCLUSAO", DateTime.Now, System.Data.DbType.DateTime);
            variaveis.Add("TEXTO", compromisso.Texto, System.Data.DbType.String, size: 150);

            const string sqlCommand = @"
                INSERT INTO 
                    COMPROMISSOS(DATA, DATA_INCLUSAO, TEXTO)
                    VALUES(@DATA, @DATA_INCLUSAO, @TEXTO)

                SELECT CAST(SCOPE_IDENTITY() AS INT)";

            return await connection.ExecuteScalarAsync<int>(sqlCommand, variaveis);
        }
    }
}
