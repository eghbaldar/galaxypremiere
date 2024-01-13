namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileAttachments
{
    public class GetUserProfileAttachmentsServiceDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // Title
        public string Filename { get; set; } // Filename
        public int DownloadCounter { get; set; } // How many times the file has been downloaded?
        public DateTime InsertDate { get; set; }
    }
}
