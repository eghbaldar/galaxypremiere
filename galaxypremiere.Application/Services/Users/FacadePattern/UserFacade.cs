using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserLoginLog.Queries.GetUsersLoginLogs;
using galaxypremiere.Application.Services.Users.Commands.ActivateUser;
using galaxypremiere.Application.Services.Users.Commands.DeleteUser;
using galaxypremiere.Application.Services.Users.Commands.PostUser;
using galaxypremiere.Application.Services.Users.Commands.UpdateUser;
using galaxypremiere.Application.Services.Users.Queries.AuthUsers;
using galaxypremiere.Application.Services.Users.Queries.GetUsers;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public UserFacade(
            IDataBaseContext context,
            IMapper mapper,
            IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
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
            get { return _getUsersService = _getUsersService ?? new GetUsersService(_context, _configuration); }
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
        //////////////////////////////////////////////////// Activate User
        private ActiviateUserService _activiateUserService;
        public ActiviateUserService ActiviateUserService
        {
            get { return _activiateUserService = _activiateUserService ?? new ActiviateUserService(_context); }
        }
        /////////////////////////////////////////////////// Auth User Login
        private AuthLoginUsersService _authLoginUsersService;
        public AuthLoginUsersService AuthLoginUsersService
        {
            get { return _authLoginUsersService = _authLoginUsersService ?? new AuthLoginUsersService(_context); }
        }
    }
}
