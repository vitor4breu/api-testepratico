using Dominio.Retorno;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private MensagemRetorno _mensagens { get; set; }

        public BaseController(MensagemRetorno mensagens)
        {
            _mensagens = mensagens;
        }

        protected IActionResult GerarRetorno<T>(T retorno)
        {
            var retornoApi = new RetornoApi<T>(retorno, _mensagens);
            if (_mensagens.ContemErro)
                return BadRequest(retornoApi);
            return Ok(retornoApi);
        }
    }
}