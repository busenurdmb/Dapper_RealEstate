using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace RealEstateUI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList:ViewComponent
    {
       

        public IViewComponentResult Invoke()
        {
           
            return View();
        }
    }
}
