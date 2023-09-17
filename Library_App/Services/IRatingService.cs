using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface IRatingService
    {
        public RatingResponse GetByBookAndUserId(int bookId, int userId);
        public RatingResponse Create(RatingRequest ratingRequest);
        public RatingResponse Update(RatingRequest ratingRequest);

    }
}
