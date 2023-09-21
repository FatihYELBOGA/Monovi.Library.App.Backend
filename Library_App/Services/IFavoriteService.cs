using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;

namespace Library_App.Services
{
    public interface IFavoriteService
    {
        public PaginationResponse<FavoriteResponse> GetFavoritesByUserId(int userId, int pageNo, int pageSize);
        public FavoriteResponse CheckFavorite(int bookId, int userId);
        public FavoriteResponse Create(FavoriteRequest favoriteRequest);
        public bool RemoveById(int id);

    }
}
