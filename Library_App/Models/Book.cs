using Library_App.Enumerations;

namespace Library_App.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? WriterId { get; set; }
        public Writer? Writer { get; set; }
        public int? PhotoId { get; set; }
        public File? Photo { get; set; }
        public int? ContentId { get; set; }
        public File? Content { get; set; }
        public BookType BookType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public Language Language { get; set; }
        public List<BookComments> BookComments { get; set; }
        public List<FavoriteBooks> FavoriteBooks { get; set; }
        public List<BookRatings> BookRatings { get; set; }
        public List<SharingBooks> SharingBooks { get; set; }

    }

}