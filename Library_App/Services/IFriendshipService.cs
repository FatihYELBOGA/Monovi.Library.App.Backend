using Library_App.DTO.Responses;
using Library_App.Enumerations;
using Library_App.Pagination;

namespace Library_App.Services
{
    public interface IFriendshipService
    {
        public PaginationResponse<UserResponse> GetAllFriendsByUserId(int userId, int pageNo, int pageSize);
        public PaginationResponse<UserResponse> GetAllFriendRequestsByUserId(int userId, int pageNo, int pageSize);
        public FriendshipResponse CheckFriendship(int user1, int user2);
        public FriendshipResponse Create(int user1, int user2);
        public bool Update(int id, RequestStatus requestStatus);

    }
}
