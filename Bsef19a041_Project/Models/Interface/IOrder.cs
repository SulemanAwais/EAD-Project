namespace Bsef19a041_Project.Models.Interface
{
    public interface IOrder
    {
        public bool AddItemToCart(int userId, String productId);
        public bool AddFirstItemToCart(int userId, String productId);
        public string products(int UserId);
        public List<Products> Products(int UserId);

    }
}
