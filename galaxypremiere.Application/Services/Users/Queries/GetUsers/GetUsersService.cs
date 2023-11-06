using Dapper;
using galaxypremiere.Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


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
        public ResultGetUsersServiceDto Execute()
        {
            string connString = _configuration.GetConnectionString("LocalServer");
            string command = "SELECT * FROM [dbo].[Users] u LEFT OUTER JOIN (select top 1 [logindatetime],[usersid] from [dbo].[UsersLoginLog] order by LoginDateTime desc ) ul ON u.id = ul.usersid";
            var connection = new SqlConnection(connString);
            var result = connection.Query<GetUsersServiceDto>(command).ToList();
            return new ResultGetUsersServiceDto
            {
                resultGetUsersServiceDto = result,
            };
        }
    }
}
