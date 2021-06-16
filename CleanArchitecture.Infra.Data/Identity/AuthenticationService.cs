﻿using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class AuthenticationService : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string userName, string password)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(userName, password, false, false);

            return result.Succeeded;
        }

        public async Task<bool> Register(string userName, string email, string password)
        {
            User newUser = new(userName, email);

            IdentityResult result = await _userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
                await _signInManager.SignInAsync(newUser, isPersistent: false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
