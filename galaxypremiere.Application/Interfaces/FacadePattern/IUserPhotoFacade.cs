using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotosAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosAlbumRename;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserPhotoFacade
    {
        PostUsersPhotosAlbumService PostUsersPhotosAlbumService { get; }
        GetUsersPhotoAlbumService GetUsersPhotoAlbumService { get; }
        DeleteUsersPhotosAlbumService DeleteUsersPhotosAlbumService { get; }
        UpdateUsersPhotosAlbumRenameService UpdateUsersPhotosAlbumRenameService { get; }
    }
}
