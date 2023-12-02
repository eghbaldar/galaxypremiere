using System.ComponentModel.DataAnnotations;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetCheckDuplicatedUsername
{
    public class RequestGetCheckDuplicatedUsernameDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "The characters of Username must be more than 3 characters.")]
        [MaxLength(30, ErrorMessage = "The characters of Username must not be more than 30 characters.")]
        public string Username { get; set; }
    }
}
