namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername
{
    public class GetUsersInformationByUsernameServiceDto
    {
        public long UsersId { get; set; }
        public string AccountType { get; set; } // check [AccountTypeConstants.cs]
        public string? Username { get; set; } // www.galaxypremiere.com/Username
        public string Nickname { get; set; }
        public string? Photo { get; set; } // avatar
        public string? Header { get; set; } // header phone (landscape)
        public byte Privacy { get; set; } = 0; // check [PrivacyConstants.cs]
    }
}
