using System.ComponentModel.DataAnnotations;

namespace EFCORE.API.Dtos
{
    public class StudentToCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsRegularStudent { get; set; }
        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be atleast 6 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }

    }
}
