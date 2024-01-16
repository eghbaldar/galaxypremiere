using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat
{
    public class UpdateUsersInformationContactService : IUpdateUsersInformationContactService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationContactService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationContactServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var userContact = _context
                .UsersAddress
                .Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                if (userContact == null) // Create for first time! (INSERT)
                {
                    galaxypremiere.Domain.Entities.Users.UsersAddress usersContact
                        = new galaxypremiere.Domain.Entities.Users.UsersAddress();
                    usersContact = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersAddress>(req);
                    _context.UsersAddress.Add(usersContact);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been update successfully.1"
                    };
                }
                else // The user already existed (UPDATE)
                {
                    var mappedDto = _mapper.Map<RequestUpdateUsersInformationContactServiceDto>(req);
                    _mapper.Map(mappedDto, userContact);
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been update successfully.2"
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user doesn't exist."
                };
            }

        }
    }
}
