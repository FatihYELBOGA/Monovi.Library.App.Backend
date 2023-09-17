using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Repositories;

namespace Library_App.Services
{
    public class RatingService : IRatingService
    {

        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public RatingResponse GetByBookAndUserId(int bookId, int userId)
        {
            BookRatings returnedBook = _ratingRepository.GetByBookAndUserId(bookId, userId);
            if (returnedBook != null)
                return new RatingResponse(returnedBook);

            return null;
        }

        public RatingResponse Create(RatingRequest ratingRequest)
        {
            BookRatings addedRating = new BookRatings()
            {
                BookId = ratingRequest.BookId,
                UserId = ratingRequest.UserId,
                Point = (int) ratingRequest.Point
            };

            BookRatings returnedBook = _ratingRepository.Create(addedRating);
            return new RatingResponse(returnedBook);
        }

        public RatingResponse Update(RatingRequest ratingRequest)
        {
            BookRatings updatedRating = _ratingRepository.GetByBookAndUserId(ratingRequest.BookId, ratingRequest.UserId);
            updatedRating.Point = ratingRequest.Point;
            BookRatings returnedRating = _ratingRepository.Update(updatedRating);
            return new RatingResponse(returnedRating);
        }

    }
}
