using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews
{
    public class GetUserProfileNewsService : IGetUserProfileNewsService
    {
        private readonly IDataBaseContext _context;
        public GetUserProfileNewsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultGetUserProfileNewsServiceDto> Execute(RequestGetUserProfileNewsDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUserProfileNewsServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var news = _context.UsersNews
                    .Where(u => u.UsersId == req.UsersId)
                    .ToList();
                if (news != null)
                {
                    var ed = news.Select(e => new GetUserProfileNewsDto
                    {
                        Id = e.Id,
                        Link = e.Link,
                        PublishedDate = e.PublishedDate,
                        Reference = e.Reference,
                        Title = e.Title,
                        InsertDate = e.InsertDate,
                    }).OrderByDescending(e => e.InsertDate).ToList();
                    return new ResultDto<ResultGetUserProfileNewsServiceDto>()
                    {
                        Data = new ResultGetUserProfileNewsServiceDto
                        {
                            getUserProfileNewsDto = ed,
                        },
                        IsSuccess = true,
                        Message = "The user does not exist."
                    };
                }
            }
            else// _mapper.Map<UsersEducation>(education)
            {
                return new ResultDto<ResultGetUserProfileNewsServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
            return new ResultDto<ResultGetUserProfileNewsServiceDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "The user does not exist."
            };
        }
    }
}
