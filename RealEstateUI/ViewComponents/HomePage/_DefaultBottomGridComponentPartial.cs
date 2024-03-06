using Microsoft.AspNetCore.Mvc;


namespace RealEstateUI.ViewComponents.HomePage
{
    public class _DefaultBottomGridComponentPartial:ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}
