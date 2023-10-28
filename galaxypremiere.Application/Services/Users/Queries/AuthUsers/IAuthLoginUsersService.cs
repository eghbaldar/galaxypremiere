using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.Queries.AuthUsers
{
    public interface IAuthLoginUsersService
    {
        ResultDto<ResultAuthLoginUsersServiceDto> Execute(RequestAuthLoginUsersServiceDto req);
    }
}
