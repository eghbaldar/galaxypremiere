using galaxypremiere.Application.Services.Users.Commands.PostUser;
using galaxypremiere.Application.Services.Users.Commands.UpdateUser;

namespace galaxypremiere.Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUsersServiceDto
    {
        public List<GetUsersServiceDto> resultGetUsersServiceDto { get; set; }
        public RequestUpdateUserServiceDto Validation { get; set; }
    }
}
