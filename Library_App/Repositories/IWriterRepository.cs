using Library_App.Models;

namespace Library_App.Repositories
{
    public interface IWriterRepository
    {
        public List<Writer> GetAll();
        public Writer GetById(int id);
        public Writer Create(Writer writer);
        public Writer Update(Writer writer);
        public bool RemoveById(int id);

    }
}
