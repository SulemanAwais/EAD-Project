namespace Bsef19a041_Project.Models.Interface
{
    public interface IProduct
    {
        public List<Products> GetProducts(string Category);
        public bool AddItemToCart(int ProductId);
        public Products GetProductById(int ProductId);
        public List<Products> GetAllProducts();
        public Products GetProduct(int Id);
        public Products UpdateProduct(int Id, Products Product);
        public bool DeleteProduct(int ProductId);
        public Products AddProduct(Products p);
        public List<Products> GetProductByName(String ProductName);



    }
}
