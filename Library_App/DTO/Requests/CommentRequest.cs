namespace Library_App.DTO.Requests
{
    public class CommentRequest
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string? Comment { get; set; }

    }

}
