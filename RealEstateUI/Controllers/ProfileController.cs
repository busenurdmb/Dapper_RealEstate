using Microsoft.AspNetCore.Mvc;

namespace RealEstateUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
