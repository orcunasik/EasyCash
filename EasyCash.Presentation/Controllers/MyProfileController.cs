using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
