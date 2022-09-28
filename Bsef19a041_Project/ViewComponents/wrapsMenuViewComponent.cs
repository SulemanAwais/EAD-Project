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
            List<String> ImageFullPath = new List<String>();
            foreach (var item in products)
            {
               String p= item.Path/*+item.ImageName*/;
                ImageFullPath.Add(p);
            }
            ViewBag.ImagePath=ImageFullPath;

            return View(products);
        }
    }
}
