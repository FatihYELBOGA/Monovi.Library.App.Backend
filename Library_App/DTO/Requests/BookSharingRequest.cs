namespace Library_App.DTO.Requests
{
    public class BookSharingRequest
    {

        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public int BookId { get; set; }

    }
}
