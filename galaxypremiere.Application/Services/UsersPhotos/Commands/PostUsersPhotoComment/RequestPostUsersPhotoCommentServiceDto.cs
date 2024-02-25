namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoComment
{
    public class RequestPostUsersPhotoCommentServiceDto
    {
        public Guid UsersPhotosId { get; set; }
        public Guid? Parent { get; set; } = null; // x=null=> main comment | x!=null => subComment
        public long UsersId { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
