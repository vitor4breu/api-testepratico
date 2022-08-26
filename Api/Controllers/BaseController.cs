using Domain;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult GerarRetorno<T>(T retorno, bool contemErro)
        {
            var retornoApi = new RetornoApi<T>(retorno, contemErro);
            if (contemErro)
                return BadRequest(retornoApi);
            return Ok(retornoApi);
        }
    }
}