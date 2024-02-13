using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername
{
    public interface IGetUsersInformationAboutByUsernameService
    {
        ResultGetUsersInformationAboutByUsernameServiceDto Execute(RequestGetUsersInformationAboutByUsernameServiceDto req);
    }
}
