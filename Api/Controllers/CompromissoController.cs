using Dominio.Interfaces.Servicos;
using Dominio.Retorno;
using Microsoft.AspNetCore.Mvc;
using Servico.DTOs;

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

        [HttpGet]
        public async Task<IActionResult> ObterCompromissos()
        {
            var users = await _compromissoService.BuscarCompromissos();
            return GerarRetorno(users);
        }

        [HttpGet("{idCompromisso}")]
        public async Task<IActionResult> ObterCompromisso(int idCompromisso)
        {
            var users = await _compromissoService.ObterCompromisso(idCompromisso);
            return GerarRetorno(users);
        }

        [HttpPost]
        public async Task<IActionResult> InserirCompromissos([FromBody] CompromissoDto compromisso)
        {
            var users = await _compromissoService.InserirCompromisso(compromisso);
            return GerarRetorno(users);
        }

        [HttpDelete("{idCompromisso}")]
        public async Task<IActionResult> DeletarCompromisso(int idCompromisso)
        {
            var users = await _compromissoService.DeletarCompromisso(idCompromisso);
            return GerarRetorno(users);
        }

        [HttpPut]
        public async Task<IActionResult> AlterarCompromisso([FromBody] CompromissoAlteracaoDto compromisso)
        {
            var users = await _compromissoService.AlterarCompromisso(compromisso);
            return GerarRetorno(users);
        }
    }
}
