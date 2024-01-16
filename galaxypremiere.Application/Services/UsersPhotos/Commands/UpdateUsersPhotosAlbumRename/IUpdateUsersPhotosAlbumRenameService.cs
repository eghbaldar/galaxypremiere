using galaxypremiere.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosAlbumRename
{
    public interface IUpdateUsersPhotosAlbumRenameService
    {
        ResultDto Execute(RequestUpdateUsersPhotosAlbumRenameServiceDto req);
    }
}
