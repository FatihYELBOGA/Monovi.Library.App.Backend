namespace Library_App.Models
{
    public class SharingBooks
    {
        public int Id { get; set; }
        public int? SenderUserId { get; set; }
        public User? SenderUser { get; set; }
        public int? ReceiverUserId { get; set; }
        public User? ReceiverUser { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }

    }

}