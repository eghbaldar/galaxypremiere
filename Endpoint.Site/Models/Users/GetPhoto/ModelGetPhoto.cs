using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoPhotos;

namespace Endpoint.Site.Models.Users.GetPhoto
{
    public class ModelGetPhoto
    {
        public ResultGetUsersPhotoAlbumServiceDto ResultGetUsersPhotoAlbumServiceDto { get; set; }
        public ResultGetUsersPhotoPhotosServiceDto ResultGetUsersPhotoPhotosServiceDto { get; set; }
    }
}
