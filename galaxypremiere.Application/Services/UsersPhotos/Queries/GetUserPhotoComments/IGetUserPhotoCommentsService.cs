using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUserPhotoComments
{
    public interface IGetUserPhotoCommentsService
    {
        ResultDto<ResultGetUserPhotoCommentsServiceDto> Execute(RequestGetUserPhotoCommentsServiceDto req);
    }
}
