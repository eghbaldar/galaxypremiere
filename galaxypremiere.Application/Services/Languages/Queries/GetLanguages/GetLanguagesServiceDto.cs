namespace galaxypremiere.Application.Services.Languages.Queries.GetLanguages
{
    public class GetLanguagesServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } // NameEnglish + NameNative => NameEnglish (NameNative)
    }
}
