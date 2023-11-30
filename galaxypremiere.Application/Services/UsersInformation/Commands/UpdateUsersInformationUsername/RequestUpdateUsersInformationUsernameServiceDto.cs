using System.ComponentModel.DataAnnotations;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationUsername
{
    public class RequestUpdateUsersInformationUsernameServiceDto
    {
        public long userId { get; set; }
        [MinLength(3, ErrorMessage = "The characters of Username must be more than 3 characters.")]
        [MaxLength(30, ErrorMessage = "The characters of Username must not be more than 30 characters.")]
        public string username { get; set; }
    }
}
