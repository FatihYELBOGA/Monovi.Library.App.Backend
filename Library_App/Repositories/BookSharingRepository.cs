using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class BookSharingRepository : IBookSharingRepository
    {

        private readonly Database _database;

        public BookSharingRepository(Database database)
        {
            _database = database;
        }

        public List<SharingBooks> GetAllBookSharings(int userId)
        {
            return _database.SharingBooks
                .Where(sb => sb.ReceiverUserId == userId)
                .Include(sb => sb.SenderUser)
                .Include(sb => sb.ReceiverUser)
                .Include(sb => sb.Book)
                    .ThenInclude(b => b.Writer)
                .Include(sb => sb.Book)
                    .ThenInclude(b => b.Photo)
                .Include(sb => sb.Book)
                    .ThenInclude(b => b.BookRatings)
                .ToList();
        }

        public SharingBooks CheckBookSharing(int user1, int user2, int bookId)
        {
            return _database.SharingBooks
                .Where(sb => sb.SenderUserId == user1 && sb.ReceiverUserId == user2 && sb.BookId == bookId)
                .FirstOrDefault();
        }

        public SharingBooks Create(SharingBooks sharingBook)
        {
            SharingBooks addedSharing = _database.SharingBooks.Add(sharingBook).Entity;
            _database.SaveChanges();
            SharingBooks returnedSharing = _database.SharingBooks
                .Where(sb => sb.Id == addedSharing.Id)
                .Include(sb => sb.SenderUser)
                .Include(sb => sb.ReceiverUser)
                .Include(sb => sb.Book)
                .FirstOrDefault();
            return returnedSharing;
        }

    }
}
