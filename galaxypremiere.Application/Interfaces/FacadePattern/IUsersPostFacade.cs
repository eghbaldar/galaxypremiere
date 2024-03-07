using galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost;
using galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public  interface IUsersPostFacade
    {
        public PostUsersPostService PostUsersPostService { get; }
        public GetUsersPostsService GetUsersPostsService { get; }
    }
}
