using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Views.Shared.Components.UserProfileNavigation
{
    public class UserProfileNavigationViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Index");
        }
    }
}
