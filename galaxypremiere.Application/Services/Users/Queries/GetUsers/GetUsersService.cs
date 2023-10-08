using galaxypremiere.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace galaxypremiere.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUsersServiceDto Execute()
        {
            var users = _context.Users
                .Include(u => u.UsersInRoles).ThenInclude(ur => ur.Roles)
                .Select(x => new GetUsersServiceDto
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    Email = x.Email,
                    Role = x.UsersInRoles.Select(ur => ur.Roles.Name).First(),
                    IsActive = x.IsActive,
                }).AsNoTracking().ToList();
            return new ResultGetUsersServiceDto
            {
                resultGetUsersServiceDto = users
            };
        }
    }
}
