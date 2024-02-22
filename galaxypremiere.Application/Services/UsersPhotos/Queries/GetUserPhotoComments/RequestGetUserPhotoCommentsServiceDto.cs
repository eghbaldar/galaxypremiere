namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUserPhotoComments
{
    public class RequestGetUserPhotoCommentsServiceDto
    {
        public Guid Id { get; set; } // Photo Id
        public long UserId { get; set; } // getting UserId of person who wants to see or leave a comment
    }
}
