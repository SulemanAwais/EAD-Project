using Bsef19a041_Project.Models;
using Bsef19a041_Project.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Bsef19a041_Project.Models.ViewModel;
using AutoMapper;

namespace Bsef19a041_Project.Controllers
{
    public class CartController : Controller
    {
        public readonly IProduct productRepo;
        private readonly ILogger<CartController> _logger;
        private readonly IWebHostEnvironment Environment;
        private readonly IMapper _mapper;

        public CartController(IProduct product, ILogger<CartController> logger, IMapper mapper ,IWebHostEnvironment environment)
        {
            productRepo=product;
            _logger=logger;
            Environment=environment;
            _mapper = mapper;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchResult(List<Products> LIST)
        {
            return View();
        }
        [HttpGet]
        public IActionResult SeacrhResult()
        {
            return View();
        }
        public IActionResult Search([FromForm] Products p)
        {
            List<Products> productList = new List<Products>();
            productList=productRepo.GetProductByName(p.ImageName);
            return View("SearchResult",productList);
        }
        [Route("Id")]
        public IActionResult AddToCart(/*[FromQuery] */int Id)
        {
            //Products p=productRepo.GetProductById(Id);
            List<Products> product = new List<Products>();
            string itemsList = "";
            string info = "";
            Products p=productRepo.GetProduct(Id);
            ProductViewModel pViewModel = _mapper.Map<ProductViewModel>(p);

            if (HttpContext.Session.Keys.Contains("added_Items"))
            {
                String addedItems = HttpContext.Session.GetString("added_Items");
                //pViewModel = pViewModel.Remove(pViewModel.Length-4, 4);
                info= pViewModel.ProductName+ " already added to the cart at \n"+addedItems;
            }
            else
            {
                itemsList = itemsList + ","+ Id;
                product.Add(p);
                int count = 1;
                String c = System.Convert.ToString(count);
                HttpContext.Session.SetString("added_Items", System.DateTime.Now.ToString());
                HttpContext.Session.SetString("quantity", c);

            }
            return View("AddToCart", info);

        }
    }
}
