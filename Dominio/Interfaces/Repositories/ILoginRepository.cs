namespace Domain.Interfaces.Repositorios
{
    public interface ILoginRepository
    {
        public bool SelectLogin(string username, string password);
    }
}
