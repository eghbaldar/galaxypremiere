namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername
{
    public class GetUsersInformationAboutByUsernameServiceDto
    {
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public string Fullname { get; set; } // this filed will be filled up with autompper=> Firstname + Middlename + Surname
        public byte Gender { get; set; } = 0; // Check: [GenderConstants.cs]
        public string GenderText { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string? BirthDay { get; set; } // 1989/02/09
        public string? Age { get; set; } // Now - Birthday
        public string? BirthCity { get; set; }
        public string? CurrentCity { get; set; }
        public string? Position { get; set; } // Director, Producer, Actor, etc.
        public string? Introduction { get; set; } //max length: 300
        public string? BIO { get; set; } //max length: 7000
        public string? Note { get; set; } // it's Trivia
    }
}
