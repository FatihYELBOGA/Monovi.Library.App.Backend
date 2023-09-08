using Library_App.Configurations;
using Library_App.DTO.Requests;
using Library_App.Models;

namespace Library_App.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private Database _database;

        public AuthRepository(Database database)
        {
            _database = database;
        }

        public bool ExistEmail(string email)
        {
            User foundUser = _database.Users.Where(u => u.Email == email).FirstOrDefault();
            if(foundUser!=null)
                return true;

            return false;
        }

        public User Login(LoginRequest loginRequest)
        {
            return _database.Users.
                Where(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password).
                FirstOrDefault();
        }

        public User Register(User addedUser)
        {
            User returnedUser = _database.Users.Add(addedUser).Entity;
            _database.SaveChanges();
            return returnedUser;
        }

    }

}
