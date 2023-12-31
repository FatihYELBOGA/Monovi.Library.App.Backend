﻿using Library_App.Configurations;
using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {

        private readonly Database _database;

        public FriendshipRepository(Database database)
        {
            _database = database;
        }

        public List<UserFriends> GetAllFriendsByUserId(int userId)
        {
            List<UserFriends> userFriends = _database.UserFriends
                .Where(uf => uf.FriendOneId == userId && uf.RequestStatus == RequestStatus.APPROVED)
                .Include(uf => uf.FriendOne)
                .Include(uf => uf.FriendTwo)
                    .ThenInclude(u => u.Profil)
                .ToList();

            foreach (var friend in _database.UserFriends
                                        .Where(uf => uf.FriendTwoId == userId && uf.RequestStatus == RequestStatus.APPROVED)
                                        .Include(uf => uf.FriendOne)
                                        .ThenInclude(u => u.Profil)
                                        .Include(uf => uf.FriendTwo)
                                        .ToList())
            {
                userFriends.Add(friend);
            }

            return userFriends;
        }

        public List<UserFriends> GetAllFriendRequestsByUserId(int userId)
        {
            return _database.UserFriends
                .Where(uf => uf.FriendTwoId == userId && uf.RequestStatus == RequestStatus.WAITING)
                .Include(uf => uf.FriendOne)
                    .ThenInclude(u => u.Profil)
                .Include(uf => uf.FriendTwo)
                .ToList();
        }

        public UserFriends GetById(int id)
        {
            return _database.UserFriends
                .Where(uf => uf.Id == id)
                .FirstOrDefault();
        }

        public UserFriends CheckFriendship(int user1, int user2)
        {
            UserFriends foundFrienship = _database.UserFriends
                .Where(uf => uf.FriendOneId == user1 && uf.FriendTwoId == user2)
                .FirstOrDefault();

            if (foundFrienship != null)
                return foundFrienship;

            return null;
        }

        public UserFriends Create(UserFriends userFriend)
        {
            UserFriends returnedFriendship = _database.UserFriends.Add(userFriend).Entity;
            _database.SaveChanges();
            return returnedFriendship;
        }

        public UserFriends Update(UserFriends userFriend)
        {
            UserFriends returnedFriendship = _database.UserFriends.Update(userFriend).Entity;
            _database.SaveChanges();
            return returnedFriendship;
        }

        public bool RemoveById(int id)
        {
            UserFriends deletedFriendship = _database.UserFriends.Where(b => b.Id == id).FirstOrDefault();
            if (deletedFriendship != null)
            {
                _database.UserFriends.Remove(deletedFriendship);
                _database.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
