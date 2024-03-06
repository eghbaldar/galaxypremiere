using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationUsernameByUserId
{
    public class GetUsersInformationUsernameByUserIdService : IGetUsersInformationUsernameByUserIdService
    {
        private readonly IDataBaseContext _context;
        public GetUsersInformationUsernameByUserIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<string> Execute(RequestGetUsersInformationUsernameByUserIdServiceDto req)
        {
            if (req == null) return new ResultDto<string> { IsSuccess = false };
            var user = _context.UsersInformation.Where(u => u.UsersId == req.UsersId).FirstOrDefault();
            if (user != null) return new ResultDto<string> { IsSuccess = true, Data = user.Username };
            else return new ResultDto<string> { IsSuccess = false, };
        }
    }
}
