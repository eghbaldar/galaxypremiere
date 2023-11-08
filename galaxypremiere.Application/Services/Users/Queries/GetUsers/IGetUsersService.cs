namespace galaxypremiere.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUsersServiceDto Execute(RequestGetUserServiceDto req);
    }
}
