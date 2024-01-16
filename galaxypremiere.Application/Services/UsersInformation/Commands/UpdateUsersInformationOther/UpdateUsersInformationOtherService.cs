using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationOther
{
    public class UpdateUsersInformationOtherService: IUpdateUsersInformationOtherService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationOtherService(IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationOtherServiceDto req)
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
                var userOther = _context
                    .UsersInformation
                    .Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                if (userOther == null) // Create for first time! (INSERT)
                {
                    galaxypremiere.Domain.Entities.Users.UsersInformation usersInfo
                        = new galaxypremiere.Domain.Entities.Users.UsersInformation();
                    usersInfo = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersInformation>(req);
                    _context.UsersInformation.Add(usersInfo);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been updated successfully.1"
                    };
                }
                else // The user already existed (UPDATE)
                {
                    var mappedDto = _mapper.Map<RequestUpdateUsersInformationOtherServiceDto>(req);
                    _mapper.Map(mappedDto, userOther);
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been updated successfully.2"
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
