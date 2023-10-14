using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Users.Commands.DeleteUser;
using galaxypremiere.Application.Services.Users.Commands.PostUser;
using galaxypremiere.Application.Services.Users.Commands.UpdateUser;
using galaxypremiere.Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.FacadePattern
{
    public class UserFacade : IUserFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserFacade(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //////////////////////////////////////////////////// Post User
        private PostUserService _postUserService;
        public PostUserService PostUserService
        {
            get { return _postUserService = _postUserService ?? new PostUserService(_context, _mapper); }
        }
        //////////////////////////////////////////////////// Get Users
        private GetUsersService _getUsersService;
        public GetUsersService GetUsersService
        {
            get { return _getUsersService = _getUsersService ?? new GetUsersService(_context); }
        }
        //////////////////////////////////////////////////// Update Users
        private UpdateUserService _updateUserService;
        public UpdateUserService UpdateUserService
        {
            get { return _updateUserService = _updateUserService ?? new UpdateUserService(_context); }
        }
        //////////////////////////////////////////////////// Delete Users
        private DeleteUserService _deleteUserService;
        public DeleteUserService DeleteUserService
        {
            get { return _deleteUserService = _deleteUserService ?? new DeleteUserService(_context); }
        }
    }
}
