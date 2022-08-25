using Domain.Interfaces.Servicos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult PostLogin(Login login)
        {
            var tokenLogin = _loginService.Login(login.Username, login.Password);
            return tokenLogin != null ? Ok(tokenLogin) : Unauthorized();
        }
    }
}