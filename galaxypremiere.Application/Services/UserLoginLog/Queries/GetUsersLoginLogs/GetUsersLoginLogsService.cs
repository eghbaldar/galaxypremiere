using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UserLoginLog.Queries.GetUsersLoginLogs
{
    public class GetUsersLoginLogsService : IGetUsersLoginLogsService
    {
        private readonly IDataBaseContext _context;
        public GetUsersLoginLogsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUsersLoginLogsServiceDto Execute(RequestGetUsersLoginLogsServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var result = _context.UsersLoginLog
                    .Where(ull => ull.UsersId == req.UsersId)
                    .Select(ull => new GetUsersLoginLogsServiceDto
                    {
                        Id = ull.Id,
                        IP = ull.IP,
                        LoginDateTime = ull.LoginDateTime,
                    })
                    .OrderByDescending(ull => ull.LoginDateTime)
                    .ToList();
                return new ResultGetUsersLoginLogsServiceDto
                {
                    GetUsersLoginLogsServiceDto = result,
                };
            }
            else
            {
                return new ResultGetUsersLoginLogsServiceDto
                {
                    GetUsersLoginLogsServiceDto = null,
                };
            }
        }
    }
}
