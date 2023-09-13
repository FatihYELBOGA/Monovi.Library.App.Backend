using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface IAuthService
    {
        public bool CheckTokenIsValid(string token);
        public bool CheckRefreshTokenIsValid(RefreshTokenRequest refreshTokenRequest);
        public LoginResponse CreateRefreshToken(RefreshTokenRequest refreshTokenRequest);
        public LoginResponse Login(LoginRequest loginRequest);
        public UserResponse Register(RegisterRequest registerRequest);

    }

}
