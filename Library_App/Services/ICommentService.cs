using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;

namespace Library_App.Services
{
    public interface ICommentService
    {
        public PaginationResponse<CommentResponse> GetByBookId(int bookId, int pageNo, int pageSize);
        public CommentResponse Create(CommentRequest commentRequest);
        public bool RemoveById(int id);

    }
}
