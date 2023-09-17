using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class RatingResponse
    {
        public int Id { get; set; }
        public BookResponse Book { get; set; }
        public UserResponse User { get; set; }
        public int? Point {  get; set; }

        public RatingResponse(BookRatings rating)
        {
            Id = rating.Id;

            if(rating.Book != null)
            {
                Book = new BookResponse(rating.Book);
            }

            if (rating.User != null)
            {
                User = new UserResponse(rating.User);
            }

            Point = rating.Point;
        }

    }
}
