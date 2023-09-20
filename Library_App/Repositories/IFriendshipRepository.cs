using Library_App.Models;

namespace Library_App.Repositories
{
    public interface IFriendshipRepository
    {
        public List<UserFriends> GetAllFriendsByUserId(int userId);
        public List<UserFriends> GetAllFriendRequestsByUserId(int userId);
        public UserFriends GetById(int id);
        public UserFriends CheckFriendship(int user1, int user2);
        public UserFriends Create(UserFriends userFriend);
        public UserFriends Update(UserFriends userFriend);
        public bool RemoveById(int id);

    }
}
