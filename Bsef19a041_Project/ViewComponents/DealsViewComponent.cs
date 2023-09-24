using Bsef19a041_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Bsef19a041_Project.Models.Repositories;
namespace Bsef19a041_Project.ViewComponents
{
    public class DealsViewComponent:ViewComponent
    {
        ProductRepository productRepo = new ProductRepository();
        //[Route("UserId")]
        public IViewComponentResult Invoke()
        {
            string category = "D";
            List<Products> products = new List<Products>();
            products=productRepo.GetProducts(category);
            return View(products);
        }
    }
}
