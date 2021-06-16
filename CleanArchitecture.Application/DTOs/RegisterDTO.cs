using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        [MinLength(5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [Compare("Password", ErrorMessage = "Passwords don´t match")]
        public string ConfirmedPassword { get; set; }
    }
}
