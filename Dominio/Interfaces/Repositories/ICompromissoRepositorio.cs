using Dominio.Models;

namespace Dominio.Interfaces.Repositorios
{
    public interface ICompromissoRepositorio
    {
        public Task<CompromissoDominio> BuscarCompromisso(int idCompromisso);
        public Task<IEnumerable<CompromissoDominio>> BuscarCompromissos();
        public Task<int> InserirCompromisso(CompromissoDominio compromisso);
        public Task<bool> AlterarCompromisso(CompromissoDominio compromisso);
        public Task<bool> ExcluirCompromisso(int idCompromisso);
    }
}
