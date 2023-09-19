using Library_App.Models;

namespace Library_App.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public List<Book> GetAllByUserId(int userId);
        public Book Create(Book book);
        public Book Update(Book book);
        public bool RemoveById(int id);

    }
}
