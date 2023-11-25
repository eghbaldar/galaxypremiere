using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral
{
    public class UpdateUsersInformationAccountService : IUpdateUsersInformationAccountService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationAccountService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
            public ResultDto Execute(RequestUpdateUsersInformationAccountDto req)
            {
            try
            {
                var userInfo = _context.UsersInformation.Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                if (userInfo == null) // Create for first time! (INSERT)
                {
                    galaxypremiere.Domain.Entities.Users.UsersInformation usersInformation
                        = new galaxypremiere.Domain.Entities.Users.UsersInformation();
                    usersInformation = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersInformation>(req);
                    _context.UsersInformation.Add(usersInformation);
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
                        var mappedDto = _mapper.Map<RequestUpdateUsersInformationAccountDto>(req);
                        _mapper.Map(mappedDto, userInfo);                        
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
            catch (Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
