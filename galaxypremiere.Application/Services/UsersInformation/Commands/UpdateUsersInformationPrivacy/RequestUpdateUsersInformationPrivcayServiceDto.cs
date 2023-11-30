namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPrivacy
{
    public class RequestUpdateUsersInformationPrivcayServiceDto
    {
        public long UsersId { get; set; }
        public byte Privacy { get; set; }
    }
}
