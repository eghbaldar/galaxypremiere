using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContact
{
    public interface IGetUsersInformationContactService
    {
        public GetUsersInformationContactServiceDto Execute(long userId);
    }
}
