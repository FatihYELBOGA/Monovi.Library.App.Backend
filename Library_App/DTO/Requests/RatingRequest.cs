namespace Library_App.DTO.Requests
{
    public class RatingRequest
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Point {  get; set; }

    }
}
