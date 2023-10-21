using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.Commands.ActivateUser
{
    public interface IActiviateUserService
    {
        ResultDto Execute(RequestActiviateUserServiceDto req);
    }
}
