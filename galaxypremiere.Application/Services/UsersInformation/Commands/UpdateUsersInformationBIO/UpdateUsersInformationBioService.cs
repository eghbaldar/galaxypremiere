using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO
{
    public class UpdateUsersInformationBioService: IUpdateUsersInformationBioService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationBioService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationBioServiceDto req)
        {
            var userBIO = _context
                    .UsersInformation
                    .Where(u => u.UsersId == req.UsersId).FirstOrDefault();
            if (userBIO == null) // Create for first time! (INSERT)
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
                    var mappedDto = _mapper.Map<RequestUpdateUsersInformationBioServiceDto>(req);
                    _mapper.Map(mappedDto, userBIO);
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
