using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface IFriendshipService
    {
        public List<UserResponse> GetAllFriendsByUserId(int userId);
        public List<UserResponse> GetAllFriendRequestsByUserId(int userId);
        public bool CheckFriendship(int user1, int user2);
        public FriendshipResponse Create(int user1, int user2);
        public FriendshipResponse Update(int id, FriendshipRequest friendshipRequest);

    }
}
