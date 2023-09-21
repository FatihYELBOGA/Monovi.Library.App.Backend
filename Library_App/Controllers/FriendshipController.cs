using Library_App.DTO.Responses;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;
using Library_App.Enumerations;
using Library_App.Pagination;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendshipController : ControllerBase
    {

        private readonly IFriendshipService _friendshipService;

        public FriendshipController(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpGet("/friends/{userId}")]
        public PaginationResponse<UserResponse> GetAllFriendsByUserId(int userId, [FromQuery] int pageNo, [FromQuery] int pageSize)
        {
            return _friendshipService.GetAllFriendsByUserId(userId, pageNo, pageSize);
        }

        [HttpGet("/friends/waiting/{userId}")]
        public PaginationResponse<UserResponse> GetAllFriendRequestsByUserId(int userId, [FromQuery] int pageNo, [FromQuery] int pageSize)
        {
            return _friendshipService.GetAllFriendRequestsByUserId(userId, pageNo, pageSize);
        }

        [HttpGet("/friends")]
        public FriendshipResponse CheckFriendship([FromQuery] int user1, [FromQuery] int user2)
        {
            return _friendshipService.CheckFriendship(user1, user2);
        }

        [HttpPost("/friends")]
        public FriendshipResponse Create([FromQuery] int user1, [FromQuery] int user2)
        {
            return _friendshipService.Create(user1, user2);
        }

        [HttpPut("/friends/{id}")]
        public bool Update(int id, [FromForm] RequestStatus requestStatus)
        {
            return _friendshipService.Update(id, requestStatus);
        }

    }
}
