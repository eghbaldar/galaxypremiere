using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.Users.Commands.PostUser
{
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
