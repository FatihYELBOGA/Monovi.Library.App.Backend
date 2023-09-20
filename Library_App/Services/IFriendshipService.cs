using Library_App.DTO.Responses;
using Library_App.Enumerations;

namespace Library_App.Services
{
    public interface IFriendshipService
    {
        public List<UserResponse> GetAllFriendsByUserId(int userId);
        public List<UserResponse> GetAllFriendRequestsByUserId(int userId);
        public RequestStatus CheckFriendship(int user1, int user2);
        public FriendshipResponse Create(int user1, int user2);
        public bool Update(int id, RequestStatus requestStatus);

    }
}
