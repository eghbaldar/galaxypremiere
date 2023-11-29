namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation
{
    public class GetUsersInformationServiceDto
    {
        public long UsersId { get; set; }
        public byte AccountType { get; set; } // check [AccountTypeConstants.cs]
        public string? Username { get; set; } // www.galaxypremiere.com/Username
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public byte Gender { get; set; } = 0; // Check: [GenderConstants.cs]
        public int CountryId { get; set; } = 0; // derived from [Countries] entity
        public int LanguageId { get; set; }
        public string? BirthDay { get; set; } // 1989/02/09
        public string? BirthCity { get; set; }
        public string? CurrentCity { get; set; }







        public string? Position { get; set; } // Director, Producer, Actor, etc.
        public byte TimeZoneId { get; set; }
        public byte CurrencyId { get; set; }
        public string? Photo { get; set; } // avatar
        public string? Header { get; set; } // header phone (landscape)
        public string? Introduction { get; set; } //max length: 300
        public string? BIO { get; set; } //max length: 7000
        public string? Note { get; set; } // it's Trivia
        public byte Privacy { get; set; } = 0; // check [PrivacyConstants.cs]
    }

}
