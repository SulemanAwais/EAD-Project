using Bsef19a041_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Bsef19a041_Project.Models.Repositories;
namespace Bsef19a041_Project.ViewComponents
{
    public class wrapsMenuViewComponent:ViewComponent
    {
        ProductRepository productRepo = new ProductRepository();
        public IViewComponentResult Invoke()
        {
            string category = "W";
            List<Products> products = new List<Products>();
            products=productRepo.GetProducts(category);
            return View(products);
        }
    }
}
