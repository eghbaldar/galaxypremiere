using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts
{
    public interface IGetUsersPostsService
    {
        ResultDto<ResultGetUsersPostsServiceDto> Execute(RequestGetUsersPostsServiceDto req);
    }
}
