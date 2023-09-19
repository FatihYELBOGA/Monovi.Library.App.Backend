using Library_App.Enumerations;

namespace Library_App.DTO.Requests
{
    public class FriendshipRequest
    {
        public int user1 {  get; set; }
        public int user2 { get; set; }
        public RequestStatus status { get; set; }

    }
}
