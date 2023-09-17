using Library_App.Models;

namespace Library_App.Repositories
{
    public interface ICommentRepository
    {
        public List<BookComments> GetByBookId(int bookId);
        public BookComments Create(BookComments comment);
        public bool RemoveById(int id);

    }
}
