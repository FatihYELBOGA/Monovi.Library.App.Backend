using Library_App.Enumerations;
using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class FriendshipResponse
    {
        public int Id { get; set; }
        public int? user1 {  get; set; }
        public int? user2 { get; set; }
        public RequestStatus status {  get; set; }

        public FriendshipResponse(UserFriends userFriend)
        {
            Id = userFriend.Id;
            user1 = userFriend.FriendOneId;
            user2 = userFriend.FriendTwoId;
            status = userFriend.RequestStatus;
        }

    }
}
