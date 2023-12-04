namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationAccountType
{
    public class RequestUpdateUsersInformationAccountTypeServiceDto
    {
        public long UsersId { get; set; }
        public byte AccountType { get; set; } // based on AccountTypeConstants Class
    }
}
