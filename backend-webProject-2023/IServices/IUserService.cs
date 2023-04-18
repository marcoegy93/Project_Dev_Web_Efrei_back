using backend_webProject_2023.Modele;

namespace backend_webProject_2023.IServices
{
    public interface IUserService
    {
        public User authentification(string login, string mdp);
        public List<User> getUserList();
        public void deleteUser(string idUser);
        public void addUser (User user);
        public void modifyUser(User user);
    }
}
