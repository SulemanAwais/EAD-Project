using Bsef19a041_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bsef19a041_Project.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult EverydayValue()
        {
            return View();
        }
        public IActionResult Wraps()
        {

            return View();
        }
        public IActionResult RiceNSpice()
        {
            return View();
        }
        [Route("UserId")]
        public IActionResult Deals ( int UserId)
        {
            User u = new User();
            u.Id=UserId;
            return View("Deals");
        }
    }
}
