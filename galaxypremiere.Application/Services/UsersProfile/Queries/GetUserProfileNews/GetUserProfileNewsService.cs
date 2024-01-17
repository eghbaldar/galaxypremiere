using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews
{
    public class GetUserProfileNewsService : IGetUserProfileNewsService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileNewsService(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                    var result = news.Select(
                        n => _mapper.Map<GetUserProfileNewsDto>(n)
                        ).OrderByDescending(e => e.InsertDate).ToList();
                    return new ResultDto<ResultGetUserProfileNewsServiceDto>()
                    {
                        Data = new ResultGetUserProfileNewsServiceDto
                        {
                            getUserProfileNewsDto = result,
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
