using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationAccountType
{
    public class UpdateUsersInformationAccountTypeService : IUpdateUsersInformationAccountTypeService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationAccountTypeService(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationAccountTypeServiceDto req)
        {
            var userType = _context
                    .UsersInformation
                    .Where(u => u.UsersId == req.UsersId).FirstOrDefault();
            if (userType == null) // Create for first time! (INSERT)
            {
                galaxypremiere.Domain.Entities.Users.UsersInformation usersInfo
                    = new galaxypremiere.Domain.Entities.Users.UsersInformation();
                usersInfo = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersInformation>(req);
                _context.UsersInformation.Add(usersInfo);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "Information has just been update successfully.1"
                };
            }
            else // The user already existed (UPDATE)
            {
                var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
                if (user != null)
                {
                    var mappedDto = _mapper.Map<RequestUpdateUsersInformationAccountTypeServiceDto>(req);
                    _mapper.Map(mappedDto, userType);
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been update successfully.2"
                    };
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
}
