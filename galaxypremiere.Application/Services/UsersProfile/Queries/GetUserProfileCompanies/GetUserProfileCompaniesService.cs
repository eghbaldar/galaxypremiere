using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies
{
    public class GetUserProfileCompaniesService : IGetUserProfileCompaniesService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUserProfileCompaniesService(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ResultGetUserProfileCompaniesServiceDto> Execute(RequestGetUserProfileCompaniesDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUserProfileCompaniesServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var company = _context.UsersCompanies
                    .Where(u => u.UsersId == req.UsersId)
                    .ToList();
                if (company != null)
                {
                    var result = company.Select(
                        c=> _mapper.Map<GetUserProfileCompaniesDto>(c)
                        ).OrderByDescending(e => e.InsertDate).ToList();
                    return new ResultDto<ResultGetUserProfileCompaniesServiceDto>()
                    {
                        Data = new ResultGetUserProfileCompaniesServiceDto
                        {
                            getUserProfileCompaniesDto = result,
                        },
                        IsSuccess = true,
                        Message = "The user does not exist."
                    };
                }
            }
            else// _mapper.Map<UsersEducation>(education)
            {
                return new ResultDto<ResultGetUserProfileCompaniesServiceDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
            return new ResultDto<ResultGetUserProfileCompaniesServiceDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "The user does not exist."
            };
        }
    }
}
