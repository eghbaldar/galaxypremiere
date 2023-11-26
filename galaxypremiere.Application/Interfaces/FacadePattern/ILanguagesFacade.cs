using galaxypremiere.Application.Services.Languages.Queries.GetLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface ILanguagesFacade
    {
        GetLanguagesService GetLanguagesService { get; }
    }
}
