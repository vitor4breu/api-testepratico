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

        public string Login(
            string username,
            string password
            )
        {
            var login = _loginRepository.SelectLogin(username, password);
            if (login)
            {
                return _tokenService.CreateToken(username);
            }
            return null;
        }
    }
}
