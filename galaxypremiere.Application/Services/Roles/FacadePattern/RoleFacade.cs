using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Roles.Queries.GetRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Roles.FacadePattern
{
    public class RoleFacade:IRolesFacade
    {
        private readonly IDataBaseContext _context;
        public RoleFacade(IDataBaseContext context)
        {
            _context = context;
        }
        ///////////////////////////////////////////////////////// Get Roles
        private GetRolesService _getRolesService;
        public GetRolesService GetRolesService
        {
            get { return _getRolesService = _getRolesService ?? new GetRolesService(_context); }
        }
        /////////////////////////////////////////////////////////
    }
}
