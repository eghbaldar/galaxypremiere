using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosAlbum
{
    public class PostUsersPhotosAlbumService: IPostUsersPhotosAlbumService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _imapper;
        public PostUsersPhotosAlbumService(IDataBaseContext context, IMapper imapper)
        {
            _context = context;
            _imapper = imapper;
        }
        public ResultDto Execute(RequestPostUsersPhotosAlbumServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var profile = _context.UsersLinks.Where(e => e.UsersId == req.UsersId).ToList();

                if (req == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Something went wrong."
                    };
                }
                UsersAlbums usersAlbums = new UsersAlbums();
                if (!String.IsNullOrEmpty(req.Title.ToString().Trim()))
                {
                    usersAlbums.UsersId = req.UsersId;
                    usersAlbums.Title = req.Title.ToString().Trim();

                    _context.UsersAlbums.Add(usersAlbums);
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Everything went Ok."
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "The title is not allowed to be empty thing."
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
        }
    }
}
