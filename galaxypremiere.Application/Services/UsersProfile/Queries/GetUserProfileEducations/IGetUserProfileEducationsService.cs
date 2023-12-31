using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations
{
    public interface IGetUserProfileEducationsService
    {
        ResultDto<ResultGetUserProfileEducationsServiceDto> Execute(RequestGetUserProfileEducationsServiceDto req);
    }
}
