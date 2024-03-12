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
            from info in _context.UsersInformation
            join user in _context.Users on info.UsersId equals user.Id into GroupUser
            from user in GroupUser.DefaultIfEmpty()
            where (info.Username == req.Username)
            select new
            {
                UserInformation = info,
                User = user,
            }
            ).FirstOrDefault();

            if (userInformation != null)
            {
                var mappedUserInformation = _mapper.Map<GetUsersInformationByUsernameServiceDto>(userInformation.UserInformation);
                mappedUserInformation.Nickname = userInformation.User.Nickname;

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
