using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Users.Commands.PostUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.FacadePattern
{
    public class UserFacade:IUserFacade
    {
        private readonly IDataBaseContext _context;
        public UserFacade(IDataBaseContext context)
        {
            _context = context;
        }
        //////////////////////////////////////////////////// Post User
        private PostUserService _postUserService;
        public PostUserService PostUserService
        {
            get { return _postUserService = _postUserService ?? new PostUserService(_context); }
        }
    }
}
