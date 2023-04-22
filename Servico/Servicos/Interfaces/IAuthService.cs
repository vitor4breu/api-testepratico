namespace Domain.Interfaces.Servicos
{
    public interface IAuthService
    {
        public Task<string?> Autenticar(string user, string password);
    }
}
