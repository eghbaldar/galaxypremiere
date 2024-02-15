using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPositions
{
    public class GetUsersInformationPositionsService : IGetUsersInformationPositionsService
    {
        private readonly IDataBaseContext _context;
        public GetUsersInformationPositionsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<string> Execute(RequestGetUsersInformationPositionsServiceDto req)
        {
            if (req.Positions != null)
            {
                int[] splited = req.Positions.Split(",").Select(int.Parse).ToArray();
                if (splited.Length > 0)
                {
                    var positions = splited.Select(positionId =>
                    {
                        var pos = _context.UsersPositions.FirstOrDefault(u => u.Id == positionId);
                        return pos != null ? pos.Position : string.Empty;
                    }).ToArray();
                    return new ResultDto<string>
                    {
                        Data = string.Join(",", positions),
                        IsSuccess = true,
                        Message = "Succeed"
                    };
                }
                else
                {
                    return new ResultDto<string>
                    {
                        Data = "NotSpecified",
                        IsSuccess = true,
                        Message = "Succeed"
                    };
                }
            }
            else
            {
                return new ResultDto<string>
                {
                    Data = "NotSpecified",
                    IsSuccess = true,
                    Message = "Succeed"
                };
            }
        }
    }
}
