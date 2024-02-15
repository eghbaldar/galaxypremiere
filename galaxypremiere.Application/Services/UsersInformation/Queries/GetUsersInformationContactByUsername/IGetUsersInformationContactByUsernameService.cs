using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername
{
    public interface IGetUsersInformationContactByUsernameService
    {
        ResultGetUsersInformationContactByUsernameServiceDto Execute(RequestGetUsersInformationContactByUsernameServiceDto req);
    }
}
