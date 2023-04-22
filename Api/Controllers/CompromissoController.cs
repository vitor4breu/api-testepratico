using Domain.Interfaces.Servicos;
using Domain.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servico.DTOs;

namespace Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CompromissoController : BaseController
    {
        private readonly ICompromissoServico _compromissoService;

        public CompromissoController(ICompromissoServico compromissoService, MensagemRetorno mensagens) : base(mensagens)
        {
            _compromissoService = compromissoService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ObterCompromissos()
        {
            var users = await _compromissoService.BuscarCompromissos();
            return GerarRetorno(users);
        }

        [HttpGet("{idUsuario}")]
        [Authorize]
        public async Task<IActionResult> ObterCompromissos([FromQuery] int idUsuario)
        {
            var users = await _compromissoService.BuscarCompromissosPorUsuario(idUsuario);
            return GerarRetorno(users);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InserirCompromissos([FromBody] CompromissoDto compromisso)
        {
            var users = await _compromissoService.InserirCompromisso(compromisso);
            return GerarRetorno(users);
        }

        [HttpDelete("{idCompromisso}")]
        [Authorize]
        public async Task<IActionResult> DeletarCompromisso([FromQuery] int idCompromisso)
        {
            var users = await _compromissoService.DeletarCompromisso(idCompromisso);
            return GerarRetorno(users);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AlterarCompromisso([FromBody] CompromissoAlteradoDto compromisso)
        {
            var users = await _compromissoService.AlterarCompromisso(compromisso);
            return GerarRetorno(users);
        }
    }
}
