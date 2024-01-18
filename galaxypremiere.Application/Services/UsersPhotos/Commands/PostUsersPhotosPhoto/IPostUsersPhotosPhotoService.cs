using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosPhoto
{
    public interface IPostUsersPhotosPhotoService
    {
        ResultDto Execute(RequestPostUsersPhotosPhotoServiceDto req);
    }
}
