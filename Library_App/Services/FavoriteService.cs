using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Pagination;
using Library_App.Repositories;

namespace Library_App.Services
{
    public class FavoriteService : IFavoriteService
    {

        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public PaginationResponse<FavoriteResponse> GetFavoritesByUserId(int userId, int pageNo, int pageSize)
        {
            List<FavoriteResponse> favoriteResponses = new List<FavoriteResponse>();
            foreach (var favourite in _favoriteRepository.GetFavoritesByUserId(userId))
            {
                favoriteResponses.Add(new FavoriteResponse(favourite));
            }
            return new PaginationResponse<FavoriteResponse>(favoriteResponses, pageNo, pageSize);
        }

        public FavoriteResponse CheckFavorite(int bookId, int userId)
        {
            FavoriteBooks returnedFavorite = _favoriteRepository.CheckFavorite(bookId, userId);
            if(returnedFavorite != null)
            {
                return new FavoriteResponse(returnedFavorite);
            }

            return null;
        }

        public FavoriteResponse Create(FavoriteRequest favoriteRequest)
        {
            FavoriteBooks addedFavorite = new FavoriteBooks()
            {
                BookId = favoriteRequest.BookId,
                UserId = favoriteRequest.UserId
            };

            FavoriteBooks returnedBook = _favoriteRepository.Create(addedFavorite);
            return new FavoriteResponse(returnedBook);
        }


        public bool RemoveById(int id)
        {
            return _favoriteRepository.RemoveById(id);
        }

    }
}
