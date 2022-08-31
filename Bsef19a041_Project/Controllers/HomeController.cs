using Microsoft.AspNetCore.Mvc;

namespace Bsef19a041_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
