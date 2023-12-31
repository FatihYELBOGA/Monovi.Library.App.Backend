﻿using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Repositories;
using Library_App.Enumerations;
using Library_App.Pagination;

namespace Library_App.Services
{
    public class FriendshipService : IFriendshipService
    {

        private readonly IFriendshipRepository _friendshipRepository;

        public FriendshipService(IFriendshipRepository friendshipRepository)
        {
            _friendshipRepository = friendshipRepository;
        }

        public PaginationResponse<UserResponse> GetAllFriendsByUserId(int userId, int pageNo, int pageSize)
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var friend in _friendshipRepository.GetAllFriendsByUserId(userId))
            {
                if (friend.FriendOneId == userId)
                    userResponses.Add(new UserResponse(friend.FriendTwo));

                if (friend.FriendTwoId == userId)
                    userResponses.Add(new UserResponse(friend.FriendOne));
            }
            return new PaginationResponse<UserResponse>(userResponses, pageNo, pageSize);
        }

        public PaginationResponse<UserResponse> GetAllFriendRequestsByUserId(int userId, int pageNo, int pageSize)
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var friend in _friendshipRepository.GetAllFriendRequestsByUserId(userId))
            {
                userResponses.Add(new UserResponse(friend.FriendOne));
            }
            return new PaginationResponse<UserResponse>(userResponses, pageNo, pageSize);
        }

        public FriendshipResponse CheckFriendship(int user1, int user2)
        {
            UserFriends foundFriendship = _friendshipRepository.CheckFriendship(user1, user2);
            if (foundFriendship != null)
                return new FriendshipResponse(foundFriendship);

            return null;
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

        public bool Update(int id, RequestStatus requestStatus)
        {
            if (requestStatus == RequestStatus.DENIED)
                return _friendshipRepository.RemoveById(id);

            UserFriends updatedFriendship = _friendshipRepository.GetById(id);
            updatedFriendship.RequestStatus = requestStatus;

            UserFriends returnedFriendship = _friendshipRepository.Update(updatedFriendship);
            if (returnedFriendship != null)
                return true;

            return false;
        }

    }
}
