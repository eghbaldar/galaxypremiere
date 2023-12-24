using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserPosition.Commands.PostUsersPositionSuggestion;
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
        private readonly IMapper _imapper;
        public UsersPositionFacade(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _imapper = mapper;
        }
        // Get Users Positions
        public GetUsersPositionsService _usersPositionsService;
        public GetUsersPositionsService GetUsersPositionsService
        {
            get { return _usersPositionsService = _usersPositionsService ?? new GetUsersPositionsService(_context); }
        }
        // Post Users Positions
        public PostUsersPositionSuggestionService _postUsersPositionSuggestionService;
        public PostUsersPositionSuggestionService PostUsersPositionSuggestionService
        {
            get { return _postUsersPositionSuggestionService = _postUsersPositionSuggestionService ?? new PostUsersPositionSuggestionService(_context, _imapper); }
        }
    }
}
