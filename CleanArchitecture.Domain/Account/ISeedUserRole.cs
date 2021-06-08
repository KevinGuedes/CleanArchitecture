using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Account
{
    public interface ISeedUserRole
    {
        void SeedUsers();

        void SeedRoles();
    }
}
