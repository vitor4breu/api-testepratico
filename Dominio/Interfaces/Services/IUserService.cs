using Domain.Models;

namespace Domain.Interfaces.Servicos
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> ReturnUsersAsync();
    }
}
