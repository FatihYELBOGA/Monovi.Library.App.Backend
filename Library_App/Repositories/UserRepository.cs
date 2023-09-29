using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly Database _database;
        private readonly IBookRepository _bookRepository;

        public UserRepository(Database database, IBookRepository bookRepository)
        {
            _database = database;
            _bookRepository = bookRepository;
        }

        public List<User> GetAll()
        {
            return _database.Users
                .Include(u => u.Profil)
                .ToList();
        }

        public User GetById(int id)
        {
            return _database.Users
                .Where(u => u.Id == id)
                .Include(u => u.Profil)
                .Include(u => u.Books)
                .Include(u => u.SenderBooks)
                .Include(u => u.ReceiverBooks)
                .Include(u => u.FavoriteBooks)
                .Include(u => u.BookComments)
                .Include(u => u.BookRatings)
                .Include(u => u.UserFriendsOne)
                .Include(u => u.UserFriendsTwo)
                .Include(u => u.RefreshToken)
                .FirstOrDefault();
        }

        public User Update(User user)
        {
            _database.Users.Update(user);
            _database.SaveChanges();
            User returnedUser = _database.Users.Where(u => u.Id == user.Id).Include(u => u.Profil).FirstOrDefault();
            return returnedUser;
        }

        public bool RemoveById(int id)
        {
            User deletedUser = this.GetById(id);

            if (deletedUser != null)
            {
                if (deletedUser.Profil != null)
                {
                    _database.Files.Remove(deletedUser.Profil);
                    _database.SaveChanges();
                }

                if (deletedUser.Books != null)
                {
                    foreach (var book in deletedUser.Books.ToList())
                    {
                        _bookRepository.RemoveById(book.Id);
                    }
                }

                if (deletedUser.SenderBooks != null)
                {
                    foreach (var sharingBook in deletedUser.SenderBooks.ToList())
                    {
                        _database.SharingBooks.Remove(sharingBook);
                        _database.SaveChanges();
                    }
                }

                if (deletedUser.ReceiverBooks != null)
                {
                    foreach (var sharingBook in deletedUser.ReceiverBooks.ToList())
                    {
                        _database.SharingBooks.Remove(sharingBook);
                        _database.SaveChanges();
                    }
                }

                if (deletedUser.FavoriteBooks != null)
                {
                    foreach (var favoriteBook in deletedUser.FavoriteBooks.ToList())
                    {
                        _database.FavoriteBooks.Remove(favoriteBook);
                        _database.SaveChanges();
                    }
                }

                if (deletedUser.BookComments != null)
                {
                    foreach (var bookComment in deletedUser.BookComments.ToList())
                    {
                        _database.BookComments.Remove(bookComment);
                        _database.SaveChanges();
                    }
                }

                if (deletedUser.BookRatings != null)
                {
                    foreach (var bookRating in deletedUser.BookRatings.ToList())
                    {
                        _database.BookRatings.Remove(bookRating);
                        _database.SaveChanges();
                    }
                }

                if (deletedUser.UserFriendsOne != null)
                {
                    foreach (var friend in deletedUser.UserFriendsOne.ToList())
                    {
                        _database.UserFriends.Remove(friend);
                        _database.SaveChanges();
                    }
                }

                if (deletedUser.UserFriendsTwo != null)
                {
                    foreach (var friend in deletedUser.UserFriendsTwo.ToList())
                    {
                        _database.UserFriends.Remove(friend);
                        _database.SaveChanges();
                    }
                }

                _database.RefreshTokens.Remove(deletedUser.RefreshToken);
                _database.SaveChanges();

                _database.Users.Remove(deletedUser);
                _database.SaveChanges();
                return true;
            }

            return false;
        }

    }

}
