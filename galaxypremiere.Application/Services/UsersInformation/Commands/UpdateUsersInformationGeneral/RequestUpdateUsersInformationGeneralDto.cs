namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral
{
    public class RequestUpdateUsersInformationGeneralDto
    {
        public long UsersId { get; set; }
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public byte Gender { get; set; } = 0; // Check: [GenderConstants.cs]
        public int CountryId { get; set; } = 0; // derived from [Countries] entity
        public int LanguageId { get; set; }
        public string? BirthDay { get; set; } // 1989/02/09
        public string? BirthCity { get; set; }
        public string? CurrentCity { get; set; }
    }
}
