namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies
{
    public class GetUserProfileCompaniesDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } // Company Name
        public string? Position { get; set; } // Such as 'CEO','Digital Artist',...
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int CountryId { get; set; }
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
        public DateTime InsertDate { get; set; }
    }
}
