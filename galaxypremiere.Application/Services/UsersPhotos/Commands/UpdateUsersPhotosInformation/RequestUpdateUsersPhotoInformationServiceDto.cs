namespace galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosInformation
{
    public class RequestUpdateUsersPhotoInformationServiceDto
    {
        public long UsersId { get; set; }
        public Guid Id { get; set; }
        public string ControlId { get; set; }
        public string? Value { get; set; }
    }
}
