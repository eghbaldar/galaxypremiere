using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common;
using galaxypremiere.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.Queries.AuthUsers
{
    public class RequestAuthLoginUsersServiceDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ResultAuthLoginUsersServiceDto
    {
        public long IdUser { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
    }
    public interface IAuthLoginUsersService
    {
        ResultDto<ResultAuthLoginUsersServiceDto> Execute(RequestAuthLoginUsersServiceDto req);
    }
    public class AuthLoginUsersService : IAuthLoginUsersService
    {
        private readonly IDataBaseContext _context;
        public AuthLoginUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultAuthLoginUsersServiceDto> Execute(RequestAuthLoginUsersServiceDto req)
        {
            try
            {
                var user = _context.Users
                    .Include(u => u.UsersInRoles)
                    .Where(u => u.Email.Equals(req.Email)).FirstOrDefault();
                if (!(user == null))
                {
                    PasswordHasher passwordHasher = new PasswordHasher();
                    var dehashPass = passwordHasher.VerifyPassword(user.Password, req.Password);
                    if (dehashPass)
                    {
                        long IdRole = user.UsersInRoles.Select(ur => ur.RolesId).First();
                        return new ResultDto<ResultAuthLoginUsersServiceDto>
                        {
                            Data = new ResultAuthLoginUsersServiceDto
                            {
                                IdUser = user.Id,
                                Fullname = user.Fullname,
                                Role = _context.Roles.Where(r => r.Id == IdRole).First().Name,
                            },
                            IsSuccess = true,
                            Message = "You're All Set!",
                        };
                    }
                    else
                        return new ResultDto<ResultAuthLoginUsersServiceDto>
                        {
                            Data = null,
                            IsSuccess = false,
                            Message = "Email or Password Is Incorrect!",
                        };
                }
                else
                    return new ResultDto<ResultAuthLoginUsersServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Email or Password Is Incorrect!",
                    };
            }
            catch (Exception ex)
            {
                return new ResultDto<ResultAuthLoginUsersServiceDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
