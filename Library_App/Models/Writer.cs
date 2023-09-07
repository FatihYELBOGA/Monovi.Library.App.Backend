using Library_App.Enumerations;

namespace Library_App.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public string Biography { get; set; }
        public List<Book> Books { get; set; }

    }

}