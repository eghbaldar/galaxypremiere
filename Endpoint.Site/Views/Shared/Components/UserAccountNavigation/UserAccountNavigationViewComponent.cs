using Endpoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Endpoint.Site.Views.Shared.Components.UserAccountNavigation
{
    public class UserAccountNavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Index");
        }
    }
}
