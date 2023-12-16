using galaxypremiere.Common.DTOs;
using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot
{
    public interface IUpdateUsersInformationHeadshotService
    {
        ResultDto Execute(RequestUpdateUsersInformationHeadshotServiceDto req);
    }
}
