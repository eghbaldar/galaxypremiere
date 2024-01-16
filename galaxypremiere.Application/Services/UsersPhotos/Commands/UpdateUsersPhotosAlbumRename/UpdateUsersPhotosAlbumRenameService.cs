using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosAlbumRename
{
    public class UpdateUsersPhotosAlbumRenameService : IUpdateUsersPhotosAlbumRenameService
    {
        private readonly IDataBaseContext _context;
        public UpdateUsersPhotosAlbumRenameService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUsersPhotosAlbumRenameServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var album = _context.UsersAlbums
                    .Where(ue => ue.Id == req.Id && ue.UsersId == req.UsersId).FirstOrDefault();
                if (album != null)
                {
                    album.Title= req.Title;
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "The information have been updated"
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "The album does not exist"
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist"
                };
            }
        }
    }
}
