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
        public readonly IUser userRepo;
        private readonly IOrder orderRepo;
       private readonly ILogger<CartController> _logger;
        private readonly IWebHostEnvironment Environment;
        private readonly IMapper _mapper;

        public CartController(IProduct product, ILogger<CartController> logger, IMapper mapper , IWebHostEnvironment environment, IUser user, IOrder orderRepo)
        {
            userRepo=user;
            productRepo=product;
            _logger=logger;
            Environment=environment;
            _mapper = mapper;
            this.orderRepo=orderRepo;
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            int userid = userRepo.LoggedInUser();
            string product = orderRepo.products(userid);
            //string[] productId;
            //productId = productList.Split(",");
            List<Products> productsInCart = new List<Products>();
            productsInCart=orderRepo.Products(userid);
            //foreach (var item in productId)
            //{
            //    int ID = int.Parse(item);
            //    Products p = productRepo.GetProductById(ID);
            //    productsInCart.Add(p);
            //}
            
            return View("ViewCart", productsInCart);
        }

        //[HttpGet]
        //public IActionResult ViewCrat()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PlaceOrder()
        {
            string info = null;
            if (HttpContext.Session.Keys.Contains("cart_confirmed"))
            {
                String cartConfirmed = HttpContext.Session.GetString("cart_confirmed");
                info=" Your order has already been placed at  \n"+cartConfirmed;
            }

            else
            {
                HttpContext.Session.SetString("cart_confirmed", System.DateTime.Now.ToString());

                info="order placed successfully";
            }
            return View("PlaceOrder",info);
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
            int userId=userRepo.LoggedInUser();
            List<Products> product = new List<Products>();
            bool isAdded = false;
            Products p=productRepo.GetProduct(Id);
            ProductViewModel pViewModel = _mapper.Map<ProductViewModel>(p);
            isAdded=orderRepo.AddFirstItemToCart(userId, Id.ToString());

            if (isAdded)
            {
                return View("AddToCart",Id);

            }
            else
            {
                return this.Ok($"Not addded");
            }
        }
    }
}
