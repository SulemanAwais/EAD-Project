using Bsef19a041_Project.Models;
using Bsef19a041_Project.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Bsef19a041_Project.Controllers
{
    public class CartController : Controller
    {
        public readonly IProduct productRepo;
        private readonly ILogger<CartController> _logger;
        private readonly IWebHostEnvironment Environment;

        public CartController(IProduct product, ILogger<CartController> logger, IWebHostEnvironment environment)
        {
            productRepo=product;
            _logger=logger;
            Environment=environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search([FromForm] Search S)
        {
            return View();
        }
       
        public IActionResult AddToCart([FromQuery] int ItemId)
        {
            Products p=productRepo.GetProductById(ItemId);
            List<Products> product = new List<Products>();
            string itemsList = "";
            if (HttpContext.Session.Keys.Contains("added_Items"))
            {
                itemsList = itemsList;
            }
            else
            {
                itemsList = itemsList + ","+ ItemId;
                product.Add(p);
                HttpContext.Session.SetString("added_Items", itemsList);
            }
            return View("AddToCart", ItemId);

        }
    }
}
