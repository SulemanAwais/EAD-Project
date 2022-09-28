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

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new(connectionString);
            connection.Open();
            string query = $"Select * from Product where Id='{Id}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                {
                    p.Id =System.Convert.ToInt32(dr.GetValue(0));
                    p.ImageName =System.Convert.ToString(dr.GetValue(1));
                    p.Path =System.Convert.ToString(dr.GetValue(2));
                    p.Price=System.Convert.ToInt32(dr.GetValue(4));
                };
            }
            return p;
        }

        public List<Products> GetProducts(string Category)
        {
            List<Products> PList = new List<Products>();
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new(connectionString);
            connection.Open();
            string query = $"Select * from Product where Category='{Category}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Products p = new()
                {
                    Id =System.Convert.ToInt32(dr.GetValue(0)),
                    ImageName =System.Convert.ToString(dr.GetValue(1)),
                    Path =System.Convert.ToString(dr.GetValue(2)),
                    Price=System.Convert.ToInt32(dr.GetValue(4)),
                };
                //p.Path=p.Path.Trim()+p.ImageName.Trim();
                PList.Add(p);
            }
            return PList;
        }

        public Products UpdateProduct(Products Product)
        {
            //var db = new ApplicationDBContext();
            //db.Product.Where(p => p.Id==Product.Id).ToList().ForEach(p => p.Price=Product.Price);
            //db.SaveChanges();
            //return Product;

            List<Products> PList = new List<Products>();
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new(connectionString);
            connection.Open();
            string query = $"Update Product set Price ={Product.Price} where Id={Product.Id}";
            SqlCommand cmd = new SqlCommand(query, connection);
            int dr = cmd.ExecuteNonQuery();
            if (dr>=1)
            {
                return Product;
            }
            connection.Close();
            return null;
        }

        public bool DeleteProduct(int ProductId)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new(connectionString);
            connection.Open();
            string query = $"Delete from Product where Id={ProductId}";
            SqlCommand cmd = new SqlCommand(query, connection);
            int dr = cmd.ExecuteNonQuery();
            if (dr>=1)
            {
                return true;
            }
            else return false;
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
