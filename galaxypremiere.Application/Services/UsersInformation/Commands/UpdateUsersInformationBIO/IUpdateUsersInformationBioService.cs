using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationAccountType;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO
{
    public interface IUpdateUsersInformationBioService
    {
        ResultDto Execute(RequestUpdateUsersInformationBioServiceDto req);
    }
}
