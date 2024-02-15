namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername
{
    public class RequestGetUsersInformationPhotosByUsernameServiceDto
    {
        public string Username { get; set; }
        public byte TotalPhotos { get; set; } // how many photos are going to be shown?
    }
}
