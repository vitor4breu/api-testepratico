using Infrastructure.Configuracoes;
using System.Data.Common;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class ConexaoSQL
    {
        private readonly string _connectionString;

        public ConexaoSQL(ConfiguracaoBancoDeDados configuracaoRepositorio)
        {
            _connectionString = configuracaoRepositorio.SQLConnectionString;
        }

        public DbConnection Sql => new SqlConnection(_connectionString);
    }
}
