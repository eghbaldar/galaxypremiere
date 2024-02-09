using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername
{
    public interface IGetUsersInformationByUsernameService
    {
        public ResultGetUsersInformationByUsernameServiceDto Execute(RequestUsersInformationByUsernameServiceDto req);
    }
}
