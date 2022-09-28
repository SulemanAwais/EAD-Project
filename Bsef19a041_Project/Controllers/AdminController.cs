using Bsef19a041_Project.Models;
using Bsef19a041_Project.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Bsef19a041_Project.Controllers
{
    public class AdminController : Controller
    {

        private readonly IProduct ProductRepo;
        private readonly IAdmin AdminRepo;
        private readonly ILogger<AdminController> _logger;
        private readonly IWebHostEnvironment Environment;
        public AdminController(ILogger<AdminController> logger, IWebHostEnvironment environment, IProduct p, IAdmin adminRepo)
        {
            _logger = logger;
            Environment = environment;
            ProductRepo=p;
            AdminRepo=adminRepo;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdminSignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminSignUp(Admin a)
        {
            AdminRepo.AddAdmin(a);
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] Admin a)
        {
            if (!ModelState.IsValid)
            {
                bool isLoggedIn=AdminRepo.AdminLogin(a.Email, a.Password);
                if (isLoggedIn)
                {
                    return View("Index");
                }
            }
                    return this.Ok($"Email or password Does Not Match");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewAllProducts()
        {
            return View(ProductRepo.GetAllProducts());
        }
        [HttpPost]
        public IActionResult EditProduct(Products P)
        {

            Products p = ProductRepo.UpdateProduct(P);

            return View("Index");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            Products p= ProductRepo.GetProduct(id);
            return View("EditProduct",p);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Products p,List<IFormFile> PostedFiles)
        {
            p.Path="/css/";
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "css");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in PostedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);

                p.ImageName=fileName;
                Func<Type>? x = fileName.GetType;
                Console.WriteLine(x);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);

                    ViewBag.Message = "file uploaded successfully";
                }
            }
            
            ProductRepo.AddProduct(p);
                return View("Added");
        }
        public IActionResult Added()
        {
            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            bool isProductDeleted = ProductRepo.DeleteProduct(id);
            if (isProductDeleted)
            {
                return View("Deleted");

            }
            return View("Index");
        }
    }
}
