using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.Comments.Queries.GetCommentsBySectionId
{
    public class GetCommentsBySectionIdService : IGetCommentsBySectionIdService
    {
        private readonly IDataBaseContext _context;
        public GetCommentsBySectionIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultGetCommentsBySectionIdServiceDto> Execute(RequestGetCommentsBySectionIdServiceDto req)
        {
            if (req == null) return new ResultDto<ResultGetCommentsBySectionIdServiceDto> { IsSuccess = false, };

            var comments = _context.Comments.Where(p => p.SectionId == req.SectionId);
            if (comments.Any())
            {
                var commentsList = (
                    from c in _context.Comments
                    join info in _context.UsersInformation on c.UsersId equals info.UsersId into infoGroup
                    from info in infoGroup.DefaultIfEmpty()
                    join user in _context.Users on c.UsersId equals user.Id into userGroup
                    from user in userGroup.DefaultIfEmpty()
                    where c.SectionId == req.SectionId
                    select new
                    {
                        Comments = c,
                        information = info,
                        user.Email,
                        AllowToRemove = req.UserId != 0 ? c.UsersId.Equals(req.UserId) ? true : false : false,
                        CountComments = c.Comment.Length,
                    }
                    )
                    .Select(x => new GetCommentsBySectionIdServiceDto
                    {
                        SectionId = x.Comments.Id,
                        Username = x.information.Username,
                        Avatar = x.information.Photo ?? null,
                        Comment = x.Comments.Comment,
                        InsertDate = x.Comments.InsertTime,
                        Email = x.Email,
                        Fullname = (x.information.Firstname ?? null) + (x.information.MiddleName ?? null) + (x.information.Surname ?? null),
                        AllowToRemove = x.AllowToRemove,
                    })
                    .OrderBy(x => x.InsertDate)
                    .ToList();
                return new ResultDto<ResultGetCommentsBySectionIdServiceDto>
                {
                    Data = new ResultGetCommentsBySectionIdServiceDto
                    {
                        GetCommentsBySectionIdServiceDto = commentsList,
                    },
                    IsSuccess = true,
                    Message = "successfull"
                };
            }
            else return new ResultDto<ResultGetCommentsBySectionIdServiceDto> { IsSuccess = false, };
        }
    }
}
