using Bsef19a041_Project.Models.Interface;
using Bsef19a041_Project.Models.ViewModel;
using Microsoft.Data.SqlClient;

namespace Bsef19a041_Project.Models.Repositories
{
    public class UserRepository : IUser
    {

        public int UserID { get; set; }
        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            var db = new ApplicationDBContext();
            var _User = from x in db.users select x;
            foreach (var item in _User)
            {
                userList.Add(item);
            }
            return userList;
        }
        public string AddUser(User u)
        {
            var db = new ApplicationDBContext();
            db.users.Add(u);
            UserID=u.Id;
            db.SaveChanges();
            return "success";

        }

        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //SqlConnection connection = new(connectionString);
        //connection.Open();
        //string query = "Select * from users";
        //SqlCommand cmd = new SqlCommand(query, connection);
        //SqlDataReader dr = cmd.ExecuteReader();
        //while (dr.Read())
        //{
        //    User u = new()
        //    {
        //        FirstName =System.Convert.ToString(dr.GetValue(1)),
        //        LastName =System.Convert.ToString(dr.GetValue(2)),
        //        Email =System.Convert.ToString(dr.GetValue(3)),
        //        Password =System.Convert.ToString(dr.GetValue(4))
        //    };
        //    userList.Add(u);
        //}

        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //SqlConnection connection = new SqlConnection(connectionString);
        //connection.Open();
        //string query = $"Insert into users(FirstName,LastName,Email,Password)values(@fN,@lN,@e,@p)";
        //SqlParameter fN = new SqlParameter("@fN", u.FirstName);
        //SqlParameter lN = new SqlParameter("@lN", u.LastName);
        //SqlParameter e = new SqlParameter("@e", u.Email);
        //SqlParameter p = new SqlParameter("@p", u.Password);
        //SqlCommand cmd = new SqlCommand(query, connection);
        //cmd.Parameters.Add(fN);
        //cmd.Parameters.Add(lN);
        //cmd.Parameters.Add(p);
        //cmd.Parameters.Add(e);
        //int dr = cmd.ExecuteNonQuery();
        //string x = "";
        //if (dr >= 1)
        //{
        //    x = "success";
        //}
        //connection.Close();
        //return x;
        public (userLogin, User) GetUserLogin(userLogin user)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = $"select * from users where Email = '{user.Email}' and Password = '{user.Password}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            //SqlParameter p1 = new SqlParameter("E", user.Email);
            //SqlParameter p2 = new SqlParameter("P", user.Password);
            //cmd.Parameters.Add(p1);
            //cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();

            User userData = new User();
            if (dr.Read())
            {
                userData.FirstName=System.Convert.ToString(dr.GetValue(1));
                userData.LastName=System.Convert.ToString(dr.GetValue(2));
                userData.Id=System.Convert.ToInt32(dr.GetValue(0));
                UserID=userData.Id;
                connection.Close();
                return (user, userData);
            }
            else
            {
                connection.Close();
                return (null, null);
            }

        }

        public int LoggedInUser()
        {
            return this.UserID;
        }

        public bool AddItemToCart(int userID, int ProductID)
        {
            var db = new ApplicationDBContext();
            var customers = db.users.Join(db.Product, cu => cu.Id,
 p => p.Id, (cu, p) => new { cu, p })
 .Select(c => new { prodId = c.p.Id, customername = c.cu.FirstName })
 .OrderByDescending(c => c.prodId).Take(1);


            return true;
        }
    }

}
