using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class User : IdentityUser
    {
        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}
