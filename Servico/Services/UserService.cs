using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> ReturnUsersAsync()
        {
            return await _userRepository.SelectUsers();
        }
    }
}
