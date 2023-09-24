namespace Bsef19a041_Project.Models.Interface
{
    public interface IAdmin
    {
        public bool AdminLogin(string email, string password);
        public void AddAdmin(Admin a);
        public int LoggedInUser();

    }
}
