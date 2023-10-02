using galaxypremiere.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;

namespace galaxypremiere.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersServiceDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class ResultGetUsersServiceDto
    {
        public List<GetUsersServiceDto> resultGetUsersServiceDto { get; set; }
    }
    public interface IGetUsersService
    {
        ResultGetUsersServiceDto Execute();
    }
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context= context;
        }
        public ResultGetUsersServiceDto Execute()
        {
            var users = _context.Users.Select(x => new GetUsersServiceDto
            {
                Fullname = x.Fullname,
                Email = x.Email,
                IsActive = x.IsActive,
            }).AsNoTracking().ToList();
            return new ResultGetUsersServiceDto
            {
                resultGetUsersServiceDto = users
            };
        }
    }
}
