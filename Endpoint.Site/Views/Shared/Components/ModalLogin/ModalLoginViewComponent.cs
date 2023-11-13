using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Views.Shared.Components.Login
{
    public class ModalLoginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Index");
        }
    }
}
