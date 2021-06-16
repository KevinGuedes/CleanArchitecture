using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Account
{
    public interface IAuthentication
    {
        Task<bool> Authenticate(string userName, string password);

        Task<bool> Register(string userName, string email, string password);

        Task Logout();
    }
}
