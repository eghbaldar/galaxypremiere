using Endpoint.Site.Utilities;
using galaxypremiere.Application.Interfaces.FacadePattern;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Endpoint.Site.Areas.Admin.Views.Shared.Components.TopRightUserPanel
{
    public class TopRightUserPanelViewComponent : ViewComponent
    {
        public static String fullname;
        public IViewComponentResult Invoke()
        {
            fullname = ClaimUtility.GetUserFullname(User as ClaimsPrincipal);
            return View("Index");
        }
    }
}
