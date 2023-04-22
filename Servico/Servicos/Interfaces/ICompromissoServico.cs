using Servico.DTOs.Compromisso;

namespace Dominio.Interfaces.Servicos
{
    public interface ICompromissoServico

    {
        public Task<CompromissoVisualizacaoDto> ObterCompromisso(int idCompromisso);
        public Task<IEnumerable<CompromissoVisualizacaoDto>> BuscarCompromissos();
        public Task<int?> InserirCompromisso(CompromissoInsercaoDto compromisso);
        public Task<bool> AlterarCompromisso(CompromissoAlteracaoDto compromisso);
        public Task<bool> DeletarCompromisso(int idCompromisso);
    }
}
