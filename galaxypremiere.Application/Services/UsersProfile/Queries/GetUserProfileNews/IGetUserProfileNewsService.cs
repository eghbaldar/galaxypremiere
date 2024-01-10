using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews
{
    public interface IGetUserProfileNewsService
    {
        public ResultDto<ResultGetUserProfileNewsServiceDto> Execute(RequestGetUserProfileNewsDto req);
    }
}
