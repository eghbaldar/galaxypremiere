using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosPhoto
{
    public class RequestPostUsersPhotosPhotoServiceDto
    {
        public long UsersId { get; set; }
        public Guid UsersAlbumsId { get; set; }
        public string? Title { get; set; } // Title
        public string? Detail { get; set; } // Detail
        public IFormFile Photo { get; set; } // Filename
    }
}
