using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral
{
    public interface IUpdateUsersInformationGeneralService
    {
        ResultDto Execute(RequestUpdateUsersInformationGeneralDto req);
    }
}
