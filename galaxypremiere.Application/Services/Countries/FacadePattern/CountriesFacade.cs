using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Countries.Queries.GetCountries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Countries.FacadePattern
{
    public class CountriesFacade: ICountiresFacade
    {
        private readonly IDataBaseContext _context;
        public CountriesFacade(IDataBaseContext context)
        {
            _context = context;
        }
        // Get Countries
        public GetCountriesService getCountriesService;
        public GetCountriesService GetCountriesService
        {
            get { return getCountriesService = getCountriesService ?? new GetCountriesService(_context); }
        }
        //
    }
}
