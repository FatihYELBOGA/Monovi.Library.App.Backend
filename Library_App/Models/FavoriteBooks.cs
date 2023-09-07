namespace Library_App.Models
{
    public class FavoriteBooks
    {
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }

    }

}