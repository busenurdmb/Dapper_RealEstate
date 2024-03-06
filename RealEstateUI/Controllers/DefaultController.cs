using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
