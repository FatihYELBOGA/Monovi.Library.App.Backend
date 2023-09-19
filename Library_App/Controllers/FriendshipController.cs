using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;

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
        public List<UserResponse> GetAllFriendsByUserId(int userId)
        {
            return _friendshipService.GetAllFriendsByUserId(userId);
        }

        [HttpGet("/friends/waiting/{userId}")]
        public List<UserResponse> GetAllFriendRequestsByUserId(int userId)
        {
            return _friendshipService.GetAllFriendRequestsByUserId(userId);
        }

        [HttpGet("/friends")]
        public bool CheckFriendship([FromQuery] int user1, [FromQuery] int user2)
        {
            return _friendshipService.CheckFriendship(user1, user2);
        }

        [HttpPost("/friends")]
        public FriendshipResponse Create([FromQuery] int user1, [FromQuery] int user2)
        {
            return _friendshipService.Create(user1, user2);
        }

        [HttpPut("/friends/{id}")]
        public FriendshipResponse Update(int id, [FromForm] FriendshipRequest friendshipRequest)
        {
            return _friendshipService.Update(id, friendshipRequest);
        }

    }
}
