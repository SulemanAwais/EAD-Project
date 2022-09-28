using Bsef19a041_Project.Models.Interface;

namespace Bsef19a041_Project.Models.Repositories
{
    public class AdminRepository : IAdmin

    {
        public void AddAdmin(Admin a)
        {
            var db = new ApplicationDBContext();
            db.AdminTable.Add(a);
            db.SaveChanges();
        }

        public bool AdminLogin(string email, string password)
        {
            var db = new ApplicationDBContext();
            Admin admin = new Admin();
            db.AdminTable.Where(a => a.Email==email).ToList().ForEach(a=>admin=a);
            if (admin!=null)
            {
                return true;
            }
            else
            return false;
        }

    }
}
