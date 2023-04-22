using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Services;
using Domain.Interfaces.Servicos;

namespace Service.Services.Implementacoes
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepositorio _authRepositorio;
        private readonly ITokenService _tokenService;

        public AuthService
            (
            IAuthRepositorio authRepository,
            ITokenService tokenService
            )
        {
            _authRepositorio = authRepository;
            _tokenService = tokenService;
        }

        public async Task<string?> Autenticar(
            string username,
            string password
            )
        {
            var login = await _authRepositorio.ObterUsuarioAutenticado(username, password);
            return login ? _tokenService.CreateToken(username) : null;
        }
    }
}
