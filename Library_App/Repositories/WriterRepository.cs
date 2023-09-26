using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class WriterRepository : IWriterRepository
    {

        private readonly Database _database;
        private readonly IBookRepository _bookRepository;

        public WriterRepository(Database database, IBookRepository bookRepository)
        {
            _database = database;
            _bookRepository = bookRepository;
        }

        public List<Writer> GetAll()
        {
            return _database.Writers
                .Include(w => w.Profil)
                .ToList();
        }

        public List<Writer> GetAllNames()
        {
            return _database.Writers.ToList();
        }

        public Writer GetById(int id)
        {
            return _database.Writers
                .Where(w => w.Id == id)
                .Include(w => w.Profil)
                .Include(w => w.Books)
                    .ThenInclude(b => b.Photo)
                .Include(w => w.Books)
                    .ThenInclude(b => b.BookRatings)
                .Include(w => w.Books)
                    .ThenInclude(b => b.User)
                .FirstOrDefault();
        }

        public Writer Create(Writer writer)
        {
            Writer returnedWriter = _database.Writers.Add(writer).Entity;
            _database.SaveChanges();
            return returnedWriter;
        }

        public Writer Update(Writer writer)
        {
            Writer returnedWriter = _database.Writers.Update(writer).Entity;
            _database.SaveChanges();
            return returnedWriter;
        }

        public bool RemoveById(int id)
        {
            Writer deletedWriter = this.GetById(id);

            if (deletedWriter != null)
            {
                if (deletedWriter.Profil != null)
                {
                    _database.Remove(deletedWriter.Profil);
                    _database.SaveChanges();
                }

                if (deletedWriter.Books != null)
                {
                    foreach (var book in deletedWriter.Books.ToList())
                    {
                        _bookRepository.RemoveById(book.Id);
                    }
                }

                _database.Writers.Remove(deletedWriter);
                _database.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
