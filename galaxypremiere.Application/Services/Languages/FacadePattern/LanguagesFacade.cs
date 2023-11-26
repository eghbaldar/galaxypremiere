using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Languages.Queries.GetLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Languages.FacadePattern
{
    public class LanguagesFacade: ILanguagesFacade
    {
        private readonly IDataBaseContext _context;
        public LanguagesFacade(IDataBaseContext context)
        {
            _context = context;
        }
        // Get Languages
        public GetLanguagesService getLanguagesService;
        public GetLanguagesService GetLanguagesService
        {
            get { return getLanguagesService = getLanguagesService ?? new GetLanguagesService(_context); }
        }
    }
}
