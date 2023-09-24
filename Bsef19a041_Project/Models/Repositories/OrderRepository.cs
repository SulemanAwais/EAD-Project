using Bsef19a041_Project.Models.Interface;

namespace Bsef19a041_Project.Models.Repositories
{
    public class OrderRepository : IOrder
    {
        public bool AddItemToCart(int userId, string productId)
        {
            var db = new ApplicationDBContext();
            var query=db.OrderTable.Where(u => u.UserId==userId)/*.Select(u => u.ProductId.Concat(",").Concat(productId))*/;
            foreach (var item in query)
            {
                item.ProductId=item.ProductId+","+productId;
            }
            db.SaveChanges();
            return true;
        }
        public bool AddFirstItemToCart(int userId, string productId)
        {
            var db = new ApplicationDBContext();
            Order o = new Order();
                o.UserId=userId;
            o.ProductId=productId;
;            db.OrderTable.Add(o);
            db.SaveChanges();
            return true;
        }

        public string products(int UserId)
        {
            var db = new ApplicationDBContext();
            string produtId = null;
            db.OrderTable.Where(o => o.UserId==UserId).ToList().ForEach(p => produtId=p.ProductId);
            db.SaveChanges();
            return produtId;
        }

        public List<Products> Products(int UserId)
        {
            List<Products> pro = new List<Products>();
            var db = new ApplicationDBContext();
            Products temp = new Products();
            var query=db.OrderTable.Where(p => p.UserId==UserId);
            foreach (var item in query)
            {
                temp.Id=int.Parse(item.ProductId);
                ProductRepository pr = new ProductRepository();
                var data=pr.GetProductById(temp.Id);
                pro.Add(data);
            }
            return pro;
        }
    }
}
