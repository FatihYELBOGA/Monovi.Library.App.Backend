using Library_App.DTO.Requests;
using Library_App.DTO.Responses;

namespace Library_App.Services
{
    public interface ICommentService
    {
        public List<CommentResponse> GetByBookId(int bookId);
        public CommentResponse Create(CommentRequest commentRequest);
        public bool RemoveById(int id);

    }
}
