using System.ComponentModel.DataAnnotations;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO
{
    public class RequestUpdateUsersInformationBioServiceDto
    {
        public long UsersId{ get; set; }
        [MaxLength(300)]
        public string? Introduction { get; set; } //max length: 300
        [MaxLength(7000)]
        public string? BIO { get; set; } //max length: 7000
        [MaxLength(7000)]
        public string? Note { get; set; } // max length: 7000 // it's Trivia
    }
}
