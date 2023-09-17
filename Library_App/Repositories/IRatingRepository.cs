using Library_App.DTO.Requests;
using Library_App.Models;

namespace Library_App.Repositories
{
    public interface IRatingRepository
    { 
        public BookRatings GetByBookAndUserId(int bookId, int userId);
        public BookRatings Create(BookRatings rating);
        public BookRatings Update(BookRatings rating);

    }
}
