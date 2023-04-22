using Servico.DTOs;

namespace Dominio.Interfaces.Servicos
{
    public interface ICompromissoServico

    {
        public Task<CompromissoDto> ObterCompromisso(int idCompromisso);
        public Task<IEnumerable<CompromissoDto>> BuscarCompromissos();
        public Task<int?> InserirCompromisso(CompromissoDto compromisso);
        public Task<bool> AlterarCompromisso(CompromissoAlteracaoDto compromisso);
        public Task<bool> DeletarCompromisso(int idCompromisso);
    }
}
