using Endpoint.Site.Utilities;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
                var retrieve = _userInformationFacade.GetUsersInformationServiceService.Execute
                (new galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation.RequestGetUsersInformationServiceDto
                {
                    UsersId = userId
                });
                if(retrieve != null)
                    username= retrieve.Username;
                else
                    username= "";
            }
            catch (Exception ex)
            {
                username = "";
            }
        }
        return View("Index");
    }
}
