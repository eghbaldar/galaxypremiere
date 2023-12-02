using galaxypremiere.Application.Interfaces.Contexts;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetCheckDuplicatedUsername
{
    public class GetCheckDuplicatedUsernameService : IGetCheckDuplicatedUsernameService
    {
        private readonly IDataBaseContext _context;
        public GetCheckDuplicatedUsernameService(IDataBaseContext context)
        {
            _context = context;
        }
        public bool Execute(RequestGetCheckDuplicatedUsernameDto req)
        {
            var check = _context
                  .UsersInformation
                  .Where(u => u.Username == req.Username)
                  .Any();
            return check;
        }
    }
}
