using alefbafilms.Common;
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
                int RowsCount; //for Pagination
                int RowsInEachOage = 20; //for Pagination
                var result = _context.UsersLoginLog
                    .Where(ull => ull.UsersId == req.UsersId)
                    .ToPaged(req.Page, RowsInEachOage, out RowsCount)
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
                    RowCount = RowsCount,
                    RowsInEachOage= RowsInEachOage,
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
