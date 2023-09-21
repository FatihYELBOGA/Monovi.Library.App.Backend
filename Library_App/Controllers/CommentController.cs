using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("/comments/{bookId}")]
        public PaginationResponse<CommentResponse> GetByBookId(int bookId, [FromQuery] int pageNo, [FromQuery] int pageSize)
        {
            return _commentService.GetByBookId(bookId, pageNo, pageSize);
        }

        [HttpPost("/comments")]
        public CommentResponse Create([FromForm] CommentRequest commentRequest)
        {
            return _commentService.Create(commentRequest);
        }

        [HttpDelete("/comments/{id}")]
        public bool RemoveById(int id)
        {
            return _commentService.RemoveById(id);
        }

    }

}
