using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Roles.Queries.GetRoles
{
    public interface IGetRolesService
    {
        List<ResultIGetRolesServiceDto> Execute();
    }
}
