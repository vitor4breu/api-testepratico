namespace Domain.Interfaces.Servicos
{
    public interface ILoginService
    {
        public Task<string?> Login(string user, string password);
    }
}
