using Library_App.Models;

namespace Library_App.Repositories
{
    public interface IUserRepository
    {
        public User GetById(int id);
        public User Update(User user);

    }

}
