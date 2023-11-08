using Dapper;
using galaxypremiere.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using alefbafilms.Common;

namespace galaxypremiere.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        private readonly IConfiguration _configuration;
        public GetUsersService(IDataBaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public ResultGetUsersServiceDto Execute(RequestGetUserServiceDto req)
        {
            int RowCount;
            int RowsOnEachPage = 10; //page-size
            string connString = _configuration.GetConnectionString("LocalServer");
            string command = "SELECT u.*,r.Name 'Role',ul.LoginDateTime FROM [dbo].[Users] u LEFT OUTER JOIN (select top 1 [logindatetime],[usersid] from [dbo].[UsersLoginLog] order by LoginDateTime desc ) ul  ON u.id = ul.usersid JOIN  [dbo].[UsersInRoles] ur ON u.id = ur.[UsersId] JOIN  [dbo].[Roles] r ON ur.RolesId=r.Id";
            var connection = new SqlConnection(connString);
            var result = connection
                .Query<GetUsersServiceDto>(command)
                .ToPaged(req.CurrentPage,RowsOnEachPage,out RowCount)
                .ToList();
            return new ResultGetUsersServiceDto
            {
                resultGetUsersServiceDto = result,
                RowCount= RowCount,
                RowsOnEachPage= RowsOnEachPage,
            };
        }
    }
}
