using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace galaxypremiere.Application.Services.Users.Commands.UpdateUser
{
    public class UpdateUserService: IUpdateUserService
    {
        private readonly IDataBaseContext _context;
        public UpdateUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUserServiceDto req)
        {
            var user = _context.Users.Include(u=>u.UsersInRoles).SingleOrDefault(u => u.Id == req.IdUser);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The User Not Found.",
                };
            }            

            user.Fullname= req.Fullname;
            user.Email= req.Email;
            
            user.UsersInRoles.Clear();
            user.UsersInRoles.Add(new UsersInRoles
            {
                Users = user,
                RolesId = req.IdRole[0],
            });

            PasswordHasher passHasher = new PasswordHasher();
            if (req.Password != null) user.Password= passHasher.HashPassword(req.Password);

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
