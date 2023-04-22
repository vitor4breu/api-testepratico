using Dominio.Interfaces.Servicos;
using Dominio.Retorno;
using Microsoft.AspNetCore.Mvc;
using Servico.DTOs.Compromisso;

namespace Api.Controllers
{
    [ApiController]
    public class CompromissoController : BaseController
    {
        private readonly ICompromissoServico _compromissoService;

        public CompromissoController(ICompromissoServico compromissoService, MensagemRetorno mensagens) : base(mensagens)
        {
            _compromissoService = compromissoService;
        }

        /// <summary>
        /// Endpoint responsavel por obter todos compromissos.
        /// </summary>
        /// <returns>Lista com compromissos existentes.</returns>
        [HttpGet]
        public async Task<IActionResult> ObterCompromissos()
        {
            var users = await _compromissoService.BuscarCompromissos();
            return GerarRetorno(users);
        }

        /// <summary>
        /// Endpoint responsável por obter determinado compromisso de acordo com o Id inserido.
        /// </summary>
        /// <param name="idCompromisso">Id do compromisso.</param>
        /// <returns>Objeto com Id, data e texto do compromisso.</returns>
        [HttpGet("{idCompromisso}")]
        public async Task<IActionResult> ObterCompromisso(int idCompromisso)
        {
            var users = await _compromissoService.ObterCompromisso(idCompromisso);
            return GerarRetorno(users);
        }

        /// <summary>
        /// Endpoint resposável por inserir um compromisso no banco de dados.
        /// </summary>
        /// <param name="compromisso">Objeto com data e texto.</param>
        /// <returns>Id do compromisso inserido.</returns>
        [HttpPost]
        public async Task<IActionResult> InserirCompromissos([FromBody] CompromissoInsercaoDto compromisso)
        {
            var users = await _compromissoService.InserirCompromisso(compromisso);
            return GerarRetorno(users);
        }

        /// <summary>
        /// Endpoint responsável por deletar um compromisso de acordo com o Id inserido.
        /// </summary>
        /// <param name="idCompromisso">Id do compromisso.</param>
        /// <returns>Booleano referente ao sucesso ao deletar o compromisso.</returns>
        [HttpDelete("{idCompromisso}")]
        public async Task<IActionResult> DeletarCompromisso(int idCompromisso)
        {
            var users = await _compromissoService.DeletarCompromisso(idCompromisso);
            return GerarRetorno(users);
        }

        /// <summary>
        /// Endpoint responsável por alterar um compromisso existente no sistema de acordo com o Id Inserido.
        /// </summary>
        /// <param name="compromisso">Objeto com Id, Texto e Data</param>
        /// <returns>Booleano referente ao sucesso na alteração do compromisso</returns>
        [HttpPut]
        public async Task<IActionResult> AlterarCompromisso([FromBody] CompromissoAlteracaoDto compromisso)
        {
            var users = await _compromissoService.AlterarCompromisso(compromisso);
            return GerarRetorno(users);
        }
    }
}
