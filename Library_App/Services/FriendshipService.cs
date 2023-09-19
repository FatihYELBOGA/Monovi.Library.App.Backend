using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Repositories;
using Library_App.Enumerations;
using System.Runtime.Intrinsics.X86;

namespace Library_App.Services
{
    public class FriendshipService : IFriendshipService
    {

        private readonly IFriendshipRepository _friendshipRepository;

        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public List<UserResponse> GetAllFriendsByUserId(int userId)
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var friend in _friendshipRepository.GetAllFriendsByUserId(userId))
            {
                if (friend.FriendOneId == userId)
                    userResponses.Add(new UserResponse(friend.FriendTwo));

                if (friend.FriendTwoId == userId)
                    userResponses.Add(new UserResponse(friend.FriendOne));
            }
            return userResponses;
        }

        public List<UserResponse> GetAllFriendRequestsByUserId(int userId)
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var friend in _friendshipRepository.GetAllFriendRequestsByUserId(userId))
            {
                userResponses.Add(new UserResponse(friend.FriendOne));
            }
            return userResponses;
        }

        public bool CheckFriendship(int user1, int user2)
        {
            UserFriends foundFriendship = _friendshipRepository.CheckFriendship(user1, user2);
            if (foundFriendship != null)
                return true;

            return false;
        }

        public FriendshipResponse Create(int user1, int user2)
        {
            UserFriends addedFriendship = new UserFriends()
            {
                FriendOneId = user1,
                FriendTwoId = user2,
                RequestStatus = RequestStatus.WAITING
            };
            UserFriends returnedFriendship = _friendshipRepository.Create(addedFriendship);

            return new FriendshipResponse(returnedFriendship);
        }

        public FriendshipResponse Update(int id, FriendshipRequest friendshipRequest)
        {
            UserFriends updatedFriendship = new UserFriends()
            {
                Id = id,
                FriendOneId = friendshipRequest.user1,
                FriendTwoId = friendshipRequest.user2,
                RequestStatus = friendshipRequest.status
            };
            UserFriends returnedFriendship = _friendshipRepository.Update(updatedFriendship);

            return new FriendshipResponse(returnedFriendship);
        }

    }
}
