using Domain.Models;
using Servico.DTOs;

namespace Domain.Interfaces.Servicos
{
    public interface ICompromissoServico

    {
        public Task<IEnumerable<CompromissoDto>> BuscarCompromissosPorUsuario(int idUsuario);
        public Task<IEnumerable<CompromissoDto>> BuscarCompromissos();
        public Task<bool> InserirCompromisso(CompromissoDto compromisso);
        public Task<bool> AlterarCompromisso(CompromissoAlteradoDto compromisso);
        public Task<bool> DeletarCompromisso(int idCompromisso);
    }
}
