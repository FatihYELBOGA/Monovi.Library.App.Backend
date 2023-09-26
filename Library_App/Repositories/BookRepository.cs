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
                .Include(b => b.SharingBooks)
                .Include(b => b.FavoriteBooks)
                .Include(b => b.BookComments)
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

        public List<Book> GetAllByWriterId(int writerId)
        {
            return _database.Books
                .Where(b => b.WriterId == writerId)
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
            Book deletedBook = this.GetById(id);

            if(deletedBook != null)
            {
                if (deletedBook.Photo != null)
                {
                    _database.Files.Remove(deletedBook.Photo);
                    _database.SaveChanges();
                }

                if (deletedBook.Content != null)
                {
                    _database.Files.Remove(deletedBook.Content);
                    _database.SaveChanges();
                }

                if (deletedBook.SharingBooks != null)
                {
                    foreach (var sharingBook in deletedBook.SharingBooks.ToList())
                    {
                        _database.SharingBooks.Remove(sharingBook);
                        _database.SaveChanges();
                    }
                }

                if (deletedBook.FavoriteBooks != null)
                {
                    foreach (var favoriteBook in deletedBook.FavoriteBooks.ToList())
                    {
                        _database.FavoriteBooks.Remove(favoriteBook);
                        _database.SaveChanges();
                    }
                }

                if (deletedBook.BookComments != null)
                {
                    foreach (var bookComment in deletedBook.BookComments.ToList())
                    {
                        _database.BookComments.Remove(bookComment);
                        _database.SaveChanges();
                    }
                }

                if (deletedBook.BookRatings != null)
                {
                    foreach (var bookRating in deletedBook.BookRatings.ToList())
                    {
                        _database.BookRatings.Remove(bookRating);
                        _database.SaveChanges();
                    }
                }

                _database.Books.Remove(deletedBook);
                _database.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
