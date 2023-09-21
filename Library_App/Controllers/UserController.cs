using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/users")]
        public PaginationResponse<UserResponse> GetAll([FromQuery] int pageNo, [FromQuery] int pageSize)
        {
            return _userService.GetAll(pageNo, pageSize);
        }

        [HttpGet("/users/{id}")]
        public UserResponse GetById(int id) 
        {
            return _userService.GetById(id);
        }

        [HttpPut("/users/{id}")]
        public UserResponse Update(int id, [FromForm] UserRequest userRequest)
        {
            return _userService.Update(id, userRequest);
        }

    }

}
