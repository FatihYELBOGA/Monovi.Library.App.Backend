using Library_App.Configurations;
using Library_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_App.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private readonly Database _database;

        public CommentRepository(Database database)
        {
            _database = database;
        }

        public List<BookComments> GetByBookId(int bookId)
        {
            return _database.BookComments
                .Where(bc => bc.BookId == bookId)
                .Include(bc => bc.User)
                .ThenInclude(u => u.Profil)
                .ToList();
        }

        public BookComments Create(BookComments comment)
        {
            BookComments addedComment = _database.BookComments.Add(comment).Entity;
            _database.SaveChanges();
            BookComments returnedComment = _database.BookComments
                .Where(bc => bc.Id == addedComment.Id)
                .Include(bc => bc.User)
                .FirstOrDefault();
            return returnedComment;
        }

        public bool RemoveById(int id)
        {
            BookComments deletedComment = _database.BookComments.Where(bc => bc.Id == id).FirstOrDefault();
            if (deletedComment != null)
            {
                _database.BookComments.Remove(deletedComment);
                _database.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
