using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeader
{
    public interface IUpdateUsersInformationHeaderService
    {
        ResultDto Execute(RequestUpdateUsersInformationHeaderServiceDto req);
    }
}
