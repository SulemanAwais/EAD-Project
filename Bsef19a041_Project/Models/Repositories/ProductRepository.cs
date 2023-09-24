using Bsef19a041_Project.Models.Interface;
using Microsoft.Data.SqlClient;

namespace Bsef19a041_Project.Models.Repositories
{
    public class ProductRepository : IProduct
    {
        public bool AddItemToCart(int ProductId)
        {
            int Price = 0;
            var db = new ApplicationDBContext();
            db.Product.Where(p => p.Id==ProductId).ToList().
                ForEach(p=>Price=p.Price);
            if (Price==0)
            {
                return false;
            }
            else
                return true;
        }

        public Products GetProductById(int ProductId)
        {
            Products pro = new Products();
            var db = new ApplicationDBContext();
            db.Product.Where(p => p.Id==ProductId ).ToList().ForEach(p=>pro=p);
            return pro;
        }
        public List<Products> GetProductByName(String ProducName)
        {
            List<Products> productList = new List<Products>();
            var db = new ApplicationDBContext();
            db.Product.Where(p => p.ImageName.Contains(ProducName)).ToList().ForEach(p => productList.Add(p));
            return productList;
        }
        public List<Products> GetAllProducts()
        {
            List<Products> ProductList = new List<Products>();
            var db = new ApplicationDBContext();
            var _product = from x in db.Product select x;
            foreach (var item in _product)
            {
                ProductList.Add(item);
            }

            return ProductList;
        }
        public Products GetProduct(int Id)
        {
            Products p = new Products();
            var db = new ApplicationDBContext();
            db.Product.Where(p => p.Id==Id).ToList().ForEach(P => p=P);
            
            return p;
        }

        public List<Products> GetProducts(string Category)
        {
            List<Products> PList = new List<Products>();
            var db = new ApplicationDBContext();
            var Query=db.Product.Where(p => p.Category==Category);
            foreach (var item in Query)
            {
                PList.Add(item);
            }
            return PList;
        }

        public Products UpdateProduct(int Id,Products Product)
        {
            var db = new ApplicationDBContext();
            var query = db.Product.Where(p => p.Id==Id);
            foreach (var item in query)
            {
                item.Price=Product.Price;
            }
            db.SaveChanges();
            return Product;

            //List<Products> PList = new List<Products>();
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection connection = new(connectionString);
            //connection.Open();
            //string query = $"Update Product set Price ={Product.Price} where Id={Product.Id}";
            //SqlCommand cmd = new SqlCommand(query, connection);
            //int dr = cmd.ExecuteNonQuery();
            //if (dr>=1)
            //{
            //    return Product;
            //}
            //connection.Close();
            //return null;
        }

        public bool DeleteProduct(int ProductId)
        {
            var db = new ApplicationDBContext();
            var query = from product in db.Product where product.Id==ProductId select product;
            Products newProduct = new Products();
            foreach (var item in query)
            {
                newProduct=item;
            }
            db.Product.Remove(newProduct);
            db.SaveChanges();
            return true;
        }

        public Products AddProduct(Products p)
        {
            var db = new ApplicationDBContext();
            db.Product.Add(p);
            db.SaveChanges();
            return p;
        }

    }
}
