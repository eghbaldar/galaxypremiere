namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername
{
    public class GetUsersInformationByUsernameServiceDto
    {
        public long UsersId { get; set; }
        public string AccountType { get; set; } // check [AccountTypeConstants.cs]
        public string? Username { get; set; } // www.galaxypremiere.com/Username
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public string Fullname { get; set; } // this filed will be filled up with autompper=> Firstname + Middlename + Surname
        public string? Photo { get; set; } // avatar
        public string? Header { get; set; } // header phone (landscape)
        public byte Privacy { get; set; } = 0; // check [PrivacyConstants.cs]
    }
}
