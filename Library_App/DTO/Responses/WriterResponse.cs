 using Library_App.Enumerations;
using Library_App.Models;

namespace Library_App.DTO.Responses
{
    public class WriterResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public FileResponse Profil { get; set; }
        public Gender Gender { get; set; }
        public Nationality Nationality { get; set; }
        public string Biography { get; set; }
        public List<BookResponse> Books { get; set; }

        public WriterResponse() { }

        public WriterResponse(Writer writer) 
        {
            Id = writer.Id;
            FirstName = writer.FirstName;
            LastName = writer.LastName;
            Gender = writer.Gender;
            Nationality = writer.Nationality;
            Biography = writer.Biography;
            Books = new List<BookResponse>();

            if (writer.Profil != null)
                Profil = new FileResponse(writer.Profil);

            if(writer.Books != null)
            {
                foreach (var book in writer.Books)
                {
                    BookResponse bookResponse = new BookResponse()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        Description = book.Description,
                        BookType = book.BookType,
                        PageNumber = book.PageNumber,
                        Language = book.Language
                    };

                    float point = 0;
                    int totalRating = 0;
                    int totalCounter = 0;
                    if (book.BookRatings != null)
                    {
                        if (book.BookRatings.Count() != 0)
                        {
                            foreach (var rating in book.BookRatings)
                            {
                                totalRating += rating.Point;
                                totalCounter++;
                            }
                            point = (float)totalRating / totalCounter;
                        }
                    }
                    bookResponse.Point = point;

                    if (book.Photo != null)
                        bookResponse.Photo = new FileResponse(book.Photo);

                    if (book.Content != null)
                        bookResponse.Content = new FileResponse(book.Content);

                    if (book.User != null)
                        bookResponse.User = new UserResponse(book.User);

                    Books.Add(bookResponse);
                }
            }

        }

    }

}
