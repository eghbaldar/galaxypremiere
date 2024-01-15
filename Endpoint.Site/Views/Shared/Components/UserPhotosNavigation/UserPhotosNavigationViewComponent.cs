using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Views.Shared.Components.UserPhotosNavigation
{
    public class UserPhotosNavigationViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Index");
        }
    }
}
