using Bsef19a041_Project.Models.Interface;
using Microsoft.Data.SqlClient;

namespace Bsef19a041_Project.Models.Repositories
{
    public class DiscountRepository:IDiscount
    {
        public List<Discount> GetOffers()
        {
            List<Discount> discountList = new List<Discount>();
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new(connectionString);
            connection.Open();
            string query = "Select * from discounts";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Discount d = new()
                {
                    Id =System.Convert.ToInt32(dr.GetValue(0)),
                    DiscountDiscription =System.Convert.ToString(dr.GetValue(1)),
                };
                discountList.Add(d);
            }
            return discountList;
        }
    }
}
