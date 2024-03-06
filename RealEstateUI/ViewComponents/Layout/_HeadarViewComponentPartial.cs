using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.ViewComponents.Layout
{
    public class _HeadarViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
