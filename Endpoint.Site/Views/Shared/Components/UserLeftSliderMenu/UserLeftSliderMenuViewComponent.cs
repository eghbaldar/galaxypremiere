using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Views.Shared.Components.UserLeftSliderMenu
{
    public class UserLeftSliderMenuViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Index");
        }
    }
}
