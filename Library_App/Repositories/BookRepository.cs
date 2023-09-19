using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly Database _database;

        public BookRepository(Database database)
        {
            _database = database;
        }

        public List<Book> GetAll()
        {
            return _database.Books
                .Include(b => b.Writer)
                .Include(b => b.Photo)
                .Include(b => b.BookRatings)
                .ToList();
        }

        public Book GetById(int id)
        {
            return _database.Books
                .Where(b => b.Id == id)
                .Include(b => b.User)
                .Include(b => b.Writer)
                .Include(b => b.Photo)
                .Include(b => b.Content)
                .Include(b => b.BookRatings)
                .FirstOrDefault();
        }

        public List<Book> GetAllByUserId(int userId)
        {
            return _database.Books
                .Where(b => b.UserId == userId)
                .Include(b => b.User)
                .Include(b => b.Writer)
                .Include(b => b.Photo)
                .Include(b => b.BookRatings)
                .ToList();
        }

        public Book Create(Book book)
        {
            Book returnedBook = _database.Books.Add(book).Entity;
            _database.SaveChanges();
            return returnedBook;
        }

        public Book Update(Book book)
        {
            Book returnedBook = _database.Update(book).Entity;
            _database.SaveChanges();
            return returnedBook;
        }

        public bool RemoveById(int id)
        {
            Book deletedBook = _database.Books.Where(b => b.Id == id).FirstOrDefault();
            if(deletedBook != null)
            {
                _database.Books.Remove(deletedBook);
                _database.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
