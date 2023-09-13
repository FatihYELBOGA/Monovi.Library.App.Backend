using Library_App.Configurations;
using Library_App.Models;

namespace Library_App.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly Database _database;

        public BookRepository(Database database)
        {
            _database = database;
        }

        public Book Create(Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public Book Update(Book book)
        {
            throw new NotImplementedException();
        }

    }
}
