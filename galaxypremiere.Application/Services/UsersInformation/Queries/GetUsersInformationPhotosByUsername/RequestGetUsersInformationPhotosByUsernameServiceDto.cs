namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername
{
    public class RequestGetUsersInformationPhotosByUsernameServiceDto
    {
        public string Username { get; set; }
        public byte TotalPhotos { get; set; } // how many photos are going to be shown?
        public long UserId { get; set; } // the user who is visiting the page and want to like the post for example!
        // if there is only a guest, "0" returns
    }
}
