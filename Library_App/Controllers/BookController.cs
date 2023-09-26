using Library_App.DTO.Requests;
using Library_App.DTO.Responses;
using Library_App.Pagination;
using Library_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet("/books")]
        public List<BookResponse> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpGet("/books/pagination")]
        public PaginationResponse<BookResponse> GetAllByPagination([FromQuery] int pageNo, [FromQuery] int pageSize)
        {
            return _bookService.GetAllByPagination(pageNo, pageSize);
        }

        [HttpGet("/books/{id}")]
        public BookResponse GetById(int id)
        {
            return _bookService.GetById(id);
        }

        [HttpGet("/books/users/{userId}")]
        public PaginationResponse<BookResponse> GetAllByUserId(int userId, [FromQuery] int pageNo, [FromQuery] int pageSize)
        {
            return _bookService.GetAllByUserId(userId, pageNo, pageSize);
        }

        [HttpGet("/books/writers/{writerId}")]
        public PaginationResponse<BookResponse> GetAllByWriterId(int writerId, [FromQuery] int pageNo, [FromQuery] int pageSize)
        {
            return _bookService.GetAllByWriterId(writerId, pageNo, pageSize);
        }

        [HttpPost("/books")]
        public BookResponse Create([FromForm] BookRequest bookRequest)
        {
            return _bookService.Create(bookRequest);
        }

        [HttpPut("/books/{id}")]
        public BookResponse Update(int id, [FromForm] BookRequest bookRequest)
        {
            return _bookService.Update(id, bookRequest);
        }

        [HttpDelete("/books/{id}")]
        public bool RemoveById(int id)
        {
            return _bookService.RemoveById(id);
        }

    }

}
