using Library_App.DTO.Requests;
using Library_App.Models;

namespace Library_App.Repositories
{
    public interface IAuthRepository
    {
        public bool ExistEmail(string email);
        public User Login(LoginRequest loginRequest);
        public User Register(User addedUser);

    }

}
