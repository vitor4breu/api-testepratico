using Domain.Models;

namespace Domain.Interfaces.Repositorios
{
    public interface ICompromissoRepositorio
    {
        public Task<IEnumerable<CompromissoDominio>> BuscarCompromissosPorUsuario(int idUsuario);
        public Task<IEnumerable<CompromissoDominio>> BuscarCompromissos();
        public Task<bool> InserirCompromisso(CompromissoDominio compromisso);
        public Task<bool> AlterarCompromisso(CompromissoDominio compromisso);
        public Task<bool> ExcluirCompromisso(int idCompromisso);
    }
}
