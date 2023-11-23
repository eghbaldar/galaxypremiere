using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral
{
    public interface IUpdateUsersInformationAccountService
    {
        ResultDto Execute(RequestUpdateUsersInformationAccountDto req);
    }
}
