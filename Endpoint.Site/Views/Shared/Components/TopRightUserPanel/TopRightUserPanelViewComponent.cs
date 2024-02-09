using Endpoint.Site.Utilities;
using galaxypremiere.Application.Interfaces.FacadePattern;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Endpoint.Site.Views.Shared.Components;

public class TopRightUserPanelViewComponent : ViewComponent
{
    public static String fullname;
    public static long userId;
    public static String? username;

    private readonly IUserInformationFacade _userInformationFacade;

    public TopRightUserPanelViewComponent(IUserInformationFacade userInformationFacade)
    {
        _userInformationFacade = userInformationFacade;
    }
    public IViewComponentResult Invoke()
    {
        if (userId == 0)
        {
            userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
        }
        if (string.IsNullOrEmpty(fullname))
        {
            fullname = ClaimUtility.GetUserFullname(User as ClaimsPrincipal);
        }
        if (string.IsNullOrEmpty(username))
        {
            try
            {
                username = _userInformationFacade.GetUsersInformationServiceService.Execute
                (new galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation.RequestGetUsersInformationServiceDto
                {
                    UsersId = userId
                }).Username;
            }
            catch (Exception ex)
            {
                username = "null";
            }
        }
        return View("Index");
    }
}
