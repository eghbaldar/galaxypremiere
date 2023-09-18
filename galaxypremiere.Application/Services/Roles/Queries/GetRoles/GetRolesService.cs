using galaxypremiere.Application.Interfaces.Contexts;

namespace galaxypremiere.Application.Services.Roles.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;
        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public List<ResultIGetRolesServiceDto> Execute()
        {
            var roles = _context.Roles.Select(x=> new ResultIGetRolesServiceDto
            {
                 Id=x.Id,
                 Name=x.Name,
            }).ToList();
            return roles;
        }
    }
}
