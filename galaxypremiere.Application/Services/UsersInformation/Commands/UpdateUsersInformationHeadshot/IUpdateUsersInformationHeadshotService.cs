using galaxypremiere.Common.DTOs;
using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot
{
    public interface IUpdateUsersInformationHeadshotService
    {
        ResultDto<string> Execute(RequestUpdateUsersInformationHeadshotServiceDto req);
    }
}
