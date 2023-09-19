using Library_App.Enumerations;

namespace Library_App.Models
{
    public class UserFriends
    {
        public int Id { get; set; }
        public int? FriendOneId { get; set; }
        public User? FriendOne { get; set; }
        public int? FriendTwoId { get; set; }
        public User? FriendTwo { get; set; }
        public RequestStatus RequestStatus { get; set; }

    }
}
