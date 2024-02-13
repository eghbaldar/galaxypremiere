using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername
{
    public class GetUsersInformationAboutByUsernameService : IGetUsersInformationAboutByUsernameService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUsersInformationAboutByUsernameService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultGetUsersInformationAboutByUsernameServiceDto Execute(RequestGetUsersInformationAboutByUsernameServiceDto req)
        {
            if (req == null)
                return new ResultGetUsersInformationAboutByUsernameServiceDto
                {
                    resultGetUsersInformationAboutByUsernameServiceDto= new ResultDto<GetUsersInformationAboutByUsernameServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "The information is not loaded, something went wrong.",
                    }
                };
            var userInformation = (
            from i in _context.UsersInformation
            join l in _context.Languages on i.LanguageId equals l.Id into languageGroup
            from l in languageGroup.DefaultIfEmpty()
            where (i.Username == req.Username)
            select new
            {
                UserInformation = i,
                LanguageName = l != null ? l.NameEnglish : null,
            }
            ).FirstOrDefault();
            if (userInformation != null)
            {
                var mappedUserInformation = _mapper.Map<GetUsersInformationAboutByUsernameServiceDto>(userInformation.UserInformation);
                mappedUserInformation.LanguageName = userInformation.LanguageName;

                return new ResultGetUsersInformationAboutByUsernameServiceDto
                {
                    resultGetUsersInformationAboutByUsernameServiceDto = new ResultDto<GetUsersInformationAboutByUsernameServiceDto>
                    {
                        Data = mappedUserInformation,
                        IsSuccess = true,
                        Message = "Success!",
                    }
                };
            }
            else
            {
                return new ResultGetUsersInformationAboutByUsernameServiceDto
                {
                    resultGetUsersInformationAboutByUsernameServiceDto = new ResultDto<GetUsersInformationAboutByUsernameServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "The information is not loaded, something went wrong.",
                    }
                };
            }
        }
    }
}
