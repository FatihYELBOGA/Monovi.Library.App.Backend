using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class WriterRepository : IWriterRepository
    {

        private readonly Database _database;

        public WriterRepository(Database database)
        {
            _database = database;
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
            Writer deletedWriter = _database.Writers.Where(w => w.Id == id).FirstOrDefault();
            if (deletedWriter != null)
            {
                _database.Writers.Remove(deletedWriter);
                _database.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
