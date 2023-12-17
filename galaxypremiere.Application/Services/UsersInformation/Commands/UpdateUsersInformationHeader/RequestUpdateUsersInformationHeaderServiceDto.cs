using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeader
{
    public class RequestUpdateUsersInformationHeaderServiceDto
    {
        public long UsersId { get; set; }
        public IFormFile Header { get; set; }
    }
}
