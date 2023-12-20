using galaxypremiere.Application.Interfaces.Contexts;

namespace galaxypremiere.Application.Services.UserPosition.Queries.GetUsersPositions
{
    public class GetUsersPositionsService : IGetUsersPositionsService
    {
        private readonly IDataBaseContext _context;
        public GetUsersPositionsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultsersPositionsServiceDto Execute()
        {
            var PositionsList = _context.UsersPositions
                .OrderByDescending(x => x.Position)
                .Select(x => new GetUsersPositionsServiceDto
                {
                    Position = x.Position,
                    Id=x.Id,
                })
                .ToList();
            return new ResultsersPositionsServiceDto
            {
                resultsersPositionsServiceDto = PositionsList,
            };
        }
    }

}
