using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPrivacy
{
    public interface IUpdateUsersInformationPrivacyService
    {
        ResultDto Execute(RequestUpdateUsersInformationPrivcayServiceDto req);
    }
}
