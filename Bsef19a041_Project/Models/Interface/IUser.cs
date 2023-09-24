using Bsef19a041_Project.Models.ViewModel;
namespace Bsef19a041_Project.Models.Interface
{
    public interface IUser
    {
        public List<User> GetAllUsers();
        public string AddUser(User u);
        public (userLogin, User) GetUserLogin(userLogin login);
        public int LoggedInUser();
        public bool AddItemToCart(int userID, int ProductID);
        //public (User, List<Products>) Cart();

    }
}
