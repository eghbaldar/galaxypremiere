using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationUsernameByUserId
{
    public interface IGetUsersInformationUsernameByUserIdService
    {
        ResultDto<string> Execute(RequestGetUsersInformationUsernameByUserIdServiceDto req);
    }
}
