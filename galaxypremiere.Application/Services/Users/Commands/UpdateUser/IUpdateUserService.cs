using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.Commands.UpdateUser
{
    public class RequestUpdateUserServiceDto
    {
        public long IdUser { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        [MinLength(10, ErrorMessage = "Name characters should be more than 10 characters.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Email Address is mandatory.")]
        [EmailAddress(ErrorMessage = "Email Address is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [MinLength(5, ErrorMessage = "Password characters should be more than 5 characters.")]
        public string? Password { get; set; }
        public List<byte> IdRole { get; set; }

    }
    public interface IUpdateUserService
    {
        ResultDto Execute(RequestUpdateUserServiceDto req);
    }
    public class UpdateUserService: IUpdateUserService
    {
        private readonly IDataBaseContext _context;
        public UpdateUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUserServiceDto req)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == req.IdUser);
            if(user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The User Not Found.",
                };
            }
            user.Fullname= req.Fullname;
            user.Email= req.Email;
            if(req.Password != null) user.Password = req.Password;
            user.UpdateDate = DateTime.Now;

            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "The Changes Were Applied.",
            };
        }
    }
}
