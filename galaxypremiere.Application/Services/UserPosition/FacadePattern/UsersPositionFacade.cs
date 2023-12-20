using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserPosition.Queries.GetUsersPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UserPosition.FacadePattern
{
    public class UsersPositionFacade : IUserPositionFacade
    {
        private readonly IDataBaseContext _context;
        public UsersPositionFacade(IDataBaseContext context)
        {
            _context = context;
        }
        // Get Users Positions Service
        public GetUsersPositionsService _usersPositionsService;
        public GetUsersPositionsService GetUsersPositionsService
        {
            get { return _usersPositionsService = _usersPositionsService ?? new GetUsersPositionsService(_context); }
        }
    }
}
