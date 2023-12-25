namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationOther
{
    public class RequestUpdateUsersInformationOtherServiceDto
    {
        public long UsersId { get; set; }
        public byte TimeZoneId { get; set; }
        public byte CurrencyId { get; set; }
    }
}
