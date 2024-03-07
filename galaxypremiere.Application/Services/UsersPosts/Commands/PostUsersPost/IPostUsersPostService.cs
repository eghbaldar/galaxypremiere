using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost
{
    public interface IPostUsersPostService
    {
        ResultDto Execute(RequestPostUsersPostServiceDto req);
    }
}
