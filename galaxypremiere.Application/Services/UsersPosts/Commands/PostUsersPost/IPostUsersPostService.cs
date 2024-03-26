using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost.PostUsersPostService;

namespace galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost
{
    public interface IPostUsersPostService
    {
        ResultDto<PostUsersPostServiceDto> Execute(RequestPostUsersPostServiceDto req);
    }
}
