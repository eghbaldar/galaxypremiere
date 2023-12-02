using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetCheckDuplicatedUsername
{
    public interface IGetCheckDuplicatedUsernameService
    {
        bool Execute(RequestGetCheckDuplicatedUsernameDto req);
    }
}
