using Library_App.Enumerations;
using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class BookResponse
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public BookType BookType { get; set; }
        public int PageNumber { get; set; }
        public Language Language { get; set; }
        public FileResponse? Photo { get; set; }
        public FileResponse? Content { get; set; }
        public UserResponse? User { get; set; }
        public WriterResponse? Writer { get; set; }  

        public BookResponse(Book book) 
        { 
            Id = book.Id;
            Name = book.Name;
            Description = book.Description;
            BookType = book.BookType;
            PageNumber = book.PageNumber;
            Language = book.Language;

            if(book.Photo != null)
                Photo = new FileResponse(book.Photo);

            if (book.Content != null)
                Content = new FileResponse(book.Content);

            if (book.User != null)
                User = new UserResponse(book.User);

            if (book.Writer != null)
                Writer = new WriterResponse(book.Writer);

        }

    }

}
