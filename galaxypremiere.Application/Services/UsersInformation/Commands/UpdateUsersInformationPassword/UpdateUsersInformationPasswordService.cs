using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPassword
{
    public class UpdateUsersInformationPasswordService : IUpdateUsersInformationPasswordService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationPasswordService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationPasswordDto req)
        {
            if (req.Password == null || req.Password.Trim().Length == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Enter your strong password please.",
                };
            }
            var user = _context
                .Users
                .Where(u => u.Id == req.UsersId)
                .First();
            if (user != null)
            {
                var mappedDto = _mapper.Map<RequestUpdateUsersInformationPasswordDto>(req);
                _mapper.Map(mappedDto, user);

                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "The information is updated successfully.",
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The User is not found.",
                };
            }
        }
    }
}
