using Domain.Interfaces.Servicos;
using Domain.Models;
using Domain.Retorno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, MensagemRetorno mensagens) : base(mensagens) 
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar([FromBody] Login login)
        {
            var tokenLogin = await _authService.Autenticar(login.Username, login.Password);
            return GerarRetorno(tokenLogin);
        }

        [HttpPost]
        public async Task<IActionResult> Teste()
        {
            return GerarRetorno(false);
        }
    }
}