namespace Bsef19a041_Project.Models.Interface
{
    public interface IUser
    {
        public List<User> GetAllUsers();
        public string AddUser(User u);
        public (userLogin, User) GetUserLogin(userLogin login);

    }
}
