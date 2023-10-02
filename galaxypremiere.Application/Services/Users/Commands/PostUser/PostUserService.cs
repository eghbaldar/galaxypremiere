using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace galaxypremiere.Application.Services.Users.Commands.PostUser
{
    public class PostUserService : IPostUserService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostUserService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestPostUserServiceDto req)
        {
            // --- MAPPER ----
            Domain.Entities.Users.Users user = _mapper.Map<Domain.Entities.Users.Users>(req);
            // --- OR THE BELOW CODE ---
            //Domain.Entities.Users.Users user = new Domain.Entities.Users.Users()
            //{
            //    Fullname = req.Fullname,
            //    Email = req.Email,
            //    Password = req.Password,
            //};

            List<UsersInRoles> usersInRoles = new List<UsersInRoles>();
            foreach (var idRole in req.IdRole)
            {
                //var role = _context.Roles.Find(idRole);
                var role = _context.Roles.AsTracking().SingleOrDefault(x => x.Id == idRole);
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
                        Message = "There Is No Role With This Attribute There.",
                    };
                }
            }
            user.UsersInRoles = usersInRoles;
            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "New User Has Just Been Added Successfully.",
            };
        }
    }
}
