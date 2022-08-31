using Microsoft.AspNetCore.Mvc;

namespace Bsef19a041_Project.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
