using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.Commands.UpdateUser
{
    public interface IUpdateUserService
    {
        ResultDto Execute(RequestUpdateUserServiceDto req);
    }
}
