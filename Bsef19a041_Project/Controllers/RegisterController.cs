using Microsoft.AspNetCore.Mvc;
using Bsef19a041_Project.Models;
using System.IO;
using System.Diagnostics;
using Bsef19a041_Project.Models.Interface;
using Bsef19a041_Project.Models.Repositories;

namespace Bsef19a041_Project.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUser userRepo;
        private readonly ILogger<RegisterController> _logger;
        private readonly IWebHostEnvironment Environment;
        public RegisterController(ILogger<RegisterController> logger, IWebHostEnvironment environment,IUser u)
        {
            _logger = logger;
            Environment = environment;
            userRepo=u;
        }
        public IActionResult ListUsers()
        {
            return View(userRepo.GetAllUsers());
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] userLogin uL)
        {

            var data=userRepo.GetUserLogin(uL);
           
            if (data.Item2!=null)
            {
                return View("Welcome", data.Item2);
            }
            else
            {
                return this.Ok($"Email or password Does Not Match");
            }
        }
        public ViewResult UserForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserForm(User u, List<IFormFile> PostedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in PostedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                Func<Type>?x = fileName.GetType;
                Console.WriteLine(x);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream); 
                   
                    ViewBag.Message = "file uploaded successfully";
                }
            }
            if (ModelState.IsValid)
            {
                userRepo.AddUser(u);
                return View("Welcome", u);
            }
            else
            {
                //ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
        }
    }
}
