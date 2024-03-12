using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationNickname
{
    public class RequestUpdateUsersInformationNicknameServiceDto
    {
        public long UsersId { get; set; }
        public string Nickname { get; set; }
    }
    public interface IUpdateUsersInformationNicknameService
    {
        ResultDto<string> Execute(RequestUpdateUsersInformationNicknameServiceDto req);
    }
    public class UpdateUsersInformationNicknameService : IUpdateUsersInformationNicknameService
    {
        private readonly IDataBaseContext _context;
        public UpdateUsersInformationNicknameService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<string> Execute(RequestUpdateUsersInformationNicknameServiceDto req)
        {
            if (req == null) return new ResultDto<string> { IsSuccess = false };
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                user.Nickname = req.Nickname;
                _context.SaveChanges();
                return new ResultDto<string> { Data = req.Nickname, IsSuccess = true };
            }
            else return new ResultDto<string> { IsSuccess = false };
        }
    }
}
