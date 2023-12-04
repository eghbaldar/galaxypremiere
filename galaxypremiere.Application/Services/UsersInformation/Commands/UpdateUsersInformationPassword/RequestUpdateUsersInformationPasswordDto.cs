namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPassword
{
    public class RequestUpdateUsersInformationPasswordDto
    {
        public long UsersId { get; set; }
        public string Password { get; set; }
    }
}
