using galaxypremiere.Application.Services.Users.Commands.PostUser;
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
    }
}
