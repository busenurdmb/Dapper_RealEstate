using Microsoft.AspNetCore.Mvc;


namespace RealEstateUI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
