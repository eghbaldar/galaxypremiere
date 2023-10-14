using galaxypremiere.Application.Services.Users.Commands.DeleteUser;
using galaxypremiere.Application.Services.Users.Commands.PostUser;
using galaxypremiere.Application.Services.Users.Commands.UpdateUser;
using galaxypremiere.Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserFacade
    {
        public PostUserService PostUserService { get; }
        public GetUsersService GetUsersService { get; }
        public UpdateUserService UpdateUserService { get; }
        public DeleteUserService DeleteUserService { get; }
    }
}
