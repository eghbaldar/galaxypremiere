namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosPhoto
{
    public class ResultPostUsersPhotosPhotoServiceDto
    {
        public Guid AlbumId { get; set; }
        public string Filename { get; set; }
        public Guid PhotoId { get; set; }
    }
}
