namespace galaxypremiere.Application.Services.UserLoginLog.Queries.GetUsersLoginLogs
{
    public class GetUsersLoginLogsServiceDto
    {
        public long Id { get; set; }
        public string IP { get; set; }
        public DateTime LoginDateTime { get; set; } = DateTime.Now;
    }
}
