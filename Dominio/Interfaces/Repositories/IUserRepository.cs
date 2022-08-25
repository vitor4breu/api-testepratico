namespace Domain.Interfaces.Repositorios
{
    public interface IUserRepository
    {
        public IEnumerable<string> SelectUsers();
    }
}
