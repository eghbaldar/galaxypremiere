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
            if (req == null)
            {
                return new ResultDto<ResultGetUserProfileEducationsServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var education = _context.UsersEducation
                    .Where(u => u.UsersId == req.UsersId)
                    .ToList();
                if (education != null)
                {
                    var result = education.Select(
                        e=>_mapper.Map<GetUserProfileEducationsServiceDto>(e)
                        ).OrderByDescending(e => e.InsertDate).ToList();
                    return new ResultDto<ResultGetUserProfileEducationsServiceDto>()
                    {
                        Data = new ResultGetUserProfileEducationsServiceDto
                        {
                            getUserProfileEducationsServiceDto = result,
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
