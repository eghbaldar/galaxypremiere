using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername
{
    public class GetUsersInformationContactByUsernameService : IGetUsersInformationContactByUsernameService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUsersInformationContactByUsernameService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultGetUsersInformationContactByUsernameServiceDto Execute(RequestGetUsersInformationContactByUsernameServiceDto req)
        {
            if (req == null)
                return new ResultGetUsersInformationContactByUsernameServiceDto
                {
                    resultGetUsersInformationContactByUsernameServiceDto = new ResultDto<GetUsersInformationContactByUsernameServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "The information is not loaded, something went wrong.",
                    }
                };
            var userContact = (
                from i in _context.UsersAddress
                    join country in _context.Countries on i.CountryId equals country.Id into countryGroup
                        from country in countryGroup.DefaultIfEmpty()
                    join info in _context.UsersInformation on i.UsersId equals info.UsersId into infoGroup
                        from info in infoGroup.DefaultIfEmpty()
                where (info.Username == req.Username)
            select new
            {
                UserContact = i,
                CountryName = country.Name,
            }
            ).FirstOrDefault();
            if (userContact != null)
            {
                var mappedUserContact = _mapper.Map<GetUsersInformationContactByUsernameServiceDto>(userContact.UserContact);
                mappedUserContact.CountryName = userContact.CountryName;

                return new ResultGetUsersInformationContactByUsernameServiceDto
                {
                    resultGetUsersInformationContactByUsernameServiceDto = new ResultDto<GetUsersInformationContactByUsernameServiceDto>
                    {
                        Data = mappedUserContact,
                        IsSuccess = true,
                        Message = "Success!",
                    }
                };
            }
            else
            {
                return new ResultGetUsersInformationContactByUsernameServiceDto
                {
                    resultGetUsersInformationContactByUsernameServiceDto = new ResultDto<GetUsersInformationContactByUsernameServiceDto>
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
