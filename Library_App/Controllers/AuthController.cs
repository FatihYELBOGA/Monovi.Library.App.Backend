using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("/auth/token-validation")]
        public bool CheckTokenIsValid([FromForm] string token)
        {
            return _authService.CheckTokenIsValid(token);
        }

        [HttpPost("/auth/refresh-token-validation")]
        public bool CheckRefreshTokenIsValid([FromForm] RefreshTokenRequest refreshTokenRequest)
        {
            return _authService.CheckRefreshTokenIsValid(refreshTokenRequest);
        }

        [HttpPost("/auth/refresh-token")]
        public LoginResponse CreateRefreshToken([FromForm] RefreshTokenRequest refreshTokenRequest)
        {
            return _authService.CreateRefreshToken(refreshTokenRequest);
        }

        [HttpPost("/auth/login")]
        public LoginResponse Login([FromForm] LoginRequest loginRequest)
        {
            return _authService.Login(loginRequest);
        }

        [HttpPost("/auth/register")]
        public UserResponse Regist([FromForm] RegisterRequest registerRequest)
        {
            return _authService.Register(registerRequest);
        }

    }

}
