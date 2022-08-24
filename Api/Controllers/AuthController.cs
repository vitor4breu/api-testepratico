using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpPost(Name = "GetWeatherForecast")]
        public IActionResult LogarUsuario                                   ()
        {
            return Ok();
        }
    }
}