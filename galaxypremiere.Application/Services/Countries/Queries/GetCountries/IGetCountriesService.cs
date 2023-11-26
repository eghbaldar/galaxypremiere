using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Countries.Queries.GetCountries
{
    public interface IGetCountriesService
    {
        public ResultGetCountriesServiceDto Execute();
    }
}
