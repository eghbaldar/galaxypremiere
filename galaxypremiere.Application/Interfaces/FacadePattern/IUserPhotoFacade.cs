using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoComment;
using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoPhoto;
using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotosAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoComment;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosPhoto;
using galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosAlbumRename;
using galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosInformation;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUserPhotoComments;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoPhotos;
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
        PostUsersPhotosPhotoService PostUsersPhotosPhotoService { get; }
        GetUsersPhotoPhotosService GetUsersPhotoPhotosService { get; }
        UpdateUsersPhotoInformationService UpdateUsersPhotoInformationService { get; }
        DeleteUsersPhotoPhotoService DeleteUsersPhotoPhotoService { get; }
        PostUsersPhotoCommentService PostUsersPhotoCommentService { get; }
        GetUserPhotoCommentsService GetUserPhotoCommentsService { get; }
        DeleteUsersPhotoCommentService DeleteUsersPhotoCommentService { get; }
    }
}
