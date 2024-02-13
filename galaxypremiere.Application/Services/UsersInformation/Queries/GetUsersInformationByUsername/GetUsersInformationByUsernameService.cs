using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername
{
    public class GetUsersInformationByUsernameService : IGetUsersInformationByUsernameService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUsersInformationByUsernameService(IDataBaseContext context, IMapper mapper)
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

            var userInformation = (
            from i in _context.UsersInformation
            where (i.Username == req.Username)
            select new
            {
                UserInformation = i,
            }
            ).FirstOrDefault();

            if (userInformation != null)
            {
                var mappedUserInformation = _mapper.Map<GetUsersInformationByUsernameServiceDto>(userInformation.UserInformation);

                return new ResultGetUsersInformationByUsernameServiceDto
                {
                    resultGetUsersInformationByUsernameServiceDto = new ResultDto<GetUsersInformationByUsernameServiceDto>
                    {
                        Data = mappedUserInformation,
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
