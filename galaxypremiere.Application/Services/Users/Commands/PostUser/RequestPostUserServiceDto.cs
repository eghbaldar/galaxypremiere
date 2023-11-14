using System.ComponentModel.DataAnnotations;

namespace galaxypremiere.Application.Services.Users.Commands.PostUser
{
    public class RequestPostUserServiceDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [MinLength(10, ErrorMessage = "Name characters should be more than 10 characters.")]
        [MaxLength(50, ErrorMessage = "Name characters should not be more than 50 characters.")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Email Address is mandatory.")]
        [EmailAddress(ErrorMessage = "Email Address is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [MinLength(5, ErrorMessage = "Password characters should be more than 5 characters.")]
        public string Password { get; set; }
        public List<byte> IdRole { get; set; }
    }
}
