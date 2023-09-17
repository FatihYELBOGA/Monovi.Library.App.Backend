using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {

        private readonly Database _database;

        public FavoriteRepository(Database database)
        {
            _database = database;
        }

        public List<FavoriteBooks> GetFavoritesByUserId(int userId)
        {
            return _database.FavoriteBooks
                .Where(fb => fb.UserId == userId)
                .Include(fb => fb.Book)
                    .ThenInclude(b => b.User)
                .Include(fb => fb.Book)
                    .ThenInclude(b => b.Writer)
                .Include(fb => fb.Book)
                    .ThenInclude(b => b.Photo)
                .Include(fb => fb.Book)
                    .ThenInclude(b => b.Content)
                .Include(fb => fb.User)
                .ToList();
        }

        public FavoriteBooks Create(FavoriteBooks favorite)
        {
            FavoriteBooks addedFavorite = _database.FavoriteBooks.Add(favorite).Entity;
            _database.SaveChanges();
            FavoriteBooks returnedFavorite = _database.FavoriteBooks
                .Where(fb => fb.Id == addedFavorite.Id)
                .Include(fb => fb.Book)
                .Include(fb => fb.User)
                .FirstOrDefault();
            return returnedFavorite;
        }

        public bool RemoveById(int id)
        {
            FavoriteBooks deletedFavorite = _database.FavoriteBooks.Where(fb => fb.Id == id).FirstOrDefault();
            if (deletedFavorite != null)
            {
                _database.FavoriteBooks.Remove(deletedFavorite);
                _database.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
