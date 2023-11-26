using galaxypremiere.Application.Services.Countries.Queries.GetCountries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface ICountiresFacade
    {
        public GetCountriesService GetCountriesService { get; }
    }
}
