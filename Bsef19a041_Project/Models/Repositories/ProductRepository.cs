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
            db.Product.Where(p => p.Id==ProductId).ToList().ForEach(p=>pro=p);
            return pro;
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
                p.Path=p.Path.Trim()+p.ImageName.Trim();
                PList.Add(p);
            }
            return PList;
        }
    }
}
