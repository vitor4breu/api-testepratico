namespace Domain.Interfaces.Repositorios
{
    public interface IAuthRepositorio
    {
        public Task<bool> ObterUsuarioAutenticado(string username, string password);
    }
}
