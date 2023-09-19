using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Repositories;

namespace Library_App.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<BookResponse> GetAll()
        {
            List<BookResponse> bookResponses = new List<BookResponse>();
            foreach (var book in _bookRepository.GetAll())
            {
                bookResponses.Add(new BookResponse(book));
            }
            return bookResponses;
        }

        public BookResponse GetById(int id)
        {
            Book foundBook = _bookRepository.GetById(id);
            if (foundBook != null)
                return new BookResponse(foundBook);

            return null;
        }

        public List<BookResponse> GetAllByUserId(int userId)
        {
            List<BookResponse> bookResponses = new List<BookResponse>();
            foreach (var book in _bookRepository.GetAllByUserId(userId))
            {
                bookResponses.Add(new BookResponse(book));
            }
            return bookResponses;
        }

        public BookResponse Create(BookRequest bookRequest)
        {
            Models.File photo = null;
            Models.File content = null;

            if (bookRequest.Photo != null)
            {
                if (bookRequest.Photo.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        bookRequest.Photo.CopyTo(stream);
                        var bytes = stream.ToArray();

                        photo = new Models.File()
                        {
                            Name = bookRequest.Photo.FileName,
                            Type = bookRequest.Photo.ContentType,
                            Content = bytes
                        };
                    }
                }
            }

            if (bookRequest.Content != null)
            {
                if (bookRequest.Content.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        bookRequest.Content.CopyTo(stream);
                        var bytes = stream.ToArray();

                        content = new Models.File()
                        {
                            Name = bookRequest.Content.FileName,
                            Type = bookRequest.Content.ContentType,
                            Content = bytes
                        };
                    }
                }
            }

            Book addedBook = new Book()
            {
                Name = bookRequest.Name,
                Description = bookRequest.Description,
                BookType = bookRequest.BookType,
                PageNumber = bookRequest.PageNumber,
                Language = bookRequest.Language,
                Photo = photo,
                Content = content,
                UserId = bookRequest.UserId,
                WriterId = bookRequest.WriterId
            };

            Book returnedBook = _bookRepository.Create(addedBook);
            return new BookResponse(returnedBook);
        }

        public BookResponse Update(int id, BookRequest bookRequest)
        {
            Models.File photo = null;
            Models.File content = null;

            Book updatedBook = _bookRepository.GetById(id);
            updatedBook.Name = bookRequest.Name;
            updatedBook.Description = bookRequest.Description;
            updatedBook.BookType = bookRequest.BookType;
            updatedBook.PageNumber = bookRequest.PageNumber;
            updatedBook.Language = bookRequest.Language;
            updatedBook.WriterId = bookRequest.WriterId;

            if (bookRequest.Photo != null)
            {
                if (bookRequest.Photo.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        bookRequest.Photo.CopyTo(stream);
                        var bytes = stream.ToArray();

                        photo = new Models.File()
                        {
                            Name = bookRequest.Photo.FileName,
                            Type = bookRequest.Photo.ContentType,
                            Content = bytes
                        };
                    }
                    updatedBook.Photo = photo;
                }
            }

            if (bookRequest.Content != null)
            {
                if (bookRequest.Content.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        bookRequest.Content.CopyTo(stream);
                        var bytes = stream.ToArray();

                        content = new Models.File()
                        {
                            Name = bookRequest.Content.FileName,
                            Type = bookRequest.Content.ContentType,
                            Content = bytes
                        };
                    }
                    updatedBook.Content = content;
                }
            }

            Book returnedBook = _bookRepository.Update(updatedBook);
            return new BookResponse(returnedBook);
        }

        public bool RemoveById(int id)
        {
            return _bookRepository.RemoveById(id);
        }

    }

}
