using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.Constants;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts
{
    public partial class GetUsersPostsService : IGetUsersPostsService
    {
        private readonly IDataBaseContext _context;
        public GetUsersPostsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultGetUsersPostsServiceDto> Execute(RequestGetUsersPostsServiceDto req)
        {
            if (req == null) return new ResultDto<ResultGetUsersPostsServiceDto> { Data = null, IsSuccess = false };
            var result =
                (from p in _context.UsersPosts
                 join info in _context.UsersInformation on p.UsersId equals info.UsersId
                 join user in _context.Users on info.UsersId equals user.Id into GroupUser
                 from user in GroupUser.DefaultIfEmpty()
                 where info.Username == req.Username && p.UsersId == info.UsersId && p.Archive == false
                 orderby p.InsertDate descending
                 select new GetUsersPostsServiceDto
                 {
                     UsersId = info.UsersId,
                     From = p.From,
                     OwnerNickname = user.Nickname,
                     FromNickname = "",
                     Post = p.Post,
                     PostId = p.Id,
                     InsertDate = p.InsertDate,
                     OwnerUsername = req.Username,
                     FromUsername = "",
                     OwnerHeadshot = info.Photo,
                     FromHeadshot = "",
                     resultGetPostPhotosByPostIdDto = new ResultGetPostPhotosByPostIdDto
                     {
                         resultGetPostPhotosByPostIdDto = _context.UsersPostsPhotos
                         .Select(upp => new GetPostPhotosByPostIdDto
                         {
                             Filename = upp.Filename,
                             Id = upp.Id,
                             InsertTime = upp.InsertDate,
                             PostId = upp.UsersPostsId,
                         })
                         .Where(upp => upp.PostId == p.Id)
                         .ToList(),
                     },
                     resultGetPostCommentsByPostIdDto = new ResultGetPostCommentsByPostIdDto
                     {
                         _resultGetPostCommentsByPostIdDto =
                         (from c in _context.Comments
                          join u in _context.Users on c.UsersId equals u.Id into GroupUser
                          from u in GroupUser.DefaultIfEmpty()
                          join info in _context.UsersInformation on c.UsersId equals info.UsersId into GroupInfo
                          from info in GroupInfo.DefaultIfEmpty()
                          where c.Section == 1 && c.SectionId == p.Id
                          select new GetPostCommentsByPostIdDto
                          {
                              Id = c.Id,
                              PostId = c.SectionId,
                              Comment = c.Comment,
                              InsertTime = c.InsertTime,
                              NicknameCommenter = u.Nickname,
                              UserId = u.Id,
                              Headshot = info.Photo,
                              AllowToRemove = c.UsersId == req.UserId,
                          }
                         ).ToList(),
                     },
                     Liked = _context.Likes.Where(l => l.UsersId == req.UserId && l.SectionId == p.Id && l.DeleteTime == null && l.Section == SectionsConstants.UserPosts).Any()
                 }).ToList();
            return new ResultDto<ResultGetUsersPostsServiceDto>
            {
                Data = new ResultGetUsersPostsServiceDto
                {
                    resultGetUsersPostsServiceDto = result,
                }
            };
            // check the archive ...
        }
    }
}
