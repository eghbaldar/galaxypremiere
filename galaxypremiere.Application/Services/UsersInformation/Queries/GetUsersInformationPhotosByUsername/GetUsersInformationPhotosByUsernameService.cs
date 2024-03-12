using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername
{
    public class GetUsersInformationPhotosByUsernameService : IGetUsersInformationPhotosByUsernameService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUsersInformationPhotosByUsernameService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultGetUsersInformationPhotosByUsernameServiceDto Execute(RequestGetUsersInformationPhotosByUsernameServiceDto req)
        {
            if (req == null) return null;

            var groupedComments = _context.Comments
                    .GroupBy(p => p.SectionId, p => p.Comment, (key, g) => new { PhotoId = key, Count = g.Count() });
            var groupedLikes = _context.Likes
                     .Where(l => l.DeleteTime == null && l.Section == SectionsConstants.UserPhotos)
                     .GroupBy(l => new { l.SectionId, l.Section })
                     .Select(g => new { SectionId = g.Key.SectionId, Section = g.Key.Section, Count = g.Count() });

            // x==0  meants it is a guest and x!=0 it is a user and her/his "userId" has just been returned.
            var currentUserLikeUnlike = _context.Likes.Where(l => l.UsersId == req.UserId && l.DeleteTime == null).AsQueryable();

            // here SectionId is equal too PhotoId
            var photos =
                (
                from p in _context.UsersPhotos
                join albums in _context.UsersAlbums on p.UsersAlbumsId equals albums.Id into GroupAlbums
                from albums in GroupAlbums.DefaultIfEmpty()
                join info in _context.UsersInformation on albums.UsersId equals info.UsersId into GroupInfo
                from info in GroupInfo.DefaultIfEmpty()
                join user in _context.Users on info.UsersId equals user.Id into GroupUser
                from user in GroupUser.DefaultIfEmpty()
                where (info.Username == req.Username)
                select new
                {
                    Photos = p,
                    Fullname = $"{info.Firstname} {info.MiddleName} {info.Surname}",
                    info = info,
                    User = user,
                }
                )
                .OrderBy(p => p.Photos.InsertDate)
                .Select(p => new GetUsersInformationPhotosByUsernameServiceDto
                {
                    Filename = p.Photos.Filename,
                    Id = p.Photos.Id,
                    Title = p.Photos.Title,
                    Detail = p.Photos.Detail,
                    VisitorCounter = p.Photos.VisitorCounter + 1,
                    CountComments = groupedComments.Where(gc => gc.PhotoId == p.Photos.Id).Select(gc => gc.Count).First().ToString(),
                    CountLikes = groupedLikes.Where(gl => gl.SectionId == p.Photos.Id).Select(gl => gl.Count).First().ToString(),
                    Like = currentUserLikeUnlike.Where(x => x.SectionId == p.Photos.Id).Any(),
                    Nickname = p.User.Nickname,
                    Headshot = p.info.Photo,
                })
                .Take(6)
                .ToList();

            if (photos != null)
            {
                return new ResultGetUsersInformationPhotosByUsernameServiceDto
                {
                    resultGetUsersInformationPhotosByUsernameServiceDto = photos,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
