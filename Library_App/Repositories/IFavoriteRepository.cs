using Library_App.Models;

namespace Library_App.Repositories
{
    public interface IFavoriteRepository
    {

        public List<FavoriteBooks> GetFavoritesByUserId(int userId);
        public FavoriteBooks CheckFavorite(int bookId, int userId);
        public FavoriteBooks Create(FavoriteBooks favorite);
        public bool RemoveById(int id);

    }
}
