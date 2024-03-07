using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost;
using galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPosts.FacadePattern
{
    public class UsersPostFacade: IUsersPostFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UsersPostFacade(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        ///////////// Post Users' Post
        private PostUsersPostService _postUsersPostService;
        public PostUsersPostService PostUsersPostService
        {
            get { return _postUsersPostService = _postUsersPostService ?? new PostUsersPostService(_context, _mapper); }
        }
        ///////////// Get Users' Posts
        private GetUsersPostsService _getUsersPostsService;
        public GetUsersPostsService GetUsersPostsService
        {
            get { return _getUsersPostsService = _getUsersPostsService ?? new GetUsersPostsService(_context); }
        }
    }
}
