using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Account;
using CleanArchitecture.Infra.Data.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;

        public AccountController(IAuthentication authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("user")]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                if (await _authenticationService.Register(register.UserName, register.Email, register.Password))
                    return Ok(new { message = $"User registered" });

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest(ModelState);
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                if (await _authenticationService.Authenticate(login.UserName, login.Password))
                    return Ok(new { message = $"User logged" });

                return StatusCode(StatusCodes.Status500InternalServerError);
                //ModelState.AddModelError("Login Failed", "User or password wornd");
            }

            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _authenticationService.Logout();

            return NoContent();
        }
    }
}
