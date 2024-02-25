using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoIncreaseVisitorCounter
{
    public interface IPostUsersPhotoIncreaseVisitorCounterService
    {
        ResultDto<PostUsersPhotoIncreaseVisitorCounterServiceDto> Execute(RequestPostUsersPhotoIncreaseVisitorCounterServiceDto req);
    }
}
