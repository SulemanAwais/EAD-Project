using Bsef19a041_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Bsef19a041_Project.Models.Repositories;
namespace Bsef19a041_Project.ViewComponents
{
    public class DiscountOffersViewComponent:ViewComponent
    {
        DiscountRepository discountRepo = new DiscountRepository();
        public IViewComponentResult Invoke()
        {
            List<Discount> discounts = new List<Discount>();
            discounts=discountRepo.GetOffers();
            return View(discounts);
        }
    }
}
