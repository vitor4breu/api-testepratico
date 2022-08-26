using Domain.Interfaces.Servicos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> PostLoginAsync(Login login)
        {
            var tokenLogin = await _loginService.Login(login.Username, login.Password);
            return GerarRetorno(tokenLogin, tokenLogin == null);
        }
    }
}