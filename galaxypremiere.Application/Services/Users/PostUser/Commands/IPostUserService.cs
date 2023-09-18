using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.PostUser.Commands
{
    public class RequestPostUserServiceDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [MinLength(10, ErrorMessage = "Name characters should be more than 10 characters.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Email Address is mandatory.")]
        [EmailAddress(ErrorMessage = "Email Address is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [MinLength(5, ErrorMessage = "Password characters should be more than 5 characters.")]
        public string Password { get; set; }
        public List<byte> IdRole { get; set; }
    }
    public interface IPostUserService
    {
        ResultDto Execute(RequestPostUserServiceDto req);
    }
    public class PostUserService : IPostUserService
    {
        private readonly IDataBaseContext _context;
        public PostUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostUserServiceDto req)
        {
            Domain.Entities.Users.Users user = new Domain.Entities.Users.Users()
            {
                Fullname = req.Fullname,
                Email = req.Email,
                Password = req.Password,
            };

            List<UsersInRoles> usersInRoles =
                new List<UsersInRoles>();
            foreach (var idRole in req.IdRole)
            {
                var role = _context.Roles.Find(idRole);
                if (role != null)
                {
                    usersInRoles.Add(new UsersInRoles
                    {
                        RolesId = idRole,
                        Roles = role,
                        UsersId = user.Id,
                        Users = user,
                    });
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "There is no role with this attribute there.",
                    };
                }
            }

            _context.Users.Add(user);
            _context.UsersInRoles.AddRange(usersInRoles);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "New User wsa added successfully.",
            };
        }
    }
}
