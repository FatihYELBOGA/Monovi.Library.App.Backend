using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
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

        public List<FavoriteResponse> GetFavoritesByUserId(int userId)
        {
            List<FavoriteResponse> favoriteResponses = new List<FavoriteResponse>();
            foreach (var favourite in _favoriteRepository.GetFavoritesByUserId(userId))
            {
                favoriteResponses.Add(new FavoriteResponse(favourite));
            }
            return favoriteResponses;
        }

        public FavoriteResponse Create(FavoriteRequest favoriteRequest)
        {
            FavoriteBooks addedFavorite = new FavoriteBooks()
            {
                BookId = favoriteRequest.BookId,
                UserId = favoriteRequest.UsertId
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
