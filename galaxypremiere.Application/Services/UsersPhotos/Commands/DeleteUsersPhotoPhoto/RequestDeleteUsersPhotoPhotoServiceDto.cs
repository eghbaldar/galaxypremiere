namespace galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoPhoto
{
    public class RequestDeleteUsersPhotoPhotoServiceDto
    {
        public long UsersId{ get; set; }
        public Guid Id { get; set; } // Photo Id
    }
}
