using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations
{
    public class GetUserProfileEducationsService : IGetUserProfileEducationsService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileEducationsService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ResultGetUserProfileEducationsServiceDto> Execute(RequestGetUserProfileEducationsServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var education = _context.UsersEducation
                    .Where(u => u.UsersId == req.UsersId)
                    .ToList();
                if (education != null)
                {
                    var ed = education.Select(e => new GetUserProfileEducationsServiceDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Field = e.Field,
                        From = e.From,
                        To = e.To,
                    }).ToList();
                    return new ResultDto<ResultGetUserProfileEducationsServiceDto>()
                    {
                        Data = new ResultGetUserProfileEducationsServiceDto
                        {
                            getUserProfileEducationsServiceDto = ed,
                        },
                        IsSuccess = true,
                        Message = "The user does not exist."
                    };
                }
            }
            else// _mapper.Map<UsersEducation>(education)
            {
                return new ResultDto<ResultGetUserProfileEducationsServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
            return new ResultDto<ResultGetUserProfileEducationsServiceDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "The user does not exist."
            };
        }
    }
}
