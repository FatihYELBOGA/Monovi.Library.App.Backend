using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class RatingRepository : IRatingRepository
    {

        private readonly Database _database;

        public RatingRepository(Database database)
        {
            _database = database;
        }

        public BookRatings GetByBookAndUserId(int bookId, int userId)
        {
            return _database.BookRatings
                .Where(br => br.BookId == bookId && br.UserId == userId)
                .Include(br => br.Book)
                .Include(br => br.User)
                .FirstOrDefault();
        }

        public BookRatings Create(BookRatings rating)
        {
            BookRatings addedRating = _database.BookRatings.Add(rating).Entity;
            _database.SaveChanges();
            BookRatings returnedRating = _database.BookRatings
                .Where(br => br.Id == addedRating.Id)
                .Include(br => br.Book)
                .Include(br => br.User)
                .FirstOrDefault();
            return returnedRating;
        }


        public BookRatings Update(BookRatings rating)
        {
            BookRatings addedRating = _database.BookRatings.Update(rating).Entity;
            _database.SaveChanges();
            BookRatings returnedRating = _database.BookRatings
                .Where(br => br.Id == addedRating.Id)
                .Include(br => br.Book)
                .Include(br => br.User)
                .FirstOrDefault();
            return returnedRating;
        }

    }

}
