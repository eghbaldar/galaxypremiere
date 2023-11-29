using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat
{
    public interface IUpdateUsersInformationContactService
    {
        public ResultDto Execute(RequestUpdateUsersInformationContactServiceDto req);
    }
}
