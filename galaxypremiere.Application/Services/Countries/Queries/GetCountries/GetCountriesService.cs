using galaxypremiere.Application.Interfaces.Contexts;

namespace galaxypremiere.Application.Services.Countries.Queries.GetCountries
{
    public class GetCountriesService: IGetCountriesService
    {
        private readonly IDataBaseContext _context;
        public GetCountriesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetCountriesServiceDto Execute()
        {
            var countries = _context.Countries
                .Select(c => new GetCountriesServiceDto
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .OrderBy(c => c.Name)
                .ToList();
            return new ResultGetCountriesServiceDto
            {
                getCountriesServiceDto = countries,
            };
        }
    }
}
