namespace Library_App.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }
        public User? User { get; set; }
        public Book? Book { get; set; }
        public Book? BookContent {  get; set; }

    }

}