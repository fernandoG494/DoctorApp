using System.ComponentModel.DataAnnotations;

namespace Models.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Password length should be minimum 4")]
        public string Password { get; set; }
    }
}
