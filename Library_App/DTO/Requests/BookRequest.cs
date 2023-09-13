using Library_App.Enumerations;

namespace Library_App.DTO.Requests
{
    public class BookRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public BookType BookType { get; set; }
        public int PageNumber { get; set; }
        public Language Language { get; set; }
        public IFormFile? Photo { get; set; }
        public IFormFile? Content { get; set; }
        public int UserId { get; set; }
        public int? WriterId { get; set; }

    }

}
