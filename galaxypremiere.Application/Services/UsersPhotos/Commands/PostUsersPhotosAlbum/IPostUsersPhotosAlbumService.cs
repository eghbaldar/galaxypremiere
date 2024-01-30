using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosAlbum
{
    public interface IPostUsersPhotosAlbumService
    {
        ResultDto<ResultPostUsersPhotosAlbumServiceDto> Execute(RequestPostUsersPhotosAlbumServiceDto req);
    }
}
