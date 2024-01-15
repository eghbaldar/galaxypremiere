using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum
{
    public interface IGetUsersPhotoAlbumService
    {
        ResultDto<ResultGetUsersPhotoAlbumServiceDto> Execute(RequestGetUsersPhotoAlbumServiceDto req);
    }
}
