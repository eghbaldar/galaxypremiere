using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPassword
{
    public interface IUpdateUsersInformationPasswordService
    {
        ResultDto Execute(RequestUpdateUsersInformationPasswordDto req);
    }
}
