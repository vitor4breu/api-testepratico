using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Services;
using Domain.Interfaces.Servicos;

namespace Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly ITokenService _tokenService;

        public LoginService
            (
            ILoginRepository loginRepository,
            ITokenService tokenService
            )
        {
            _loginRepository = loginRepository;
            _tokenService = tokenService;
        }

        public async Task<string?> Login(
            string username,
            string password
            )
        {
            var login = await _loginRepository.SelectLogin(username, password);
            return login ? _tokenService.CreateToken(username) : null;
        }
    }
}
