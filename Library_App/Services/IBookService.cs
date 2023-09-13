using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface IBookService
    {
        public List<BookResponse> GetAll();
        public BookResponse GetById(int id);
        public BookResponse Create(BookRequest bookRequest);
        public BookResponse Update(int id, BookRequest bookRequest);
        public bool RemoveById(int id);

    }

}
