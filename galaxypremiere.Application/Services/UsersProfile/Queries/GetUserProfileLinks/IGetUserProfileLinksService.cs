using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileLinks
{
    public interface IGetUserProfileLinksService
    {
        public ResultDto<ResultGetUserProfileLinksServiceDto> Execute(RequestGetUserProfileLinksDto req);
    }
}
