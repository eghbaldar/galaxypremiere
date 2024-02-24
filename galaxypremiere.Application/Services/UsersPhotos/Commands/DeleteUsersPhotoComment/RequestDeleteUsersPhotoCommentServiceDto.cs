namespace galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoComment
{
    public class RequestDeleteUsersPhotoCommentServiceDto
    {
        public Guid Id { get; set; } // Photo Id
        public long UserId { get; set; } // Who does want to remove the comment?
    }
}
