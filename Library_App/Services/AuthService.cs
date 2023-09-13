using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Library_App.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public bool CheckTokenIsValid(string token)
        {
            if (ConvertStringToToken(token) != null)
                return true;

            return false;
        }

        private JwtSecurityToken ConvertStringToToken(string token)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWTConfig:key").Value));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                return jwtToken;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CheckRefreshTokenIsValid(RefreshTokenRequest refreshTokenRequest)
        {
            RefreshToken updatedRefreshToken = _authRepository.CheckRefreshToken(refreshTokenRequest);
            if (updatedRefreshToken != null && updatedRefreshToken.Expiration.CompareTo(DateTime.Now) > 0)
                return true;

            return false;
        }

        public LoginResponse CreateRefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            loginResponse.Success = false;
            loginResponse.JWTToken = null;
            loginResponse.RefreshToken = null;
            loginResponse.Id = null;
            loginResponse.Username = null;
            loginResponse.Role = null;
            loginResponse.Message = "user id or refresh token is mistake!";

            RefreshToken updatedRefreshToken =  _authRepository.CheckRefreshToken(refreshTokenRequest);
            if (updatedRefreshToken!=null)
            {
                if (updatedRefreshToken.Expiration.CompareTo(DateTime.Now) > 0)
                {
                    updatedRefreshToken.Token = CreateRefreshToken();
                    updatedRefreshToken.Expiration = DateTime.Now.AddHours(Convert.ToInt64(_configuration.GetSection("JWTConfig:refresh-token-expiration-hour").Value)); ;
                    _authRepository.UpdateRefreshToken(updatedRefreshToken);

                    loginResponse.Success = true;

                    string signingKey = _configuration.GetSection("JWTConfig:key").Value;
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                    var claims = new[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(updatedRefreshToken.UserId)),
                    new Claim(JwtRegisteredClaimNames.Email, updatedRefreshToken.User.Email),
                    new Claim(ClaimTypes.Role, updatedRefreshToken.User.Role.ToString())
                };
                    var jwtSecurityToken = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddHours(Convert.ToInt64(_configuration.GetSection("JWTConfig:token-expiration-hour").Value)),
                        notBefore: DateTime.Now,
                        signingCredentials: credentials
                    );

                    loginResponse.JWTToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    loginResponse.RefreshToken = updatedRefreshToken.Token;
                    loginResponse.Id = updatedRefreshToken.UserId;
                    loginResponse.Username = updatedRefreshToken.User.Email;
                    loginResponse.Role = updatedRefreshToken.User.Role;
                    loginResponse.Message = "successful refresh token";
                }
            } 

            return loginResponse;
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            User foundUser = _authRepository.Login(loginRequest);

            if (foundUser == null) {
                loginResponse.Success = false;
                loginResponse.JWTToken = null;
                loginResponse.Id = null;
                loginResponse.Username = null;
                loginResponse.Role = null;
                loginResponse.Message = "username or password is mistake!";
            } else {
                loginResponse.Success = true;

                // create token
                string signingKey = _configuration.GetSection("JWTConfig:key").Value;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(foundUser.Id)),
                    new Claim(JwtRegisteredClaimNames.Email, foundUser.Email),
                    new Claim(ClaimTypes.Role, foundUser.Role.ToString())
                };
                var jwtSecurityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(Convert.ToInt64(_configuration.GetSection("JWTConfig:token-expiration-hour").Value)),
                    notBefore: DateTime.Now,
                    signingCredentials: credentials
                );

                loginResponse.JWTToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                loginResponse.RefreshToken = CreateRefreshToken();
                loginResponse.Id = foundUser.Id;
                loginResponse.Username = foundUser.Email;
                loginResponse.Role = foundUser.Role;
                loginResponse.Message = "successful login!";

                RefreshToken foundRefreshToken = _authRepository.ExistRefreshToken(foundUser.Id);
                if (foundRefreshToken != null)
                {
                    foundRefreshToken.Token = loginResponse.RefreshToken;
                    foundRefreshToken.Expiration = DateTime.Now.AddHours(Convert.ToInt64(_configuration.GetSection("JWTConfig:refresh-token-expiration-hour").Value));
                    _authRepository.UpdateRefreshToken(foundRefreshToken);
                }
                else
                {
                    RefreshToken addedRefreshToken = new RefreshToken()
                    {
                        UserId = foundUser.Id,
                        Token = loginResponse.RefreshToken,
                        Expiration = DateTime.Now.AddSeconds(30)
                    };
                    _authRepository.CreateRefreshToken(addedRefreshToken);
                }
            }

            return loginResponse;
        }

        private string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        public UserResponse Register(RegisterRequest registerRequest)
        {
            bool foundUser = _authRepository.ExistEmail(registerRequest.Email);
            if (foundUser) 
                throw new Exception("username is already exist!");

            User addedUser = new User()
            {
                Email = registerRequest.Email,
                Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(registerRequest.Password)),
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Role = Enumerations.Role.USER
            };

            User returnedUser = _authRepository.Register(addedUser);
            return new UserResponse(returnedUser);
        }

    }

}
