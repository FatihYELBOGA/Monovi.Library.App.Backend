using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
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

        public BookResponse Create(BookRequest bookRequest)
        {
            throw new NotImplementedException();
        }

        public List<BookResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public BookResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public BookResponse Update(BookRequest bookRequest)
        {
            throw new NotImplementedException();
        }

    }

}
