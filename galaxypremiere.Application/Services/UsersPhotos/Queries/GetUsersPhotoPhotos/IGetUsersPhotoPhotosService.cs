using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoPhotos
{
    public interface IGetUsersPhotoPhotosService
    {
        ResultDto<ResultGetUsersPhotoPhotosServiceDto> Execute(RequestGetUsersPhotoPhotosServiceDto req);
    }
}
