using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.Commands.DeleteUser
{
    public class RequestDeleteUserServiceDto
    {
        public long IdUser { get; set; }
    }
    public interface IDeleteUserService
    {
        ResultDto Execute(RequestDeleteUserServiceDto req);
    }
    public class DeleteUserService: IDeleteUserService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUserServiceDto req)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == req.IdUser);
            if (!(user == null))
            {
                user.DeleteDate = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "The User Was Deleted Successfully",
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "This User Does Not Exists",
                };
            }
        }
    }
}
