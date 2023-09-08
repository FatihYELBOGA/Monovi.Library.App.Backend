using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Repositories;

namespace Library_App.Services
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            User foundUser = _authRepository.Login(loginRequest);

            if (foundUser == null) {
                loginResponse.Success = false;
                loginResponse.Id = null;
                loginResponse.Message = "username or password is mistake!";
            } else {
                loginResponse.Success = true;
                loginResponse.Id = foundUser.Id;
                loginResponse.Message = "username and password is invalid!";
            }

            return loginResponse;
        }

        public UserResponse Register(RegisterRequest registerRequest)
        {
            bool foundUser = _authRepository.ExistEmail(registerRequest.Email);
            if (foundUser) 
                throw new Exception("username is already exist!");

            User addedUser = new User()
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName
            };

            User returnedUser = _authRepository.Register(addedUser);
            return new UserResponse()
            {
                Id = returnedUser.Id,
                Email = returnedUser.Email,
                FirstName = returnedUser.FirstName,
                LastName = returnedUser.LastName
            };
        }

    }

}
