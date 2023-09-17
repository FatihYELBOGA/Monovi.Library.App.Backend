using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class FavoriteResponse
    {

        public BookResponse Book { get; set; }
        public UserResponse User {  get; set; }

        public FavoriteResponse(FavoriteBooks favorite)
        {

            if(favorite.Book != null)
            {
                Book = new BookResponse(favorite.Book);
            }

            if (favorite.User != null)
            {
                User = new UserResponse(favorite.User);
            }

        }

    }
}
