using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationOther
{
    public interface IUpdateUsersInformationOtherService
    {
        ResultDto Execute(RequestUpdateUsersInformationOtherServiceDto req);
    }
}
