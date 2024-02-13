namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat
{
    public class RequestUpdateUsersInformationContactServiceDto
    {
        public long UsersId{ get; set; }
        public string? Address1 { get; set; } //line1
        public string? Address2 { get; set; } //lien2
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public int CountryId { get; set; }
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
    }
}
