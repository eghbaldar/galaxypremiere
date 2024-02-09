using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername
{
    public class GetUsersInformationByUsernameService : IGetUsersInformationByUsernameService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUsersInformationByUsernameService(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultGetUsersInformationByUsernameServiceDto Execute(RequestUsersInformationByUsernameServiceDto req)
        {
            if (req == null)
                return new ResultGetUsersInformationByUsernameServiceDto
                {
                    resultGetUsersInformationByUsernameServiceDto = new ResultDto<GetUsersInformationByUsernameServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "The page does not exist.",
                    }
                };
            var userInformation = _context.UsersInformation
                .Where(u => u.Username == req.Username)
                .Select(u => _mapper.Map<GetUsersInformationByUsernameServiceDto>(u))
                .FirstOrDefault();
            if (userInformation != null)
            {
                return new ResultGetUsersInformationByUsernameServiceDto
                {
                    resultGetUsersInformationByUsernameServiceDto = new ResultDto<GetUsersInformationByUsernameServiceDto>
                    {
                        Data = userInformation,
                        IsSuccess = true,
                        Message = "Success!",
                    }
                };
            }
            else
            {
                return new ResultGetUsersInformationByUsernameServiceDto
                {
                    resultGetUsersInformationByUsernameServiceDto = new ResultDto<GetUsersInformationByUsernameServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "The page does not exist.",
                    }
                };
            }
        }
    }
}
