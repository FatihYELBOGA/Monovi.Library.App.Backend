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

        [HttpPost("/auth/refresh-token")]
        public LoginResponse CreateRefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            return _authService.CreateRefreshToken(refreshTokenRequest);
        }


        [HttpPost("/auth/login")]
        public LoginResponse Login(LoginRequest loginRequest)
        {
            return _authService.Login(loginRequest);
        }

        [Authorize]
        [HttpPost("/auth/register")]
        public UserResponse Regist(RegisterRequest registerRequest)
        {
            return _authService.Register(registerRequest);
        }

    }

}
