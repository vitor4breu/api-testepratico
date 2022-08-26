namespace Domain.Interfaces.Repositorios
{
    public interface ILoginRepository
    {
        public Task<bool> SelectLogin(string username, string password);
    }
}
