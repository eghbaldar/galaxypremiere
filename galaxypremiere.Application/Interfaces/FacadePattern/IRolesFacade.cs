using galaxypremiere.Application.Services.Roles.Queries.GetRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IRolesFacade
    {
        GetRolesService GetRolesService { get; }
    }
}
