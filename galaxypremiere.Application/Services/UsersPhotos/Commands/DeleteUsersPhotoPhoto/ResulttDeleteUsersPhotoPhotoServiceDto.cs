namespace galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoPhoto
{
    public class ResulttDeleteUsersPhotoPhotoServiceDto
    {
        public bool Leftover { get; set; } // whether a photo exists or not
        public string?  RandomPhoto { get; set; } // return a random photo to feature as the album cover
    }
}
