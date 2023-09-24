using Bsef19a041_Project.Models.Interface;
using Microsoft.Data.SqlClient;

namespace Bsef19a041_Project.Models.Repositories
{
    public class DiscountRepository:IDiscount
    {
        public List<Discount> GetOffers()
        {
            List<Discount> discountList = new List<Discount>();
            var db = new ApplicationDBContext();
            var query = from discount in db.discounts select discount;
            foreach (var item in query)
            {
                discountList.Add(item);
            }
            return discountList;
        }
    }
}
 