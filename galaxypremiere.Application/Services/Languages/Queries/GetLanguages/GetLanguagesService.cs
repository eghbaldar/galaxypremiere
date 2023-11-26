using galaxypremiere.Application.Interfaces.Contexts;

namespace galaxypremiere.Application.Services.Languages.Queries.GetLanguages
{
    public class GetLanguagesService: IGetLanguagesService
    {
        private readonly IDataBaseContext _context;
        public GetLanguagesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetLanguagesServiceDto Execute()
        {
            var langs = _context.Languages
                .Select(la => new GetLanguagesServiceDto
                {
                    Id = la.Id,
                    Name = la.NameEnglish + " (" + la.NameNative + ")",
                })
                .OrderBy(la=>la.Name)
                .ToList();
            return new ResultGetLanguagesServiceDto
            {
                getLanguagesServiceDto = langs,
            };
        }
    }
}
