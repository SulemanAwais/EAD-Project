using Microsoft.Data.SqlClient;
using Bsef19a041_Project.Models.Interface;

namespace Bsef19a041_Project.Models.Repositories
{
    public class ContentRepository:IContent
    {
        public List<Content> GetContent()
        {
            List<Content> contentList = new List<Content>();
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new(connectionString);
            connection.Open();
            string query = "Select * from contents";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Content c = new()
                {
                    Id =System.Convert.ToInt32(dr.GetValue(0)),
                    ImageName =System.Convert.ToString(dr.GetValue(1)),
                    Path =System.Convert.ToString(dr.GetValue(2)),
                };
                contentList.Add(c);
            }
            return contentList;
        }
    }
}
