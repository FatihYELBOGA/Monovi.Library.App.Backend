using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly Database _database;

        public UserRepository(Database database)
        {
            _database = database;
        }

        public User GetById(int id)
        {
            return _database.Users
                .Where(u => u.Id == id)
                .Include(u => u.Profil)
                .FirstOrDefault();
        }

        public User Update(User user)
        {
            _database.Users.Update(user);
            _database.SaveChanges();
            User returnedUser = _database.Users.Where(u => u.Id == user.Id).Include(u => u.Profil).FirstOrDefault();
            return returnedUser;
        }

    }

}
