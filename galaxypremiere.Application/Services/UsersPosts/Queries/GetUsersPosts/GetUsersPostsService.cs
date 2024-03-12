using galaxypremiere.Application.Interfaces.Contexts;
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
                             PostId= upp.UsersPostsId,
                         })
                         .Where(upp => upp.PostId == p.Id)
                         .ToList(),
                     }
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
