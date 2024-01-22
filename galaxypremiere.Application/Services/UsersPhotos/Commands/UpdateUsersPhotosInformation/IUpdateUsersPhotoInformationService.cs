using galaxypremiere.Common.DTOs;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosInformation
{
    public interface IUpdateUsersPhotoInformationService
    {
        ResultDto Execute(RequestUpdateUsersPhotoInformationServiceDto req);
    }
}
