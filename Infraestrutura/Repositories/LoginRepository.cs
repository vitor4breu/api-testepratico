using Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public bool SelectLogin(string username, string password)
        {
            return true;
        }
    }
}
