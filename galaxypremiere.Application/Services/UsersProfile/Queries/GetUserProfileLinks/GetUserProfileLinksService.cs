using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileLinks
{
    public class GetUserProfileLinksService : IGetUserProfileLinksService
    {
        private readonly IDataBaseContext _context;
        public GetUserProfileLinksService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultGetUserProfileLinksServiceDto> Execute(RequestGetUserProfileLinksDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUserProfileLinksServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var links = _context.UsersLinks
                    .Where(u => u.UsersId == req.UsersId)
                    .ToList();
                if (links != null)
                {
                    var ed = links.Select(e => new GetUserProfileLinksDto
                    {
                        Id = e.Id,
                        Link = e.Link,
                        Title = e.Title,
                        InsertDate = e.InsertDate,
                    }).OrderByDescending(e => e.InsertDate).ToList();
                    return new ResultDto<ResultGetUserProfileLinksServiceDto>()
                    {
                        Data = new ResultGetUserProfileLinksServiceDto
                        {
                            getUserProfileLinksDto = ed,
                        },
                        IsSuccess = true,
                        Message = "The user does not exist."
                    };
                }
            }
            else// _mapper.Map<UsersEducation>(education)
            {
                return new ResultDto<ResultGetUserProfileLinksServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
            return new ResultDto<ResultGetUserProfileLinksServiceDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "The user does not exist."
            };
        }
    }
}
