namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoPhotos
{
    public class GetUsersPhotoPhotosServiceDto
    {
        public long UsersId { get; set; }
        public Guid Id { get; set; } // Photo Id
        public Guid UsersAlbumsId { get; set; }
        public string Title { get; set; } // Title
        public string Detail { get; set; } // Detail
        public string Filename { get; set; } // Filename
        public int DownloadCounter { get; set; } // How many times the file has been downloaded?
        public DateTime InsertDate { get; set; }
    }
}
