namespace galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosAlbumRename
{
    public class RequestUpdateUsersPhotosAlbumRenameServiceDto
    {
        public long UsersId{ get; set; }
        public Guid  Id { get; set; }
        public string Title { get; set; }
    }
}
