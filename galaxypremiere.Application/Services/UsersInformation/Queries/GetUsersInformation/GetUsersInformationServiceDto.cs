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
        /// <summary>
        /// //////////////////////////////////////////////// User's Address
        /// </summary>
        public string? Address1 { get; set; } //line1
        public string? Address2 { get; set; } //lien2
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? RecoveryEmail { get; set; }
        public string? Website { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Stage32 { get; set; }
        public string? Youtube { get; set; }
        public string? Linkden { get; set; }
        public string? Vimeo { get; set; }
        public string? Imdb { get; set; }
        /// <summary>
        /// //////////////////////////////////////////////// End of User's Address
        /// </summary>
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
