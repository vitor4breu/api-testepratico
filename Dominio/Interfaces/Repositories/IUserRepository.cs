using Domain.Models;

namespace Domain.Interfaces.Repositorios
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> SelectUsers();
    }
}
