namespace galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotosAlbum
{
    public class RequestDeleteUsersPhotosAlbumServiceDto
    {
        public long UsersId { get; set; }
        public Guid Id { get; set; } // The ID of the album
    }
}
