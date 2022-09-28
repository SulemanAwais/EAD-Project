using Bsef19a041_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Bsef19a041_Project.Models.Repositories;
using Bsef19a041_Project.Models.Interface;

namespace Bsef19a041_Project.ViewComponents
{
    public class SearchViewCmponent : ViewComponent
    {
        public readonly IProduct productRepo;
        public SearchViewCmponent(IProduct product)
        {
            productRepo=product;
        }

        public IViewComponentResult Invoke([FromForm] Products p)
        {
            List<Products> productList = new List<Products>();
            productList=productRepo.GetProductByName(p.ImageName);
            return View(productList);
        }
    }
}
