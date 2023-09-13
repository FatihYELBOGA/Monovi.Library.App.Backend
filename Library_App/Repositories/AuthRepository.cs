using Library_App.Configurations;
using Library_App.DTO.Requests;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Library_App.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly Database _database;

        public AuthRepository(Database database)
        {
            _database = database;
        }

        public RefreshToken CheckRefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            return _database.RefreshTokens
                .Where(rt => rt.UserId == refreshTokenRequest.UserId && rt.Token==refreshTokenRequest.Token)
                .Include(rt => rt.User)
                .FirstOrDefault();
        }

        public RefreshToken ExistRefreshToken(int userId)
        {
            return _database.RefreshTokens.Where(rt => rt.UserId == userId).FirstOrDefault();
        }

        public void CreateRefreshToken(RefreshToken refreshToken)
        {
            _database.RefreshTokens.Add(refreshToken);
            _database.SaveChanges();
        }

        public void UpdateRefreshToken(RefreshToken refreshToken)
        {
            _database.RefreshTokens.Update(refreshToken);
            _database.SaveChanges();
        }

        public bool ExistEmail(string email)
        {
            User foundUser = _database.Users.Where(u => u.Email == email).FirstOrDefault();
            if (foundUser != null)
                return true;

            return false;
        }

        public User Login(LoginRequest loginRequest)
        {
            return _database.Users
                 .Where(u => u.Email == loginRequest.Email && u.Password == Convert.ToBase64String(Encoding.UTF8.GetBytes(loginRequest.Password)))
                 .FirstOrDefault();
        }

        public User Register(User addedUser)
        {
            User returnedUser = _database.Users.Add(addedUser).Entity;
            _database.SaveChanges();
            return returnedUser;
        }

    }

}
