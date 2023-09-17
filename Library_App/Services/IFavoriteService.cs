using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface IFavoriteService
    {
        public List<FavoriteResponse> GetFavoritesByUserId(int userId);
        public bool CheckFavorite(int bookId, int userId);
        public FavoriteResponse Create(FavoriteRequest favoriteRequest);
        public bool RemoveById(int id);

    }
}
