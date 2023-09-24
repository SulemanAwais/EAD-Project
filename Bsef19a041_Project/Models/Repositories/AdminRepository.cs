using Bsef19a041_Project.Models.Interface;

namespace Bsef19a041_Project.Models.Repositories
{
    public class AdminRepository : IAdmin

    {
        public static int UserID { get; set; }

        public void AddAdmin(Admin a)
        {
            var db = new ApplicationDBContext();
            db.AdminTable.Add(a);
            db.SaveChanges();
        }
        public int LoggedInUser()
        {
            return UserID;
        }
        public bool AdminLogin(string email, string password)
        {
            var db = new ApplicationDBContext();
            Admin admin = new Admin();
            db.AdminTable.Where(a => a.Email==email).ToList().ForEach(a=>admin=a);
            UserID=admin.Id;

            if (admin!=null)
            {
                return true;
            }
            else
            return false;
        }

    }
}
