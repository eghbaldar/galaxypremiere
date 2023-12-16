using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot
{
    public class RequestUpdateUsersInformationHeadshotServiceDto
    {
        public long UsersId { get; set; }
        public IFormFile Photo { get; set; } // Headshot
    }
}
