using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Models;
using Library_App.Pagination;
using Library_App.Repositories;

namespace Library_App.Services
{
    public class CommentService : ICommentService
    {

        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public PaginationResponse<CommentResponse> GetByBookId(int bookId, int pageNo, int pageSize)
        {
            List<CommentResponse> commentResponses = new List<CommentResponse>();
            foreach (var comment in _commentRepository.GetByBookId(bookId))
            {
                commentResponses.Add(new CommentResponse(comment));
            };
            return new PaginationResponse<CommentResponse>(commentResponses, pageNo, pageSize);
        }

        public CommentResponse Create(CommentRequest commentRequest)
        {
            BookComments addedComment = new BookComments()
            {
                BookId = commentRequest.BookId,
                UserId = commentRequest.UserId,
                Comment = commentRequest.Comment,
                CommentDate = DateTime.Now
            };

            BookComments returnedComment = _commentRepository.Create(addedComment);
            return new CommentResponse(returnedComment);
        }

        public bool RemoveById(int id)
        {
            return _commentRepository.RemoveById(id);
        }

    }
}
