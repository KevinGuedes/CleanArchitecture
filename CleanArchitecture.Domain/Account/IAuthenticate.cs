using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> RegisterUser(string userName, string email, string password);

        Task Logout();
    }
}
