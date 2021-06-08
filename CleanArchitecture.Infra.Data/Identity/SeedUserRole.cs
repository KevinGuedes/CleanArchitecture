using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class SeedUserRole : ISeedUserRole
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRole(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole adminRole = new IdentityRole();
                adminRole.Name = "Admin";
                adminRole.NormalizedName = "ADMIN";

                IdentityResult result = _roleManager.CreateAsync(adminRole).Result;
            }

            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole userRole = new();
                userRole.Name = "User";
                userRole.NormalizedName = "USER";

                IdentityResult result = _roleManager.CreateAsync(userRole).Result;
            }
        }

        public void SeedUsers()
        {
            string userNameAdmin = "Kevin";
            string emailAdmin = "kevinguedes@edu.unifor.br";
            string passwordAdmin = "!)*nfs$heat%";

            if (_userManager.FindByEmailAsync(emailAdmin).Result == null)
            {
                User user = new(userNameAdmin, emailAdmin);
                user.NormalizedEmail = emailAdmin.ToUpper();
                user.NormalizedUserName = userNameAdmin.ToUpper();
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();


                IdentityResult result = _userManager.CreateAsync(user, passwordAdmin).Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
            }


            string userName = "Kariny";
            string email = "kariny@gmail.com";
            string password = "kariny123";

            if (_userManager.FindByEmailAsync(email).Result == null)
            {
                User user = new(userName, email);
                user.NormalizedEmail = email.ToUpper();
                user.NormalizedUserName = userName.ToUpper();
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();


                IdentityResult result = _userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "User").Wait();
            }
        }
    }
}
